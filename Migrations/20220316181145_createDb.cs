using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LoginMicroservice.Migrations
{
    public partial class createDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MutualFundPriceDetails",
                columns: table => new
                {
                    MutualFundId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MutualFundName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MutualFundPrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MutualFundPriceDetails", x => x.MutualFundId);
                });

            migrationBuilder.CreateTable(
                name: "StockPriceDetails",
                columns: table => new
                {
                    StockId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StockName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StockPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockPriceDetails", x => x.StockId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "PortfolioDetails",
                columns: table => new
                {
                    PortfolioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioDetails", x => x.PortfolioId);
                    table.ForeignKey(
                        name: "FK_PortfolioDetails_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MutualFundDetails",
                columns: table => new
                {
                    MutualFunBuyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PortfolioId = table.Column<int>(type: "int", nullable: false),
                    MutualFundId = table.Column<int>(type: "int", nullable: false),
                    MutualFundUnits = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MutualFundDetails", x => x.MutualFunBuyId);
                    table.ForeignKey(
                        name: "FK_MutualFundDetails_MutualFundPriceDetails_MutualFundId",
                        column: x => x.MutualFundId,
                        principalTable: "MutualFundPriceDetails",
                        principalColumn: "MutualFundId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MutualFundDetails_PortfolioDetails_PortfolioId",
                        column: x => x.PortfolioId,
                        principalTable: "PortfolioDetails",
                        principalColumn: "PortfolioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StockDetails",
                columns: table => new
                {
                    StockBuyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PortfolioId = table.Column<int>(type: "int", nullable: false),
                    StockId = table.Column<int>(type: "int", nullable: false),
                    StockCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockDetails", x => x.StockBuyId);
                    table.ForeignKey(
                        name: "FK_StockDetails_PortfolioDetails_PortfolioId",
                        column: x => x.PortfolioId,
                        principalTable: "PortfolioDetails",
                        principalColumn: "PortfolioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StockDetails_StockPriceDetails_StockId",
                        column: x => x.StockId,
                        principalTable: "StockPriceDetails",
                        principalColumn: "StockId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MutualFundDetails_MutualFundId",
                table: "MutualFundDetails",
                column: "MutualFundId");

            migrationBuilder.CreateIndex(
                name: "IX_MutualFundDetails_PortfolioId",
                table: "MutualFundDetails",
                column: "PortfolioId");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioDetails_UserId",
                table: "PortfolioDetails",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StockDetails_PortfolioId",
                table: "StockDetails",
                column: "PortfolioId");

            migrationBuilder.CreateIndex(
                name: "IX_StockDetails_StockId",
                table: "StockDetails",
                column: "StockId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MutualFundDetails");

            migrationBuilder.DropTable(
                name: "StockDetails");

            migrationBuilder.DropTable(
                name: "MutualFundPriceDetails");

            migrationBuilder.DropTable(
                name: "PortfolioDetails");

            migrationBuilder.DropTable(
                name: "StockPriceDetails");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}