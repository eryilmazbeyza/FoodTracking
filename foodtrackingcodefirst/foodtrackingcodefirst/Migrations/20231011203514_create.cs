using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace foodtrackingcodefirst.Migrations
{
    public partial class create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "nutritions",
                columns: table => new
                {
                    NutritionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NutritionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vitamins = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Minerals = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhisicalActivity = table.Column<bool>(type: "bit", nullable: false),
                    BloodValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nutritions", x => x.NutritionID);
                });

            migrationBuilder.CreateTable(
                name: "patients",
                columns: table => new
                {
                    PatientID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    DiseaseID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patients", x => x.PatientID);
                });

            migrationBuilder.CreateTable(
                name: "diets",
                columns: table => new
                {
                    DietID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DietType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DietStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DietEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DietPlan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NutritionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_diets", x => x.DietID);
                    table.ForeignKey(
                        name: "FK_diets_nutritions_NutritionID",
                        column: x => x.NutritionID,
                        principalTable: "nutritions",
                        principalColumn: "NutritionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "clinics",
                columns: table => new
                {
                    ClinicID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClinicName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoctorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoctorSpecialty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClinicNumber = table.Column<int>(type: "int", nullable: false),
                    PatientID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clinics", x => x.ClinicID);
                    table.ForeignKey(
                        name: "FK_clinics_patients_PatientID",
                        column: x => x.PatientID,
                        principalTable: "patients",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "diseases",
                columns: table => new
                {
                    DiseaseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiseaseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SideEffects = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_diseases", x => x.DiseaseID);
                    table.ForeignKey(
                        name: "FK_diseases_patients_PatientID",
                        column: x => x.PatientID,
                        principalTable: "patients",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "meals",
                columns: table => new
                {
                    MealID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MealName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Calories = table.Column<int>(type: "int", nullable: false),
                    Protein = table.Column<int>(type: "int", nullable: false),
                    Carbs = table.Column<int>(type: "int", nullable: false),
                    Fat = table.Column<int>(type: "int", nullable: false),
                    DietID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_meals", x => x.MealID);
                    table.ForeignKey(
                        name: "FK_meals_diets_DietID",
                        column: x => x.DietID,
                        principalTable: "diets",
                        principalColumn: "DietID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_clinics_PatientID",
                table: "clinics",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_diets_NutritionID",
                table: "diets",
                column: "NutritionID");

            migrationBuilder.CreateIndex(
                name: "IX_diseases_PatientID",
                table: "diseases",
                column: "PatientID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_meals_DietID",
                table: "meals",
                column: "DietID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "clinics");

            migrationBuilder.DropTable(
                name: "diseases");

            migrationBuilder.DropTable(
                name: "meals");

            migrationBuilder.DropTable(
                name: "patients");

            migrationBuilder.DropTable(
                name: "diets");

            migrationBuilder.DropTable(
                name: "nutritions");
        }
    }
}
