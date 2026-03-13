# 🏆 Stardew Valley Achievement Tracker Mod

**Your personal in-game coach for 100% completion.** This SMAPI mod tracks your Steam/Stardew Valley achievement progress in real-time and gives you dynamic, contextual suggestions to complete them as efficiently as possible.

> Built with ❤️ for achievement hunters who want to optimize their playthrough.

---

## ✨ Features

### 📋 Day-by-Day Year 1 Guide (Guía Tab)
A complete **112-day walkthrough** for Year 1, showing **only today's tasks** — not walls of text. Includes:
- Exact shopping lists with crop quantities and fertilizer types
- Bundle delivery timings for the Community Center
- Birthday gifts with specific quality recommendations
- Festival strategies (Egg Festival Strawberry rush, Fair Spinning Wheel green bet, etc.)
- Deadlines ("Last day to plant Cauliflower without fertilizer")
- Pro tips (Salmonberry reload trick, Night Market submarine fish)
- Tomorrow's preview so you can prepare

<img width="1920" height="1080" alt="image" src="https://github.com/user-attachments/assets/cc75df68-c59e-453b-8b1e-1be54c87a87f" />


### 🎯 Smart Daily Suggestions (Hoy Tab)
Every suggestion is **tied to an incomplete achievement** — no generic tips:
- 💰 Money achievements → seasonal earning strategies
- 🎣 Fish achievements → weather-specific catches with location/time/difficulty
- ❤️ Friendship achievements → today's birthday gifts, upcoming birthdays, easy seasonal gifts
- ⭐ Skill achievements → which skills are below level 10
- 🍳 Cooking / 🔨 Crafting / 🏛️ Donation achievements → specific tips
- Completed categories automatically hide

<img width="1920" height="1080" alt="image" src="https://github.com/user-attachments/assets/2173df2e-da71-45b3-a962-e0ef7dc5433e" />


### 🐟 Fish Guide (Pesca Tab)
Full list of catchable fish **right now**, filtered by current season and weather:
- Grouped by location
- Time range and difficulty for each fish
- Weather-exclusive fish highlighted (🌧️ rain only / ☀️ sun only)
- Tied to your fish achievement progress

### ❤️ Friendship Guide (Amistad Tab)
- Target achievement with progress percentage
- Today's birthday with loved gifts and point values
- Upcoming birthdays (next 3) with gift recommendations
- Complete point system reference
- Universal loved gifts with exceptions
- Easy seasonal gifts you can find right now

### 🏅 Achievement Progress (Logros Tab)
- All achievements sorted by completion
- Color-coded progress bars (🟢 >75% / 🟡 >40% / 🔴 <40%)
- Exact progress values (e.g., "23,500/25,000 (94%)")
- ✅ Completed achievements marked

<img width="1920" height="1080" alt="image" src="https://github.com/user-attachments/assets/b1f336f8-dc04-447e-b694-7037b284fb23" />

---

## 🔧 Installation

### Requirements
- [Stardew Valley](https://store.steampowered.com/app/413150/Stardew_Valley/) (v1.6+)
- [SMAPI](https://smapi.io/) (v3.0.0+)

### Steps
1. Install SMAPI if you haven't already
2. Download the latest release from [Releases](../../releases)
3. Unzip into your `Stardew Valley/Mods/` folder:
   ```
   Stardew Valley/
   └── Mods/
       └── AchievementTrackingMod/
           ├── manifest.json
           └── MiPrimerMod.dll
   ```
4. Launch the game through SMAPI
5. Press **F8** to open the tracker (configurable)
6. Press **N** to pause/resume the passing of time, while allowing you to move freely (configurable)

---

## ⚙️ Configuration

After first launch, a `config.json` file is created in the mod folder:

```json
{
  "ToggleMenuKey": "F8",
  "ToggleTimeKey": "N"
}
```

Change `F8` or `N` to any [SMAPI key](https://stardewvalleywiki.com/Modding:Player_Guide/Key_Bindings) you prefer.

---

## 🏗️ Building from Source

### Prerequisites
- [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- Stardew Valley + SMAPI installed

### Steps

1. Clone the repository:
   ```bash
   git clone https://github.com/YOUR_USERNAME/StardewAchievementTracker.git
   cd StardewAchievementTracker
   ```

2. Create/edit `Directory.Build.props` with your game path:
   ```xml
   <Project>
     <PropertyGroup>
       <GamePath>C:\Program Files (x86)\Steam\steamapps\common\Stardew Valley</GamePath>
     </PropertyGroup>
   </Project>
   ```

3. Build:
   ```bash
   dotnet build
   ```

4. The mod is automatically deployed to your `Mods/` folder by SMAPI's build config.

---

## 📁 Project Structure

```
AchievementTrackingMod/
├── ModEntry.cs                      # Entry point: wires events, hotkey, console output
├── ModConfig.cs                     # Configuration (toggle key)
├── manifest.json                    # SMAPI mod metadata
├── Framework/
│   ├── AchievementData.cs           # Achievement data model + progress calculation
│   ├── AchievementTracker.cs        # Loads & tracks all achievements from game data
│   ├── SuggestionEngine.cs          # Combines all data into contextual suggestions
│   └── Data/
│       ├── DailyGuideData.cs        # 112-day Year 1 walkthrough (day-by-day)
│       ├── FishDatabase.cs          # 50+ fish with season/location/weather/time
│       ├── CalendarData.cs          # 33 birthdays + 13 festivals with tips
│       └── FriendshipTips.cs        # Universal gifts, point values, seasonal tips
└── UI/
    └── TrackerMenu.cs               # In-game UI with 5 scrollable tabs
```

---

## 🎮 How It Works

1. **On game load**: The mod reads all achievements from `Data/Achievements` and calculates your current progress
2. **Each morning**: `SuggestionEngine` generates tips based on:
   - Which achievements are **still incomplete**
   - Current **season, day, and weather**
   - **Birthday/festival** calendar data
   - Available **fish** for today's conditions
3. **On F8 press**: Opens the `TrackerMenu` with 5 tabs
4. **Daily console output**: Key suggestions are also printed to the SMAPI console

---

## 📊 Data Sources

| Data | Source | Entries |
|------|--------|---------|
| Fish | [Stardew Valley Wiki](https://stardewvalleywiki.com/Fish) | 50+ fish |
| Birthdays | [Wiki Calendar](https://stardewvalleywiki.com/Calendar) | 33 NPCs |
| Festivals | [Wiki Calendar](https://stardewvalleywiki.com/Calendar) | 13 events |
| Friendship | [Wiki Friendship](https://stardewvalleywiki.com/Friendship) | Points, gifts, exceptions |
| Year 1 Guide | Community optimization guides | 112 days |

---

## 🤝 Contributing

Contributions are welcome! Here are some ideas:

- [ ] Add Year 2+ daily guide data
- [ ] Track individual fish caught (cross-reference with fish achievement)
- [ ] Add Ginger Island content
- [ ] Localization (English translation)
- [ ] NPC schedule integration (where to find villagers today)
- [ ] Integration with other mods (Stardew Valley Expanded, etc.)

### To contribute:
1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

---

## 📜 License

This project is open source and available under the [MIT License](LICENSE).

---

## 🙏 Credits

- **[ConcernedApe](https://twitter.com/ConcernedApe)** — Stardew Valley creator
- **[SMAPI](https://smapi.io/)** by Pathoschild — The modding framework
- **[Stardew Valley Wiki](https://stardewvalleywiki.com/)** — Fish, calendar, and friendship data
- **Community guides** — Year 1 optimization strategies

---

> *This mod does not modify any game files. It only reads game data to display information.*
