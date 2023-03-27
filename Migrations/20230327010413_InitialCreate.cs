using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movies_API_WS.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Customer",
            //    columns: table => new
            //    {
            //        CustomerId = table.Column<int>(type: "int", nullable: false),
            //        Age = table.Column<int>(type: "int", nullable: false),
            //        Gender = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false),
            //        Occupation = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Customer_CustomerId", x => x.CustomerId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Movie",
            //    columns: table => new
            //    {
            //        MovieId = table.Column<int>(type: "int", nullable: false),
            //        Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Movie_MovieId", x => x.MovieId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Rating",
            //    columns: table => new
            //    {
            //        CustomerId = table.Column<int>(type: "int", nullable: false),
            //        MovieId = table.Column<int>(type: "int", nullable: false),
            //        Rating = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Rating", x => new { x.CustomerId, x.MovieId });
            //        table.ForeignKey(
            //            name: "FK_Rating_Customer",
            //            column: x => x.CustomerId,
            //            principalTable: "Customer",
            //            principalColumn: "CustomerId",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Rating_Movie",
            //            column: x => x.MovieId,
            //            principalTable: "Movie",
            //            principalColumn: "MovieId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Rating_MovieId",
            //    table: "Rating",
            //    column: "MovieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Movie");
        }
    }
}
