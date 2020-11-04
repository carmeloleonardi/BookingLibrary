using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingLibrary.Migrations
{
    public partial class InitialMigrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Editors",
                columns: table => new
                {
                    EditorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EditorName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editors", x => x.EditorId);
                });

            migrationBuilder.CreateTable(
                name: "AuthorBiographies",
                columns: table => new
                {
                    AuthorBiographyId = table.Column<int>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Nationality = table.Column<string>(nullable: true),
                    AuthorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorBiographies", x => x.AuthorBiographyId);
                    table.ForeignKey(
                        name: "FK_AuthorBiographies_Authors_AuthorBiographyId",
                        column: x => x.AuthorBiographyId,
                        principalTable: "Authors",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(type: "decimal(5, 2)", nullable: false),
                    Isbn = table.Column<string>(nullable: true),
                    EditorId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_Books_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Editors_EditorId",
                        column: x => x.EditorId,
                        principalTable: "Editors",
                        principalColumn: "EditorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuthorBooks",
                columns: table => new
                {
                    AuthorId = table.Column<int>(nullable: false),
                    BookId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorBooks", x => new { x.AuthorId, x.BookId });
                    table.ForeignKey(
                        name: "FK_AuthorBooks_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorBooks_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Italo", "Calvivo" },
                    { 2, "Italo", "Svevo" },
                    { 3, "Martin", "Fowler" },
                    { 4, "Erich", "Gamma" },
                    { 5, "Richard", "Helm" },
                    { 6, "Ralph", "Johnson" },
                    { 7, "John", "Vlissides" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 6, "Crime" },
                    { 5, "Romantic" },
                    { 4, "Horror" },
                    { 2, "Computer Science" },
                    { 1, "Narrative" },
                    { 3, "Thriller" }
                });

            migrationBuilder.InsertData(
                table: "Editors",
                columns: new[] { "EditorId", "EditorName" },
                values: new object[,]
                {
                    { 4, "PEARSON Addison Wesley" },
                    { 1, "Rizzoli" },
                    { 2, "PACKT" },
                    { 3, "Mondadori" },
                    { 5, "Mondadori" }
                });

            migrationBuilder.InsertData(
                table: "AuthorBiographies",
                columns: new[] { "AuthorBiographyId", "AuthorId", "DateOfBirth", "Description", "Nationality" },
                values: new object[] { 1, 3, new DateTime(1963, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Together with Kent Beck he was one of the fathers of extreme programming and agile software development. He is a member of the Agile Alliance and one of the authors of the Agile Manifesto. Among his most influential works we can mention UML Distilled on the UML language and Refactoring: Improving the Design of Existing Code which introduced the concept of refactoring, today among the cornerstones of agile and test driven development methodologies. He introduced the concept of dependency injection, widely used in the practice of developing automated tests.", "England" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "CategoryId", "EditorId", "Isbn", "Price", "Title" },
                values: new object[,]
                {
                    { 1, 1, 3, "5ab6829o", 13.5m, "Il sentiero dei nidi di ragno" },
                    { 2, 1, 3, "7493b423", 12.2m, "Il barone rampante" },
                    { 3, 1, 3, "6283472992a", 13.5m, "Il visconte dimezzato" },
                    { 4, 1, 3, "3738347383", 17.5m, "La coscienza di Zeno" },
                    { 5, 2, 4, "127238437", 24.5m, "UML distilled" },
                    { 6, 2, 4, "887192150X", 39m, "Design Patterns" }
                });

            migrationBuilder.InsertData(
                table: "AuthorBooks",
                columns: new[] { "AuthorId", "BookId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 4 },
                    { 3, 5 },
                    { 4, 6 },
                    { 5, 6 },
                    { 6, 6 },
                    { 7, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorBooks_BookId",
                table: "AuthorBooks",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_EditorId",
                table: "Books",
                column: "EditorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorBiographies");

            migrationBuilder.DropTable(
                name: "AuthorBooks");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Editors");
        }
    }
}
