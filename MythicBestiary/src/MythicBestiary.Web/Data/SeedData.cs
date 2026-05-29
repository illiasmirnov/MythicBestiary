
namespace MythicBestiary.Data;

public static class SeedData
{
    public static async Task InitializeAsync(MongoDbContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        long existingCreaturesCount = await context.Creatures.CountDocumentsAsync(_ => true);

        if (existingCreaturesCount > 0)
        {
            return;
        }

        await context.Creatures.InsertManyAsync(CreateCreatures());
    }

    private static List<Creature> CreateCreatures()
    {
        DateTime createdAt = DateTime.UtcNow;

        return new List<Creature>
        {
            new()
            {
                Id = "creature_001",
                Name = "Горинич",
                Slug = "horynych",
                Description = "П’ятиголовий дракон, кожна голова якого володіє окремою стихією та атакує почергово.",
                Category = "Дракон",
                Mythology = "Слов’янська",
                Origin = "Розрив між божественним і людським світом",
                ThreatLevel = "Катастрофічний",
                Abilities = new()
                {
                    "Стихійне дихання",
                    "Контроль температури та тиску",
                    "Почерговий випуск руйнівної енергії",
                    "Комбінування сумісних стихій",
                    "Божественна регенерація"
                },
                Weaknesses = new() { "Стародавні реліквії", "Розділення голів" },
                Images = new()
                {
                    new() { Url = "/images/creatures/horynych.jpg", Alt = "Горинич" }
                },
                HistoricalNotes = new()
                {
                    new()
                    {
                        Title = "Перші згадки",
                        Content = "Істота живе за межами світу, вивченого людьми, у розриві між божественним і людським простором.",
                        CreatedAt = createdAt
                    }
                },
                RelatedCreatures = new(),
                CreatedAt = createdAt,
                UpdatedAt = createdAt
            },

            new()
            {
                Id = "creature_002",
                Name = "Вогненний дракон",
                Slug = "fire-dragon",
                Description = "Дракон із темно-червоною лускою та плавно вигнутими рогами. Повітря навколо нього постійно розпечене.",
                Category = "Дракон",
                Mythology = "Пустельні легенди",
                Origin = "Савани, пустелі та оази",
                ThreatLevel = "Високий",
                Abilities = new() { "Вогняне дихання", "Контроль полум’я", "Теплові хвилі" },
                Weaknesses = new() { "Крижана магія", "Вода" },
                Images = new()
                {
                    new() { Url = "/images/creatures/fire-dragon.jpg", Alt = "Вогненний дракон" }
                },
                HistoricalNotes = new(),
                RelatedCreatures = new(),
                CreatedAt = createdAt,
                UpdatedAt = createdAt
            },

            new()
            {
                Id = "creature_003",
                Name = "Водяний дракон",
                Slug = "water-dragon",
                Description = "Дракон із темно-синьою та бірюзовою лускою. Його тіло постійно вкрите вологою, а поруч відчуваються холод і перепади тиску.",
                Category = "Дракон",
                Mythology = "Океанічна",
                Origin = "Глибокі моря, затоплені печери та давні підводні руїни",
                ThreatLevel = "Високий",
                Abilities = new()
                {
                    "Водяне дихання",
                    "Керування потоками води",
                    "Створення хвиль високого тиску",
                    "Конденсація пари",
                    "Крижане охолодження"
                },
                Weaknesses = new() { "Вогонь", "Вулканічний жар" },
                Images = new()
                {
                    new() { Url = "/images/creatures/water-dragon.jpg", Alt = "Водяний дракон" }
                },
                HistoricalNotes = new(),
                RelatedCreatures = new(),
                CreatedAt = createdAt,
                UpdatedAt = createdAt
            },

            new()
            {
                Id = "creature_004",
                Name = "Земляний дракон",
                Slug = "earth-dragon",
                Description = "Його тіло нагадує цілісний кам’яний масив. Рухи повільні, але руйнівні.",
                Category = "Дракон",
                Mythology = "Гірська",
                Origin = "Підземні печери та гірські розломи",
                ThreatLevel = "Критичний",
                Abilities = new() { "Контроль землі", "Сейсмічні удари", "Кам’яна броня" },
                Weaknesses = new() { "Блискавка", "Руйнування ядра" },
                Images = new()
                {
                    new() { Url = "/images/creatures/earth-dragon.jpg", Alt = "Земляний дракон" }
                },
                HistoricalNotes = new(),
                RelatedCreatures = new(),
                CreatedAt = createdAt,
                UpdatedAt = createdAt
            },

            new()
            {
                Id = "creature_005",
                Name = "Штормовий дракон",
                Slug = "storm-dragon",
                Description = "Істота, що з’являється лише під час грозових буревіїв.",
                Category = "Дракон",
                Mythology = "Небесна",
                Origin = "Грозові фронти",
                ThreatLevel = "Високий",
                Abilities = new() { "Блискавка", "Електричний імпульс", "Політ у бурі" },
                Weaknesses = new() { "Заземлення", "Магічна тиша" },
                Images = new()
                {
                    new() { Url = "/images/creatures/storm-dragon.jpg", Alt = "Штормовий дракон" }
                },
                HistoricalNotes = new(),
                RelatedCreatures = new(),
                CreatedAt = createdAt,
                UpdatedAt = createdAt
            },

            new()
            {
                Id = "creature_006",
                Name = "Небесний змій",
                Slug = "sky-serpent",
                Description = "Міфічна істота, що мешкає у високих повітряних потоках. Існують сумніви щодо її реальності.",
                Category = "Змій",
                Mythology = "Небесна",
                Origin = "Високі повітряні потоки",
                ThreatLevel = "Середній",
                Abilities = new() { "Політ", "Контроль вітру" },
                Weaknesses = new(),
                Images = new(),
                HistoricalNotes = new(),
                RelatedCreatures = new(),
                CreatedAt = createdAt,
                UpdatedAt = createdAt
            },

            new()
            {
                Id = "creature_007",
                Name = "Куно-теш",
                Slug = "kuno-tesh",
                Description = "Людиноподібний карлик із плоским обличчям і довгими вухами. Вважає себе нащадком блискавок і дітей вітру.",
                Category = "Гуманоїд",
                Mythology = "Гірська",
                Origin = "Гірські ущелини та сухі скелі",
                ThreatLevel = "Високий",
                Abilities = new()
                {
                    "Контроль повітря",
                    "Блискавичний удар",
                    "Напад із тилу",
                    "Позначення території шипами"
                },
                Weaknesses = new() { "Стабільні бар’єри" },
                Images = new(),
                HistoricalNotes = new()
                {
                    new()
                    {
                        Title = "Відомості про знахідки",
                        Content = "Істоту описували народи гірських ущелин і мисливці сухих скель. Серед трофеїв згадуються клапоть шаманської тканини, зуб летючого щура та маска предка.",
                        CreatedAt = createdAt
                    }
                },
                RelatedCreatures = new(),
                CreatedAt = createdAt,
                UpdatedAt = createdAt
            },

            new()
            {
                Id = "creature_008",
                Name = "Мирда-кал",
                Slug = "mirda-kal",
                Description = "Карлик із попелясто-білою шкірою, що поклоняється силі попелу та вулканічного вогню.",
                Category = "Гуманоїд",
                Mythology = "Вулканічна",
                Origin = "Випалені яри та скелясті котловини",
                ThreatLevel = "Високий",
                Abilities = new()
                {
                    "Контроль вогню",
                    "Ритуальні танці",
                    "Виклик спалахів із тріщин"
                },
                Weaknesses = new(),
                Images = new(),
                HistoricalNotes = new(),
                RelatedCreatures = new(),
                CreatedAt = createdAt,
                UpdatedAt = createdAt
            },

            new()
            {
                Id = "creature_009",
                Name = "Шіо-тан",
                Slug = "shio-tan",
                Description = "Шаман болотяних кіл, що тлумачить знаки на поверхні води.",
                Category = "Шаман",
                Mythology = "Болотна",
                Origin = "Болотисті низини та затоплені яри",
                ThreatLevel = "Середній",
                Abilities = new()
                {
                    "Керування водяною парою",
                    "Приховування у тумані",
                    "Шепіт перед атакою"
                },
                Weaknesses = new(),
                Images = new(),
                HistoricalNotes = new(),
                RelatedCreatures = new(),
                CreatedAt = createdAt,
                UpdatedAt = createdAt
            },

            new()
            {
                Id = "creature_010",
                Name = "Друнг-мек",
                Slug = "drung-mek",
                Description = "Хронікар племені грози.",
                Category = "Гуманоїд",
                Mythology = "Племінна",
                Origin = "Високі плато",
                ThreatLevel = "Середній",
                Abilities = new(),
                Weaknesses = new(),
                Images = new(),
                HistoricalNotes = new()
                {
                    new()
                    {
                        Title = "Походження відомостей",
                        Content = "Відомості про істоту походять від народу високих плато.",
                        CreatedAt = createdAt
                    }
                },
                RelatedCreatures = new(),
                CreatedAt = createdAt,
                UpdatedAt = createdAt
            },

            new()
            {
                Id = "creature_011",
                Name = "Енцу-хай",
                Slug = "enzu-hai",
                Description = "Ловець тіней, що вистежує жертв у густих лісах.",
                Category = "Хижак",
                Mythology = "Лісова",
                Origin = "Густі ліси та прибережні яри",
                ThreatLevel = "Середній",
                Abilities = new()
                {
                    "Стеження",
                    "Повітряні пастки",
                    "Раптовий напад"
                },
                Weaknesses = new(),
                Images = new(),
                HistoricalNotes = new()
                {
                    new()
                    {
                        Title = "Надійність джерел",
                        Content = "Істоту описували лісові племена, однак надійність цих свідчень залишається низькою.",
                        CreatedAt = createdAt
                    }
                },
                RelatedCreatures = new(),
                CreatedAt = createdAt,
                UpdatedAt = createdAt
            },

            new()
            {
                Id = "creature_012",
                Name = "Моргул-син",
                Slug = "morgul-sin",
                Description = "Людиноподібна істота середнього зросту з рогами гірського барана та попелястими візерунками на шкірі. Представники клану Вогняної Тіні відомі як ковалі духу.",
                Category = "Гуманоїд",
                Mythology = "Вулканічна",
                Origin = "Вулканічні нагір’я",
                ThreatLevel = "Катастрофічний",
                Abilities = new()
                {
                    "Контроль вогню",
                    "Ритуальний поєдинок",
                    "Кування духовної енергії",
                    "Підсилення зброї жаром"
                },
                Weaknesses = new(),
                Images = new(),
                HistoricalNotes = new()
                {
                    new()
                    {
                        Title = "Фольклор",
                        Content = "У переказах Моргул-синів називають творцями Пісні Заліза, що звучить у кістках воїнів. Перед боєм вони мовчать і викликають ворога на ритуальний двобій.",
                        CreatedAt = createdAt
                    }
                },
                RelatedCreatures = new(),
                CreatedAt = createdAt,
                UpdatedAt = createdAt
            }
        };
    }
}