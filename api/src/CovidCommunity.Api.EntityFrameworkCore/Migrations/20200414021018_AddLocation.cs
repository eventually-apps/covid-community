using Microsoft.EntityFrameworkCore.Migrations;

namespace CovidCommunity.Api.Migrations
{
    public partial class AddLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserLocationId",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    PrimaryAddress = table.Column<string>(nullable: true),
                    SecondaryAddress = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Zip = table.Column<int>(nullable: false),
                    LocationOwnerId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_Users_LocationOwnerId",
                        column: x => x.LocationOwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserLocationId",
                table: "Users",
                column: "UserLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_LocationOwnerId",
                table: "Locations",
                column: "LocationOwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Locations_UserLocationId",
                table: "Users",
                column: "UserLocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Locations_UserLocationId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserLocationId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserLocationId",
                table: "Users");
        }
    }
}
