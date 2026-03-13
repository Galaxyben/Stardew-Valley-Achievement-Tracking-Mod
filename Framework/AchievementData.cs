using System.Collections.Generic;

namespace MiPrimerMod.Framework
{
    /// <summary>Represents the type of requirement for an achievement.</summary>
    public enum AchievementType
    {
        Money,
        Fish,
        Shipping,
        Donation,
        Friendship,
        Skills,
        Cooking,
        Crafting,
        Mining,
        Misc
    }

    /// <summary>Represents a single achievement and its tracking metadata.</summary>
    public class AchievementData
    {
        /// <summary>The internal ID of the achievement (matches Stardew's Data/Achievements).</summary>
        public int Id { get; set; }

        /// <summary>The name of the achievement.</summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>The description of what needs to be done.</summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>The broad category this achievement falls under.</summary>
        public AchievementType Type { get; set; }

        /// <summary>Indicates if the player has already unlocked this achievement.</summary>
        public bool IsUnlocked { get; set; }

        /// <summary>The maximum value needed to complete the achievement (e.g., 15000 for Greenhorn).</summary>
        public int MaxValue { get; set; }

        /// <summary>The current progress the player has made.</summary>
        public int CurrentValue { get; set; }

        /// <summary>Optional context IDs. For example, specific item IDs needed for 'Catch every fish'.</summary>
        public List<int> TargetIds { get; set; } = new List<int>();

        /// <summary>
        /// Returns the progress as a percentage from 0.0 to 1.0.
        /// </summary>
        public float GetProgressPercentage()
        {
            if (IsUnlocked) return 1.0f;
            if (MaxValue <= 0) return 0f;
            
            float progress = (float)CurrentValue / MaxValue;
            return progress > 1.0f ? 1.0f : progress;
        }
    }
}
