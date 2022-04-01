﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportsStore.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up( MigrationBuilder migrationBuilder )
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<long>( type: "bigint", nullable: false )
                        .Annotation( "SqlServer:Identity", "1, 1" ),
                    Name = table.Column<string>( type: "nvarchar(max)", nullable: false ),
                    Description = table.Column<string>( type: "nvarchar(max)", nullable: false ),
                    Price = table.Column<decimal>( type: "decimal(18,2)", nullable: false ),
                    Category = table.Column<string>( type: "nvarchar(max)", nullable: false )
                },
                constraints: table =>
                {
                    table.PrimaryKey( "PK_Products", x => x.ProductID );
                } );
        }

        protected override void Down( MigrationBuilder migrationBuilder )
        {
            migrationBuilder.DropTable(
                name: "Products" );
        }
    }
}
