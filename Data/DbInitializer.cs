using Microsoft.EntityFrameworkCore;
using proyecto_aspnet.Models;

namespace proyecto_aspnet.Data;

public static class DbInitializer
{
    public static void Initialize(IServiceProvider services)
    {
                using var scope = services.CreateScope();

        var db = scope.ServiceProvider
            .GetRequiredService<ApplicationDbContext>();

        // Evita insertar los mismos datos en cada inicio.
        if (db.Videogames.Any())
            return;

        // DESARROLLADORES
        var konami = new Developer
        {
            Name = "Konami",
            Description = "Desarrolladora y editora japonesa."
        };

        var squareEnix = new Developer
        {
            Name = "Square Enix",
            Description = "Desarrolladora japonesa de RPG."
        };

        var teamCherry = new Developer
        {
            Name = "Team Cherry",
            Description = "Estudio independiente australiano."
        };

        var mojang = new Developer
        {
            Name = "Mojang Studios",
            Description = "Estudio creador de Minecraft."
        };

        var cdProjekt = new Developer
        {
            Name = "CD Projekt Red",
            Description = "Estudio polaco de videojuegos."
        };

        db.Developers.AddRange(
            konami, squareEnix, teamCherry, mojang, cdProjekt
        );

        // EDITORAS
        var konamiPublisher = new Publisher
        {
            Name = "Konami",
            Description = "Editora japonesa."
        };

        var squareEnixPublisher = new Publisher
        {
            Name = "Square Enix",
            Description = "Editora de videojuegos."
        };

        var teamCherryPublisher = new Publisher
        {
            Name = "Team Cherry",
            Description = "Editora independiente."
        };

        var microsoft = new Publisher
        {
            Name = "Xbox Game Studios",
            Description = "Editora de videojuegos."
        };

        var cdProjektPublisher = new Publisher
        {
            Name = "CD Projekt",
            Description = "Editora polaca."
        };

        db.Publishers.AddRange(
            konamiPublisher,
            squareEnixPublisher,
            teamCherryPublisher,
            microsoft,
            cdProjektPublisher
        );

        // GÉNEROS
        var accion = new Genre
        {
            Name = "Acción",
            Description = "Juegos centrados en la acción."
        };

        var rpg = new Genre
        {
            Name = "RPG",
            Description = "Juegos de rol y progresión."
        };

        var aventura = new Genre
        {
            Name = "Aventura",
            Description = "Juegos centrados en explorar."
        };

        var sandbox = new Genre
        {
            Name = "Sandbox",
            Description = "Juegos con libertad de construcción."
        };

        db.Genres.AddRange(accion, rpg, aventura, sandbox);

        // SUBGÉNEROS
        var sigilo = new SubGenre
        {
            Name = "Sigilo",
            Description = "Evitar o superar enemigos sin ser detectado.",
            Genre = accion
        };

        var metroidvania = new SubGenre
        {
            Name = "Metroidvania",
            Description = "Exploración y habilidades desbloqueables.",
            Genre = aventura
        };

        var mundoAbierto = new SubGenre
        {
            Name = "Mundo abierto",
            Description = "Exploración libre de un mundo amplio.",
            Genre = aventura
        };

        var construccion = new SubGenre
        {
            Name = "Construcción",
            Description = "Crear estructuras y modificar el entorno.",
            Genre = sandbox
        };

        var jrpg = new SubGenre
        {
            Name = "JRPG",
            Description = "Juego de rol de tradición japonesa.",
            Genre = rpg
        };

        db.SubGenres.AddRange(
            sigilo, metroidvania, mundoAbierto, construccion, jrpg
        );

        // CONSOLAS Y PLATAFORMAS
        var ps2 = new VideoConsole
        {
            Name = "PlayStation 2",
            ReleaseDate = new DateOnly(2000, 3, 4),
            ReleasePrice = 299.99m,
            Description = "Consola doméstica de Sony."
        };

        var pc = new VideoConsole
        {
            Name = "PC",
            ReleaseDate = new DateOnly(1981, 1, 1),
            ReleasePrice = 0m,
            Description = "Ordenador personal."
        };

        var ps4 = new VideoConsole
        {
            Name = "PlayStation 4",
            ReleaseDate = new DateOnly(2013, 11, 15),
            ReleasePrice = 399.99m,
            Description = "Consola doméstica de Sony."
        };

        var switchConsole = new VideoConsole
        {
            Name = "Nintendo Switch",
            ReleaseDate = new DateOnly(2017, 3, 3),
            ReleasePrice = 329.99m,
            Description = "Consola híbrida de Nintendo."
        };

        var xbox360 = new VideoConsole
        {
            Name = "Xbox 360",
            ReleaseDate = new DateOnly(2005, 11, 22),
            ReleasePrice = 299.99m,
            Description = "Consola doméstica de Microsoft."
        };

        db.VideoConsoles.AddRange(
            ps2, pc, ps4, switchConsole, xbox360
        );

        // SAGAS
        var metalGearSaga = new Saga
        {
            Name = "Metal Gear",
            ReleaseDate = new DateOnly(1987, 7, 13),
            Description = "Saga de acción y sigilo."
        };

        var finalFantasySaga = new Saga
        {
            Name = "Final Fantasy",
            ReleaseDate = new DateOnly(1987, 12, 18),
            Description = "Saga de juegos de rol."
        };

        var minecraftSaga = new Saga
        {
            Name = "Minecraft",
            ReleaseDate = new DateOnly(2011, 11, 18),
            Description = "Franquicia de construcción y exploración."
        };

        var witcherSaga = new Saga
        {
            Name = "The Witcher",
            ReleaseDate = new DateOnly(2007, 10, 26),
            Description = "Saga de rol y fantasía."
        };

        var hollowKnightSaga = new Saga
        {
            Name = "Hollow Knight",
            ReleaseDate = new DateOnly(2017, 2, 24),
            Description = "Universo de aventuras y exploración."
        };

        db.Sagas.AddRange(
            metalGearSaga,
            finalFantasySaga,
            minecraftSaga,
            witcherSaga,
            hollowKnightSaga
        );

        // Guardamos las entidades principales antes de
        // construir los videojuegos.
        db.SaveChanges();

        // VIDEOJUEGOS
        var metalGear = new Videogame
        {
            Name = "Metal Gear Solid 3: Snake Eater",
            ReleaseDate = new DateOnly(2004, 11, 17),
            ReleasePrice = 59.99m,
            Description =
                "Aventura de acción y sigilo ambientada en la Guerra Fría.",
            Players = 1,
            Developer = konami,
            Publisher = konamiPublisher,
            Saga = metalGearSaga,
            GameEngine = GameEngine.RAGE,
            Genres = { accion, aventura },
            SubGenres = { sigilo },
            Languages = { Language.ES, Language.EN, Language.JA },
            VideoConsoles = { ps2 }
        };

        var finalFantasy = new Videogame
        {
            Name = "Final Fantasy X",
            ReleaseDate = new DateOnly(2001, 7, 19),
            ReleasePrice = 59.99m,
            Description =
                "Un RPG japonés protagonizado por Tidus y Yuna.",
            Players = 1,
            Developer = squareEnix,
            Publisher = squareEnixPublisher,
            Saga = finalFantasySaga,
            GameEngine = GameEngine.UnrealEngine,
            Genres = { rpg, aventura },
            SubGenres = { jrpg },
            Languages = { Language.ES, Language.EN, Language.JA },
            VideoConsoles = { ps2 }
        };

        var minecraft = new Videogame
        {
            Name = "Minecraft",
            ReleaseDate = new DateOnly(2011, 11, 18),
            ReleasePrice = 26.95m,
            Description =
                "Construcción, exploración y supervivencia en un mundo de bloques.",
            Players = 8,
            Developer = mojang,
            Publisher = microsoft,
            Saga = minecraftSaga,
            GameEngine = GameEngine.Unity,
            Genres = { sandbox, aventura },
            SubGenres = { construccion },
            Languages = { Language.ES, Language.EN, Language.FR },
            VideoConsoles = { pc, switchConsole, xbox360 }
        };

        var witcher = new Videogame
        {
            Name = "The Witcher 3: Wild Hunt",
            ReleaseDate = new DateOnly(2015, 5, 19),
            ReleasePrice = 59.99m,
            Description =
                "RPG de mundo abierto protagonizado por Geralt de Rivia.",
            Players = 1,
            Developer = cdProjekt,
            Publisher = cdProjektPublisher,
            Saga = witcherSaga,
            GameEngine = GameEngine.CreationEngine,
            Genres = { rpg, accion, aventura },
            SubGenres = { mundoAbierto },
            Languages = { Language.ES, Language.EN, Language.FR, Language.DE },
            VideoConsoles = { pc, ps4, switchConsole }
        };

        var hollowKnight = new Videogame
        {
            Name = "Hollow Knight",
            ReleaseDate = new DateOnly(2017, 2, 24),
            ReleasePrice = 14.99m,
            Description =
                "Aventura de exploración en el reino subterráneo de Hallownest.",
            Players = 1,
            Developer = teamCherry,
            Publisher = teamCherryPublisher,
            Saga = hollowKnightSaga,
            GameEngine = GameEngine.Unity,
            Genres = { accion, aventura },
            SubGenres = { metroidvania },
            Languages = { Language.ES, Language.EN, Language.FR },
            VideoConsoles = { pc, switchConsole, ps4 }
        };

        db.Videogames.AddRange(
            metalGear,
            finalFantasy,
            minecraft,
            witcher,
            hollowKnight
        );

        db.SaveChanges();
    }
}
