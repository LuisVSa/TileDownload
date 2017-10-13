Imports TileServer  ' this is the DLL Interface
Imports System.Reflection
Imports System.IO


Public Class Form1

    Private myServer As IServer
    Private myServers As New ArrayList
    Private NoOfServers As Integer
    Private myFolder As String = My.Application.Info.DirectoryPath
    Private Const PI As Double = 3.14159265358979
    Private TileExtension As String
    Private maxZoom As Integer
    Private TileName As String
    Private FullTileName As String
    Private TileDir As String
    Private TileFolder As String
    Private X As Integer
    Private Y As Integer
    Private Zoom As Integer

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Label5.Text = ""
        Dim myAssembly As Assembly

        Dim myFiles As String()
        Dim Dll, DllBase As String

        Dim myTypes As Type()
        Dim myType As Type

        ' The following statement gives a warning saying it is deprecated

        ' AppDomain.CurrentDomain.AppendPrivatePath("Tiles")

        ' Therefore, in order to load the dlls existing in subfolder Tiles
        ' we need to declare that folder in App.config file. 

        ' <runtime>
        '  <assemblyBinding xmlns = "urn:schemas-microsoft-com:asm.v1" >
        '    <probing privatePath="Tiles"/>
        '          </assemblyBinding>
        ' </runtime>

        ' get all DLL files that are inside the subfolder Tiles
        myFiles = Directory.GetFiles(myFolder & "\Tiles", "*.dll")

        ' load all these DLLs and get their type (eg their classes). If they
        ' implement the interface "TileServer.IServer" add these classes
        ' to myServers array 

        For Each Dll In myFiles
            DllBase = Path.GetFileNameWithoutExtension(Dll)
            myAssembly = Assembly.Load(DllBase)
            myTypes = myAssembly.GetTypes
            For Each myType In myTypes
                If myType.GetInterface("IServer") IsNot Nothing Then
                    If Not myType.IsAbstract Then
                        myServers.Add(myType)
                    End If
                End If
            Next
        Next

        NoOfServers = myServers.Count

        ' place the name of the servers in a list box
        Dim N As Integer
        For N = 1 To NoOfServers
            ListMapServers.Items.Add(myServers(N - 1).Name)
        Next

        ' by default select the first server (eg class) and create an instance of it
        ListMapServers.SelectedIndex = 0
        myServer = Activator.CreateInstance(myServers(ListMapServers.SelectedIndex))
        TileExtension = myServer.ImageType  ' ".JPG" ".PNG" or whatever
        maxZoom = myServer.MaximumZoom

    End Sub

    Private Sub CmdGetTile_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGetTile.Click

        ClearImage()

        If DoCheck() = False Then
            Exit Sub
        End If

        If My.Computer.FileSystem.FileExists(FullTileName) Then
            PictureTile.Image = Image.FromFile(FullTileName)
            Me.Text = TileName & " - from cache!"
            Exit Sub
        End If

        Dim TempFile As String = myFolder & "\temp" & TileExtension

        If myServer.DownloadTile(X, Y, Zoom, TempFile) Then
            If Not My.Computer.FileSystem.DirectoryExists(TileFolder) Then
                Directory.CreateDirectory(TileFolder)
            End If
            My.Computer.FileSystem.CopyFile(TempFile, FullTileName, True)
            PictureTile.Image = Image.FromFile(FullTileName)
            My.Computer.FileSystem.DeleteFile(TempFile)
            Me.Text = TileName & " - from internet!"
        Else
            Label5.Text = "DOWNLOAD ERROR!"
        End If

    End Sub

    Private Sub CmdClearCache_Click(sender As Object, e As EventArgs) Handles CmdClearCache.Click

        ClearImage()

        If DoCheck() = False Then
            Exit Sub
        End If

        If My.Computer.FileSystem.FileExists(FullTileName) Then
            My.Computer.FileSystem.DeleteFile(FullTileName)
            Me.Text = ""
        Else
            Label5.Text = "NOT IN CACHE!"
        End If

    End Sub

    Private Function XFromLon(ByVal lon As Double, ByVal Zoom As Integer) As Integer

        Dim dXY As Double

        dXY = PI / (2 ^ Zoom)
        lon = PI + lon * PI / 180.0
        XFromLon = Int(lon / dXY)

    End Function

    Private Function YFromLat(ByVal lat As Double, ByVal Zoom As Integer) As Integer

        Dim dXY As Double

        dXY = PI / (2 ^ Zoom)

        lat = lat * PI / 360.0  ' equivalent to lat=lat/2
        lat = lat + PI / 4.0
        lat = Math.Tan(lat)
        lat = Math.Log(lat)
        lat = PI - lat
        YFromLat = Int(lat / dXY)

    End Function

    Private Sub ListMapServers_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListMapServers.SelectedIndexChanged

        myServer = Nothing
        myServer = Activator.CreateInstance(myServers(ListMapServers.SelectedIndex))
        TileExtension = myServer.ImageType  ' ".JPG" ".PNG" or whatever
        maxZoom = myServer.MaximumZoom

    End Sub

    Private Function TileDirFromXYZ(ByVal X As Integer, ByVal Y As Integer, ByVal Z As Integer) As String

        TileDirFromXYZ = ""
        If Z < 4 Then Exit Function

        Dim N As Integer
        Dim Limit As Integer

        For N = Z To 4 Step -1
            Limit = 2 ^ N
            If X < Limit Then
                If Y < Limit Then
                    TileDirFromXYZ = TileDirFromXYZ & "\0"
                Else
                    TileDirFromXYZ = TileDirFromXYZ & "\2"
                    Y = Y - Limit
                End If
            Else
                If Y < Limit Then
                    TileDirFromXYZ = TileDirFromXYZ & "\1"
                Else
                    TileDirFromXYZ = TileDirFromXYZ & "\3"
                    Y = Y - Limit
                End If
                X = X - Limit
            End If
        Next

    End Function

    Private Sub ClearImage()

        If PictureTile.Image IsNot Nothing Then PictureTile.Image.Dispose()
        PictureTile.Image = Nothing
        Label5.Text = ""
        Me.Text = ""
        Me.Refresh()

    End Sub

    Private Function DoCheck() As Boolean

        DoCheck = False

        Try
            Zoom = CInt(Val(txtZoom.Text))
            If Zoom > maxZoom Then
                Label5.Text = "ZOOM TOO LARGE!"
                Exit Function
            End If
        Catch ex As Exception
            Label5.Text = "CHECK ZOOM!"
            Exit Function
        End Try

        Dim Lat, Lon As Double
        Try
            Lat = Val(txtLatitude.Text)
            Lon = Val(txtLongitude.Text)
            If (Lat > 89) Or (Lat < -89) Then
                Label5.Text = "CHECK LAT!"
                Exit Function
            End If
            If (Lon > 180) Or (Lon < -180) Then
                Label5.Text = "CHECK LON!"
                Exit Function
            End If
            X = XFromLon(Lon, Zoom)
            Y = YFromLat(Lat, Zoom)
        Catch ex As Exception
            Label5.Text = "CHECK LAT/LON!"
            Exit Function
        End Try

        TileFolder = myFolder & "\Tiles\" & myServer.ServerName
        TileDir = TileDirFromXYZ(X, Y, Zoom)
        TileName = "L" & Trim(Zoom) & "X" & Trim(X) & "Y" & Trim(Y) & TileExtension
        FullTileName = TileFolder & "\" & TileDir & "\" & TileName

        DoCheck = True

    End Function

End Class
