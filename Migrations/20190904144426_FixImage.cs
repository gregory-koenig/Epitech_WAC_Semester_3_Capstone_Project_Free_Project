using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ccsrb.Migrations
{
    public partial class FixImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Picture",
                table: "Images",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Picture",
                table: "Images",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
