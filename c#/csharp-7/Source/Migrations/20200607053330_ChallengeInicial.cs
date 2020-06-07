using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Source.Migrations
{
    public partial class ChallengeInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "challenge",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(maxLength: 100, nullable: false),
                    slug = table.Column<string>(maxLength: 50, nullable: false),
                    created_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_challenge", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "company",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(maxLength: 100, nullable: false),
                    slug = table.Column<string>(maxLength: 50, nullable: false),
                    created_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_company", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    full_name = table.Column<string>(maxLength: 100, nullable: false),
                    email = table.Column<string>(maxLength: 100, nullable: false),
                    nickname = table.Column<string>(maxLength: 50, nullable: false),
                    password = table.Column<string>(maxLength: 255, nullable: false),
                    created_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "acceleration",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    challenge_id = table.Column<int>(nullable: false),
                    name = table.Column<string>(maxLength: 100, nullable: false),
                    slug = table.Column<string>(maxLength: 50, nullable: false),
                    created_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_acceleration", x => x.id);
                    table.ForeignKey(
                        name: "FK_Acceleration_Challenge",
                        column: x => x.challenge_id,
                        principalTable: "challenge",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "submission",
                columns: table => new
                {
                    user_id = table.Column<int>(nullable: false),
                    challenge_id = table.Column<int>(nullable: false),
                    score = table.Column<string>(nullable: false),
                    created_at = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: true),
                    ChallengeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_submission", x => new { x.user_id, x.challenge_id });
                    table.ForeignKey(
                        name: "FK_submission_challenge_ChallengeId",
                        column: x => x.ChallengeId,
                        principalTable: "challenge",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_submission_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "candidate",
                columns: table => new
                {
                    user_id = table.Column<int>(nullable: false),
                    acceleration_id = table.Column<int>(nullable: false),
                    company_id = table.Column<int>(nullable: false),
                    status = table.Column<int>(nullable: false),
                    created_at = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: true),
                    AccelerationId = table.Column<int>(nullable: true),
                    CompanyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_candidate", x => new { x.user_id, x.acceleration_id, x.company_id });
                    table.ForeignKey(
                        name: "FK_candidate_acceleration_AccelerationId",
                        column: x => x.AccelerationId,
                        principalTable: "acceleration",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_candidate_company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_candidate_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_acceleration_challenge_id",
                table: "acceleration",
                column: "challenge_id");

            migrationBuilder.CreateIndex(
                name: "IX_candidate_AccelerationId",
                table: "candidate",
                column: "AccelerationId");

            migrationBuilder.CreateIndex(
                name: "IX_candidate_CompanyId",
                table: "candidate",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_candidate_UserId",
                table: "candidate",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_submission_ChallengeId",
                table: "submission",
                column: "ChallengeId");

            migrationBuilder.CreateIndex(
                name: "IX_submission_UserId",
                table: "submission",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "candidate");

            migrationBuilder.DropTable(
                name: "submission");

            migrationBuilder.DropTable(
                name: "acceleration");

            migrationBuilder.DropTable(
                name: "company");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "challenge");
        }
    }
}
