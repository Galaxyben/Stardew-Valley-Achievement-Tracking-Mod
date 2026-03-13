using System.Collections.Generic;
using System.Linq;

namespace MiPrimerMod.Framework.Data
{
    /// <summary>A single day's guide entry.</summary>
    public class GuideEntry
    {
        public string Season { get; set; } = string.Empty;
        public int Day { get; set; }
        public int Year { get; set; } = 1;
        public List<string> Tasks { get; set; } = new();
    }

    /// <summary>
    /// Day-by-day walkthrough optimized for achievement speed-running.
    /// Source: User's custom guide (Guia_Diaria_Stardew_Valley.md).
    /// </summary>
    public static class DailyGuideData
    {
        public static readonly List<GuideEntry> Year1Guide = new()
        {
            // ═══════════════════════════════════════════════
            //  SPRING — Year 1
            // ═══════════════════════════════════════════════

            new() { Season = "spring", Day = 1, Tasks = {
                "📺 TV: Revisa clima y fortuna del día.",
                "🌱 Limpia 30 plots (usa guadaña en césped). Planta las 15 Parsnip Seeds.",
                "🪓 Corta 5 árboles (NO quites los tocones). Con 50 Wood → construye un Chest.",
                "🌿 Forrajea: Dandelion, Leek, Wild Horseradish, Daffodil en el bosque sur. Spring Onions al sureste.",
                "🛒 Ve a Pierre's ANTES de las 5PM: compra 2-3 Cauliflower, Potato y Bean Starters. El resto en Parsnips.",
                "💬 Habla con todos los NPCs. Visita el Saloon de noche (Shane, Pam, Clint, Emily, Gus).",
                "🌱 Al volver: planta TODO lo comprado + Mixed Seeds."
            }},

            new() { Season = "spring", Day = 2, Tasks = {
                "📺 TV + riega cultivos.",
                "🪓 Limpia más terreno y corta árboles (sin gastar toda la energía).",
                "🏖️ Visita la playa ANTES de las 5PM → Willy te da la Bamboo Pole GRATIS.",
                "🎣 Pesca un poco en playa, río, lago. Guarda al menos 1 de cada pez.",
                "📦 Guarda: Green Algae, Seaweed, Coral, Clams, 1 Sea Urchin, 1 Mussel/Oyster/Cockle.",
                "💬 Completa la quest de Introductions. Dale un Daffodil a Haley si quieres bailar en el Flower Dance.",
                "🛒 Si sobra dinero → más Parsnip Seeds en Pierre's."
            }},

            new() { Season = "spring", Day = 3, Tasks = {
                "⚠️ Pierre's cerrado (miércoles). Usa JojaMart solo si es urgente.",
                "🌱 Riega cultivos. Corta árboles, forrajea y/o pesca.",
                "🎯 Meta: Foraging Level 4 antes del Día 15 (necesitas ~109 árboles o equivalente).",
                "🏖️ Junta 300 Wood para reparar el puente de la playa (acceso a Coral/Sea Urchins)."
            }},

            new() { Season = "spring", Day = 4, Tasks = {
                "🌱 Riega. Rutina: forrajear, pescar o minar.",
                "🎯 Sigue trabajando hacia Foraging Level 4.",
                "💬 Intenta befriend a Marnie (le gusta Quartz) y Caroline (le gusta Daffodil)."
            }},

            new() { Season = "spring", Day = 5, Tasks = {
                "⭐ DÍA IMPORTANTE: Cosecha Parsnips. Guarda los Gold quality (necesitas 5 total),",
                "  1 Silver (regalo para Lewis), 2 Normal (Community Center + quests). Vende el resto → compra más seeds.",
                "🏛️ Community Center: si es día soleado, entra al pueblo desde Bus Stop entre 8AM-1PM.",
                "  Lewis te muestra el Center. Entra y haz clic en el pergamino dorado en Crafts Room.",
                "⛏️ MINAS se abren hoy. Lleva solo pickaxe. Meta: 20 Copper Ore + 25 Stone, Floor 5.",
                "  Mata todos los insectos que veas (125 = upgrade de arma). Sal ANTES de 1AM.",
                "🛒 Traveling Cart en el bosque (pero probablemente no tienes dinero aún)."
            }},

            new() { Season = "spring", Day = 6, Tasks = {
                "⭐ CORREO: Clint da blueprints del Furnace (20 Copper + 25 Stone).",
                "  Rasmodius te invita a su torre. Marlon da quest de 10 slimes.",
                "🌱 Cosecha Parsnips del Día 2. Craftea Scarecrow (50 Wood, 20 Fiber, 1 Coal).",
                "🧙 Visita la Torre del Wizard al sur del bosque → traduce el pergamino → poción.",
                "🏛️ Entrega Spring Foraging Bundle (Daffodil, Leek, Dandelion, Wild Horseradish)",
                "  + 1 Parsnip para Spring Crops Bundle.",
                "⛏️ Mata al menos 10 Green Slimes. Sigue minando copper."
            }},

            new() { Season = "spring", Day = 7, Tasks = {
                "🎂 CUMPLEAÑOS DE LEWIS: Dale un Parsnip Silver quality (o normal).",
                "🌱 Cosecha Potatoes del Día 1 → 1 para Community Center, keep 1, vende el resto.",
                "🛒 Traveling Cart disponible (domingos en el bosque).",
                "🎯 Sigue comprando y plantando Parsnip Seeds!"
            }},

            new() { Season = "spring", Day = 8, Tasks = {
                "🌱 Riega. Forrajea, pesca y/o mina.",
                "🛒 Sigue comprando Parsnips y plantando.",
                "🏖️ Repara el puente de la playa si tienes 300 Wood."
            }},

            new() { Season = "spring", Day = 9, Tasks = {
                "⚠️ ÚLTIMO DÍA para plantar Parsnips (necesitas espacio + dinero para Strawberry Seeds el Día 13).",
                "🌱 Compra MÁXIMO 4 Parsnip Seeds más (5 = 100g = 1 Strawberry Seed perdida).",
                "🎯 Ahorra todo el dinero posible para el Egg Festival."
            }},

            new() { Season = "spring", Day = 10, Tasks = {
                "🎂 CUMPLEAÑOS DE VINCENT: Dale un Daffodil.",
                "🐾 Si es soleado y ganas >1,000g: recibes tu mascota (perro/gato). Elige el nombre bien (no se puede cambiar).",
                "🌱 Riega. Forrajea, pesca, mina."
            }},

            new() { Season = "spring", Day = 11, Tasks = {
                "🌱 Cosecha primeros Green Beans → 1 para Community Center, keep 1, vende el resto.",
                "📬 Carta de Robin: busca su hacha perdida (Cindersap Forest, cerca de Spring Onions, este).",
                "🎯 Sigue juntando dinero para Strawberry Seeds."
            }},

            new() { Season = "spring", Day = 12, Tasks = {
                "🛒 Traveling Cart en el bosque. Guarda al menos 2,000g para Strawberries.",
                "🐾 Si no recibiste mascota el Día 10, debería aparecer hoy (si no llueve).",
                "🎯 Meta: Foraging Level 4 antes del Día 15."
            }},

            new() { Season = "spring", Day = 13, Tasks = {
                "⭐⭐ EGG FESTIVAL — DÍA CRÍTICO.",
                "🌱 ANTES del festival: cosecha TODO. Vende Parsnips/Potatoes. Guarda 1 Cauliflower.",
                "  Hoe y riega 1 plot por cada 100g que tengas.",
                "🎪 Festival: entra al pueblo entre 9AM-2PM. Compra TODAS las Strawberry Seeds que puedas pagar.",
                "  ¡Habla con TODOS antes de hablar con Lewis!",
                "🌱 DESPUÉS: Planta TODAS las Strawberry Seeds. Completa Spring Crops Bundle con Cauliflower",
                "  → recibes 20 Speed-Gro. Úsalos en 20 plantas de Strawberry (crucial = +2,400g extra).",
                "⚠️ Riega esas 20 plantas TODOS LOS DÍAS hasta el Día 28."
            }},

            new() { Season = "spring", Day = 14, Tasks = {
                "🎂 CUMPLEAÑOS DE HALEY: Dale Daffodil de mejor calidad. Si llega a 2 corazones → cutscene con Emily.",
                "🌱 Riega TODO. Compra más Parsnip Seeds para subir Farming level.",
                "🔨 Si tienes Farming/Foraging 3 → Tappers (2 Copper Bars + 40 Wood c/u) y Speed-Gro."
            }},

            new() { Season = "spring", Day = 15, Tasks = {
                "🫐 SALMONBERRY SEASON (Días 15-18).",
                "💡 TRUCO: Cierra el juego al menú y recarga el día. Los arbustos multiplicarán berries x2-3.",
                "🫐 Con Foraging 4 → 2 berries por arbusto. Salmonberries = buen regalo para:",
                "  Demetrius, Jodi, Kent, Leah, Linus, Pam, Robin, Sandy, Shane.",
                "🌱 Riega. Dedica el resto del día a recolectar por TODOS los mapas."
            }},

            new() { Season = "spring", Day = 16, Tasks = {
                "🫐 Sigue recolectando Salmonberries por todos los mapas.",
                "⚠️ Último día para plantar Cauliflower sin fertilizante.",
                "🏛️ Si tienes 5 donaciones al museo → 9 Cauliflower Seeds gratis.",
                "🌱 Riega todo."
            }},

            new() { Season = "spring", Day = 17, Tasks = {
                "🫐 Salmonberry season continúa. Riega.",
                "📺 Revisa Living Off the Land en la TV.",
                "🎣 Si tienes Fishing 3 → Crab Pot Bundle (Clam+Oyster+Mussel+Cockle+Crab) = 3 Crab Pots gratis."
            }},

            new() { Season = "spring", Day = 18, Tasks = {
                "🎂 CUMPLEAÑOS DE PAM: Dale una Salmonberry.",
                "🫐 Último día de Salmonberry season.",
                "🌱 Riega. Cosecha lo que esté listo."
            }},

            new() { Season = "spring", Day = 19, Tasks = {
                "🌱 Riega. Planta Tulips (Evelyn los ama), Kale, y Blue Jazz si quieres.",
                "💬 Socializa. Da regalos a aldeanos con pocos corazones.",
                "🔨 Prepara artesanías si tienes los niveles."
            }},

            new() { Season = "spring", Day = 20, Tasks = {
                "🎂 CUMPLEAÑOS DE SHANE: Dale una Salmonberry.",
                "🌱 Cosecha Speed-Gro Strawberries → vende directo a Pierre → compra Large Backpack (2,000g).",
                "⚠️ Último día para Blue Jazz y Spring Seeds."
            }},

            new() { Season = "spring", Day = 21, Tasks = {
                "🌱 Riega. Visita Traveling Cart → compra Rare Seed (1,000g) y/o Red Cabbage si hay.",
                "⚠️ Último día para plantar Blue Jazz y Spring Seeds."
            }},

            new() { Season = "spring", Day = 22, Tasks = {
                "⚠️ Último día para plantar Potatoes, Kale, Tulips.",
                "🌱 Riega. Sigue juntando dinero.",
                "🏛️ Revisa qué Bundles puedes completar."
            }},

            new() { Season = "spring", Day = 23, Tasks = {
                "⚠️ Último día para dar regalos a candidatos antes del Flower Dance.",
                "⚠️ Último día para comprar Parsnip Seeds.",
                "🌱 Riega todo. Prepara para el festival de mañana."
            }},

            new() { Season = "spring", Day = 24, Tasks = {
                "🎪 FLOWER DANCE — Festival en Cindersap Forest.",
                "🌱 ANTES: riega y cosecha TODO (no puedes salir una vez dentro).",
                "💃 Si tienes 4+ corazones con Haley/Shane → puedes bailar (+250 pts = 1 corazón).",
                "🌱 Speed-Gro Strawberries: segunda cosecha hoy (envíalas, Pierre no compra en festivales)."
            }},

            new() { Season = "spring", Day = 25, Tasks = {
                "🌱 Strawberries normales: segunda y última cosecha. Ya no necesitan riego.",
                "🎯 Empieza a planificar para Summer."
            }},

            new() { Season = "spring", Day = 26, Tasks = {
                "🎂 CUMPLEAÑOS DE PIERRE: Daffodil o Parsnip Gold quality.",
                "🏗️ Considera Copper Axe upgrade (para Large Stumps → Hardwood → Stable → Horse).",
                "🏗️ Considera construir Silo (100 Stone, 5 Copper Bars, 10 Clay, 100g). Necesitas 3-4 para Winter."
            }},

            new() { Season = "spring", Day = 27, Tasks = {
                "🎂 CUMPLEAÑOS DE EMILY: Topaz u otra gema.",
                "🔨 MEJOR DÍA para mejorar Watering Can a Copper (2,000g + 5 Copper Bars).",
                "  No necesitas regar mañana (Día 28 es último día).",
                "🎣 Si llueve → pesca Eel (ocean después de 4PM, solo lluvia). También Catfish y Shad en ríos."
            }},

            new() { Season = "spring", Day = 28, Tasks = {
                "⚠️ ÚLTIMO DÍA DE SPRING. Cosecha TOTAL. NO riegues nada.",
                "⛏️ Pasa el día en las minas, intenta llegar a Floor 40 para Iron.",
                "🍄 ~Día 26+: Si ganaste suficiente, Demetrius ofrece la cueva.",
                "  Elige MUSHROOMS (mejor a largo plazo) o Fruit Bats (mejor corto plazo).",
                "💰 Necesitas 15,000-20,000g para Summer Día 1."
            }},

            // ═══════════════════════════════════════════════
            //  SUMMER — Year 1
            // ═══════════════════════════════════════════════

            new() { Season = "summer", Day = 1, Tasks = {
                "⭐⭐ DÍA CRÍTICO — SHOPPING LIST (~5,700g base):",
                "🌱 Limpia cultivos muertos. Despeja nuevas rocas/troncos.",
                "🛒 Compra en Pierre's: 6 Wheat, 6 Radish, 6 Hot Pepper, 6 Tomato,",
                "  6 Hops, 9+ Corn (con Basic Fertilizer), 20+ Melon (con Basic Fertilizer),",
                "  resto en Blueberries (máx ~75 que puedas regar). 1 Sunflower en JojaMart.",
                "🧪 Fertilizer: Speed-Gro en Wheat, Radish, Hops (~18). Basic en Corn y Melon.",
                "⚠️ IMPORTANTE: Pon fertilizante ANTES de plantar Hops (no se puede después con Starters)."
            }},

            new() { Season = "summer", Day = 2, Tasks = {
                "🌱 Riega. Forrajea: Grape, Spice Berry, Sweet Pea (nuevos de verano).",
                "🎣 Si llueve: pesca Red Snapper (océano) y Sturgeon (lago montaña).",
                "  Guarda Sturgeons para Fish Pond → Caviar."
            }},

            new() { Season = "summer", Day = 3, Tasks = {
                "🌋 EARTHQUAKE nocturna → se abre la ruta al Railroad y al Spa.",
                "♨️ ¡El Spa restaura energía/salud GRATIS! (~1 hora in-game parado en el agua).",
                "📬 Lewis pide sus 'shorts' → están en la habitación de Marnie (necesitas 2 corazones con ella).",
                "🌱 Riega todo."
            }},

            new() { Season = "summer", Day = 4, Tasks = {
                "🎂 CUMPLEAÑOS DE JAS: Sweet Pea o Daffodil gold quality.",
                "🌱 Primera cosecha de Wheat (Speed-Gro) → compra 6+ más seeds.",
                "🌱 Riega todo."
            }},

            new() { Season = "summer", Day = 5, Tasks = {
                "🌱 Riega. Forrajea por todos los mapas.",
                "🎯 Sigue subiendo skills y socializando."
            }},

            new() { Season = "summer", Day = 6, Tasks = {
                "🌱 Primera cosecha de Radishes (Speed-Gro) y Hot Peppers.",
                "🏛️ 1 Hot Pepper para Community Center. Guarda para George (quest), Shane y Lewis (lo aman).",
                "🌱 Riega todo."
            }},

            new() { Season = "summer", Day = 7, Tasks = {
                "🌱 Riega. Forrajea, pesca o mina.",
                "🛒 Traveling Cart (domingos). Revisa items raros."
            }},

            new() { Season = "summer", Day = 8, Tasks = {
                "🎂 CUMPLEAÑOS DE GUS: Daffodil o Sweet Pea.",
                "🔨 Considera mejorar herramientas si tienes recursos.",
                "🌱 Riega."
            }},

            new() { Season = "summer", Day = 9, Tasks = {
                "🌱 Riega. Rutina: cosecha, minas, pesca.",
                "🎯 Ahorra para el Coop (4,000g + 300 Wood + 100 Stone)."
            }},

            new() { Season = "summer", Day = 10, Tasks = {
                "🎂 CUMPLEAÑOS DE MARU: Strawberry Gold quality o Quartz.",
                "🌱 Primera cosecha de Hops → envía 15, guarda el resto para Pale Ale (necesita Keg = Farming 8).",
                "🌱 Riega."
            }},

            new() { Season = "summer", Day = 11, Tasks = {
                "🎪 LUAU — Festival en la playa (entra entre 10AM-2PM).",
                "🍲 Trae Cauliflower Gold quality (o Sturgeon Gold) para la sopa del gobernador.",
                "  El resultado afecta amistad con TODOS los aldeanos.",
                "🌱 Riega antes de ir."
            }},

            new() { Season = "summer", Day = 12, Tasks = {
                "🌱 Primera cosecha de Tomatoes y Speed-Gro Blueberries = GRAN ingreso.",
                "📦 Envía 15 Blueberries.",
                "🏗️ Con 4,000g + 300 Wood + 100 Stone → encarga Coop a Robin.",
                "🏖️ Extras en la playa por 3 días. Traveling Cart (viernes)."
            }},

            new() { Season = "summer", Day = 13, Tasks = {
                "🎂 CUMPLEAÑOS DE ALEX: Sweet Pea o Daffodil.",
                "🌱 Primera cosecha de Melons → compra más seeds. Guarda Gold quality (necesitas 5).",
                "⚡ Lightning Rods: crafteá 2+ (1 Iron Bar + 1 Refined Quartz + 5 Bat Wings).",
                "  Protege cultivos + produce Battery Packs. Primera Battery → túnel Bus Stop."
            }},

            new() { Season = "summer", Day = 14, Tasks = {
                "🌱 Riega. Sigue rutina.",
                "🛒 Traveling Cart.",
                "🐝 Bee Houses si tienes Iron + Maple Syrup (40 Wood, 8 Coal, 1 Iron Bar, 1 Maple Syrup)."
            }},

            new() { Season = "summer", Day = 15, Tasks = {
                "🏗️ Si encargaste Coop el Día 12 → lista hoy.",
                "⚠️ Último día para plantar Starfruit sin Speed-Gro (seed gratis con 15 donaciones al museo).",
                "🌱 Riega todo."
            }},

            new() { Season = "summer", Day = 16, Tasks = {
                "⚠️ Último día para plantar Melons sin Speed-Gro.",
                "🌱 Riega. Sigue rutina."
            }},

            new() { Season = "summer", Day = 17, Tasks = {
                "🎂 CUMPLEAÑOS DE SAM: Tigerseye, Pizza (300g en Saloon), o Sweet Pea.",
                "🐔 Compra 4 Chickens (mínimo 1 blanca + 1 brown).",
                "🌱 Riega."
            }},

            new() { Season = "summer", Day = 18, Tasks = {
                "🌱 Riega. Pesca o mina.",
                "🎯 Sigue ahorrando y mejorando herramientas."
            }},

            new() { Season = "summer", Day = 19, Tasks = {
                "🎂 CUMPLEAÑOS DE DEMETRIUS: Strawberry o Ice Cream (stand de Alex).",
                "🛒 Traveling Cart.",
                "🌱 Riega."
            }},

            new() { Season = "summer", Day = 20, Tasks = {
                "🌱 Segunda cosecha de Speed-Gro Blueberries = GRAN ingreso.",
                "🌳 Compra saplings de Apple y Pomegranate (necesarios para Junimos).",
                "🔨 Mejora Pickaxe y Axe a Iron.",
                "⚠️ Último día para Summer Spangles.",
                "📦 Demetrius Quest → Melon."
            }},

            new() { Season = "summer", Day = 21, Tasks = {
                "⚠️ Último día para plantar Poppies.",
                "🌻 Planta 1 Sunflower cerca de Bee Houses (florece Fall 1).",
                "🛒 Traveling Cart.",
                "🌱 Riega."
            }},

            new() { Season = "summer", Day = 22, Tasks = {
                "🎂 CUMPLEAÑOS DEL DWARF: Necesitas hablar Dwarvish (4 scrolls al museo).",
                "🌱 Cosecha Blueberries (no Speed-Gro). Último día para Radishes sin Speed-Gro.",
                "🍵 Caroline's Tea Leaves."
            }},

            new() { Season = "summer", Day = 23, Tasks = {
                "🌱 Riega. Rutina: cosecha, minas, pesca.",
                "🎯 Ahorra para Fall (15,000-20,000g)."
            }},

            new() { Season = "summer", Day = 24, Tasks = {
                "🎂 CUMPLEAÑOS DE WILLY: Catfish, Sturgeon, o Mead (Honey en Keg).",
                "🌱 Cosecha Speed-Gro Blueberries.",
                "🌱 Riega todo."
            }},

            new() { Season = "summer", Day = 25, Tasks = {
                "🌾 Planta último Speed-Gro Wheat.",
                "🌱 Cosecha Melons (no Speed-Gro).",
                "🌱 Riega."
            }},

            new() { Season = "summer", Day = 26, Tasks = {
                "🌱 Última cosecha Blueberries (no Speed-Gro) → deja de regar esas.",
                "  Última cosecha Speed-Gro Radishes → planta Wheat en su lugar.",
                "🛒 Traveling Cart."
            }},

            new() { Season = "summer", Day = 27, Tasks = {
                "🌱 Riega (penúltimo día).",
                "🎯 Meta: Iron Axe antes de Fall → abrir Secret Woods (Hardwood renovable).",
                "🛒 Traveling Cart → última oportunidad para Rare Seed (1,000g)."
            }},

            new() { Season = "summer", Day = 28, Tasks = {
                "⚠️ ÚLTIMO DÍA. Cosecha final de Speed-Gro Blueberries.",
                "🌾 RIEGA Corn, Wheat y Sunflowers (¡sobreviven el cambio de estación!).",
                "🌺 Recoge Poppies ANTES de dormir.",
                "🎪 Dance of the Moonlight Jellies por la noche en la playa.",
                "🛒 Traveling Cart → última chance para Rare Seed.",
                "💰 Meta: tener 15,000-20,000g para Fall."
            }},

            // ═══════════════════════════════════════════════
            //  FALL — Year 1
            // ═══════════════════════════════════════════════

            new() { Season = "fall", Day = 1, Tasks = {
                "⭐⭐ DÍA CRÍTICO — SHOPPING LIST:",
                "🌾 Los Wheat, Corn y Sunflowers del verano siguen vivos → sigue regando.",
                "🛒 Compra: 6 Bok Choy (Speed-Gro), 6 Amaranth (Speed-Gro),",
                "  6 Eggplant (Quality Fertilizer, NO Speed-Gro),",
                "  6 Grape Starter (Speed-Gro, fertiliza ANTES de plantar),",
                "  20 Pumpkin (Quality Fertilizer), 9 Yam (Speed-Gro),",
                "  50-100+ Cranberry (Quality Fertilizer, NO Speed-Gro).",
                "🌹 Fairy Rose cerca de Bee Houses (Speed-Gro).",
                "🌱 Planta todos los Rare Seeds del Traveling Cart (Quality Fertilizer)."
            }},

            new() { Season = "fall", Day = 2, Tasks = {
                "🎂 CUMPLEAÑOS DE PENNY: Dale un Melon Gold quality.",
                "📋 Special Orders Board: se construye hoy, revisa en el pueblo.",
                "🎣 Pesca: Salmon y Tiger Trout en río. Walleye si llueve (río, 12PM+).",
                "  Eel en océano con lluvia de noche. Midnight Carp en lago montaña (10PM-2AM)."
            }},

            new() { Season = "fall", Day = 3, Tasks = {
                "⚠️ Pierre's cerrado (miércoles).",
                "📬 Carta de Marnie → pide Amaranth.",
                "🍂 Forrajea: Common Mushrooms, Wild Plums, Hazelnuts, Blackberries."
            }},

            new() { Season = "fall", Day = 4, Tasks = {
                "🌱 Primera cosecha Wheat y Bok Choy (Speed-Gro). Compra seeds de reemplazo.",
                "🌱 Riega."
            }},

            new() { Season = "fall", Day = 5, Tasks = {
                "🎂 CUMPLEAÑOS DE ELLIOTT: Lobster o Sweet Pea Gold quality.",
                "🛒 Traveling Cart.",
                "🌱 Riega."
            }},

            new() { Season = "fall", Day = 6, Tasks = {
                "🌱 Primera cosecha Eggplant → 1 para Community Center.",
                "🌱 Riega."
            }},

            new() { Season = "fall", Day = 7, Tasks = {
                "🌱 Primera cosecha Amaranth + segundo Wheat/Bok Choy. Dale Amaranth a Marnie.",
                "🛒 Traveling Cart (domingos)."
            }},

            new() { Season = "fall", Day = 8, Tasks = {
                "🫐 BLACKBERRY SEASON (Días 8-11). Mismo truco que Salmonberries (recarga el día).",
                "  Con Foraging 8+ → 3 berries por arbusto.",
                "🌱 Primera cosecha de CRANBERRIES = ingreso masivo.",
                "🏗️ Mejora Barn o Coop (necesitas Ducks y Goats para Greenhouse).",
                "📋 Revisa Special Orders."
            }},

            new() { Season = "fall", Day = 9, Tasks = {
                "🫐 Sigue con Blackberries.",
                "🌱 Primera cosecha Yam (Speed-Gro) → 1 para Community Center.",
                "📬 Carta sobre Stardew Valley Fair."
            }},

            new() { Season = "fall", Day = 10, Tasks = {
                "🫐 Blackberries.",
                "🌱 Primera cosecha Pumpkin (Deluxe Speed-Gro) → 1 para Junimos = completa Fall Crops Bundle.",
                "  Guarda 1 Gold para Fair + 1 para quest + 1 Gold para Abigail."
            }},

            new() { Season = "fall", Day = 11, Tasks = {
                "🎂 CUMPLEAÑOS DE JODI: Chocolate Cake (de Bundle de 2,500g Junimo, obtienes 3).",
                "🫐 Último día de Blackberry season.",
                "🌱 Riega."
            }},

            new() { Season = "fall", Day = 12, Tasks = {
                "🌱 Riega. Rutina normal.",
                "🛒 Traveling Cart."
            }},

            new() { Season = "fall", Day = 13, Tasks = {
                "🎂 CUMPLEAÑOS DE ABIGAIL: Amethyst, Chocolate Cake, o Pumpkin Gold quality.",
                "🌱 Segunda cosecha de Cranberries.",
                "🌱 Riega."
            }},

            new() { Season = "fall", Day = 14, Tasks = {
                "⚠️ Último día para pedir Deluxe Barn a Robin y tener Pigs maduros antes de Winter.",
                "  (Compra Pigs el Día 17).",
                "🛒 Traveling Cart.",
                "🌱 Riega."
            }},

            new() { Season = "fall", Day = 15, Tasks = {
                "🎂 Cumpleaños de Sandy (solo si desbloqueaste el desierto).",
                "🎯 Prepara 9 ítems para el Grange Display del Fair mañana (6+ categorías diferentes):",
                "  Animal: Large Milk/Egg mejor calidad | Artisan: Mayonnaise/Cheese Gold",
                "  Cooking: Life Elixir | Fish: mejor calidad | Foraging: Chanterelle/Purple Mushroom",
                "  Fruits: Melon Gold | Minerals: Diamond | Vegetables: Pumpkin/Cauliflower Gold"
            }},

            new() { Season = "fall", Day = 16, Tasks = {
                "🎪 STARDEW VALLEY FAIR — DÍA CRÍTICO.",
                "🌱 Atiende granja primero → ve al fair con ítems preparados.",
                "📊 Monta el Grange Display → Lewis juzga.",
                "🎰 Spinning Wheel: SIEMPRE apuesta al VERDE (75% probabilidad de ganar).",
                "🎯 Meta: 2,000 Star Tokens para comprar STARDROP (+energía máxima permanente).",
                "⚠️ RECOGE tus ítems del Grange antes de irte (haz clic en ellos)."
            }},

            new() { Season = "fall", Day = 17, Tasks = {
                "🐷 ÚLTIMO DÍA para comprar Pigs y conseguir Truffles antes de Winter.",
                "🌱 Riega. Cosecha lo que haya."
            }},

            new() { Season = "fall", Day = 18, Tasks = {
                "🎂 CUMPLEAÑOS DE MARNIE: Diamond.",
                "🌱 Cosecha Cranberries + Yams.",
                "🌱 Riega."
            }},

            new() { Season = "fall", Day = 19, Tasks = {
                "🌱 Gran día de cosecha: Wheat, Bok Choy, Amaranth, Deluxe Speed-Gro Pumpkins.",
                "🛒 Traveling Cart."
            }},

            new() { Season = "fall", Day = 20, Tasks = {
                "🌱 Riega. Cosecha y vende.",
                "💬 Socializa."
            }},

            new() { Season = "fall", Day = 21, Tasks = {
                "🎂 CUMPLEAÑOS DE ROBIN: Goat Cheese.",
                "🛒 Traveling Cart."
            }},

            new() { Season = "fall", Day = 22, Tasks = {
                "📋 Special Orders. Caroline's Tea Leaves.",
                "🌱 Riega."
            }},

            new() { Season = "fall", Day = 23, Tasks = {
                "🌱 Cosecha Cranberries.",
                "🌱 Riega."
            }},

            new() { Season = "fall", Day = 24, Tasks = {
                "🎂 CUMPLEAÑOS DE GEORGE: Leek Gold quality.",
                "🌱 Riega. Cosecha lo que haya."
            }},

            new() { Season = "fall", Day = 25, Tasks = {
                "🌱 Última cosecha Amaranth. Planta último Wheat + Bok Choy.",
                "  Planta 6 Wheat extra donde estaba el Amaranth."
            }},

            new() { Season = "fall", Day = 26, Tasks = {
                "🌱 Última cosecha Yam.",
                "🛒 Traveling Cart. Considera Mill si tienes 4 Cloth."
            }},

            new() { Season = "fall", Day = 27, Tasks = {
                "🎪 SPIRIT'S EVE — Festival con laberinto (premio secreto).",
                "  Pueblo cerrado hasta 10PM.",
                "🐷 Si compraste Pigs el Día 17 → maduran hoy → al menos 1 Truffle."
            }},

            new() { Season = "fall", Day = 28, Tasks = {
                "⚠️ ÚLTIMO DÍA DE FALL. Cosecha TODO absolutamente.",
                "🏡 Si Greenhouse desbloqueado → planta 100+ Cranberries + Fruit Trees.",
                "🔥 Coloca Heaters en Coop y Barn.",
                "🌾 HAY: necesitas 3-4 Silos llenos (672-896 hay) para Winter con todos los animales.",
                "🌧️ Si tienes Truffles → posible Rain Totem en Winter para Mermaid's Pendant (matrimonio Year 1)."
            }},

            // ═══════════════════════════════════════════════
            //  WINTER — Year 1
            // ═══════════════════════════════════════════════

            new() { Season = "winter", Day = 1, Tasks = {
                "❄️ NO HAY CULTIVOS al aire libre. Solo Greenhouse y animales.",
                "🚌 Si tienes 42,500g → completa Vault Bundles → repara el Bus al desierto.",
                "  Visita desierto con flor para Sandy. Pesca Sandfish (Specialty Fish Bundle).",
                "👤 Al entrar a Bus Stop → sigue la figura sombría al pueblo y rastrea sus huellas.",
                "📋 Revisa Special Orders (lunes)."
            }},

            new() { Season = "winter", Day = 2, Tasks = {
                "🎣 Quest de Willy: pesca un Squid (océano, SOLO de noche en Winter).",
                "  Guarda extras para Fish Pond → Squid Ink."
            }},

            new() { Season = "winter", Day = 3, Tasks = {
                "🎂 CUMPLEAÑOS DE LINUS: Cactus Fruit, Coconut, o Yam."
            }},

            new() { Season = "winter", Day = 4, Tasks = {
                "🏜️ Visita a Sandy → compra Deluxe Speed-Gro a 80g (Pierre cobra 200g).",
                "  Stockea para Spring.",
                "⛏️ Minas o pesca el resto del día."
            }},

            new() { Season = "winter", Day = 5, Tasks = {
                "🛒 Traveling Cart.",
                "⛏️ Minas todo el día. Sin cultivos = tiempo de minería intensa."
            }},

            new() { Season = "winter", Day = 6, Tasks = {
                "⛏️ Minas. Socializa por la tarde.",
                "📺 Revisa Queen of Sauce en la TV (domingo)."
            }},

            new() { Season = "winter", Day = 7, Tasks = {
                "🎂 CUMPLEAÑOS DE CAROLINE: Green Tea o Summer Spangle Gold quality.",
                "🛒 Traveling Cart."
            }},

            new() { Season = "winter", Day = 8, Tasks = {
                "🎪 FESTIVAL OF ICE — Bosque cerrado hasta 10AM. Concurso de pesca (atrapa 5 peces).",
                "⛏️ Después del festival: minas."
            }},

            new() { Season = "winter", Day = 9, Tasks = {
                "⛏️ Minas todo el día. Fabrica Quality Sprinklers (Iron Bar + Gold Bar + Refined Quartz) para Spring.",
                "🎯 Cuantos más sprinklers, menos tiempo regando en Spring."
            }},

            new() { Season = "winter", Day = 10, Tasks = {
                "🎂 CUMPLEAÑOS DE SEBASTIAN: Frozen Tear (minas), Sashimi, o Void Egg Gold quality.",
                "  Pierre's cerrado (miércoles).",
                "⛏️ Minas."
            }},

            new() { Season = "winter", Day = 11, Tasks = {
                "⛏️ Minas. Craftea sprinklers y bombas.",
                "🎯 Organiza tu granja para Year 2."
            }},

            new() { Season = "winter", Day = 12, Tasks = {
                "🧙 Quest del Wizard → Void Essence (Shadow Brutes/Shaman, Floor 80+).",
                "🛒 Traveling Cart."
            }},

            new() { Season = "winter", Day = 13, Tasks = {
                "⛏️ Minas. Socializa.",
                "🎯 Prepara para Night Market (empieza en 2 días)."
            }},

            new() { Season = "winter", Day = 14, Tasks = {
                "🎂 CUMPLEAÑOS DE HARVEY: Coffee, Pickles, Wine, o Truffle Oil.",
                "🛒 Traveling Cart.",
                "🎯 Night Market empieza MAÑANA."
            }},

            new() { Season = "winter", Day = 15, Tasks = {
                "🎪 NIGHT MARKET (Días 15-17, playa 5PM-2AM).",
                "🚢 ¡PESCA EN EL SUBMARINO! Peces exclusivos: Blobfish, Spook Fish, Midnight Squid.",
                "🧜 Mermaid Boat: secreto en Secret Note #15.",
                "🛒 Tiendas del pueblo abiertas durante el día.",
                "⛏️ Minas durante el día, Night Market por la noche."
            }},

            new() { Season = "winter", Day = 16, Tasks = {
                "🎪 NIGHT MARKET Día 2. Sigue pescando en el submarino.",
                "🧙 Cone Hat es más barato en Magic Shop Boat.",
                "⛏️ Minas durante el día."
            }},

            new() { Season = "winter", Day = 17, Tasks = {
                "🎂 CUMPLEAÑOS DEL WIZARD: Purple Mushroom, Solar/Void Essence, Super Cucumber.",
                "🎪 NIGHT MARKET ÚLTIMO DÍA. ¡Última oportunidad para peces del submarino!",
                "  Asegúrate de tener Blobfish, Spook Fish, Midnight Squid.",
                "⚠️ Crab Pots en la playa desaparecen durante festival (regresan Día 18)."
            }},

            new() { Season = "winter", Day = 18, Tasks = {
                "📬 Carta de Lewis → tu amigo secreto para Feast of the Winter Star.",
                "  Busca su regalo amado de mejor calidad.",
                "🏜️ Visita a Sandy para más Deluxe Speed-Gro."
            }},

            new() { Season = "winter", Day = 19, Tasks = {
                "🛒 Traveling Cart.",
                "⛏️ Minas."
            }},

            new() { Season = "winter", Day = 20, Tasks = {
                "🎂 CUMPLEAÑOS DE EVELYN: Beet, Chocolate Cake, Diamond, Fairy Rose, o Tulip."
            }},

            new() { Season = "winter", Day = 21, Tasks = {
                "🛒 Traveling Cart. Robin's Quest → 10 Hardwood.",
                "🌿 Si tienes receta de Fiber Seeds → planta para proteger plots arados."
            }},

            new() { Season = "winter", Day = 22, Tasks = {
                "🍵 Tea Leaves de Caroline's room (excepto Mié/Jue esta semana).",
                "⛏️ Minas."
            }},

            new() { Season = "winter", Day = 23, Tasks = {
                "🎂 CUMPLEAÑOS DE LEAH: Goat Cheese Gold quality."
            }},

            new() { Season = "winter", Day = 24, Tasks = {
                "⛏️ Minas. Últimos días del Año 1.",
                "🎯 Mañana es Feast of the Winter Star."
            }},

            new() { Season = "winter", Day = 25, Tasks = {
                "🎪 FEAST OF THE WINTER STAR — Trae regalo para amigo secreto.",
                "🏜️ ¡ÚLTIMA OPORTUNIDAD! Sandy vende Deluxe Speed-Gro barato. Pam conduce el bus.",
                "  Compra Rhubarb seeds para Spring.",
                "🛒 PLANIFICACIÓN SPRING YEAR 2 (compra seeds/Speed-Gro):",
                "  18 Rhubarb (54 seeds + Deluxe Speed-Gro), 6 Parsnip (54), 6 Garlic (54, nuevo Year 2),",
                "  6 Potato (36), 6 Kale (36), 20 Cauliflower (60), 10 Green Beans.",
                "  78 plots → 78 Deluxe Speed-Gro (Strawberries del Día 13 aparte)."
            }},

            new() { Season = "winter", Day = 26, Tasks = {
                "🎂 CUMPLEAÑOS DE CLINT: Topaz.",
                "🛒 Traveling Cart. Última chance para mejorar Watering Can antes de Spring.",
                "🛒 KROBUS (Sewers): Vende 1 Iridium Sprinkler por 10,000g cada viernes."
            }},

            new() { Season = "winter", Day = 27, Tasks = {
                "⛏️ Buen día para minas (intenta llegar a Floor 120). Lleva comida/pociones.",
                "🌱 Coloca sprinklers para Spring."
            }},

            new() { Season = "winter", Day = 28, Tasks = {
                "⚠️ ÚLTIMO DÍA DEL AÑO 1.",
                "🛒 Traveling Cart.",
                "⚠️ NO prepares fields (se desordenan en Spring 1 de todos modos, excepto si plantaste Fiber Seeds).",
                "💤 Ahorra energía. Duerme antes de medianoche.",
                "🏆 ¡Revisa tus logros y celebra lo que lograste en tu primer año!"
            }},
        };

        /// <summary>Returns the guide entry for today.</summary>
        public static GuideEntry? GetTodaysGuide(string season, int day, int year)
        {
            if (year > 1) return null;
            return Year1Guide.FirstOrDefault(g => g.Season == season.ToLower() && g.Day == day);
        }

        /// <summary>Returns tomorrow's guide for preview.</summary>
        public static GuideEntry? GetTomorrowsGuide(string season, int day, int year)
        {
            if (year > 1) return null;
            int nextDay = day + 1;
            string nextSeason = season;
            if (nextDay > 28)
            {
                nextDay = 1;
                nextSeason = season switch
                {
                    "spring" => "summer",
                    "summer" => "fall",
                    "fall" => "winter",
                    "winter" => "spring",
                    _ => season
                };
                if (nextSeason == "spring" && season == "winter") return null;
            }
            return Year1Guide.FirstOrDefault(g => g.Season == nextSeason.ToLower() && g.Day == nextDay);
        }
    }
}
