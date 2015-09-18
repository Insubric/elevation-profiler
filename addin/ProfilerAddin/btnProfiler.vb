Public Class btnProfiler
    Inherits ESRI.ArcGIS.Desktop.AddIns.Button

    Dim dockWindow As IDockableWindow

    Protected Overrides Sub OnClick()

        'Dim dockWindow As ESRI.ArcGIS.Framework.IDockableWindow

        ' Only get/create the dockable window if it's not there
        If dockWindow Is Nothing Then
            Dim dockWinID As UID = New UIDClass()
            'dockWinID.Value = "WSL_Profiler_DockableWindow"
            dockWinID.Value = My.ThisAddIn.IDs.frmProfiler
            dockWindow = My.ArcMap.DockableWindowManager.GetDockableWindow(dockWinID)
        End If

        dockWindow.Show((Not dockWindow.IsVisible()))
    End Sub

    'Protected Overrides Sub OnUpdate()
    '    Enabled = My.ArcMap.Application IsNot Nothing
    'End Sub

End Class
