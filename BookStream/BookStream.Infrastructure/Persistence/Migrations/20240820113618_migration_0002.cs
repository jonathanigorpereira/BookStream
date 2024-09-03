using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStream.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class migration_0002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AgeRating",
                table: "Books",
                newName: "IdAgeRating");

            migrationBuilder.CreateTable(
                name: "AgeRating",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgeRating", x => x.Id);
                });

            // Inserir dados na tabela AgeRating
            migrationBuilder.InsertData(
                table: "AgeRating",
                columns: new[] { "Id", "Description", "CreatedAt", "IsDeleted" },
                values: new object[,]
                {
                    { 1, "Livre para todos os públicos", DateTime.Now, false },
                    { 2, "Recomendado para maiores de 10 anos (PG)", DateTime.Now, false },
                    { 3, "Recomendado para maiores de 13 anos", DateTime.Now, false },
                    { 4, "Recomendado para maiores de 16 anos", DateTime.Now, false },
                    { 5, "Recomendado para maiores de 18 anos", DateTime.Now, false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_IdAgeRating",
                table: "Books",
                column: "IdAgeRating");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_AgeRating_IdAgeRating",
                table: "Books",
                column: "IdAgeRating",
                principalTable: "AgeRating",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_AgeRating_IdAgeRating",
                table: "Books");

            migrationBuilder.DropTable(
                name: "AgeRating");

            migrationBuilder.DropIndex(
                name: "IX_Books_IdAgeRating",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "IdAgeRating",
                table: "Books",
                newName: "AgeRating");
        }
    }
}
