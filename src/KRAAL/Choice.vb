Imports Spectre.Console

Public Class Choice
    Sub New(text As String, choose As Action)
        Me.Text = text
        Me.Choose = choose
    End Sub
    ReadOnly Property Text As String
    ReadOnly Property Choose As Action
    Public Shared Sub Pick(title As String, choices As IEnumerable(Of Choice))
        Dim prompt As New SelectionPrompt(Of Integer) With
            {
                .Converter = Function(x) choices(x).Text,
                .SearchEnabled = True,
                .WrapAround = True,
                .Title = title
            }
        prompt.AddChoices(Enumerable.Range(0, choices.Count))
        choices(AnsiConsole.Prompt(prompt)).Choose.Invoke()
    End Sub
    Public Shared Sub Pause(title As String)
        Pick(title, {New Choice("Ok", Sub() Return)})
    End Sub
End Class
