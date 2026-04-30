using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HX.MCPServer.Repository.Migrations
{
    /// <inheritdoc />
    public partial class SyncPolicyModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Core",
                table: "Policy",
                keyColumn: "Id",
                keyValue: new Guid("2b3c4d5e-6f7a-8b9c-0d1e-2f3a4b5c6d7e"),
                column: "Producer",
                value: "InsureMax Program");

            migrationBuilder.UpdateData(
                schema: "Core",
                table: "Policy",
                keyColumn: "Id",
                keyValue: new Guid("3c4d5e6f-7a8b-9c0d-1e2f-3a4b5c6d7e8f"),
                column: "Carrier",
                value: "InsureMax Insurance");

            migrationBuilder.UpdateData(
                schema: "Core",
                table: "Policy",
                keyColumn: "Id",
                keyValue: new Guid("4d5e6f7a-8b9c-0d1e-2f3a-4b5c6d7e8f9a"),
                column: "Carrier",
                value: "AssuranceAmerica Insurance");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Core",
                table: "Policy",
                keyColumn: "Id",
                keyValue: new Guid("2b3c4d5e-6f7a-8b9c-0d1e-2f3a4b5c6d7e"),
                column: "Producer",
                value: "Smith & Associates Insurance");

            migrationBuilder.UpdateData(
                schema: "Core",
                table: "Policy",
                keyColumn: "Id",
                keyValue: new Guid("3c4d5e6f-7a8b-9c0d-1e2f-3a4b5c6d7e8f"),
                column: "Carrier",
                value: "Travelers Insurance");

            migrationBuilder.UpdateData(
                schema: "Core",
                table: "Policy",
                keyColumn: "Id",
                keyValue: new Guid("4d5e6f7a-8b9c-0d1e-2f3a-4b5c6d7e8f9a"),
                column: "Carrier",
                value: "Nationwide Insurance");
        }
    }
}
