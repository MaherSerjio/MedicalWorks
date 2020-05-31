using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment2.Migrations
{
    public partial class AddPolicyDomainClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PolicyId",
                table: "Claims",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PolicyId",
                table: "Beneficiaries",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Policies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Effective = table.Column<DateTime>(nullable: false),
                    Expiry = table.Column<DateTime>(nullable: false),
                    Premium = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    IsValid = table.Column<bool>(nullable: false),
                    Police_No = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policies", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Claims_PolicyId",
                table: "Claims",
                column: "PolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_PolicyId",
                table: "Beneficiaries",
                column: "PolicyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Beneficiaries_Policies_PolicyId",
                table: "Beneficiaries",
                column: "PolicyId",
                principalTable: "Policies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Claims_Policies_PolicyId",
                table: "Claims",
                column: "PolicyId",
                principalTable: "Policies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beneficiaries_Policies_PolicyId",
                table: "Beneficiaries");

            migrationBuilder.DropForeignKey(
                name: "FK_Claims_Policies_PolicyId",
                table: "Claims");

            migrationBuilder.DropTable(
                name: "Policies");

            migrationBuilder.DropIndex(
                name: "IX_Claims_PolicyId",
                table: "Claims");

            migrationBuilder.DropIndex(
                name: "IX_Beneficiaries_PolicyId",
                table: "Beneficiaries");

            migrationBuilder.DropColumn(
                name: "PolicyId",
                table: "Claims");

            migrationBuilder.DropColumn(
                name: "PolicyId",
                table: "Beneficiaries");
        }
    }
}
