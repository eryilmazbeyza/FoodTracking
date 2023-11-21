﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using foodtrackingcodefirst.Models;

namespace foodtrackingcodefirst.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231011203514_create")]
    partial class create
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("foodtrackingcodefirst.Models.Clinic", b =>
                {
                    b.Property<int>("ClinicID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClinicName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ClinicNumber")
                        .HasColumnType("int");

                    b.Property<string>("DoctorName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DoctorSpecialty")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PatientID")
                        .HasColumnType("int");

                    b.HasKey("ClinicID");

                    b.HasIndex("PatientID");

                    b.ToTable("clinics");
                });

            modelBuilder.Entity("foodtrackingcodefirst.Models.Diet", b =>
                {
                    b.Property<int>("DietID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DietEnd")
                        .HasColumnType("datetime2");

                    b.Property<string>("DietPlan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DietStart")
                        .HasColumnType("datetime2");

                    b.Property<string>("DietType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NutritionID")
                        .HasColumnType("int");

                    b.HasKey("DietID");

                    b.HasIndex("NutritionID");

                    b.ToTable("diets");
                });

            modelBuilder.Entity("foodtrackingcodefirst.Models.Disease", b =>
                {
                    b.Property<int>("DiseaseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DiseaseName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PatientID")
                        .HasColumnType("int");

                    b.Property<string>("SideEffects")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DiseaseID");

                    b.HasIndex("PatientID")
                        .IsUnique();

                    b.ToTable("diseases");
                });

            modelBuilder.Entity("foodtrackingcodefirst.Models.Meal", b =>
                {
                    b.Property<int>("MealID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Calories")
                        .HasColumnType("int");

                    b.Property<int>("Carbs")
                        .HasColumnType("int");

                    b.Property<int>("DietID")
                        .HasColumnType("int");

                    b.Property<int>("Fat")
                        .HasColumnType("int");

                    b.Property<string>("MealName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Protein")
                        .HasColumnType("int");

                    b.HasKey("MealID");

                    b.HasIndex("DietID");

                    b.ToTable("meals");
                });

            modelBuilder.Entity("foodtrackingcodefirst.Models.Nutrition", b =>
                {
                    b.Property<int>("NutritionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BloodValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Minerals")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NutritionType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhisicalActivity")
                        .HasColumnType("bit");

                    b.Property<string>("Vitamins")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NutritionID");

                    b.ToTable("nutritions");
                });

            modelBuilder.Entity("foodtrackingcodefirst.Models.Patient", b =>
                {
                    b.Property<int>("PatientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("DiseaseID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<string>("PatientName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("PatientID");

                    b.ToTable("patients");
                });

            modelBuilder.Entity("foodtrackingcodefirst.Models.Clinic", b =>
                {
                    b.HasOne("foodtrackingcodefirst.Models.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("foodtrackingcodefirst.Models.Diet", b =>
                {
                    b.HasOne("foodtrackingcodefirst.Models.Nutrition", "Nutrition")
                        .WithMany()
                        .HasForeignKey("NutritionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Nutrition");
                });

            modelBuilder.Entity("foodtrackingcodefirst.Models.Disease", b =>
                {
                    b.HasOne("foodtrackingcodefirst.Models.Patient", "Patient")
                        .WithOne("Disease")
                        .HasForeignKey("foodtrackingcodefirst.Models.Disease", "PatientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("foodtrackingcodefirst.Models.Meal", b =>
                {
                    b.HasOne("foodtrackingcodefirst.Models.Diet", "Diet")
                        .WithMany()
                        .HasForeignKey("DietID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Diet");
                });

            modelBuilder.Entity("foodtrackingcodefirst.Models.Patient", b =>
                {
                    b.Navigation("Disease");
                });
#pragma warning restore 612, 618
        }
    }
}
