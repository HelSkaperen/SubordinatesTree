using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SubordinatesTree.Migrations
{
    public partial class treemigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "LeaderId",
                table: "Persons",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "LeaderId",
                table: "Persons",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
