Imports KRAAL.Domain

Friend Module UniverseInitializer
    Private Const FACTION_COUNT = 5
    Private Const STAR_COUNT = 100
    Private Const UNIVERSE_SIZE_X = 100.0
    Private Const UNIVERSE_SIZE_Y = 100.0
    Private Const UNIVERSE_SIZE_Z = 100.0
    Private ReadOnly random As New Random()
    Friend Sub Initialize(universe As IUniverse)
        InitializeFactions(universe)
        InitializeStars(universe)
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

    Private Sub InitializeStars(universe As IUniverse)
        For Each dummy In Enumerable.Range(0, STAR_COUNT)
            GenerateStar(universe)
        Next
    End Sub

    Private Sub GenerateStar(universe As IUniverse)
        Dim starCount = universe.Stars.Count
        Dim starName = $"Star #{starCount + 1}"
        Dim starX = UNIVERSE_SIZE_X * random.NextDouble()
        Dim starY = UNIVERSE_SIZE_Y * random.NextDouble()
        Dim starZ = UNIVERSE_SIZE_Z * random.NextDouble()
        universe.Stars.Create(starName, starX, starY, starZ)
    End Sub

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
