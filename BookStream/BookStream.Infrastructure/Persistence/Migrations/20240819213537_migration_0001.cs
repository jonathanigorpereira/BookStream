using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStream.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class migration_0001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Synopsis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Publisher = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdGenre = table.Column<int>(type: "int", nullable: false),
                    UnformatedISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearOfPublication = table.Column<int>(type: "int", nullable: false),
                    AgeRating = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Genres_IdGenre",
                        column: x => x.IdGenre,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_IdGenre",
                table: "Books",
                column: "IdGenre");

            // Insert seed data into Genres table
            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Genre", "CreatedAt", "IsDeleted" },
                values: new object[,]
                {
                    // Ficção
                    { 1, "Romance", DateTime.UtcNow, false },
                    { 2, "Ficção Científica", DateTime.UtcNow, false },
                    { 3, "Fantasia", DateTime.UtcNow, false },
                    { 4, "Terror", DateTime.UtcNow, false },
                    { 5, "Mistério", DateTime.UtcNow, false },
                    { 6, "Suspense", DateTime.UtcNow, false },
                    { 7, "Distopia", DateTime.UtcNow, false },
                    { 8, "Ficção Histórica", DateTime.UtcNow, false },
                    { 9, "Ficção Contemporânea", DateTime.UtcNow, false },
                    { 10, "Jovem Adulto", DateTime.UtcNow, false },
                    { 11, "Ficção Infantil", DateTime.UtcNow, false },
                    { 12, "Fábula", DateTime.UtcNow, false },
                    { 13, "Contos", DateTime.UtcNow, false },
                    { 14, "Drama", DateTime.UtcNow, false },
                    { 15, "Comédia", DateTime.UtcNow, false },

                    // Não-Ficção
                    { 16, "Biografia", DateTime.UtcNow, false },
                    { 17, "Memórias", DateTime.UtcNow, false },
                    { 18, "História", DateTime.UtcNow, false },
                    { 19, "Ciência", DateTime.UtcNow, false },
                    { 20, "Filosofia", DateTime.UtcNow, false },
                    { 21, "Psicologia", DateTime.UtcNow, false },
                    { 22, "Autoajuda", DateTime.UtcNow, false },
                    { 23, "Negócios", DateTime.UtcNow, false },
                    { 24, "Espiritualidade", DateTime.UtcNow, false },
                    { 25, "Política", DateTime.UtcNow, false },
                    { 26, "Esportes", DateTime.UtcNow, false },
                    { 27, "Viagem", DateTime.UtcNow, false },
                    { 28, "Culinária", DateTime.UtcNow, false },
                    { 29, "Arte", DateTime.UtcNow, false },
                    { 30, "Educação", DateTime.UtcNow, false },

                    // Outros Gêneros
                    { 31, "Poesia", DateTime.UtcNow, false },
                    { 32, "Teatro", DateTime.UtcNow, false },
                    { 33, "Ensaios", DateTime.UtcNow, false },
                    { 34, "Crônicas", DateTime.UtcNow, false }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
               table: "Genres",
               keyColumn: "Id",
               keyValues: new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34 });

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
