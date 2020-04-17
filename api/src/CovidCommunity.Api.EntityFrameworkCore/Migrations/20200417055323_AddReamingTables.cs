using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CovidCommunity.Api.Migrations
{
    public partial class AddReamingTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InventoryByLocations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(nullable: false),
                    LocationId = table.Column<int>(nullable: false),
                    ItemByLocationQuantity = table.Column<int>(nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryByLocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryByLocations_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryByLocations_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestOrders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderRequestedByUserId = table.Column<long>(nullable: false),
                    OrderForLocationId = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    FulfillmentDate = table.Column<DateTime>(nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestOrders_Locations_OrderForLocationId",
                        column: x => x.OrderForLocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequestOrders_Users_OrderRequestedByUserId",
                        column: x => x.OrderRequestedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestOrderId = table.Column<int>(nullable: false),
                    RequestedItemId = table.Column<int>(nullable: false),
                    RequestedAmount = table.Column<int>(nullable: false),
                    RequestedDate = table.Column<DateTime>(nullable: false),
                    FulfilledDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_RequestOrders_RequestOrderId",
                        column: x => x.RequestOrderId,
                        principalTable: "RequestOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requests_Items_RequestedItemId",
                        column: x => x.RequestedItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryByLocations_ItemId",
                table: "InventoryByLocations",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryByLocations_LocationId",
                table: "InventoryByLocations",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestOrders_OrderForLocationId",
                table: "RequestOrders",
                column: "OrderForLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestOrders_OrderRequestedByUserId",
                table: "RequestOrders",
                column: "OrderRequestedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_RequestOrderId",
                table: "Requests",
                column: "RequestOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_RequestedItemId",
                table: "Requests",
                column: "RequestedItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryByLocations");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "RequestOrders");
        }
    }
}
