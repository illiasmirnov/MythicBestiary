using MongoDB.Driver;
using MythicBestiary.Models;

namespace MythicBestiary.Data;

public static class SeedData
{
    public static async Task InitializeAsync(MongoDbContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        var existingCreaturesCount = await context.Creatures
            .CountDocumentsAsync(_ => true);

        if (existingCreaturesCount > 0)
        {
            return;
        }

        var creatures = CreateCreatures();

        if (creatures.Count == 0)
        {
            return;
        }

        await context.Creatures.InsertManyAsync(creatures);
    }

    private static List<Creature> CreateCreatures()
    {
        var createdAt = DateTime.UtcNow;

        return new List<Creature>
        {
            new Creature
            {
                Id = "creature_001",
                Name = "Горинич",
                Slug = "horynych",
                Description = "П’ятиголовий дракон із різними стихіями, що атакують почергово.",
                Category = "Дракон",
                Mythology = "Слов’янська",
                Origin = "Межа між божественним і людським світом",
                ThreatLevel = "Катастрофічний",
                Abilities = new List<string>
                {
                    "Стихійне дихання",
                    "Контроль температури та тиску",
                    "Комбінування стихій",
                    "Божественна регенерація"
                },
                Weaknesses = new List<string>
                {
                    "Стародавні реліквії",
                    "Розділення голів"
                },
                Images = new List<ImageResource>
                {
                    new ImageResource
                    {
                        Url = "/images/creatures/horynych.jpg",
                        Alt = "Горинич"
                    }
                },
                HistoricalNotes = new List<HistoricalNote>
                {
                    new HistoricalNote
                    {
                        Title = "Перші згадки",
                        Content = "Згадки про Горинича знайдено у стародавніх рукописах північних земель.",
                        CreatedAt = createdAt
                    }
                },
                RelatedCreatures = new List<RelatedCreature>(),
                CreatedAt = createdAt,
                UpdatedAt = createdAt
            },

            new Creature
            {
                Id = "creature_002",
                Name = "Вогненний дракон",
                Slug = "fire-dragon",
                Description = "Дракон із темно-червоною лускою, що випромінює сильний жар.",
                Category = "Дракон",
                Mythology = "Пустельні легенди",
                Origin = "Савани та пустелі",
                ThreatLevel = "Високий",
                Abilities = new List<string>
                {
                    "Вогняне дихання",
                    "Контроль полум’я",
                    "Теплові хвилі"
                },
                Weaknesses = new List<string>
                {
                    "Крижана магія",
                    "Вода"
                },
                Images = new List<ImageResource>
                {
                    new ImageResource
                    {
                        Url = "/images/creatures/fire-dragon.jpg",
                        Alt = "Вогненний дракон"
                    }
                },
                HistoricalNotes = new List<HistoricalNote>(),
                RelatedCreatures = new List<RelatedCreature>(),
                CreatedAt = createdAt,
                UpdatedAt = createdAt
            },

            new Creature
            {
                Id = "creature_003",
                Name = "Водяний дракон",
                Slug = "water-dragon",
                Description = "Дракон із темно-синьою лускою, що керує водними потоками.",
                Category = "Дракон",
                Mythology = "Океанічна",
                Origin = "Глибокі моря та затоплені печери",
                ThreatLevel = "Високий",
                Abilities = new List<string>
                {
                    "Керування водою",
                    "Хвилі високого тиску",
                    "Крижане охолодження"
                },
                Weaknesses = new List<string>
                {
                    "Вогонь",
                    "Вулканічний жар"
                },
                Images = new List<ImageResource>
                {
                    new ImageResource
                    {
                        Url = "/images/creatures/water-dragon.jpg",
                        Alt = "Водяний дракон"
                    }
                },
                HistoricalNotes = new List<HistoricalNote>(),
                RelatedCreatures = new List<RelatedCreature>(),
                CreatedAt = createdAt,
                UpdatedAt = createdAt
            },

            new Creature
            {
                Id = "creature_004",
                Name = "Земляний дракон",
                Slug = "earth-dragon",
                Description = "Кам’яний дракон із надзвичайною фізичною міцністю.",
                Category = "Дракон",
                Mythology = "Гірська",
                Origin = "Підземні печери та розломи",
                ThreatLevel = "Критичний",
                Abilities = new List<string>
                {
                    "Контроль землі",
                    "Сейсмічні удари",
                    "Кам’яна броня"
                },
                Weaknesses = new List<string>
                {
                    "Блискавка",
                    "Руйнування ядра"
                },
                Images = new List<ImageResource>
                {
                    new ImageResource
                    {
                        Url = "/images/creatures/earth-dragon.jpg",
                        Alt = "Земляний дракон"
                    }
                },
                HistoricalNotes = new List<HistoricalNote>(),
                RelatedCreatures = new List<RelatedCreature>(),
                CreatedAt = createdAt,
                UpdatedAt = createdAt
            },

            new Creature
            {
                Id = "creature_005",
                Name = "Штормовий дракон",
                Slug = "storm-dragon",
                Description = "Істота, що з’являється лише під час грозових буревіїв.",
                Category = "Дракон",
                Mythology = "Небесна",
                Origin = "Грозові фронти",
                ThreatLevel = "Високий",
                Abilities = new List<string>
                {
                    "Блискавка",
                    "Електричні імпульси",
                    "Політ у бурі"
                },
                Weaknesses = new List<string>
                {
                    "Заземлення",
                    "Магічна тиша"
                },
                Images = new List<ImageResource>
                {
                    new ImageResource
                    {
                        Url = "/images/creatures/storm-dragon.jpg",
                        Alt = "Штормовий дракон"
                    }
                },
                HistoricalNotes = new List<HistoricalNote>(),
                RelatedCreatures = new List<RelatedCreature>(),
                CreatedAt = createdAt,
                UpdatedAt = createdAt
            },

            new Creature
            {
                Id = "creature_006",
                Name = "Небесний змій",
                Slug = "sky-serpent",
                Description = "Міфічна істота, що мешкає у високих повітряних потоках.",
                Category = "Змій",
                Mythology = "Небесна",
                Origin = "Високі повітряні шари",
                ThreatLevel = "Середній",
                Abilities = new List<string>
                {
                    "Польоти",
                    "Контроль вітру"
                },
                Weaknesses = new List<string>(),
                Images = new List<ImageResource>(),
                HistoricalNotes = new List<HistoricalNote>(),
                RelatedCreatures = new List<RelatedCreature>(),
                CreatedAt = createdAt,
                UpdatedAt = createdAt
            },

            new Creature
            {
                Id = "creature_007",
                Name = "Куно-теш",
                Slug = "kuno-tesh",
                Description = "Людиноподібна істота, пов’язана з блискавками та вітром.",
                Category = "Гуманоїд",
                Mythology = "Гірська",
                Origin = "Гірські ущелини",
                ThreatLevel = "Високий",
                Abilities = new List<string>
                {
                    "Контроль повітря",
                    "Блискавичний удар",
                    "Атаки з тіні"
                },
                Weaknesses = new List<string>
                {
                    "Стабільні бар’єри"
                },
                Images = new List<ImageResource>(),
                HistoricalNotes = new List<HistoricalNote>(),
                RelatedCreatures = new List<RelatedCreature>(),
                CreatedAt = createdAt,
                UpdatedAt = createdAt
            },

            new Creature
            {
                Id = "creature_008",
                Name = "Мирда-кал",
                Slug = "mirda-kal",
                Description = "Поклоняється силі попелу та вулканічного вогню.",
                Category = "Гуманоїд",
                Mythology = "Вулканічна",
                Origin = "Випалені яри",
                ThreatLevel = "Високий",
                Abilities = new List<string>
                {
                    "Контроль вогню",
                    "Виклик спалахів"
                },
                Weaknesses = new List<string>(),
                Images = new List<ImageResource>(),
                HistoricalNotes = new List<HistoricalNote>(),
                RelatedCreatures = new List<RelatedCreature>(),
                CreatedAt = createdAt,
                UpdatedAt = createdAt
            },

            new Creature
            {
                Id = "creature_009",
                Name = "Шіо-тан",
                Slug = "shio-tan",
                Description = "Шаман болотяних територій.",
                Category = "Шаман",
                Mythology = "Болотна",
                Origin = "Болотисті низини",
                ThreatLevel = "Середній",
                Abilities = new List<string>
                {
                    "Керування туманом",
                    "Контроль водяної пари"
                },
                Weaknesses = new List<string>(),
                Images = new List<ImageResource>(),
                HistoricalNotes = new List<HistoricalNote>(),
                RelatedCreatures = new List<RelatedCreature>(),
                CreatedAt = createdAt,
                UpdatedAt = createdAt
            },

            new Creature
            {
                Id = "creature_010",
                Name = "Друнг-мек",
                Slug = "drung-mek",
                Description = "Хронікар племені грози.",
                Category = "Гуманоїд",
                Mythology = "Племінна",
                Origin = "Високі плато",
                ThreatLevel = "Середній",
                Abilities = new List<string>(),
                Weaknesses = new List<string>(),
                Images = new List<ImageResource>(),
                HistoricalNotes = new List<HistoricalNote>(),
                RelatedCreatures = new List<RelatedCreature>(),
                CreatedAt = createdAt,
                UpdatedAt = createdAt
            },

            new Creature
            {
                Id = "creature_011",
                Name = "Енцу-хай",
                Slug = "enzu-hai",
                Description = "Ловець тіней у густих лісах.",
                Category = "Хижак",
                Mythology = "Лісова",
                Origin = "Густі ліси",
                ThreatLevel = "Середній",
                Abilities = new List<string>
                {
                    "Стеження",
                    "Пастки",
                    "Раптовий напад"
                },
                Weaknesses = new List<string>(),
                Images = new List<ImageResource>(),
                HistoricalNotes = new List<HistoricalNote>(),
                RelatedCreatures = new List<RelatedCreature>(),
                CreatedAt = createdAt,
                UpdatedAt = createdAt
            },

            new Creature
            {
                Id = "creature_012",
                Name = "Моргул-син",
                Slug = "morgul-sin",
                Description = "Людиноподібна істота з ритуальною культурою кування духу.",
                Category = "Гуманоїд",
                Mythology = "Вулканічна",
                Origin = "Вулканічні нагір’я",
                ThreatLevel = "Катастрофічний",
                Abilities = new List<string>
                {
                    "Кування духовної енергії",
                    "Контроль вогню",
                    "Ритуальний поєдинок"
                },
                Weaknesses = new List<string>(),
                Images = new List<ImageResource>(),
                HistoricalNotes = new List<HistoricalNote>(),
                RelatedCreatures = new List<RelatedCreature>(),
                CreatedAt = createdAt,
                UpdatedAt = createdAt
            }
        };
    }
}