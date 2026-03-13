using System;
using System.Collections.Generic;
using System.Linq;
using StardewModdingAPI;
using StardewValley;
using MiPrimerMod.Framework.Data;

namespace MiPrimerMod.Framework
{
    /// <summary>
    /// Generates dynamic, contextual suggestions that are ALWAYS tied to an incomplete achievement.
    /// Every tip exists to help the player complete a specific achievement.
    /// </summary>
    public class SuggestionEngine
    {
        private readonly IMonitor Monitor;

        public SuggestionEngine(IMonitor monitor)
        {
            this.Monitor = monitor;
        }

        /// <summary>
        /// Generates the main "Daily Goals" panel.
        /// Every suggestion is linked to an incomplete achievement.
        /// </summary>
        public List<string> GenerateDailySuggestions(AchievementTracker tracker)
        {
            var suggestions = new List<string>();

            if (!Context.IsWorldReady || Game1.player == null)
                return suggestions;

            string season = Game1.currentSeason;
            int day = Game1.dayOfMonth;
            bool isRaining = Game1.isRaining;
            string seasonEs = TranslateSeason(season);

            var incomplete = tracker.AllAchievements.Values.Where(a => !a.IsUnlocked).ToList();

            // If no incomplete achievements, congratulate
            if (incomplete.Count == 0)
            {
                suggestions.Add("🏆 ¡Felicidades! ¡Has desbloqueado TODOS los logros! ¡Eres leyenda!");
                return suggestions;
            }

            // ═══════════════════════════════════════════
            //  MONEY ACHIEVEMENTS → Earning/selling tips
            // ═══════════════════════════════════════════
            var moneyAch = incomplete
                .Where(a => a.Type == AchievementType.Money && a.CurrentValue < a.MaxValue)
                .OrderBy(a => a.MaxValue)
                .FirstOrDefault();
            if (moneyAch != null)
            {
                int needed = moneyAch.MaxValue - moneyAch.CurrentValue;
                suggestions.Add($"💰 [{moneyAch.Name}] Te faltan {needed:N0}g. ¡Vende cultivos, artesanías o pesca!");

                // Season-specific money tips
                string moneyTip = season switch
                {
                    "spring" => "Cultiva Parsnips/Cauliflower. Pesca Catfish con lluvia (1500g+).",
                    "summer" => "Blueberries y Starfruit son muy rentables. Pesca Lava Eel en las minas.",
                    "fall"   => "Cranberries rinden múltiples cosechas. Los Ancient Fruit son oro puro.",
                    "winter" => "Sin cultivos: pesca, minas y procesado artesanal son tu ingreso.",
                    _ => ""
                };
                if (!string.IsNullOrEmpty(moneyTip))
                    suggestions.Add($"   💡 Tip {seasonEs}: {moneyTip}");
            }

            // ═══════════════════════════════════════════
            //  FRIENDSHIP ACHIEVEMENTS → Birthday & gift tips
            // ═══════════════════════════════════════════
            var friendAch = incomplete
                .Where(a => a.Type == AchievementType.Friendship && a.CurrentValue < a.MaxValue)
                .OrderBy(a => a.MaxValue)
                .FirstOrDefault();
            if (friendAch != null)
            {
                int need = friendAch.MaxValue - friendAch.CurrentValue;
                suggestions.Add($"❤️ [{friendAch.Name}] Necesitas {need} amigo(s) más con suficientes corazones.");

                // Birthday today → HUGE opportunity for this achievement
                var birthday = CalendarData.GetBirthdayToday(season, day);
                if (birthday != null)
                {
                    string gifts = string.Join(", ", birthday.LovedGifts.Take(3));
                    suggestions.Add($"   🎂 ¡CUMPLEAÑOS de {birthday.Villager} HOY! Regala: {gifts} (x8 pts = hasta 640 amistad).");
                }

                // Upcoming birthdays → prepare in advance
                var upcoming = CalendarData.GetUpcomingBirthdays(season, day, 2);
                foreach (var bday in upcoming)
                {
                    int daysUntil = bday.Day - day;
                    string gift = bday.LovedGifts.FirstOrDefault() ?? "cualquier regalo amado";
                    suggestions.Add($"   📅 Cumpleaños de {bday.Villager} en {daysUntil} día(s) (Día {bday.Day}). Prepara: {gift}.");
                }

                // General friendship advice tied to achievement
                suggestions.Add($"   💬 Habla con todos diariamente (+20 pts). Da 2 regalos/semana (+10 bonus domingo).");

                // Season-specific easy gifts
                if (FriendshipTips.EasyGiftsBySeason.ContainsKey(season))
                    suggestions.Add($"   🌿 Regalos fáciles ahora: {FriendshipTips.EasyGiftsBySeason[season]}");
            }

            // ═══════════════════════════════════════════
            //  FISH ACHIEVEMENTS → What to fish today
            // ═══════════════════════════════════════════
            var fishAch = incomplete.FirstOrDefault(a => a.Type == AchievementType.Fish);
            if (fishAch != null)
            {
                var availableFish = FishDatabase.GetAvailableFish(season, isRaining);
                string weatherTxt = isRaining ? "lloviendo" : "soleado";
                suggestions.Add($"🎣 [{fishAch.Name}] {availableFish.Count} peces disponibles hoy ({seasonEs}, {weatherTxt}).");

                // Weather-exclusive fish → urgent
                if (isRaining)
                {
                    var rainOnly = availableFish.Where(f => f.Weather == "Rain").ToList();
                    if (rainOnly.Count > 0)
                    {
                        string names = string.Join(", ", rainOnly.Select(f => $"{f.Name} ({string.Join("/", f.Locations)})"));
                        suggestions.Add($"   🌧️ ¡SOLO con lluvia! Prioriza: {names}.");
                    }
                }
                else
                {
                    var sunOnly = availableFish.Where(f => f.Weather == "Sun").ToList();
                    if (sunOnly.Count > 0)
                    {
                        string names = string.Join(", ", sunOnly.Select(f => $"{f.Name} ({string.Join("/", f.Locations)})"));
                        suggestions.Add($"   ☀️ ¡SOLO con sol! Aprovecha: {names}.");
                    }
                }

                // Top 3 hardest available fish
                var hardest = availableFish.OrderByDescending(f => f.Difficulty).Take(3);
                foreach (var fish in hardest)
                {
                    string locs = string.Join(", ", fish.Locations);
                    suggestions.Add($"   🐟 {fish.Name} — {locs} | {fish.TimeRange} | Dif: {fish.Difficulty}");
                }
            }

            // ═══════════════════════════════════════════
            //  COOKING ACHIEVEMENTS → Recipe tips
            // ═══════════════════════════════════════════
            var cookAch = incomplete.FirstOrDefault(a => a.Type == AchievementType.Cooking);
            if (cookAch != null)
            {
                suggestions.Add($"🍳 [{cookAch.Name}] Cocina nuevas recetas. Revisa la TV los domingos para aprender recetas.");
                suggestions.Add($"   💡 Sube amistad con aldeanos para desbloquear recetas por correo.");
            }

            // ═══════════════════════════════════════════
            //  CRAFTING ACHIEVEMENTS → Crafting tips
            // ═══════════════════════════════════════════
            var craftAch = incomplete.FirstOrDefault(a => a.Type == AchievementType.Crafting);
            if (craftAch != null)
            {
                suggestions.Add($"🔨 [{craftAch.Name}] Craftea cada ítem al menos una vez. Sube skills para nuevas recetas.");
            }

            // ═══════════════════════════════════════════
            //  SKILL ACHIEVEMENTS → Which skills to train
            // ═══════════════════════════════════════════
            var skillAch = incomplete.FirstOrDefault(a => a.Type == AchievementType.Skills);
            if (skillAch != null)
            {
                int need = skillAch.MaxValue - skillAch.CurrentValue;
                suggestions.Add($"⭐ [{skillAch.Name}] Sube {need} habilidad(es) más al nivel 10.");

                // Show which skills are not yet at 10
                var skillsBelow10 = new List<string>();
                if (Game1.player.FarmingLevel < 10) skillsBelow10.Add($"Farming ({Game1.player.FarmingLevel}/10)");
                if (Game1.player.MiningLevel < 10) skillsBelow10.Add($"Mining ({Game1.player.MiningLevel}/10)");
                if (Game1.player.ForagingLevel < 10) skillsBelow10.Add($"Foraging ({Game1.player.ForagingLevel}/10)");
                if (Game1.player.FishingLevel < 10) skillsBelow10.Add($"Fishing ({Game1.player.FishingLevel}/10)");
                if (Game1.player.CombatLevel < 10) skillsBelow10.Add($"Combat ({Game1.player.CombatLevel}/10)");
                if (skillsBelow10.Count > 0)
                    suggestions.Add($"   📊 Habilidades pendientes: {string.Join(", ", skillsBelow10)}");
            }

            // ═══════════════════════════════════════════
            //  DONATION ACHIEVEMENTS → Museum tips
            // ═══════════════════════════════════════════
            var donationAch = incomplete.FirstOrDefault(a => a.Type == AchievementType.Donation);
            if (donationAch != null)
            {
                suggestions.Add($"🏛️ [{donationAch.Name}] Dona minerales y artefactos al museo de Gunther.");
                suggestions.Add($"   ⛏️ Explora las minas y abre geodes en Clint para nuevos minerales.");
            }

            // ═══════════════════════════════════════════
            //  FESTIVAL tied to any achievement
            // ═══════════════════════════════════════════
            var festival = CalendarData.GetFestivalToday(season, day);
            if (festival != null)
            {
                suggestions.Add($"🎪 ¡Hoy: {festival.Name}! {festival.Tip}");
            }
            else
            {
                var upcomingFest = CalendarData.GetUpcomingFestivals(season, day, 1);
                foreach (var fest in upcomingFest)
                {
                    int daysUntil = fest.Day - day;
                    suggestions.Add($"🎪 En {daysUntil} día(s): {fest.Name}. {fest.Tip}");
                }
            }

            // Summary
            int totalIncomplete = incomplete.Count;
            int totalAll = tracker.AllAchievements.Count;
            suggestions.Add($"📈 Progreso global: {totalAll - totalIncomplete}/{totalAll} logros completados.");

            return suggestions;
        }

        /// <summary>
        /// Returns a detailed fish list, but ONLY if there is an incomplete fish achievement.
        /// Otherwise returns a message saying fishing achievements are complete.
        /// </summary>
        public List<string> GetDetailedFishList(AchievementTracker tracker)
        {
            var lines = new List<string>();

            if (!Context.IsWorldReady)
                return lines;

            // Check if there's any fish achievement pending
            bool hasFishAch = tracker.AllAchievements.Values.Any(a => a.Type == AchievementType.Fish && !a.IsUnlocked);
            if (!hasFishAch)
            {
                lines.Add("✅ ¡Todos los logros de pesca completados!");
                lines.Add("");
                lines.Add("Ya no necesitas pescar para logros,");
                lines.Add("pero aquí tienes los peces de la temporada:");
                lines.Add("");
            }
            else
            {
                var fishAch = tracker.AllAchievements.Values.FirstOrDefault(a => a.Type == AchievementType.Fish && !a.IsUnlocked);
                lines.Add($"🎯 Objetivo: {fishAch!.Name} — {fishAch.Description}");
                lines.Add("");
            }

            string season = Game1.currentSeason;
            bool isRaining = Game1.isRaining;
            string seasonEs = TranslateSeason(season);
            string weatherTxt = isRaining ? "Lluvia 🌧️" : "Sol ☀️";

            lines.Add($"Peces en {seasonEs} ({weatherTxt}):");
            lines.Add("");

            var fish = FishDatabase.GetAvailableFish(season, isRaining)
                .OrderBy(f => string.Join(", ", f.Locations))
                .ThenBy(f => f.Name);

            string lastLocation = "";
            foreach (var f in fish)
            {
                string loc = string.Join(", ", f.Locations);
                if (loc != lastLocation)
                {
                    lines.Add($"── {loc} ──");
                    lastLocation = loc;
                }

                string weatherIcon = f.Weather switch
                {
                    "Rain" => "🌧️",
                    "Sun" => "☀️",
                    _ => "🌤️"
                };

                lines.Add($"  {weatherIcon} {f.Name} | {f.TimeRange} | Dif: {f.Difficulty}");
            }

            return lines;
        }

        /// <summary>
        /// Returns friendship advice, but ONLY if there is an incomplete friendship achievement.
        /// </summary>
        public List<string> GetFriendshipAdvice(AchievementTracker tracker)
        {
            var lines = new List<string>();

            if (!Context.IsWorldReady)
                return lines;

            // Check if there's any friendship achievement pending
            var friendAch = tracker.AllAchievements.Values
                .Where(a => a.Type == AchievementType.Friendship && !a.IsUnlocked)
                .OrderBy(a => a.MaxValue)
                .FirstOrDefault();

            if (friendAch == null)
            {
                lines.Add("✅ ¡Todos los logros de amistad completados!");
                lines.Add("");
                lines.Add("Ya no necesitas subir corazones para logros.");
                return lines;
            }

            int need = friendAch.MaxValue - friendAch.CurrentValue;
            lines.Add($"🎯 Objetivo: {friendAch.Name} — {friendAch.Description}");
            lines.Add($"   Progreso: {friendAch.CurrentValue}/{friendAch.MaxValue} ({(int)(friendAch.GetProgressPercentage() * 100)}%)");
            lines.Add("");

            string season = Game1.currentSeason;
            int day = Game1.dayOfMonth;
            var birthday = CalendarData.GetBirthdayToday(season, day);

            // Birthday alert
            if (birthday != null)
            {
                string gifts = string.Join(", ", birthday.LovedGifts.Take(4));
                lines.Add($"🎂 ¡HOY: Cumpleaños de {birthday.Villager}!");
                lines.Add($"   Regala: {gifts}");
                lines.Add($"   Un regalo amado hoy = 640 puntos (¡casi 3 corazones!)");
                lines.Add("");
            }

            // Upcoming birthdays
            var upcoming = CalendarData.GetUpcomingBirthdays(season, day, 3);
            if (upcoming.Count > 0)
            {
                lines.Add("📅 Próximos cumpleaños:");
                foreach (var bday in upcoming)
                {
                    int daysUntil = bday.Day - day;
                    string gifts = string.Join(", ", bday.LovedGifts.Take(3));
                    lines.Add($"   {bday.Villager} (Día {bday.Day}, en {daysUntil}d) → {gifts}");
                }
                lines.Add("");
            }

            // Point system reference
            lines.Add("📖 Sistema de puntos:");
            foreach (var kvp in FriendshipTips.PointValues)
            {
                string sign = kvp.Value >= 0 ? "+" : "";
                lines.Add($"   {kvp.Key}: {sign}{kvp.Value} pts");
            }
            lines.Add("");

            // Season-specific easy gifts
            if (FriendshipTips.EasyGiftsBySeason.ContainsKey(season))
            {
                lines.Add($"🌿 Regalos fáciles ({TranslateSeason(season)}):");
                lines.Add($"   {FriendshipTips.EasyGiftsBySeason[season]}");
                lines.Add("");
            }

            // Universal loves
            lines.Add("💎 Regalos amados universales (funcionan con casi todos):");
            lines.Add($"   {string.Join(", ", FriendshipTips.UniversalLoves)}");
            lines.Add("");
            lines.Add("⚠️ Excepciones:");
            foreach (var exc in FriendshipTips.UniversalLoveExceptions)
                lines.Add($"   {exc.Key}: {exc.Value}");

            return lines;
        }

        /// <summary>
        /// Returns the day-by-day Year 1 guide for the current in-game day.
        /// Only shows TODAY's tasks — not the whole guide.
        /// </summary>
        public List<string> GetDailyGuide()
        {
            var lines = new List<string>();

            if (!Context.IsWorldReady)
                return lines;

            string season = Game1.currentSeason;
            int day = Game1.dayOfMonth;
            int year = Game1.year;
            string seasonEs = TranslateSeason(season);
            string dayOfWeek = Game1.shortDayNameFromDayOfSeason(day);

            // Header
            lines.Add($"📋 GUIA DEL DIA — {seasonEs} {day} ({dayOfWeek}), Año {year}");
            lines.Add("═══════════════════════════════════════");

            if (year > 1)
            {
                lines.Add("");
                lines.Add("📖 La guía día-a-día cubre el Año 1.");
                lines.Add("Ya completaste tu primer año. ¡Buen trabajo!");
                lines.Add("");
                lines.Add("Usa las otras pestañas (Hoy, Pesca, Amistad)");
                lines.Add("para seguir avanzando hacia tus logros pendientes.");
                return lines;
            }

            var todaysGuide = DailyGuideData.GetTodaysGuide(season, day, year);

            if (todaysGuide != null)
            {
                lines.Add("");
                foreach (var task in todaysGuide.Tasks)
                {
                    // Add bullet icon based on content
                    string icon = "▸";
                    if (task.Contains("🎂") || task.Contains("🎪") || task.Contains("🫐"))
                        icon = "";  // Already has emoji
                    else if (task.Contains("Riega") || task.Contains("Planta"))
                        icon = "🌱";
                    else if (task.Contains("Minas") || task.Contains("minas") || task.Contains("Floor"))
                        icon = "⛏️";
                    else if (task.Contains("Pesca") || task.Contains("pesca") || task.Contains("Catfish"))
                        icon = "🎣";
                    else if (task.Contains("Compra") || task.Contains("Vende"))
                        icon = "💰";
                    else if (task.Contains("Social") || task.Contains("Habla") || task.Contains("Regala") || task.Contains("regalo"))
                        icon = "💬";
                    else if (task.Contains("ÚLTIMO") || task.Contains("Cosecha TODO"))
                        icon = "⚠️";

                    lines.Add($"  {icon} {task}");
                }
            }
            else
            {
                lines.Add("");
                lines.Add("Sin tareas específicas para hoy.");
                lines.Add("Usa las pestañas Hoy y Pesca para ver");
                lines.Add("sugerencias basadas en tus logros pendientes.");
            }

            // Tomorrow preview
            lines.Add("");
            lines.Add("──── Mañana ────");
            var tomorrowGuide = DailyGuideData.GetTomorrowsGuide(season, day, year);
            if (tomorrowGuide != null && tomorrowGuide.Tasks.Count > 0)
            {
                // Show just the first 2 tasks as a preview
                int previewCount = Math.Min(2, tomorrowGuide.Tasks.Count);
                for (int i = 0; i < previewCount; i++)
                {
                    string task = tomorrowGuide.Tasks[i];
                    if (task.Length > 60)
                        task = task.Substring(0, 57) + "...";
                    lines.Add($"  ▹ {task}");
                }
                if (tomorrowGuide.Tasks.Count > previewCount)
                    lines.Add($"  ... y {tomorrowGuide.Tasks.Count - previewCount} tareas más.");
            }
            else
            {
                lines.Add("  Sin información para mañana.");
            }

            return lines;
        }

        private string TranslateSeason(string season)
        {
            return season switch
            {
                "spring" => "Primavera",
                "summer" => "Verano",
                "fall" => "Otoño",
                "winter" => "Invierno",
                _ => season
            };
        }
    }
}
