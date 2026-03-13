using System;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using MiPrimerMod.Framework;

namespace MiPrimerMod
{
    /// <summary>El punto de entrada principal del mod para SMAPI.</summary>
    internal sealed class ModEntry : Mod
    {
        private AchievementTracker Tracker = null!;
        private SuggestionEngine Engine = null!;
        private ModConfig Config = null!;

        public override void Entry(IModHelper helper)
        {
            this.Config = this.Helper.ReadConfig<ModConfig>();
            this.Tracker = new AchievementTracker(this.Monitor, this.Helper);
            this.Engine = new SuggestionEngine(this.Monitor);

            helper.Events.GameLoop.SaveLoaded += this.OnSaveLoaded;
            helper.Events.GameLoop.DayStarted += this.OnDayStarted;
            helper.Events.Input.ButtonPressed += this.OnButtonPressed;
        }

        private void OnButtonPressed(object? sender, ButtonPressedEventArgs e)
        {
            if (!Context.IsWorldReady) return;

            if (e.Button == this.Config.ToggleMenuKey)
            {
                if (Game1.activeClickableMenu == null)
                {
                    this.Monitor.Log("Abriendo Achievement Tracker", LogLevel.Debug);
                    Game1.activeClickableMenu = new MiPrimerMod.UI.TrackerMenu(this.Tracker, this.Engine);
                }
                else if (Game1.activeClickableMenu is MiPrimerMod.UI.TrackerMenu)
                {
                    Game1.activeClickableMenu = null;
                }
            }
        }

        private void OnSaveLoaded(object? sender, SaveLoadedEventArgs e)
        {
            this.Tracker.LoadAchievements();
            this.Tracker.UpdateProgress();
            this.Monitor.Log($"Achievement Tracker: {this.Tracker.AllAchievements.Count} logros cargados.", LogLevel.Info);
        }

        private void OnDayStarted(object? sender, DayStartedEventArgs e)
        {
            this.Tracker.UpdateProgress();

            // Print a daily summary to the SMAPI console
            var suggestions = this.Engine.GenerateDailySuggestions(this.Tracker);
            this.Monitor.Log("═══ Metas del Día ═══", LogLevel.Info);
            foreach (var s in suggestions)
                this.Monitor.Log($"  {s}", LogLevel.Info);
        }
    }
}
