Imports System.Runtime.CompilerServices
Imports TGGD.Presentation

Friend Module Menu
    <Extension>
    Friend Sub RunMenu(
                      ui As IUIContext,
                      prompt As (Mood, String),
                      runLoop As Action(Of Action(Of String, Action), Action))
        Dim running = True
        Do While running
            Dim choices As New List(Of (String, Action))
            runLoop(Sub(x, y) choices.Add((x, y)), Sub() running = False)
            ui.Choose(prompt, choices.ToArray()).Invoke()
        Loop
    End Sub
End Module
