using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SignalRPizzaOrder.Client.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    Password = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    FullName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Type = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CategoryName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Password = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ContactName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Address = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Phone = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    SupplierId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CompanyName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Address = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.SupplierId);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderDate = table.Column<DateOnly>(type: "date", nullable: true),
                    RequiredDate = table.Column<DateOnly>(type: "date", nullable: true),
                    ShippedDate = table.Column<DateOnly>(type: "date", nullable: true),
                    Freight = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    ShipAddress = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    CustomerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Order_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    QuantityPerUnit = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    UnitPrice = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    ProductImage = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    SupplierId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Product_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Supplier",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UnitPrice = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    Quantity = table.Column<int>(type: "integer", nullable: true),
                    OrderId = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetailId);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "FullName", "Password", "Type", "UserName" },
                values: new object[,]
                {
                    { 1, "John Doe", "password123", "Savings", "johndoe" },
                    { 2, "Jane Smith", "mypassword", "Checking", "janesmith" },
                    { 3, "Michael Johnson", "securepass", "Business", "michaelj" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName", "Description" },
                values: new object[,]
                {
                    { 1, "Electronics", "Electronic Items" },
                    { 2, "Clothing", "Clothing Items" },
                    { 3, "Grocery", "Grocery Items" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerID", "Address", "ContactName", "Password", "Phone" },
                values: new object[,]
                {
                    { 1, "123 Maple Street, Springfield", "Alice Johnson", "alice123", "555-1234" },
                    { 2, "456 Oak Avenue, Rivertown", "Bob Smith", "bobsecure", "555-5678" },
                    { 3, "789 Pine Road, Lakeview", "Catherine Lee", "catlee2024", "555-9012" }
                });

            migrationBuilder.InsertData(
                table: "Supplier",
                columns: new[] { "SupplierId", "Address", "CompanyName", "Phone" },
                values: new object[,]
                {
                    { 1, "123 Tech Lane, Silicon Valley", "Tech Supplies Inc.", "555-1234" },
                    { 2, "456 Audio Street, Music City", "Sound Systems Co.", "555-5678" },
                    { 3, "789 Device Road, Innovation Park", "Gadget World", "555-9012" }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "OrderId", "CustomerId", "Freight", "OrderDate", "RequiredDate", "ShipAddress", "ShippedDate" },
                values: new object[,]
                {
                    { 1, 1, 25.50m, new DateOnly(2024, 9, 1), new DateOnly(2024, 9, 10), "123 Elm Street, Springfield", new DateOnly(2024, 9, 5) },
                    { 2, 2, 15.75m, new DateOnly(2024, 8, 15), new DateOnly(2024, 8, 25), "456 Oak Avenue, Rivertown", new DateOnly(2024, 8, 20) },
                    { 3, 3, 30.00m, new DateOnly(2024, 7, 20), new DateOnly(2024, 7, 30), "789 Pine Road, Lakeview", new DateOnly(2024, 7, 25) }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "CategoryId", "ProductImage", "ProductName", "QuantityPerUnit", "SupplierId", "UnitPrice" },
                values: new object[,]
                {
                    { 1, 1, "headphones.jpg", "Wireless Headphones", "1 pair", 1, 50.00m },
                    { 2, 1, "speaker.jpg", "Bluetooth Speaker", "1 piece", 2, 25.00m },
                    { 3, 2, "smartwatch.jpg", "Smartwatch", "1 piece", 3, 100.00m }
                });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "OrderDetailId", "OrderId", "ProductId", "Quantity", "UnitPrice" },
                values: new object[,]
                {
                    { 1, 1, 1, 2, 50.00m },
                    { 2, 2, 2, 5, 25.00m },
                    { 3, 3, 3, 1, 100.00m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                table: "Order",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_SupplierId",
                table: "Product",
                column: "SupplierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Supplier");
        }
    }
}
