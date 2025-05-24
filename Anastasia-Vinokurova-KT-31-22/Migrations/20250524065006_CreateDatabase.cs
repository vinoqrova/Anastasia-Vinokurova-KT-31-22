using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Anastasia_Vinokurova_KT_31_22.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Academic_degree",
                columns: table => new
                {
                    c_Academic_degree_id = table.Column<int>(type: "int", nullable: false, comment: "Bltynbabrfnjh cntgtyb")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_Academic_degree_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Название степени (например, кандидат наук)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Academic_degree_Academic_degree_id", x => x.c_Academic_degree_id);
                });

            migrationBuilder.CreateTable(
                name: "Тitle",
                columns: table => new
                {
                    Тitle_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор должности")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_Тitle_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Название должности (например, доцент)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Тitle_Тitle_id", x => x.Тitle_id);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    subject_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор предмета")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_subject_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Название предмета"),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false, comment: "Помечено как удалённое (soft-delete)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Subject_subject_id", x => x.subject_id);
                });

            migrationBuilder.CreateTable(
                name: "faculty",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор кафедры")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_faculty_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Название кафедры"),
                    c_admin_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор администратора(заведующего) кафедры")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_faculty_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prepod",
                columns: table => new
                {
                    prepod_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор препода")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_prepod_firstname = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "Имя препода"),
                    c_prepod_lastname = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "Фамилия препода"),
                    c_prepod_midname = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "Отчество препода"),
                    c_Academic_degree_id = table.Column<int>(type: "int", nullable: false, comment: "Степень(учёная) преподавателя"),
                    c_Тitle_id = table.Column<int>(type: "int", nullable: false, comment: "Должность преподавателя"),
                    c_faculty_id = table.Column<int>(type: "int", nullable: false, comment: "Айди кафедры")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Prepod_prepod_id", x => x.prepod_id);
                    table.ForeignKey(
                        name: "fk_Academic_degree_id",
                        column: x => x.c_Academic_degree_id,
                        principalTable: "Academic_degree",
                        principalColumn: "c_Academic_degree_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_f_group_id",
                        column: x => x.c_faculty_id,
                        principalTable: "faculty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_Тitle_id",
                        column: x => x.c_Тitle_id,
                        principalTable: "Тitle",
                        principalColumn: "Тitle_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    para_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор занятия")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_subject_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор предмета"),
                    c_prepod_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор преподавателя"),
                    c_schedule_day_of_week = table.Column<byte>(type: "tinyint", nullable: false, comment: "День недели (1-6 = Пн-Сб)"),
                    c_schedule_order_in_day = table.Column<byte>(type: "tinyint", nullable: false, comment: "Порядок занятия в дне (1-8)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Schedule_Id", x => x.para_id);
                    table.ForeignKey(
                        name: "fk_prepod_id",
                        column: x => x.c_prepod_id,
                        principalTable: "Prepod",
                        principalColumn: "prepod_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_subject_id",
                        column: x => x.c_subject_id,
                        principalTable: "Subject",
                        principalColumn: "subject_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "idx_faculty_fk_admin_id_prepod_id",
                table: "faculty",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_faculty_c_admin_id",
                table: "faculty",
                column: "c_admin_id");

            migrationBuilder.CreateIndex(
                name: "idx_Prepod_fk_Academic_degree_id",
                table: "Prepod",
                column: "c_Academic_degree_id");

            migrationBuilder.CreateIndex(
                name: "idx_Prepod_fk_f_group_id",
                table: "Prepod",
                column: "c_faculty_id");

            migrationBuilder.CreateIndex(
                name: "idx_Prepod_fk_Тitle_id",
                table: "Prepod",
                column: "c_Тitle_id");

            migrationBuilder.CreateIndex(
                name: "idx_Schedule_fk_prepod_id",
                table: "Schedule",
                column: "c_prepod_id");

            migrationBuilder.CreateIndex(
                name: "idx_Schedule_fk_subject_id",
                table: "Schedule",
                column: "c_subject_id");

            migrationBuilder.AddForeignKey(
                name: "fk_admin_id_prepod_id",
                table: "faculty",
                column: "c_admin_id",
                principalTable: "Prepod",
                principalColumn: "prepod_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_admin_id_prepod_id",
                table: "faculty");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropTable(
                name: "Prepod");

            migrationBuilder.DropTable(
                name: "Academic_degree");

            migrationBuilder.DropTable(
                name: "faculty");

            migrationBuilder.DropTable(
                name: "Тitle");
        }
    }
}
