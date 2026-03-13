using System.Collections.Generic;

namespace MiPrimerMod.Framework.Data
{
    /// <summary>Represents a fish and when/where it can be caught.</summary>
    public class FishInfo
    {
        public string Name { get; set; } = string.Empty;
        public List<string> Seasons { get; set; } = new();
        public List<string> Locations { get; set; } = new();
        public string Weather { get; set; } = "Any";   // "Any", "Sun", "Rain"
        public string TimeRange { get; set; } = "6am-2am"; // Default: all day
        public int Difficulty { get; set; } = 0;
    }

    /// <summary>
    /// A comprehensive database of fish availability, sourced from the Stardew Valley Wiki.
    /// </summary>
    public static class FishDatabase
    {
        public static readonly List<FishInfo> AllFish = new()
        {
            // ═══════════════════════════════════════════
            //  OCEAN FISH
            // ═══════════════════════════════════════════
            new() { Name = "Pufferfish",     Seasons = { "summer" },              Locations = { "Ocean" },          Weather = "Sun",  TimeRange = "12pm-4pm",  Difficulty = 80 },
            new() { Name = "Anchovy",        Seasons = { "spring", "fall" },      Locations = { "Ocean" },          Weather = "Any",  TimeRange = "6am-2am",   Difficulty = 30 },
            new() { Name = "Tuna",           Seasons = { "summer", "winter" },    Locations = { "Ocean" },          Weather = "Any",  TimeRange = "6am-7pm",   Difficulty = 70 },
            new() { Name = "Sardine",        Seasons = { "spring", "fall", "winter" }, Locations = { "Ocean" },     Weather = "Any",  TimeRange = "6am-7pm",   Difficulty = 30 },
            new() { Name = "Red Snapper",    Seasons = { "summer", "fall", "winter" }, Locations = { "Ocean" },     Weather = "Rain", TimeRange = "6am-7pm",   Difficulty = 40 },
            new() { Name = "Red Mullet",     Seasons = { "summer", "winter" },    Locations = { "Ocean" },          Weather = "Any",  TimeRange = "6am-7pm",   Difficulty = 55 },
            new() { Name = "Herring",        Seasons = { "spring", "winter" },    Locations = { "Ocean" },          Weather = "Any",  TimeRange = "6am-7pm",   Difficulty = 25 },
            new() { Name = "Eel",            Seasons = { "spring", "fall" },      Locations = { "Ocean" },          Weather = "Rain", TimeRange = "4pm-2am",   Difficulty = 70 },
            new() { Name = "Octopus",        Seasons = { "summer" },              Locations = { "Ocean" },          Weather = "Any",  TimeRange = "6am-1pm",   Difficulty = 95 },
            new() { Name = "Squid",          Seasons = { "winter" },              Locations = { "Ocean" },          Weather = "Any",  TimeRange = "6pm-2am",   Difficulty = 75 },
            new() { Name = "Sea Cucumber",   Seasons = { "fall", "winter" },      Locations = { "Ocean" },          Weather = "Any",  TimeRange = "6am-7pm",   Difficulty = 40 },
            new() { Name = "Super Cucumber", Seasons = { "summer", "fall" },      Locations = { "Ocean" },          Weather = "Any",  TimeRange = "6pm-2am",   Difficulty = 80 },
            new() { Name = "Flounder",       Seasons = { "spring", "summer" },    Locations = { "Ocean" },          Weather = "Any",  TimeRange = "6am-8pm",   Difficulty = 50 },
            new() { Name = "Halibut",        Seasons = { "spring", "summer", "winter" }, Locations = { "Ocean" },   Weather = "Any",  TimeRange = "6am-11am, 7pm-2am", Difficulty = 50 },
            new() { Name = "Tilapia",        Seasons = { "summer", "fall" },      Locations = { "Ocean" },          Weather = "Any",  TimeRange = "6am-2pm",   Difficulty = 50 },
            new() { Name = "Albacore",       Seasons = { "fall", "winter" },      Locations = { "Ocean" },          Weather = "Any",  TimeRange = "6am-11am, 6pm-2am", Difficulty = 60 },

            // ═══════════════════════════════════════════
            //  RIVER FISH (Town / Forest)
            // ═══════════════════════════════════════════
            new() { Name = "Sunfish",        Seasons = { "spring", "summer" },    Locations = { "River" },          Weather = "Sun",  TimeRange = "6am-7pm",   Difficulty = 30 },
            new() { Name = "Catfish",        Seasons = { "spring", "fall" },      Locations = { "River", "Secret Woods" }, Weather = "Rain", TimeRange = "6am-12am", Difficulty = 75 },
            new() { Name = "Shad",           Seasons = { "spring", "summer", "fall" }, Locations = { "River" },     Weather = "Rain", TimeRange = "9am-2am",   Difficulty = 45 },
            new() { Name = "Smallmouth Bass",Seasons = { "spring", "fall" },      Locations = { "River" },          Weather = "Any",  TimeRange = "6am-2am",   Difficulty = 28 },
            new() { Name = "Tiger Trout",    Seasons = { "fall", "winter" },      Locations = { "River" },          Weather = "Any",  TimeRange = "6am-7pm",   Difficulty = 60 },
            new() { Name = "Salmon",         Seasons = { "fall" },                Locations = { "River" },          Weather = "Any",  TimeRange = "6am-7pm",   Difficulty = 50 },
            new() { Name = "Walleye",        Seasons = { "fall" },                Locations = { "River", "Mountain Lake" }, Weather = "Rain", TimeRange = "12pm-2am", Difficulty = 45 },
            new() { Name = "Pike",           Seasons = { "summer", "winter" },    Locations = { "River" },          Weather = "Any",  TimeRange = "6am-2am",   Difficulty = 60 },
            new() { Name = "Rainbow Trout",  Seasons = { "summer" },              Locations = { "River", "Mountain Lake" }, Weather = "Sun", TimeRange = "6am-7pm", Difficulty = 45 },
            new() { Name = "Bream",          Seasons = { "spring", "summer", "fall", "winter" }, Locations = { "River" }, Weather = "Any", TimeRange = "6pm-2am", Difficulty = 35 },
            new() { Name = "Dorado",         Seasons = { "summer" },              Locations = { "River (Forest)" }, Weather = "Any",  TimeRange = "6am-7pm",   Difficulty = 78 },
            new() { Name = "Lingcod",        Seasons = { "winter" },              Locations = { "River", "Mountain Lake" }, Weather = "Any", TimeRange = "6am-2am", Difficulty = 85 },
            new() { Name = "Perch",          Seasons = { "winter" },              Locations = { "River", "Mountain Lake" }, Weather = "Any", TimeRange = "6am-2am", Difficulty = 35 },
            new() { Name = "Goby",           Seasons = { "spring", "summer", "fall", "winter" }, Locations = { "River (Forest)" }, Weather = "Any", TimeRange = "6am-2am", Difficulty = 50 },

            // ═══════════════════════════════════════════
            //  MOUNTAIN LAKE FISH
            // ═══════════════════════════════════════════
            new() { Name = "Largemouth Bass",Seasons = { "spring", "summer", "fall", "winter" }, Locations = { "Mountain Lake" }, Weather = "Any", TimeRange = "6am-7pm", Difficulty = 50 },
            new() { Name = "Carp",           Seasons = { "spring", "summer", "fall", "winter" }, Locations = { "Mountain Lake", "Secret Woods", "Sewers" }, Weather = "Any", TimeRange = "6am-2am", Difficulty = 15 },
            new() { Name = "Bullhead",       Seasons = { "spring", "summer", "fall", "winter" }, Locations = { "Mountain Lake" }, Weather = "Any", TimeRange = "6am-2am", Difficulty = 46 },
            new() { Name = "Sturgeon",       Seasons = { "summer", "winter" },    Locations = { "Mountain Lake" },  Weather = "Any",  TimeRange = "6am-7pm",   Difficulty = 78 },
            new() { Name = "Midnight Carp",  Seasons = { "fall", "winter" },      Locations = { "Mountain Lake", "River (Forest)" }, Weather = "Any", TimeRange = "10pm-2am", Difficulty = 55 },
            new() { Name = "Chub",           Seasons = { "spring", "summer", "fall", "winter" }, Locations = { "Mountain Lake", "River (Forest)" }, Weather = "Any", TimeRange = "6am-2am", Difficulty = 35 },

            // ═══════════════════════════════════════════
            //  MINES FISH
            // ═══════════════════════════════════════════
            new() { Name = "Ghostfish",      Seasons = { "spring", "summer", "fall", "winter" }, Locations = { "Mines (Floor 20-60)" },  Weather = "Any", TimeRange = "6am-2am", Difficulty = 50 },
            new() { Name = "Stonefish",      Seasons = { "spring", "summer", "fall", "winter" }, Locations = { "Mines (Floor 20)" },     Weather = "Any", TimeRange = "6am-2am", Difficulty = 65 },
            new() { Name = "Ice Pip",        Seasons = { "spring", "summer", "fall", "winter" }, Locations = { "Mines (Floor 60)" },     Weather = "Any", TimeRange = "6am-2am", Difficulty = 85 },
            new() { Name = "Lava Eel",       Seasons = { "spring", "summer", "fall", "winter" }, Locations = { "Mines (Floor 100)" },    Weather = "Any", TimeRange = "6am-2am", Difficulty = 90 },

            // ═══════════════════════════════════════════
            //  DESERT / SPECIAL
            // ═══════════════════════════════════════════
            new() { Name = "Sandfish",       Seasons = { "spring", "summer", "fall", "winter" }, Locations = { "Desert" }, Weather = "Any", TimeRange = "6am-8pm", Difficulty = 65 },
            new() { Name = "Scorpion Carp",  Seasons = { "spring", "summer", "fall", "winter" }, Locations = { "Desert" }, Weather = "Any", TimeRange = "6am-8pm", Difficulty = 90 },
            new() { Name = "Woodskip",       Seasons = { "spring", "summer", "fall", "winter" }, Locations = { "Secret Woods", "Forest Farm" }, Weather = "Any", TimeRange = "6am-2am", Difficulty = 50 },
            new() { Name = "Void Salmon",    Seasons = { "spring", "summer", "fall", "winter" }, Locations = { "Witch's Swamp" }, Weather = "Any", TimeRange = "6am-2am", Difficulty = 80 },
            new() { Name = "Slimejack",      Seasons = { "spring", "summer", "fall", "winter" }, Locations = { "Mutant Bug Lair" }, Weather = "Any", TimeRange = "6am-2am", Difficulty = 55 },

            // ═══════════════════════════════════════════
            //  LEGENDARY FISH
            // ═══════════════════════════════════════════
            new() { Name = "Legend",         Seasons = { "spring" },              Locations = { "Mountain Lake" },  Weather = "Rain", TimeRange = "6am-2am",   Difficulty = 110 },
            new() { Name = "Mutant Carp",    Seasons = { "spring", "summer", "fall", "winter" }, Locations = { "Sewers" }, Weather = "Any", TimeRange = "6am-2am", Difficulty = 80 },
            new() { Name = "Crimsonfish",    Seasons = { "summer" },              Locations = { "Ocean (East Pier)" }, Weather = "Any", TimeRange = "6am-2am", Difficulty = 95 },
            new() { Name = "Angler",         Seasons = { "fall" },                Locations = { "River (Town, north bridge)" }, Weather = "Any", TimeRange = "6am-2am", Difficulty = 85 },
            new() { Name = "Glacierfish",    Seasons = { "winter" },              Locations = { "River (Forest, island tip)" }, Weather = "Any", TimeRange = "6am-2am", Difficulty = 100 },
        };

        /// <summary>Returns fish available in the given season.</summary>
        public static List<FishInfo> GetFishBySeason(string season)
        {
            var results = new List<FishInfo>();
            foreach (var fish in AllFish)
            {
                if (fish.Seasons.Contains(season.ToLower()))
                    results.Add(fish);
            }
            return results;
        }

        /// <summary>Returns fish available in the given season AND weather.</summary>
        public static List<FishInfo> GetAvailableFish(string season, bool isRaining)
        {
            var results = new List<FishInfo>();
            string weather = isRaining ? "Rain" : "Sun";

            foreach (var fish in AllFish)
            {
                if (!fish.Seasons.Contains(season.ToLower()))
                    continue;

                if (fish.Weather == "Any" || fish.Weather == weather)
                    results.Add(fish);
            }
            return results;
        }
    }
}
