using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace one_db_prototype_chilibean.Migrations.SqliteMigrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "club_main_tbl",
                columns: table => new
                {
                    club_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    club_name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_club_main_tbl", x => x.club_id);
                });

            migrationBuilder.CreateTable(
                name: "activity_profile_tbl",
                columns: table => new
                {
                    activity_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    club_id = table.Column<int>(type: "INTEGER", nullable: false),
                    person_in_charge = table.Column<string>(type: "TEXT", nullable: false),
                    activity_title = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    club_id1 = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_activity_profile_tbl", x => x.activity_id);
                    table.ForeignKey(
                        name: "FK_activity_profile_tbl_club_main_tbl_club_id",
                        column: x => x.club_id,
                        principalTable: "club_main_tbl",
                        principalColumn: "club_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_activity_profile_tbl_club_main_tbl_club_id1",
                        column: x => x.club_id1,
                        principalTable: "club_main_tbl",
                        principalColumn: "club_id");
                });

            migrationBuilder.CreateTable(
                name: "activity_brief_tbl",
                columns: table => new
                {
                    activity_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    activity_brief_description = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    activity_date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_activity_brief_tbl", x => x.activity_id);
                    table.ForeignKey(
                        name: "FK_activity_brief_tbl_activity_profile_tbl_activity_id",
                        column: x => x.activity_id,
                        principalTable: "activity_profile_tbl",
                        principalColumn: "activity_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "activity_budget_plan_tbl",
                columns: table => new
                {
                    budget_plan_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    activity_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    item_name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    price = table.Column<decimal>(type: "TEXT", nullable: false),
                    quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_activity_budget_plan_tbl", x => x.budget_plan_id);
                    table.ForeignKey(
                        name: "FK_activity_budget_plan_tbl_activity_profile_tbl_activity_id",
                        column: x => x.activity_id,
                        principalTable: "activity_profile_tbl",
                        principalColumn: "activity_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "activity_detail_tbl",
                columns: table => new
                {
                    activity_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    activity_rationale = table.Column<string>(type: "TEXT", maxLength: 5000, nullable: false),
                    activity_objectives = table.Column<string>(type: "TEXT", maxLength: 5000, nullable: false),
                    activity_activity_type = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    activity_activity_reach = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_activity_detail_tbl", x => x.activity_id);
                    table.ForeignKey(
                        name: "FK_activity_detail_tbl_activity_profile_tbl_activity_id",
                        column: x => x.activity_id,
                        principalTable: "activity_profile_tbl",
                        principalColumn: "activity_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "activity_status_tbl",
                columns: table => new
                {
                    activity_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    activity_overall_status = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    is_draft = table.Column<bool>(type: "INTEGER", nullable: false),
                    admin_1_status = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    admin_2_status = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    admin_3_status = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    checked_date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_activity_status_tbl", x => x.activity_id);
                    table.ForeignKey(
                        name: "FK_activity_status_tbl_activity_profile_tbl_activity_id",
                        column: x => x.activity_id,
                        principalTable: "activity_profile_tbl",
                        principalColumn: "activity_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "remarks_activity_tbl",
                columns: table => new
                {
                    activity_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    activity_title_remark = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    activity_brief_description_remark = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    rationale_remark = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    objectives_remark = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    activity_type_remark = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    activity_date_remark = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    activity_reach_remark = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    activity_budget_remark = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_remarks_activity_tbl", x => x.activity_id);
                    table.ForeignKey(
                        name: "FK_remarks_activity_tbl_activity_profile_tbl_activity_id",
                        column: x => x.activity_id,
                        principalTable: "activity_profile_tbl",
                        principalColumn: "activity_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_activity_budget_plan_tbl_activity_id",
                table: "activity_budget_plan_tbl",
                column: "activity_id");

            migrationBuilder.CreateIndex(
                name: "IX_activity_profile_tbl_club_id",
                table: "activity_profile_tbl",
                column: "club_id");

            migrationBuilder.CreateIndex(
                name: "IX_activity_profile_tbl_club_id1",
                table: "activity_profile_tbl",
                column: "club_id1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "activity_brief_tbl");

            migrationBuilder.DropTable(
                name: "activity_budget_plan_tbl");

            migrationBuilder.DropTable(
                name: "activity_detail_tbl");

            migrationBuilder.DropTable(
                name: "activity_status_tbl");

            migrationBuilder.DropTable(
                name: "remarks_activity_tbl");

            migrationBuilder.DropTable(
                name: "activity_profile_tbl");

            migrationBuilder.DropTable(
                name: "club_main_tbl");
        }
    }
}
