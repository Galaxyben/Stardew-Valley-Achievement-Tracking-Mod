using System;
using System.Collections.Generic;
using System.Linq;
using StardewModdingAPI;
using StardewValley;

namespace MiPrimerMod.Framework
{
    /// <summary>Service responsible for reading and tracking achievement progress.</summary>
    public class AchievementTracker
    {
        private readonly IMonitor Monitor;
        private readonly IModHelper Helper;

        /// <summary>A cache of all achievements parsed from the game data.</summary>
        public Dictionary<int, AchievementData> AllAchievements { get; private set; }

        public AchievementTracker(IMonitor monitor, IModHelper helper)
        {
            this.Monitor = monitor;
            this.Helper = helper;
            this.AllAchievements = new Dictionary<int, AchievementData>();
        }

        /// <summary>
        /// Loads the base definitions of all achievements from the game's data files.
        /// This should be called after the save is loaded.
        /// </summary>
        public void LoadAchievements()
        {
            this.AllAchievements.Clear();

            try
            {
                // En Stardew Valley 1.6, DataLoader is used to access data securely.
                var achievementData = DataLoader.Achievements(Game1.content);

                foreach (var kvp in achievementData)
                {
                    int id = kvp.Key;
                    string rawData = kvp.Value;

                    // SDV 1.6 format: "Name^Prerequisite^DescriptionUnlocked^DescriptionLocked^showAtFestival"
                    // Example: "Greenhorn^false^Earn 15,000g.^Earn 15,000g.^true"
                    string[] parts = rawData.Split('^');
                    if (parts.Length >= 1)
                    {
                        string name = parts[0];
                        // Description is at index 2 (unlock text) or index 3 (locked text)
                        string description = parts.Length >= 4 ? parts[3] : (parts.Length >= 3 ? parts[2] : name);

                        var data = new AchievementData
                        {
                            Id = id,
                            Name = name,
                            Description = description,
                            Type = DetermineType(id)
                        };

                        this.AllAchievements[id] = data;
                    }
                }

                this.Monitor.Log($"Loaded {this.AllAchievements.Count} achievements from game data.", LogLevel.Debug);
            }
            catch (Exception ex)
            {
                this.Monitor.Log($"Error loading achievements: {ex.Message}", LogLevel.Error);
            }
        }

        /// <summary>
        /// Updates the current tracking status (unlocked state and progress).
        /// </summary>
        public void UpdateProgress()
        {
            if (Game1.player == null) return;

            foreach (var kvp in this.AllAchievements)
            {
                int id = kvp.Key;
                AchievementData data = kvp.Value;

                // Check if the player already has the achievement unlocked
                data.IsUnlocked = Game1.player.achievements.Contains(id);

                if (!data.IsUnlocked)
                {
                    // If not unlocked, calculate the current progress based on the game state
                    CalculateProgress(data);
                }
            }
        }

        /// <summary>
        /// Returns all achievements sorted by progress (closest to completion first), then unlocked last.
        /// </summary>
        public List<AchievementData> GetSortedAchievements()
        {
            return this.AllAchievements.Values
                .OrderBy(a => a.IsUnlocked)                     // Incomplete first
                .ThenByDescending(a => a.GetProgressPercentage()) // Closest to completion first
                .ToList();
        }

        /// <summary>
        /// Determines achievement type based on Stardew Valley's hardcoded IDs.
        /// </summary>
        private AchievementType DetermineType(int id)
        {
            // Explicit parentheses for clarity
            if ((id >= 0 && id <= 4) || id == 34) return AchievementType.Money;
            if (id >= 5 && id <= 10) return AchievementType.Friendship;
            if (id >= 11 && id <= 12) return AchievementType.Donation;
            if (id >= 15 && id <= 17) return AchievementType.Cooking;
            if (id >= 20 && id <= 22) return AchievementType.Crafting;
            if (id >= 24 && id <= 26) return AchievementType.Fish;
            if (id >= 27 && id <= 28) return AchievementType.Shipping;
            if (id >= 29 && id <= 32) return AchievementType.Skills;

            return AchievementType.Misc;
        }

        /// <summary>
        /// Logic to calculate the specific requirements for an achievement.
        /// This compares Game1.player stats to the known hardcoded requirements of Stardew Valley.
        /// </summary>
        private void CalculateProgress(AchievementData data)
        {
            // Use long to prevent uint -> int overflow for large money values
            long totalMoney = Game1.player.totalMoneyEarned;

            switch (data.Id)
            {
                // ==============================
                // MONEY ACHIEVEMENTS
                // ==============================
                case 0: // Greenhorn (15,000g)
                    data.MaxValue = 15000;
                    data.CurrentValue = (int)Math.Min(totalMoney, int.MaxValue);
                    break;
                case 1: // Cowpoke (50,000g)
                    data.MaxValue = 50000;
                    data.CurrentValue = (int)Math.Min(totalMoney, int.MaxValue);
                    break;
                case 2: // Homesteader (250,000g)
                    data.MaxValue = 250000;
                    data.CurrentValue = (int)Math.Min(totalMoney, int.MaxValue);
                    break;
                case 3: // Millionaire (1,000,000g)
                    data.MaxValue = 1000000;
                    data.CurrentValue = (int)Math.Min(totalMoney, int.MaxValue);
                    break;
                case 4: // Legend (10,000,000g)
                    data.MaxValue = 10000000;
                    data.CurrentValue = (int)Math.Min(totalMoney, 10000000);
                    break;

                // ==============================
                // FRIENDSHIP ACHIEVEMENTS
                // 1 heart = 250 friendship points
                // ==============================
                case 5: // A New Friend (reach 5-heart with 1 villager)
                    data.MaxValue = 1;
                    data.CurrentValue = CountFriendsWithHearts(5);
                    break;
                case 6: // Cliques (reach 5-heart with 4 villagers)
                    data.MaxValue = 4;
                    data.CurrentValue = CountFriendsWithHearts(5);
                    break;
                case 7: // Networking (reach 5-heart with 10 villagers)
                    data.MaxValue = 10;
                    data.CurrentValue = CountFriendsWithHearts(5);
                    break;
                case 8: // Popular (reach 5-heart with 20 villagers)
                    data.MaxValue = 20;
                    data.CurrentValue = CountFriendsWithHearts(5);
                    break;
                case 9: // Best Friends (reach 10-heart with 1 villager)
                    data.MaxValue = 1;
                    data.CurrentValue = CountFriendsWithHearts(10);
                    break;
                case 10: // The Beloved Farmer (reach 10-heart with 8 villagers)
                    data.MaxValue = 8;
                    data.CurrentValue = CountFriendsWithHearts(10);
                    break;

                // ==============================
                // SKILL ACHIEVEMENTS
                // ==============================
                case 29: // Singular Talent (1 skill at level 10)
                    data.MaxValue = 1;
                    data.CurrentValue = CountSkillsAtLevel(10);
                    break;
                case 30: // Master of the Five Ways (all 5 skills at level 10)
                    data.MaxValue = 5;
                    data.CurrentValue = CountSkillsAtLevel(10);
                    break;

                // ==============================
                // SHIPPING / COLLECTION
                // ==============================
                case 34: // Full Shipment (ship every item)
                    data.MaxValue = 1;
                    data.CurrentValue = 0; // Complex: needs item-by-item comparison
                    break;

                // Default: unknown or complex tracking
                default:
                    data.MaxValue = 1;
                    data.CurrentValue = 0;
                    break;
            }
        }

        private int CountFriendsWithHearts(int hearts)
        {
            int requiredPoints = hearts * 250;
            int count = 0;
            if (Game1.player.friendshipData != null)
            {
                foreach (var relation in Game1.player.friendshipData.Values)
                {
                    if (relation.Points >= requiredPoints)
                        count++;
                }
            }
            return count;
        }

        private int CountSkillsAtLevel(int level)
        {
            int count = 0;
            if (Game1.player.FarmingLevel >= level) count++;
            if (Game1.player.MiningLevel >= level) count++;
            if (Game1.player.ForagingLevel >= level) count++;
            if (Game1.player.FishingLevel >= level) count++;
            if (Game1.player.CombatLevel >= level) count++;
            return count;
        }

        /// <summary>
        /// Generates a list of suggestions or daily goals based on the player's current context
        /// and incomplete achievements.
        /// </summary>
        public List<string> GetDailySuggestions()
        {
            var suggestions = new List<string>();

            if (!Context.IsWorldReady || Game1.player == null)
                return suggestions;

            var incomplete = this.AllAchievements.Values.Where(a => !a.IsUnlocked).ToList();

            // Money
            var moneyAch = incomplete
                .Where(a => a.Type == AchievementType.Money)
                .OrderBy(a => a.MaxValue)
                .FirstOrDefault(a => a.CurrentValue < a.MaxValue);
            if (moneyAch != null)
            {
                int needed = moneyAch.MaxValue - moneyAch.CurrentValue;
                if (needed > 0)
                    suggestions.Add($"💰 Gana {needed:N0}g más para '{moneyAch.Name}'.");
            }

            // Friendship
            var friendAch = incomplete
                .Where(a => a.Type == AchievementType.Friendship)
                .OrderBy(a => a.MaxValue)
                .FirstOrDefault(a => a.CurrentValue < a.MaxValue);
            if (friendAch != null)
            {
                int need = friendAch.MaxValue - friendAch.CurrentValue;
                suggestions.Add($"❤️ Necesitas {need} amigo(s) más con corazones para '{friendAch.Name}'.");
            }

            // Skills
            var skillAch = incomplete.FirstOrDefault(a => a.Type == AchievementType.Skills);
            if (skillAch != null)
            {
                suggestions.Add($"⭐ Sube habilidades al nivel 10 para '{skillAch.Name}'.");
            }

            // Fish
            var fishAch = incomplete.FirstOrDefault(a => a.Type == AchievementType.Fish);
            if (fishAch != null)
            {
                string season = Game1.currentSeason switch
                {
                    "spring" => "primavera",
                    "summer" => "verano",
                    "fall" => "otoño",
                    "winter" => "invierno",
                    _ => Game1.currentSeason
                };
                suggestions.Add($"🎣 Aprovecha el {season} para pescar nuevas especies.");
            }

            // Cooking
            var cookAch = incomplete.FirstOrDefault(a => a.Type == AchievementType.Cooking);
            if (cookAch != null)
            {
                suggestions.Add($"🍳 Intenta cocinar nuevas recetas para '{cookAch.Name}'.");
            }

            if (suggestions.Count == 0)
            {
                suggestions.Add("🎉 ¡No hay sugerencias urgentes! ¡Sigue disfrutando del valle!");
            }

            return suggestions;
        }
    }
}
