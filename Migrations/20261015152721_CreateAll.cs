using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proyecto_aspnet.Migrations
{
    /// <inheritdoc />
    public partial class CreateAll : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Developers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sagas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ReleaseDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sagas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VideoConsoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ReleaseDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    ReleasePrice = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoConsoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubGenres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    GenreId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubGenres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubGenres_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Videogames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ReleaseDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    ReleasePrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Players = table.Column<int>(type: "INTEGER", nullable: false),
                    PublisherId = table.Column<int>(type: "INTEGER", nullable: false),
                    DeveloperId = table.Column<int>(type: "INTEGER", nullable: false),
                    Languages = table.Column<string>(type: "TEXT", nullable: false),
                    GameEngine = table.Column<int>(type: "INTEGER", nullable: false),
                    SagaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videogames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Videogames_Developers_DeveloperId",
                        column: x => x.DeveloperId,
                        principalTable: "Developers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Videogames_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Videogames_Sagas_SagaId",
                        column: x => x.SagaId,
                        principalTable: "Sagas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenreVideogame",
                columns: table => new
                {
                    GenresId = table.Column<int>(type: "INTEGER", nullable: false),
                    VideogamesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreVideogame", x => new { x.GenresId, x.VideogamesId });
                    table.ForeignKey(
                        name: "FK_GenreVideogame_Genres_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreVideogame_Videogames_VideogamesId",
                        column: x => x.VideogamesId,
                        principalTable: "Videogames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubGenreVideogame",
                columns: table => new
                {
                    SubGenresId = table.Column<int>(type: "INTEGER", nullable: false),
                    VideogamesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubGenreVideogame", x => new { x.SubGenresId, x.VideogamesId });
                    table.ForeignKey(
                        name: "FK_SubGenreVideogame_SubGenres_SubGenresId",
                        column: x => x.SubGenresId,
                        principalTable: "SubGenres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubGenreVideogame_Videogames_VideogamesId",
                        column: x => x.VideogamesId,
                        principalTable: "Videogames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VideoConsoleVideogame",
                columns: table => new
                {
                    VideoConsolesId = table.Column<int>(type: "INTEGER", nullable: false),
                    VideogamesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoConsoleVideogame", x => new { x.VideoConsolesId, x.VideogamesId });
                    table.ForeignKey(
                        name: "FK_VideoConsoleVideogame_VideoConsoles_VideoConsolesId",
                        column: x => x.VideoConsolesId,
                        principalTable: "VideoConsoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VideoConsoleVideogame_Videogames_VideogamesId",
                        column: x => x.VideogamesId,
                        principalTable: "Videogames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenreVideogame_VideogamesId",
                table: "GenreVideogame",
                column: "VideogamesId");

            migrationBuilder.CreateIndex(
                name: "IX_SubGenres_GenreId",
                table: "SubGenres",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_SubGenreVideogame_VideogamesId",
                table: "SubGenreVideogame",
                column: "VideogamesId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoConsoleVideogame_VideogamesId",
                table: "VideoConsoleVideogame",
                column: "VideogamesId");

            migrationBuilder.CreateIndex(
                name: "IX_Videogames_DeveloperId",
                table: "Videogames",
                column: "DeveloperId");

            migrationBuilder.CreateIndex(
                name: "IX_Videogames_PublisherId",
                table: "Videogames",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_Videogames_SagaId",
                table: "Videogames",
                column: "SagaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenreVideogame");

            migrationBuilder.DropTable(
                name: "SubGenreVideogame");

            migrationBuilder.DropTable(
                name: "VideoConsoleVideogame");

            migrationBuilder.DropTable(
                name: "SubGenres");

            migrationBuilder.DropTable(
                name: "VideoConsoles");

            migrationBuilder.DropTable(
                name: "Videogames");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Developers");

            migrationBuilder.DropTable(
                name: "Publishers");

            migrationBuilder.DropTable(
                name: "Sagas");
        }
    }
}
