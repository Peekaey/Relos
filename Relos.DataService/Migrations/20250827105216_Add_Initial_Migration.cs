using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Relos.DataService.Migrations
{
    /// <inheritdoc />
    public partial class Add_Initial_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedBySystemUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdatedBySystemUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: true),
                    ArchivedBySystemUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastLoginUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserOauthAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    AuthProvider = table.Column<int>(type: "integer", nullable: false),
                    Uuid = table.Column<string>(type: "text", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Avatar = table.Column<string>(type: "text", nullable: true),
                    CreatedBySystemUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdatedBySystemUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: true),
                    ArchivedBySystemUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOauthAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserOauthAccounts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Workspaces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WorkspaceName = table.Column<string>(type: "text", nullable: false),
                    WorkspaceDescription = table.Column<string>(type: "text", nullable: false),
                    WorkspaceOwnerId = table.Column<int>(type: "integer", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "integer", nullable: false),
                    LastUpdatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdatedByUserId = table.Column<int>(type: "integer", nullable: false),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: true),
                    ArchivedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ArchivedByUserId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workspaces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workspaces_Users_ArchivedByUserId",
                        column: x => x.ArchivedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Workspaces_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Workspaces_Users_LastUpdatedByUserId",
                        column: x => x.LastUpdatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Workspaces_Users_WorkspaceOwnerId",
                        column: x => x.WorkspaceOwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "integer", nullable: false),
                    LastUpdatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdatedByUserId = table.Column<int>(type: "integer", nullable: false),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: true),
                    ArchivedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ArchivedByUserId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    PrimaryNumber = table.Column<string>(type: "text", nullable: true),
                    SecondaryNumber = table.Column<string>(type: "text", nullable: true),
                    Position = table.Column<string>(type: "text", nullable: true),
                    CompanyName = table.Column<string>(type: "text", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: true),
                    WorkspaceId = table.Column<int>(type: "integer", nullable: false),
                    ContactId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contacts_Users_ArchivedByUserId",
                        column: x => x.ArchivedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contacts_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contacts_Users_LastUpdatedByUserId",
                        column: x => x.LastUpdatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contacts_Workspaces_WorkspaceId",
                        column: x => x.WorkspaceId,
                        principalTable: "Workspaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomContactFieldTemplate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "integer", nullable: false),
                    LastUpdatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdatedByUserId = table.Column<int>(type: "integer", nullable: false),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: true),
                    ArchivedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ArchivedByUserId = table.Column<int>(type: "integer", nullable: true),
                    ContactFieldType = table.Column<int>(type: "integer", nullable: false),
                    FieldName = table.Column<string>(type: "text", nullable: false),
                    WorkspaceId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomContactFieldTemplate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomContactFieldTemplate_Users_ArchivedByUserId",
                        column: x => x.ArchivedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CustomContactFieldTemplate_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomContactFieldTemplate_Users_LastUpdatedByUserId",
                        column: x => x.LastUpdatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomContactFieldTemplate_Workspaces_WorkspaceId",
                        column: x => x.WorkspaceId,
                        principalTable: "Workspaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_ArchivedByUserId",
                table: "Contacts",
                column: "ArchivedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_ContactId",
                table: "Contacts",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_CreatedByUserId",
                table: "Contacts",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_LastUpdatedByUserId",
                table: "Contacts",
                column: "LastUpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_WorkspaceId",
                table: "Contacts",
                column: "WorkspaceId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomContactFieldTemplate_ArchivedByUserId",
                table: "CustomContactFieldTemplate",
                column: "ArchivedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomContactFieldTemplate_CreatedByUserId",
                table: "CustomContactFieldTemplate",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomContactFieldTemplate_LastUpdatedByUserId",
                table: "CustomContactFieldTemplate",
                column: "LastUpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomContactFieldTemplate_WorkspaceId",
                table: "CustomContactFieldTemplate",
                column: "WorkspaceId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOauthAccounts_UserId",
                table: "UserOauthAccounts",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Workspaces_ArchivedByUserId",
                table: "Workspaces",
                column: "ArchivedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Workspaces_CreatedByUserId",
                table: "Workspaces",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Workspaces_LastUpdatedByUserId",
                table: "Workspaces",
                column: "LastUpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Workspaces_WorkspaceOwnerId",
                table: "Workspaces",
                column: "WorkspaceOwnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "CustomContactFieldTemplate");

            migrationBuilder.DropTable(
                name: "UserOauthAccounts");

            migrationBuilder.DropTable(
                name: "Workspaces");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
