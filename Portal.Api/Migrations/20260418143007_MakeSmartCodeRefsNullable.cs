using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portal.Api.Migrations
{
    /// <inheritdoc />
    public partial class MakeSmartCodeRefsNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_SmartCodes_GenderIdentityId",
                table: "UserProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_SmartCodes_PrimaryLanguageId",
                table: "UserProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_SmartCodes_SexualIdentityId",
                table: "UserProfiles");

            migrationBuilder.AlterColumn<Guid>(
                name: "SexualIdentityId",
                table: "UserProfiles",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "PrimaryLanguageId",
                table: "UserProfiles",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "GenderIdentityId",
                table: "UserProfiles",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_SmartCodes_GenderIdentityId",
                table: "UserProfiles",
                column: "GenderIdentityId",
                principalTable: "SmartCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_SmartCodes_PrimaryLanguageId",
                table: "UserProfiles",
                column: "PrimaryLanguageId",
                principalTable: "SmartCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_SmartCodes_SexualIdentityId",
                table: "UserProfiles",
                column: "SexualIdentityId",
                principalTable: "SmartCodes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_SmartCodes_GenderIdentityId",
                table: "UserProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_SmartCodes_PrimaryLanguageId",
                table: "UserProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_SmartCodes_SexualIdentityId",
                table: "UserProfiles");

            migrationBuilder.AlterColumn<Guid>(
                name: "SexualIdentityId",
                table: "UserProfiles",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "PrimaryLanguageId",
                table: "UserProfiles",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "GenderIdentityId",
                table: "UserProfiles",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_SmartCodes_GenderIdentityId",
                table: "UserProfiles",
                column: "GenderIdentityId",
                principalTable: "SmartCodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_SmartCodes_PrimaryLanguageId",
                table: "UserProfiles",
                column: "PrimaryLanguageId",
                principalTable: "SmartCodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_SmartCodes_SexualIdentityId",
                table: "UserProfiles",
                column: "SexualIdentityId",
                principalTable: "SmartCodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
