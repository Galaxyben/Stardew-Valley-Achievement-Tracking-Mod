using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using StardewValley.Menus;
using MiPrimerMod.Framework;

namespace MiPrimerMod.UI
{
    /// <summary>
    /// Achievement Tracker menu with 5 tabs and word-wrapped text.
    /// </summary>
    public class TrackerMenu : IClickableMenu
    {
        // ───── Tab IDs ─────
        private const int TabGuide = 0;
        private const int TabDaily = 1;
        private const int TabFish = 2;
        private const int TabFriendship = 3;
        private const int TabAchievements = 4;
        private const int TabCount = 5;

        // ───── Data ─────
        private readonly AchievementTracker Tracker;
        private readonly SuggestionEngine Engine;

        // Wrapped lines (already split to fit the content width)
        private List<string> GuideLines;
        private List<string> DailySuggestions;
        private List<string> FishLines;
        private List<string> FriendshipLines;
        private List<AchievementData> SortedAchievements;

        // ───── UI State ─────
        private int ActiveTab = TabGuide;
        private int ScrollOffset = 0;
        private int MaxVisibleRows = 11;

        // ───── Layout ─────
        private int ContentWidth;

        // ───── Tab buttons ─────
        private readonly ClickableComponent[] tabButtons;
        private static readonly string[] TabNames = { "Guia", "Hoy", "Pesca", "Amistad", "Logros" };

        // ───── Scroll buttons ─────
        private ClickableTextureComponent scrollUpButton = null!;
        private ClickableTextureComponent scrollDownButton = null!;

        public TrackerMenu(AchievementTracker tracker, SuggestionEngine engine)
            : base(
                  Game1.uiViewport.Width / 2 - 500,
                  Game1.uiViewport.Height / 2 - 340,
                  1000,
                  680,
                  showUpperRightCloseButton: true)
        {
            this.Tracker = tracker;
            this.Engine = engine;
            this.ContentWidth = this.width - 180;

            // Refresh all data and word-wrap to fit
            this.Tracker.UpdateProgress();
            this.GuideLines = WrapLines(this.Engine.GetDailyGuide(), this.ContentWidth);
            this.DailySuggestions = WrapLines(this.Engine.GenerateDailySuggestions(this.Tracker), this.ContentWidth);
            this.FishLines = WrapLines(this.Engine.GetDetailedFishList(this.Tracker), this.ContentWidth);
            this.FriendshipLines = WrapLines(this.Engine.GetFriendshipAdvice(this.Tracker), this.ContentWidth);
            this.SortedAchievements = this.Tracker.GetSortedAchievements();

            // Create tab buttons (5 tabs)
            int tabY = this.yPositionOnScreen + 12;
            int tabWidth = 120;
            int tabHeight = 44;
            int gap = 6;
            int totalTabWidth = TabCount * tabWidth + (TabCount - 1) * gap;
            int startX = this.xPositionOnScreen + (this.width - totalTabWidth) / 2;

            this.tabButtons = new ClickableComponent[TabCount];
            for (int i = 0; i < TabCount; i++)
            {
                this.tabButtons[i] = new ClickableComponent(
                    new Rectangle(startX + i * (tabWidth + gap), tabY, tabWidth, tabHeight),
                    TabNames[i]);
            }

            // Scroll arrows
            this.scrollUpButton = new ClickableTextureComponent(
                new Rectangle(this.xPositionOnScreen + this.width - 80, this.yPositionOnScreen + 90, 44, 48),
                Game1.mouseCursors,
                new Rectangle(421, 459, 11, 12),
                4f);

            this.scrollDownButton = new ClickableTextureComponent(
                new Rectangle(this.xPositionOnScreen + this.width - 80, this.yPositionOnScreen + this.height - 80, 44, 48),
                Game1.mouseCursors,
                new Rectangle(421, 472, 11, 12),
                4f);
        }

        // ───────────────────────────────────────────
        //  WORD WRAP — splits long lines to fit width
        // ───────────────────────────────────────────
        private static List<string> WrapLines(List<string> source, int maxWidth)
        {
            var result = new List<string>();
            int pixelWidth = maxWidth - 20; // padding

            foreach (var line in source)
            {
                if (string.IsNullOrEmpty(line))
                {
                    result.Add(line);
                    continue;
                }

                // If it fits, add directly
                if (Game1.smallFont.MeasureString(line).X <= pixelWidth)
                {
                    result.Add(line);
                    continue;
                }

                // Word-wrap: split by spaces and build lines
                string[] words = line.Split(' ');
                string current = "";
                bool isFirstLine = true;

                foreach (var word in words)
                {
                    string test = string.IsNullOrEmpty(current) ? word : current + " " + word;

                    if (Game1.smallFont.MeasureString(test).X > pixelWidth)
                    {
                        // Current line is full, emit it
                        if (!string.IsNullOrEmpty(current))
                        {
                            result.Add(current);
                            // Continuation lines get indent
                            current = isFirstLine ? "    " + word : "    " + word;
                            isFirstLine = false;
                        }
                        else
                        {
                            // Single word is too long — add it anyway
                            result.Add(word);
                            current = "";
                        }
                    }
                    else
                    {
                        current = test;
                    }
                }

                if (!string.IsNullOrEmpty(current))
                    result.Add(current);
            }

            return result;
        }

        // ───────────────────────────────────────────
        //  INPUT
        // ───────────────────────────────────────────
        public override void receiveLeftClick(int x, int y, bool playSound = true)
        {
            base.receiveLeftClick(x, y, playSound);

            for (int i = 0; i < this.tabButtons.Length; i++)
            {
                if (this.tabButtons[i].containsPoint(x, y))
                {
                    this.ActiveTab = i;
                    this.ScrollOffset = 0;
                    Game1.playSound("smallSelect");
                    return;
                }
            }

            int maxRows = GetCurrentMaxRows();
            if (this.scrollUpButton.containsPoint(x, y) && this.ScrollOffset > 0)
            {
                this.ScrollOffset--;
                Game1.playSound("shwip");
            }
            else if (this.scrollDownButton.containsPoint(x, y) && this.ScrollOffset < maxRows - this.MaxVisibleRows)
            {
                this.ScrollOffset++;
                Game1.playSound("shwip");
            }
        }

        public override void receiveScrollWheelAction(int direction)
        {
            base.receiveScrollWheelAction(direction);
            int maxRows = GetCurrentMaxRows();
            if (direction > 0 && this.ScrollOffset > 0)
                this.ScrollOffset--;
            else if (direction < 0 && this.ScrollOffset < maxRows - this.MaxVisibleRows)
                this.ScrollOffset++;
        }

        private int GetCurrentMaxRows()
        {
            return this.ActiveTab switch
            {
                TabGuide => this.GuideLines.Count,
                TabDaily => this.DailySuggestions.Count,
                TabFish => this.FishLines.Count,
                TabFriendship => this.FriendshipLines.Count,
                TabAchievements => this.SortedAchievements.Count,
                _ => 0
            };
        }

        // ───────────────────────────────────────────
        //  DRAW
        // ───────────────────────────────────────────
        public override void draw(SpriteBatch b)
        {
            // Dim background
            b.Draw(Game1.fadeToBlackRect, Game1.graphics.GraphicsDevice.Viewport.Bounds, Color.Black * 0.75f);

            // Menu box
            Game1.drawDialogueBox(this.xPositionOnScreen, this.yPositionOnScreen, this.width, this.height, speaker: false, drawOnlyBox: true);

            // Tabs
            for (int i = 0; i < this.tabButtons.Length; i++)
                DrawTab(b, this.tabButtons[i], this.ActiveTab == i);

            // Content area
            int contentX = this.xPositionOnScreen + 80;
            int contentY = this.yPositionOnScreen + 110;

            switch (this.ActiveTab)
            {
                case TabGuide:
                    DrawTextList(b, this.GuideLines, contentX, contentY, this.ContentWidth);
                    break;
                case TabDaily:
                    DrawTextList(b, this.DailySuggestions, contentX, contentY, this.ContentWidth);
                    break;
                case TabFish:
                    DrawTextList(b, this.FishLines, contentX, contentY, this.ContentWidth);
                    break;
                case TabFriendship:
                    DrawTextList(b, this.FriendshipLines, contentX, contentY, this.ContentWidth);
                    break;
                case TabAchievements:
                    DrawAchievementsTab(b, contentX, contentY, this.ContentWidth);
                    break;
            }

            // Scroll arrows
            int maxRows = GetCurrentMaxRows();
            if (this.ScrollOffset > 0)
                this.scrollUpButton.draw(b);
            if (this.ScrollOffset < maxRows - this.MaxVisibleRows)
                this.scrollDownButton.draw(b);

            base.draw(b);
            this.drawMouse(b);
        }

        // ───────────────────────────────────────────
        //  Generic Text List — no truncation, already wrapped
        // ───────────────────────────────────────────
        private void DrawTextList(SpriteBatch b, List<string> lines, int x, int y, int width)
        {
            int rowHeight = 38;
            int end = Math.Min(this.ScrollOffset + this.MaxVisibleRows, lines.Count);

            for (int i = this.ScrollOffset; i < end; i++)
            {
                int rowY = y + (i - this.ScrollOffset) * rowHeight;

                // Alternate row shading
                if ((i - this.ScrollOffset) % 2 == 0)
                    b.Draw(Game1.fadeToBlackRect, new Rectangle(x, rowY, width, rowHeight - 2), Color.Black * 0.1f);

                string text = lines[i];

                // Color-code by emoji/content
                Color textColor = Game1.textColor;
                if (text.Contains("🎂") || text.Contains("🎪") || text.Contains("FESTIVAL") || text.Contains("CUMPLEAÑOS"))
                    textColor = Color.Gold;
                else if (text.Contains("🌧️"))
                    textColor = new Color(100, 149, 237);
                else if (text.Contains("☀️"))
                    textColor = Color.Orange;
                else if (text.Contains("🐟") || text.Contains("🎣"))
                    textColor = new Color(0, 191, 255);
                else if (text.Contains("──") || text.StartsWith("═"))
                    textColor = Color.LightGray;
                else if (text.Contains("📋") || text.Contains("📖"))
                    textColor = new Color(255, 215, 0);
                else if (text.Contains("✅") || text.Contains("🏆"))
                    textColor = Color.LimeGreen;
                else if (text.Contains("⚠️") || text.Contains("ÚLTIMO") || text.Contains("¡NO") || text.Contains("CRÍTICO"))
                    textColor = Color.OrangeRed;
                else if (text.Contains("⭐"))
                    textColor = new Color(255, 223, 100);

                Utility.drawTextWithShadow(b, text, Game1.smallFont,
                    new Vector2(x + 8, rowY + 6), textColor);
            }
        }

        // ───────────────────────────────────────────
        //  Achievements Tab (with progress bars)
        // ───────────────────────────────────────────
        private void DrawAchievementsTab(SpriteBatch b, int x, int y, int width)
        {
            int rowHeight = 58;
            int end = Math.Min(this.ScrollOffset + this.MaxVisibleRows, this.SortedAchievements.Count);

            for (int i = this.ScrollOffset; i < end; i++)
            {
                var ach = this.SortedAchievements[i];
                int rowY = y + (i - this.ScrollOffset) * rowHeight;

                Color rowBg = ach.IsUnlocked ? Color.DarkGreen * 0.25f : Color.Black * 0.12f;
                b.Draw(Game1.fadeToBlackRect, new Rectangle(x, rowY, width, rowHeight - 4), rowBg);

                string label = ach.IsUnlocked ? $"✅ {ach.Name}" : ach.Name;
                Utility.drawTextWithShadow(b, label, Game1.smallFont,
                    new Vector2(x + 12, rowY + 4), ach.IsUnlocked ? Color.LimeGreen : Game1.textColor);

                if (!ach.IsUnlocked && ach.MaxValue > 0)
                {
                    int barX = x + 12;
                    int barY = rowY + 30;
                    int barWidth = width - 150;
                    int barHeight = 14;

                    b.Draw(Game1.fadeToBlackRect, new Rectangle(barX, barY, barWidth, barHeight), Color.DarkGray * 0.5f);

                    float pct = ach.GetProgressPercentage();
                    int fillWidth = (int)(barWidth * pct);
                    Color barColor = pct > 0.75f ? Color.LimeGreen : (pct > 0.4f ? Color.Gold : Color.OrangeRed);
                    if (fillWidth > 0)
                        b.Draw(Game1.fadeToBlackRect, new Rectangle(barX, barY, fillWidth, barHeight), barColor * 0.85f);

                    string pctText = $"{ach.CurrentValue}/{ach.MaxValue} ({(int)(pct * 100)}%)";
                    Utility.drawTextWithShadow(b, pctText, Game1.smallFont,
                        new Vector2(barX + barWidth + 8, barY - 4), Game1.textColor);
                }
                else if (ach.IsUnlocked)
                {
                    Utility.drawTextWithShadow(b, "Completado", Game1.smallFont,
                        new Vector2(x + 12, rowY + 30), Color.LimeGreen * 0.7f);
                }
            }
        }

        // ───────────────────────────────────────────
        //  Tab Renderer
        // ───────────────────────────────────────────
        private void DrawTab(SpriteBatch b, ClickableComponent tab, bool isActive)
        {
            Color bgColor = isActive ? Color.SandyBrown * 0.65f : Color.Black * 0.25f;
            b.Draw(Game1.fadeToBlackRect, tab.bounds, bgColor);

            Color textColor = isActive ? Color.White : Color.Gray;
            Vector2 textSize = Game1.smallFont.MeasureString(tab.name);
            Utility.drawTextWithShadow(b, tab.name, Game1.smallFont,
                new Vector2(
                    tab.bounds.X + tab.bounds.Width / 2 - textSize.X / 2,
                    tab.bounds.Y + tab.bounds.Height / 2 - textSize.Y / 2),
                textColor);
        }
    }
}
