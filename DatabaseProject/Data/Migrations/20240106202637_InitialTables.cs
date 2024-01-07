using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseProject.Data.Migrations
{
    public partial class InitialTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "authors",
                columns: table => new
                {
                    author_id = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: false),
                    author_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    author_surname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    author_age = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_authors", x => x.author_id);
                });

            migrationBuilder.CreateTable(
                name: "co_supervisors",
                columns: table => new
                {
                    co_sup_id = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: false),
                    co_sup_name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    co_sup_surname = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    co_sup_age = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__co_super__CB64971F52E984BA", x => x.co_sup_id);
                });

            migrationBuilder.CreateTable(
                name: "subject_topics",
                columns: table => new
                {
                    st_id = table.Column<int>(type: "int", nullable: false),
                    st_name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__subject___A85E81CF42660A42", x => x.st_id);
                });

            migrationBuilder.CreateTable(
                name: "supervisors",
                columns: table => new
                {
                    sup_id = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: false),
                    sup_name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    sup_surname = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    sup_age = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__supervis__FB8F785F52102143", x => x.sup_id);
                });

            migrationBuilder.CreateTable(
                name: "university",
                columns: table => new
                {
                    uni_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    uni_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    uni_address = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__universi__5D928CDE0B495EF1", x => x.uni_id);
                });

            migrationBuilder.CreateTable(
                name: "institutes",
                columns: table => new
                {
                    ins_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ins_name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    uni_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__institut__9CB72D20BE7905B8", x => x.ins_id);
                    table.ForeignKey(
                        name: "FK__institute__uni_i__7F2BE32F",
                        column: x => x.uni_id,
                        principalTable: "university",
                        principalColumn: "uni_id");
                });

            migrationBuilder.CreateTable(
                name: "thesis",
                columns: table => new
                {
                    thesis_no = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    @abstract = table.Column<string>(name: "abstract", type: "text", nullable: false),
                    author_id = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: false),
                    type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    uni_id = table.Column<int>(type: "int", nullable: false),
                    ins_id = table.Column<int>(type: "int", nullable: false),
                    num_pages = table.Column<int>(type: "int", nullable: false),
                    language = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    submission_date = table.Column<DateTime>(type: "date", nullable: false),
                    sup_id = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: true),
                    co_sup_id = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__thesis__50ACADFD0B7433F7", x => x.thesis_no);
                    table.ForeignKey(
                        name: "FK__thesis__author_i__03F0984C",
                        column: x => x.author_id,
                        principalTable: "authors",
                        principalColumn: "author_id");
                    table.ForeignKey(
                        name: "FK__thesis__co_sup_i__07C12930",
                        column: x => x.co_sup_id,
                        principalTable: "co_supervisors",
                        principalColumn: "co_sup_id");
                    table.ForeignKey(
                        name: "FK__thesis__ins_id__05D8E0BE",
                        column: x => x.ins_id,
                        principalTable: "institutes",
                        principalColumn: "ins_id");
                    table.ForeignKey(
                        name: "FK__thesis__sup_id__06CD04F7",
                        column: x => x.sup_id,
                        principalTable: "supervisors",
                        principalColumn: "sup_id");
                    table.ForeignKey(
                        name: "FK__thesis__uni_id__04E4BC85",
                        column: x => x.uni_id,
                        principalTable: "university",
                        principalColumn: "uni_id");
                });

            migrationBuilder.CreateTable(
                name: "keywords",
                columns: table => new
                {
                    key_id = table.Column<int>(type: "int", nullable: false),
                    key_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    thesis_no = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__keywords__97DF9ACD6DA19E79", x => x.key_id);
                    table.ForeignKey(
                        name: "FK__keywords__thesis__0A9D95DB",
                        column: x => x.thesis_no,
                        principalTable: "thesis",
                        principalColumn: "thesis_no");
                });

            migrationBuilder.CreateTable(
                name: "t_subjects",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    thesis_no = table.Column<int>(type: "int", nullable: true),
                    st_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_subjects", x => x.id);
                    table.ForeignKey(
                        name: "FK__t_subject__st_id__10566F31",
                        column: x => x.st_id,
                        principalTable: "subject_topics",
                        principalColumn: "st_id");
                    table.ForeignKey(
                        name: "FK__t_subject__thesi__0F624AF8",
                        column: x => x.thesis_no,
                        principalTable: "thesis",
                        principalColumn: "thesis_no");
                });

            migrationBuilder.CreateIndex(
                name: "IX_institutes_uni_id",
                table: "institutes",
                column: "uni_id");

            migrationBuilder.CreateIndex(
                name: "IX_keywords_thesis_no",
                table: "keywords",
                column: "thesis_no");

            migrationBuilder.CreateIndex(
                name: "IX_t_subjects_st_id",
                table: "t_subjects",
                column: "st_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_subjects_thesis_no",
                table: "t_subjects",
                column: "thesis_no");

            migrationBuilder.CreateIndex(
                name: "IX_thesis_author_id",
                table: "thesis",
                column: "author_id");

            migrationBuilder.CreateIndex(
                name: "IX_thesis_co_sup_id",
                table: "thesis",
                column: "co_sup_id");

            migrationBuilder.CreateIndex(
                name: "IX_thesis_ins_id",
                table: "thesis",
                column: "ins_id");

            migrationBuilder.CreateIndex(
                name: "IX_thesis_sup_id",
                table: "thesis",
                column: "sup_id");

            migrationBuilder.CreateIndex(
                name: "IX_thesis_uni_id",
                table: "thesis",
                column: "uni_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "keywords");

            migrationBuilder.DropTable(
                name: "t_subjects");

            migrationBuilder.DropTable(
                name: "subject_topics");

            migrationBuilder.DropTable(
                name: "thesis");

            migrationBuilder.DropTable(
                name: "authors");

            migrationBuilder.DropTable(
                name: "co_supervisors");

            migrationBuilder.DropTable(
                name: "institutes");

            migrationBuilder.DropTable(
                name: "supervisors");

            migrationBuilder.DropTable(
                name: "university");
        }
    }
}
