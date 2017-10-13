# TileDownload

Programme to Test Tile Server Plugins

TileDownload is a Visual Basic testing programme to illustrate the download of image tiles from the internet. It implements the TileServer interface for external plugins. It requires the file TileServer.dll to exist side by side with the exexcutable TileDownload.exe in the folder ..\bin\debug\. In addition it a subfolder named tiles (..\bin\debug\Tiles\) should contain a plugin. In this repos a plugin called VirtualEarth.dll is placed on that subfolder. You can place many plugins inside this Tiles subfolder.

When the programme starts it looks for plugins and, if found, it list the available plugins on a List Box. You specify a tile by its Zoom, Latitude and Longitude. When you press the "Get Tile" button, the programme checks if the tile has been already downloaded and stored in its cache. If not it tries to download the tile from the specified Tile Server. If the tile arrives it is shown in a Picture box and it stored in a cache structure inside the Tiles folder.

There is a zip file inside the My Project folder that containts the executable. You may try it if you get difficulties in compiling the code yourself.
