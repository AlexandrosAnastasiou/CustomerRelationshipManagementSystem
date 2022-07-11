using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerRelationshipManagementSystem.Migrations
{
    public partial class relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_CustomerCalls_Tbl_CustomerInfo_CustomerInfoCustomerId",
                table: "Tbl_CustomerCalls");

            migrationBuilder.RenameColumn(
                name: "CustomerInfoCustomerId",
                table: "Tbl_CustomerCalls",
                newName: "CustomerRefId");

            migrationBuilder.RenameIndex(
                name: "IX_Tbl_CustomerCalls_CustomerInfoCustomerId",
                table: "Tbl_CustomerCalls",
                newName: "IX_Tbl_CustomerCalls_CustomerRefId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_CustomerCalls_Tbl_CustomerInfo_CustomerRefId",
                table: "Tbl_CustomerCalls",
                column: "CustomerRefId",
                principalTable: "Tbl_CustomerInfo",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_CustomerCalls_Tbl_CustomerInfo_CustomerRefId",
                table: "Tbl_CustomerCalls");

            migrationBuilder.RenameColumn(
                name: "CustomerRefId",
                table: "Tbl_CustomerCalls",
                newName: "CustomerInfoCustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Tbl_CustomerCalls_CustomerRefId",
                table: "Tbl_CustomerCalls",
                newName: "IX_Tbl_CustomerCalls_CustomerInfoCustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_CustomerCalls_Tbl_CustomerInfo_CustomerInfoCustomerId",
                table: "Tbl_CustomerCalls",
                column: "CustomerInfoCustomerId",
                principalTable: "Tbl_CustomerInfo",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
