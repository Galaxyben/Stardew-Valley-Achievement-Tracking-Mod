using System.Collections.Generic;
using System.Linq;

namespace MiPrimerMod.Framework.Data
{
    /// <summary>Represents a villager birthday entry.</summary>
    public class BirthdayEntry
    {
        public string Villager { get; set; } = string.Empty;
        public string Season { get; set; } = string.Empty;
        public int Day { get; set; }

        /// <summary>Best loved gifts for this villager (easy to obtain ones).</summary>
        public List<string> LovedGifts { get; set; } = new();
    }

    /// <summary>Represents a seasonal festival.</summary>
    public class FestivalEntry
    {
        public string Name { get; set; } = string.Empty;
        public string Season { get; set; } = string.Empty;
        public int Day { get; set; }
        public string Tip { get; set; } = string.Empty;
    }

    /// <summary>
    /// Complete calendar database for all four seasons, sourced from the Stardew Valley Wiki.
    /// </summary>
    public static class CalendarData
    {
        // ═══════════════════════════════════════════
        //  ALL BIRTHDAYS (Season, Day, Villager, LovedGifts)
        // ═══════════════════════════════════════════
        public static readonly List<BirthdayEntry> Birthdays = new()
        {
            // ─── SPRING ───
            new() { Villager = "Kent",    Season = "spring", Day = 4,  LovedGifts = { "Fiddlehead Risotto", "Roasted Hazelnuts" } },
            new() { Villager = "Lewis",   Season = "spring", Day = 7,  LovedGifts = { "Autumn's Bounty", "Glazed Yams", "Hot Pepper", "Green Tea" } },
            new() { Villager = "Vincent", Season = "spring", Day = 10, LovedGifts = { "Grape", "Snail", "Pink Cake" } },
            new() { Villager = "Haley",   Season = "spring", Day = 14, LovedGifts = { "Coconut", "Sunflower", "Pink Cake", "Fruit Salad" } },
            new() { Villager = "Pam",     Season = "spring", Day = 18, LovedGifts = { "Beer", "Cactus Fruit", "Mead", "Pale Ale", "Parsnip" } },
            new() { Villager = "Shane",   Season = "spring", Day = 20, LovedGifts = { "Beer", "Hot Pepper", "Pizza", "Pepper Poppers" } },
            new() { Villager = "Pierre",  Season = "spring", Day = 26, LovedGifts = { "Fried Calamari" } },
            new() { Villager = "Emily",   Season = "spring", Day = 27, LovedGifts = { "Amethyst", "Aquamarine", "Cloth", "Emerald", "Jade", "Ruby", "Survival Burger", "Topaz", "Wool" } },

            // ─── SUMMER ───
            new() { Villager = "Jas",       Season = "summer", Day = 4,  LovedGifts = { "Fairy Rose", "Pink Cake", "Plum Pudding" } },
            new() { Villager = "Gus",       Season = "summer", Day = 8,  LovedGifts = { "Diamond", "Escargot", "Fish Taco", "Orange", "Tropical Curry" } },
            new() { Villager = "Maru",      Season = "summer", Day = 10, LovedGifts = { "Battery Pack", "Cauliflower", "Cheese Cauliflower", "Diamond", "Gold Bar", "Iridium Bar", "Miner's Treat", "Pepper Poppers", "Radioactive Bar", "Rhubarb Pie", "Strawberry" } },
            new() { Villager = "Alex",      Season = "summer", Day = 13, LovedGifts = { "Complete Breakfast", "Salmon Dinner" } },
            new() { Villager = "Sam",       Season = "summer", Day = 17, LovedGifts = { "Cactus Fruit", "Maple Bar", "Pizza", "Tigerseye" } },
            new() { Villager = "Demetrius", Season = "summer", Day = 19, LovedGifts = { "Bean Hotpot", "Ice Cream", "Rice Pudding", "Strawberry" } },
            new() { Villager = "Dwarf",     Season = "summer", Day = 22, LovedGifts = { "Amethyst", "Aquamarine", "Emerald", "Jade", "Lemon Stone", "Ruby", "Topaz" } },
            new() { Villager = "Willy",     Season = "summer", Day = 24, LovedGifts = { "Catfish", "Diamond", "Gold Bar", "Iridium Bar", "Mead", "Octopus", "Pumpkin", "Sea Cucumber", "Sturgeon" } },
            new() { Villager = "Leo",       Season = "summer", Day = 26, LovedGifts = { "Duck Feather", "Mango", "Ostrich Egg", "Poi" } },

            // ─── FALL ───
            new() { Villager = "Penny",   Season = "fall", Day = 2,  LovedGifts = { "Diamond", "Emerald", "Melon", "Poppy", "Poppyseed Muffin", "Red Plate", "Roots Platter", "Sandfish", "Tom Kha Soup" } },
            new() { Villager = "Elliott", Season = "fall", Day = 5,  LovedGifts = { "Crab Cakes", "Duck Feather", "Lobster", "Pomegranate", "Tom Kha Soup" } },
            new() { Villager = "Jodi",    Season = "fall", Day = 11, LovedGifts = { "Chocolate Cake", "Crispy Bass", "Diamond", "Eggplant Parmesan", "Fried Mushroom", "Pancakes", "Rhubarb Pie", "Vegetable Medley" } },
            new() { Villager = "Abigail", Season = "fall", Day = 13, LovedGifts = { "Amethyst", "Banana Pudding", "Blackberry Cobbler", "Chocolate Cake", "Pufferfish", "Pumpkin", "Spicy Eel" } },
            new() { Villager = "Sandy",   Season = "fall", Day = 15, LovedGifts = { "Crocus", "Daffodil", "Mango Sticky Rice", "Sweet Pea" } },
            new() { Villager = "Marnie",  Season = "fall", Day = 18, LovedGifts = { "Diamond", "Farmer's Lunch", "Pink Cake", "Pumpkin Pie" } },
            new() { Villager = "Robin",   Season = "fall", Day = 21, LovedGifts = { "Goat Cheese", "Peach", "Spaghetti" } },
            new() { Villager = "George",  Season = "fall", Day = 24, LovedGifts = { "Fried Mushroom", "Leek" } },

            // ─── WINTER ───
            new() { Villager = "Krobus",    Season = "winter", Day = 1,  LovedGifts = { "Diamond", "Iridium Bar", "Pumpkin", "Void Egg", "Void Mayonnaise", "Wild Horseradish" } },
            new() { Villager = "Linus",     Season = "winter", Day = 3,  LovedGifts = { "Blueberry Tart", "Cactus Fruit", "Coconut", "Dish O' The Sea", "Yam" } },
            new() { Villager = "Caroline",  Season = "winter", Day = 7,  LovedGifts = { "Fish Taco", "Green Tea", "Summer Spangle", "Tropical Curry" } },
            new() { Villager = "Sebastian", Season = "winter", Day = 10, LovedGifts = { "Frog Egg", "Frozen Tear", "Obsidian", "Pumpkin Soup", "Sashimi", "Void Egg" } },
            new() { Villager = "Harvey",    Season = "winter", Day = 14, LovedGifts = { "Coffee", "Pickles", "Super Meal", "Truffle Oil", "Wine" } },
            new() { Villager = "Wizard",    Season = "winter", Day = 17, LovedGifts = { "Purple Mushroom", "Solar Essence", "Super Cucumber", "Void Essence" } },
            new() { Villager = "Evelyn",    Season = "winter", Day = 20, LovedGifts = { "Beet", "Chocolate Cake", "Diamond", "Fairy Rose", "Stuffing", "Tulip" } },
            new() { Villager = "Leah",      Season = "winter", Day = 23, LovedGifts = { "Goat Cheese", "Poppyseed Muffin", "Salad", "Stir Fry", "Truffle", "Vegetable Medley", "Wine" } },
            new() { Villager = "Clint",     Season = "winter", Day = 26, LovedGifts = { "Amethyst", "Aquamarine", "Artichoke Dip", "Emerald", "Fiddlehead Risotto", "Gold Bar", "Iridium Bar", "Jade", "Omni Geode", "Ruby", "Topaz" } },
        };

        // ═══════════════════════════════════════════
        //  FESTIVALS
        // ═══════════════════════════════════════════
        public static readonly List<FestivalEntry> Festivals = new()
        {
            // Spring  
            new() { Name = "Egg Festival",      Season = "spring", Day = 13, Tip = "Participa en la Egg Hunt para ganar un Straw Hat. ¡Habla con todos los aldeanos para amistad!" },
            new() { Name = "Desert Festival",    Season = "spring", Day = 15, Tip = "Visita el Desert Festival (Día 15-17). Hay peces raros y actividades especiales." },
            new() { Name = "Flower Dance",       Season = "spring", Day = 24, Tip = "Necesitas 4+ corazones para bailar con alguien. ¡Es una gran oportunidad de amistad!" },

            // Summer
            new() { Name = "Luau",                  Season = "summer", Day = 11, Tip = "Trae un ingrediente de alta calidad (Gold Star+) para el guiso del gobernador. ¡Gana amistad con todos!" },
            new() { Name = "Trout Derby",            Season = "summer", Day = 20, Tip = "Pesca truchas en el Trout Derby (Día 20-21) para ganar premios especiales." },
            new() { Name = "Dance of the Moonlight Jellies", Season = "summer", Day = 28, Tip = "¡Festival relajante en la playa! Habla con todos para subir amistad." },

            // Fall
            new() { Name = "Stardew Valley Fair",  Season = "fall", Day = 16, Tip = "Exhibe tus mejores 9 ítems en el Grange Display. Artículos de alta calidad ganan más puntos." },
            new() { Name = "Spirit's Eve",          Season = "fall", Day = 27, Tip = "¡Explora el laberinto para encontrar un Golden Pumpkin (regalo universal amado)!" },

            // Winter
            new() { Name = "Festival of Ice",      Season = "winter", Day = 8,  Tip = "Concurso de pesca. ¡Practica tus habilidades de pesca antes!" },
            new() { Name = "SquidFest",             Season = "winter", Day = 12, Tip = "Pesca calamares en el SquidFest (Día 12-13) para premios especiales." },
            new() { Name = "Night Market",           Season = "winter", Day = 15, Tip = "Night Market (Día 15-17). ¡Pesca en el submarino para peces exclusivos como Blobfish y Spook Fish!" },
            new() { Name = "Feast of the Winter Star", Season = "winter", Day = 25, Tip = "Los regalos del Winter Star dan x5 puntos de amistad. ¡Da un regalo amado para ganar casi 2 corazones!" },
        };

        /// <summary>Returns the birthday entry for a specific season and day, or null.</summary>
        public static BirthdayEntry? GetBirthdayToday(string season, int day)
        {
            return Birthdays.FirstOrDefault(b => b.Season == season.ToLower() && b.Day == day);
        }

        /// <summary>Returns upcoming birthdays in this season (from today onwards).</summary>
        public static List<BirthdayEntry> GetUpcomingBirthdays(string season, int currentDay, int count = 3)
        {
            return Birthdays
                .Where(b => b.Season == season.ToLower() && b.Day > currentDay)
                .OrderBy(b => b.Day)
                .Take(count)
                .ToList();
        }

        /// <summary>Returns the festival for a specific season and day, or null.</summary>
        public static FestivalEntry? GetFestivalToday(string season, int day)
        {
            return Festivals.FirstOrDefault(f => f.Season == season.ToLower() && f.Day == day);
        }

        /// <summary>Returns upcoming festivals in this season.</summary>
        public static List<FestivalEntry> GetUpcomingFestivals(string season, int currentDay, int count = 2)
        {
            return Festivals
                .Where(f => f.Season == season.ToLower() && f.Day > currentDay)
                .OrderBy(f => f.Day)
                .Take(count)
                .ToList();
        }
    }
}
