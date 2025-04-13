using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "owner",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    owner_name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_owner", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "place",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    u_r_l = table.Column<string>(type: "text", nullable: false),
                    address = table.Column<string>(type: "text", nullable: false),
                    width = table.Column<double>(type: "double precision", nullable: false),
                    longitude = table.Column<double>(type: "double precision", nullable: false),
                    owner_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_place", x => x.id);
                    table.ForeignKey(
                        name: "FK_place_owner_owner_id",
                        column: x => x.owner_id,
                        principalSchema: "public",
                        principalTable: "owner",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "user",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    login = table.Column<string>(type: "text", nullable: false),
                    password_hash = table.Column<string>(type: "text", nullable: false),
                    password_salt = table.Column<string>(type: "text", nullable: false),
                    system_role = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    banned_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    invited_by_id = table.Column<Guid>(type: "uuid", nullable: true),
                    owner_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_owner_owner_id",
                        column: x => x.owner_id,
                        principalSchema: "public",
                        principalTable: "owner",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_user_user_invited_by_id",
                        column: x => x.invited_by_id,
                        principalSchema: "public",
                        principalTable: "user",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "user_token",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    refresh_token = table.Column<string>(type: "text", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    expiration_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_token", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_token_user_user_id",
                        column: x => x.user_id,
                        principalSchema: "public",
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "event",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    welcome_speech = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    newlyweds = table.Column<string>(type: "text", nullable: false),
                    place_id = table.Column<long>(type: "bigint", nullable: false),
                    photo_id = table.Column<long>(type: "bigint", nullable: false),
                    owner_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_event", x => x.id);
                    table.ForeignKey(
                        name: "FK_event_owner_owner_id",
                        column: x => x.owner_id,
                        principalSchema: "public",
                        principalTable: "owner",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_event_place_place_id",
                        column: x => x.place_id,
                        principalSchema: "public",
                        principalTable: "place",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "guest",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    is_come = table.Column<bool>(type: "boolean", nullable: true),
                    need_transfer = table.Column<bool>(type: "boolean", nullable: true),
                    couple_name = table.Column<string>(type: "text", nullable: true),
                    event_id = table.Column<long>(type: "bigint", nullable: false),
                    alcohol = table.Column<int[]>(type: "integer[]", nullable: true),
                    message_type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_guest", x => x.id);
                    table.ForeignKey(
                        name: "FK_guest_event_event_id",
                        column: x => x.event_id,
                        principalSchema: "public",
                        principalTable: "event",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "photo",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    file_name = table.Column<string>(type: "text", nullable: false),
                    event_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_photo", x => x.id);
                    table.ForeignKey(
                        name: "FK_photo_event_event_id",
                        column: x => x.event_id,
                        principalSchema: "public",
                        principalTable: "event",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "schedule",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    time = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    event_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_schedule", x => x.id);
                    table.ForeignKey(
                        name: "FK_schedule_event_event_id",
                        column: x => x.event_id,
                        principalSchema: "public",
                        principalTable: "event",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_event_owner_id",
                schema: "public",
                table: "event",
                column: "owner_id");

            migrationBuilder.CreateIndex(
                name: "IX_event_place_id",
                schema: "public",
                table: "event",
                column: "place_id");

            migrationBuilder.CreateIndex(
                name: "IX_guest_event_id",
                schema: "public",
                table: "guest",
                column: "event_id");

            migrationBuilder.CreateIndex(
                name: "IX_photo_event_id",
                schema: "public",
                table: "photo",
                column: "event_id");

            migrationBuilder.CreateIndex(
                name: "IX_place_owner_id",
                schema: "public",
                table: "place",
                column: "owner_id");

            migrationBuilder.CreateIndex(
                name: "IX_schedule_event_id",
                schema: "public",
                table: "schedule",
                column: "event_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_invited_by_id",
                schema: "public",
                table: "user",
                column: "invited_by_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_owner_id",
                schema: "public",
                table: "user",
                column: "owner_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_token_user_id",
                schema: "public",
                table: "user_token",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_event_photo_photo_id",
                schema: "public",
                table: "event",
                column: "photo_id",
                principalSchema: "public",
                principalTable: "photo",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_event_owner_owner_id",
                schema: "public",
                table: "event");

            migrationBuilder.DropForeignKey(
                name: "FK_place_owner_owner_id",
                schema: "public",
                table: "place");

            migrationBuilder.DropForeignKey(
                name: "FK_event_photo_photo_id",
                schema: "public",
                table: "event");

            migrationBuilder.DropTable(
                name: "guest",
                schema: "public");

            migrationBuilder.DropTable(
                name: "schedule",
                schema: "public");

            migrationBuilder.DropTable(
                name: "user_token",
                schema: "public");

            migrationBuilder.DropTable(
                name: "user",
                schema: "public");

            migrationBuilder.DropTable(
                name: "owner",
                schema: "public");

            migrationBuilder.DropTable(
                name: "photo",
                schema: "public");

            migrationBuilder.DropTable(
                name: "event",
                schema: "public");

            migrationBuilder.DropTable(
                name: "place",
                schema: "public");
        }
    }
}
