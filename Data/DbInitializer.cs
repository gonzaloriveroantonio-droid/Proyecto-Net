using Microsoft.EntityFrameworkCore;
using proyecto_aspnet.Models;

namespace proyecto_aspnet.Data;

public static class DbInitializer
{
    public static void Initialize(IServiceProvider services)
    {
        var context = services.GetRequiredService<ApplicationDbContext>();

        // aplica  migraciones pendientes al arrancar la app
        context.Database.Migrate();
        if (context.Videogames.Any())
            return;
            
        // DESARROLLADORES
        var nintendo = new Developer
        {
            Namge = "Nintendo EPD",
            Description = "Estudio interno de desarrollo de Nintendo."
        };

        var gameFreak = new Developer
        {
            Namge = "Game Freak",
            Description = "Estudio conocido por la saga Pokemon."
        };

        var capcom = new Developer
        {
            Namge = "Capcom",
            Description = "Desarrolladora japonesa de videojuegos."
        };

        var squareEnix = new Developer
        {
            Namge = "Square Enix",
            Description = "Desarrolladora de RPG y juegos de aventura."
        };

        context.Developers.AddRange(
            nintendo, gameFreak, capcom, squareEnix
        );
        context.SaveChanges();

        // EDITORAS
        var nintendoPublisher = new Publisher
        {
            Namge = "Nintendo",
            Description = "Editora de videojuegos y fabricante de consolas."
        };

        var capcomPublisher = new Publisher
        {
            Namge = "Capcom",
            Description = "Editora japonesa de videojuegos."
        };

        var squareEnixPublisher = new Publisher
        {
            Namge = "Square Enix",
            Description = "Editora especializada en juegos de rol."
        };

        context.Publishers.AddRange(
            nintendoPublisher, capcomPublisher, squareEnixPublisher
        );
        context.SaveChanges();

        // CONSOLAS
        var ds = new VideoConsole
        {
            Name = "Nintendo DS",
            ReleseDate = new DateOnly(2004, 11, 21),
            PriceReleaseDate = 149.99m,
            Description = "Consola portátil de doble pantalla."
        };

        var ps2 = new VideoConsole
        {
            Name = "PlayStation 2",
            ReleseDate = new DateOnly(2000, 3, 4),
            PriceReleaseDate = 449.99m,
            Description = "Consola doméstica de Sony."
        };

        var threeDS = new VideoConsole
        {
            Name = "Nintendo 3DS",
            ReleseDate = new DateOnly(2011, 2, 26),
            PriceReleaseDate = 249.99m,
            Description = "Consola portátil con efecto 3D."
        };

        var switchConsole = new VideoConsole
        {
            Name = "Nintendo Switch",
            ReleseDate = new DateOnly(2017, 3, 3),
            PriceReleaseDate = 329.99m,
            Description = "Consola híbrida portátil y doméstica."
        };

        context.VideoConsoles.AddRange(ds, ps2, threeDS, switchConsole);
        context.SaveChanges();

        // GÉNEROS Y SUBGÉNEROS
        var adventure = new Genre
        {
            Name = "Aventura",
            Description = "Juegos centrados en explorar y descubrir."
        };

        adventure.SubGenres.AddRange(new[]
        {
        new SubGenre
        {
            Name = "Aventura gráfica",
            Description = "Juegos centrados en puzles y exploración."
        },
        new SubGenre
        {
            Name = "Mundo abierto",
            Description = "Juegos con libertad para explorar."
        }
    });

        var rpg = new Genre
        {
            Name = "RPG",
            Description = "Juegos de rol con progresión de personajes."
        };

        rpg.SubGenres.AddRange(new[]
        {
        new SubGenre
        {
            Name = "JRPG",
            Description = "Juegos de rol de estilo japonés."
        },
        new SubGenre
        {
            Name = "ARPG",
            Description = "Juegos de rol con combate en tiempo real."
        }
    });

        var simulation = new Genre
        {
            Name = "Simulación",
            Description = "Juegos que simulan actividades o sistemas."
        };

        simulation.SubGenres.AddRange(new[]
        {
        new SubGenre
        {
            Name = "Simulación de vida",
            Description = "Juegos sobre la vida cotidiana."
        },
        new SubGenre
        {
            Name = "Gestión",
            Description = "Juegos centrados en administrar recursos."
        }
    });

        var platformer = new Genre
        {
            Name = "Plataformas",
            Description = "Juegos de saltos y obstáculos."
        };

        var action = new Genre
        {
            Name = "Acción",
            Description = "Juegos centrados en reflejos y combate."
        };

        var horror = new Genre
        {
            Name = "Terror",
            Description = "Juegos diseñados para generar tensión."
        };

        context.Genres.AddRange(
            adventure, rpg, simulation, platformer, action, horror
        );
        context.SaveChanges();

        // VIDEOJUEGOS
        context.Videogames.AddRange(
            new Videogame
            {
                Name = "Pokemon Platinum",
                ReleseDate = new DateOnly(2008, 9, 13),
                PriceReleaseDate = 39.99m,
                Description = "Aventura de captura y entrenamiento de criaturas.",
                Players = 1,
                DeveloperId = gameFreak.Id,
                PublisherId = nintendoPublisher.Id,
                Publiser = nintendoPublisher,
                Developer = gameFreak,
                VideoConsoleId = ds.Id,
                VideoConsole = ds,
                Genres = new List<Genre> { rpg, adventure },
                Languages = new List<Language>
                {
                Language.ES, Language.EN, Language.FR,
                Language.DE, Language.IT
                },
                GameEngine = GameEngine.GameMaker
            },

            new Videogame
            {
                Name = "Animal Crossing Wild World",
                ReleseDate = new DateOnly(2005, 11, 23),
                PriceReleaseDate = 39.99m,
                Description = "Simulador de vida en un pueblo.",
                Players = 4,
                DeveloperId = nintendo.Id,
                PublisherId = nintendoPublisher.Id,
                Publiser = nintendoPublisher,
                Developer = nintendo,
                VideoConsoleId = ds.Id,
                VideoConsole = ds,
                Genres = new List<Genre> { simulation },
                Languages = new List<Language>
                {
                Language.ES, Language.EN, Language.FR,
                Language.DE, Language.IT
                },
                GameEngine = GameEngine.GameMaker
            },

            new Videogame
            {
                Name = "Kingdom Hearts",
                ReleseDate = new DateOnly(2002, 3, 28),
                PriceReleaseDate = 59.99m,
                Description = "RPG de acción que mezcla personajes de Disney y Square.",
                Players = 1,
                DeveloperId = squareEnix.Id,
                PublisherId = squareEnixPublisher.Id,
                Publiser = squareEnixPublisher,
                Developer = squareEnix,
                VideoConsoleId = ps2.Id,
                VideoConsole = ps2,
                Genres = new List<Genre> { rpg, action, adventure },
                Languages = new List<Language>
                {
                Language.ES, Language.EN, Language.FR,
                Language.DE, Language.IT
                },
                GameEngine = GameEngine.UnrealEngine
            },

            new Videogame
            {
                Name = "Resident Evil 4",
                ReleseDate = new DateOnly(2005, 1, 11),
                PriceReleaseDate = 59.99m,
                Description = "Aventura de acción y terror.",
                Players = 1,
                DeveloperId = capcom.Id,
                PublisherId = capcomPublisher.Id,
                Publiser = capcomPublisher,
                Developer = capcom,
                VideoConsoleId = ps2.Id,
                VideoConsole = ps2,
                Genres = new List<Genre> { action, horror },
                Languages = new List<Language>
                {
                Language.ES, Language.EN, Language.FR,
                Language.DE, Language.IT
                },
                GameEngine = GameEngine.REEngine
            },

            new Videogame
            {
                Name = "Pokemon X",
                ReleseDate = new DateOnly(2013, 10, 12),
                PriceReleaseDate = 39.99m,
                Description = "Aventura de Pokemon ambientada en Kalos.",
                Players = 4,
                DeveloperId = gameFreak.Id,
                PublisherId = nintendoPublisher.Id,
                Publiser = nintendoPublisher,
                Developer = gameFreak,
                VideoConsoleId = threeDS.Id,
                VideoConsole = threeDS,
                Genres = new List<Genre> { rpg, adventure },
                Languages = new List<Language>
                {
                Language.ES, Language.EN, Language.FR,
                Language.DE, Language.IT, Language.JA
                },
                GameEngine = GameEngine.GameMaker
            },

            new Videogame
            {
                Name = "Fantasy Life",
                ReleseDate = new DateOnly(2012, 12, 27),
                PriceReleaseDate = 39.99m,
                Description = "RPG con oficios, fabricación y exploración.",
                Players = 3,
                DeveloperId = nintendo.Id,
                PublisherId = nintendoPublisher.Id,
                Publiser = nintendoPublisher,
                Developer = nintendo,
                VideoConsoleId = threeDS.Id,
                VideoConsole = threeDS,
                Genres = new List<Genre> { rpg, adventure, simulation },
                Languages = new List<Language>
                {
                Language.ES, Language.EN, Language.FR,
                Language.DE, Language.IT
                },
                GameEngine = GameEngine.GameMaker
            },

            new Videogame
            {
                Name = "The Legend of Zelda Breath of the Wild",
                ReleseDate = new DateOnly(2017, 3, 3),
                PriceReleaseDate = 59.99m,
                Description = "Aventura de mundo abierto.",
                Players = 1,
                DeveloperId = nintendo.Id,
                PublisherId = nintendoPublisher.Id,
                Publiser = nintendoPublisher,
                Developer = nintendo,
                VideoConsoleId = switchConsole.Id,
                VideoConsole = switchConsole,
                Genres = new List<Genre> { adventure, action },
                Languages = new List<Language>
                {
                Language.ES, Language.EN, Language.FR,
                Language.DE, Language.IT, Language.JA
                },
                GameEngine = GameEngine.GameMaker
            },

            new Videogame
            {
                Name = "Resident Evil Village",
                ReleseDate = new DateOnly(2021, 5, 7),
                PriceReleaseDate = 59.99m,
                Description = "Aventura de terror y supervivencia.",
                Players = 1,
                DeveloperId = capcom.Id,
                PublisherId = capcomPublisher.Id,
                Publiser = capcomPublisher,
                Developer = capcom,
                VideoConsoleId = switchConsole.Id,
                VideoConsole = switchConsole,
                Genres = new List<Genre> { action, horror },
                Languages = new List<Language>
                {
                Language.ES, Language.EN, Language.FR,
                Language.DE, Language.IT, Language.JA
                },
                GameEngine = GameEngine.REEngine
            }
        );

        context.SaveChanges();
























        // DATOS DEMO
        /*         if (!context.VideoConsoles.Any())
                {
                    context.VideoConsoles.AddRange(
            new VideoConsole
            {
                Name = "Nintendo DS",
                ReleseDate = new DateOnly(2004, 11, 21),
                Description = "Consola portátil de Nintendo."
            },
            new VideoConsole
            {
                Name = "PlayStation 2",
                ReleseDate = new DateOnly(2000, 3, 4),
                Description = "Consola doméstica de Sony."
            },
            new VideoConsole
            {
                Name = "Nintendo 3DS",
                ReleseDate = new DateOnly(2011, 2, 26),
                Description = "Consola portátil con pantalla 3D."
            },
            new VideoConsole
            {
                Name = "Nintendo Switch",
                ReleseDate = new DateOnly(2017, 3, 3),
                Description = "Consola híbrida portátil y doméstica."
            }
        );

                    context.SaveChanges();
                }

                if (!context.Videogames.Any())
                {
                    var nintendoDS = context.VideoConsoles.First(v => v.Name == "Nintendo DS");
                    var playStation2 = context.VideoConsoles.First(v => v.Name == "PlayStation 2");
                    var nintendo3DS = context.VideoConsoles.First(v => v.Name == "Nintendo 3DS");
                    var nintendoSwitch = context.VideoConsoles.First(v => v.Name == "Nintendo Switch");
                    context.Videogames.AddRange(
            // Nintendo DS
            new Videogame
            {
                Name = "Pokemon Platinum",
                ReleseDate = new DateOnly(2008, 9, 13),
                Description = "Aventura de captura de criaturas.",

                VideoConsole = nintendoDS
            },
            new Videogame
            {
                Name = "Animal Crossing Wild World",
                ReleseDate = new DateOnly(2005, 11, 23),
                Description = "Simulador de vida y comunidad.",

                VideoConsole = nintendoDS
            },
            new Videogame
            {
                Name = "New Super Mario Bros",
                ReleseDate = new DateOnly(2006, 5, 15),
                Description = "Juego de plataformas en dos dimensiones.",

                VideoConsole = nintendoDS
            },

            // PlayStation 2
            new Videogame
            {
                Name = "Kingdom Hearts",
                ReleseDate = new DateOnly(2002, 3, 28),
                Description = "RPG de acción y aventura.",

                VideoConsole = playStation2
            },
            new Videogame
            {
                Name = "The Sims 2",
                ReleseDate = new DateOnly(2004, 9, 14),
                Description = "Simulador de vida.",

                VideoConsole = playStation2
            },
            new Videogame
            {
                Name = "Resident Evil 4",
                ReleseDate = new DateOnly(2005, 1, 11),
                Description = "Aventura de terror y supervivencia.",

                VideoConsole = playStation2
            },

            // Nintendo 3DS
            new Videogame
            {
                Name = "Fantasy Life",
                ReleseDate = new DateOnly(2012, 12, 27),
                Description = "RPG con oficios, exploración y fabricación.",

                VideoConsole = nintendo3DS
            },
            new Videogame
            {
                Name = "Animal Crossing New Leaf",
                ReleseDate = new DateOnly(2012, 11, 8),
                Description = "Simulador de vida en un pueblo.",

                VideoConsole = nintendo3DS
            },
            new Videogame
            {
                Name = "Super Mario 3D Land",
                ReleseDate = new DateOnly(2011, 11, 3),
                Description = "Juego de plataformas en 3D.",

                VideoConsole = nintendo3DS
            },

            // Nintendo Switch
            new Videogame
            {
                Name = "Animal Crossing New Horizons",
                ReleseDate = new DateOnly(2020, 3, 20),
                Description = "Simulador de vida en una isla.",

                VideoConsole = nintendoSwitch
            },
            new Videogame
            {
                Name = "The Legend of Zelda Breath of the Wild",
                ReleseDate = new DateOnly(2017, 3, 3),
                Description = "Aventura de mundo abierto.",

                VideoConsole = nintendoSwitch
            },
            new Videogame
            {
                Name = "Super Mario Odyssey",
                ReleseDate = new DateOnly(2017, 10, 27),
                Description = "Aventura y plataformas en 3D.",

                VideoConsole = nintendoSwitch
            }
        );

                    context.SaveChanges();
                } */
    }
}
