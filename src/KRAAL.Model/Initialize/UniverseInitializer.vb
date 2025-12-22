Imports KRAAL.Domain

Friend Module UniverseInitializer
    Private Const FACTION_COUNT = 5
    Private Const UNIVERSE_SIZE_X = 100.0
    Private Const UNIVERSE_SIZE_Y = 100.0
    Private Const UNIVERSE_SIZE_Z = 100.0
    Private Const STAR_GENERATOR_TRY_COUNT = 1000
    Private Const MINIMUM_STAR_DISTANCE = 10.0
    Private ReadOnly random As New Random()
    Friend Sub Initialize(universe As IUniverse)
        InitializeFactions(universe)
        InitializeStars(universe, STAR_GENERATOR_TRY_COUNT)
        InitializeParties(universe)
    End Sub

    Private Sub InitializeParties(universe As IUniverse)
        Dim playerParty = universe.Parties.Create()
        universe.PlayerParty = playerParty
        Dim allStars = universe.Stars.All
        Dim shipX = allStars.Average(Function(x) x.StarX)
        Dim shipY = allStars.Average(Function(x) x.StarY)
        Dim shipZ = allStars.Average(Function(x) x.StarZ)
        playerParty.CreateShip("Shippy McShipface", shipX, shipY, shipZ)
    End Sub

    Private Sub InitializeStars(universe As IUniverse, tryCount As Integer)
        Dim attempt As Integer = 0
        Dim positions As New List(Of (X As Double, Y As Double, Z As Double))
        Do While attempt < tryCount
            If GenerateStar(universe, positions) Then
                attempt = 0
            Else
                attempt += 1
            End If
        Loop
    End Sub

    Private Function GenerateStar(universe As IUniverse, positions As List(Of (X As Double, Y As Double, Z As Double))) As Boolean
        Dim starX = UNIVERSE_SIZE_X * random.NextDouble()
        Dim starY = UNIVERSE_SIZE_Y * random.NextDouble()
        Dim starZ = UNIVERSE_SIZE_Z * random.NextDouble()
        If positions.Any(Function(p) Math.Sqrt(Math.Pow(starX - p.X, 2) + Math.Pow(starY - p.Y, 2) + Math.Pow(starZ - p.Z, 2)) < MINIMUM_STAR_DISTANCE) Then
            Return False
        End If
        Dim starCount = universe.Stars.Count
        Dim starName = $"Star #{starCount + 1}"
        universe.Stars.Create(starName, starX, starY, starZ)
        positions.Add((starX, starY, starZ))
        Return True
    End Function

    Private Sub InitializeFactions(universe As IUniverse)
        For Each dummy In Enumerable.Range(0, FACTION_COUNT)
            GenerateFaction(universe)
        Next
    End Sub

    Private Sub GenerateFaction(universe As IUniverse)
        Dim factionCount = universe.Factions.Count
        Dim factionName = $"Faction #{factionCount + 1}"
        universe.Factions.Create(factionName)
    End Sub
End Module
