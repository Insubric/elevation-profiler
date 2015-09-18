Attribute VB_Name = "cmdlg_folder"
' Date: 24/06/2013
' ELEVATION PROFILER
' module "cmdlg_folder" (i.e. folder command dialog)
'
' Elevation profiler is a GIS tool that automatically calculate transverse or longitudinal elevation profiles starting from a shapefile of points and a digital elevation model (DEM)
' The tool il conceived as a VBA macro (composed by a form and 5 modules) that can be added and run from the visual basic editor in ArcMap
'
' Authors:
'
' University of Eastern Finland  and  University of Kuopio (Finland)
' Markus Stocker:  markus.stocker@gmail.com  or  markus.stocker@uef.fi
'
' Swiss Federal Research Institute WSL (Switzerland)
' Boris Pezzatti:  boris.pezzatti@wsl.ch
' Patrik Krebs:  patrik.krebs@wsl.ch
'
' Copyright 2013 by WSL
'
'
Option Explicit
' declarations for the Windows Dialog

Private Declare Function SHBrowseForFolder Lib "shell32.dll" Alias _
        "SHBrowseForFolderA" (lpBrowseInfo As BROWSEINFO) As Long

Private Declare Function SHGetPathFromIDList Lib "shell32.dll" Alias _
        "SHGetPathFromIDListA" (ByVal pidl As Long, _
        ByVal pszPath As String) As Long

Private Const BIF_RETURNONLYFSDIRS = &H1

Private Type BROWSEINFO
   hOwner As Long
   pidlRoot As Long
   pszDisplayName  As String
   lpszTitle As String
   ulFlags As Long
   lpfn As Long
   lParam As Long
   iImage As Long
End Type

Private Type SHITEMID
   cb As Long
   abID As Byte
End Type

Private Type ITEMIDLIST
   mkid As SHITEMID
End Type


Public Function GetBrowseDirectory() As String
   Dim bi As BROWSEINFO
   Dim IDL As ITEMIDLIST
   Dim r As Long
   Dim pidl As Long
   Dim tmpPath As String
   Dim pos As Integer

   'bi.hOwner = Owner.hWnd
   bi.pidlRoot = 0&
   bi.lpszTitle = "Choose a directory from the list."
   bi.ulFlags = BIF_RETURNONLYFSDIRS
   pidl = SHBrowseForFolder(bi)

   tmpPath = Space$(512)
   r = SHGetPathFromIDList(ByVal pidl, ByVal tmpPath)

   If r Then
      pos = InStr(tmpPath, Chr$(0))
      tmpPath = Left(tmpPath, pos - 1)

      If Right(tmpPath, 1) <> "\" Then tmpPath = tmpPath & "\"
         GetBrowseDirectory = tmpPath
      Else
         GetBrowseDirectory = ""
      End If

End Function



 

