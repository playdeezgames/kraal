Imports KRAAL.Model
Imports KRAAL.Presentation
Imports TGGD.Persistence.Sqlite
Imports TGGD.Presentation.Spectre

Module Program
    Sub Main(args As String())
        Using store As New Store()
            MainMenu.Run(
            KRAALModel.Create(store),
            New UIContext())
        End Using
    End Sub
End Module
