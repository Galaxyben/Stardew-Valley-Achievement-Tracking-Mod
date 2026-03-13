using System.Collections.Generic;

namespace MiPrimerMod.Framework.Data
{
    /// <summary>
    /// Friendship tips and advice sourced from the Stardew Valley Wiki.
    /// Contains universal gift data and actionable daily advice.
    /// </summary>
    public static class FriendshipTips
    {
        // ═══════════════════════════════════════════
        //  UNIVERSAL LOVED GIFTS (80 pts base, x8 on bday = 640!)
        //  Almost every villager loves these.
        // ═══════════════════════════════════════════
        public static readonly List<string> UniversalLoves = new()
        {
            "Golden Pumpkin",
            "Magic Rock Candy",
            "Pearl",
            "Prismatic Shard",
            "Rabbit's Foot",
            "Stardrop Tea"
        };

        // Exceptions to universal loves
        public static readonly Dictionary<string, string> UniversalLoveExceptions = new()
        {
            { "Haley", "Prismatic Shard (she hates it)" },
            { "Penny", "Rabbit's Foot (she hates it)" }
        };

        // ═══════════════════════════════════════════
        //  EASY-TO-OBTAIN GIFTS THAT ARE WIDELY LIKED
        // ═══════════════════════════════════════════
        public static readonly Dictionary<string, string> EasyGiftsBySeason = new()
        {
            { "spring", "Daffodil (forageando), Leek (forageando), Dandelion (forageando)" },
            { "summer", "Sweet Pea (forageando), Hot Pepper (cultivando), Melon (cultivando)" },
            { "fall",   "Blackberry (forageando, días 8-11 gratis), Pumpkin (cultivando), Cranberry (cultivando)" },
            { "winter", "Crocus (forageando), Crystal Fruit (forageando), Holly (forageando, ¡pero muchos la odian!)" }
        };

        // ═══════════════════════════════════════════
        //  FRIENDSHIP POINT VALUES (for reference)
        // ═══════════════════════════════════════════
        public static readonly Dictionary<string, int> PointValues = new()
        {
            { "Hablar diario",        20 },
            { "Regalo amado",         80 },
            { "Regalo amado (Cumple)", 640 },
            { "Regalo gustado",       45 },
            { "Regalo gustado (Cumple)", 360 },
            { "Regalo neutral",       20 },
            { "Regalo no gustado",   -20 },
            { "Regalo odiado",       -40 },
            { "Quest completada",    150 },
            { "2 regalos en la semana (bonus)", 10 },
        };

        /// <summary>
        /// Generates contextual friendship advice for the current game state.
        /// </summary>
        public static List<string> GetFriendshipAdvice(string season, int dayOfMonth, bool hasBirthdayToday)
        {
            var tips = new List<string>();

            // Always remind to talk daily
            tips.Add("💬 Habla con cada aldeano que veas (+20 pts/día). ¡No cuesta nada!");

            // Birthday tip
            if (hasBirthdayToday)
            {
                tips.Add("🎂 ¡HOY hay un cumpleaños! Los regalos dan x8 puntos. ¡Un regalo amado = 640 pts (casi 3 corazones)!");
            }

            // Weekly gift reminder
            if (dayOfMonth % 7 <= 1) // Near start of week
            {
                tips.Add("🎁 Recuerda: puedes dar 2 regalos por semana a cada aldeano. Dar los 2 te da +10 bonus el domingo.");
            }

            // Season-specific easy gifts
            if (EasyGiftsBySeason.ContainsKey(season))
            {
                tips.Add($"🌿 Regalos fáciles en esta temporada: {EasyGiftsBySeason[season]}");
            }

            // Universal loves reminder
            tips.Add("💎 Los regalos universales amados (Golden Pumpkin, Prismatic Shard, Rabbit's Foot, Pearl) funcionan con casi todos.");

            // Exceptions warning
            tips.Add("⚠️ Excepciones: Haley ODIA Prismatic Shard, Penny ODIA Rabbit's Foot.");

            return tips;
        }
    }
}
