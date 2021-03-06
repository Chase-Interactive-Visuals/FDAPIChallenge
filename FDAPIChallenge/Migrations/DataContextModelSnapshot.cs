// <auto-generated />
using System;
using FDAPIChallenge.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FDAPIChallenge.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FDAPIChallenge.Models.Aircraft", b =>
                {
                    b.Property<int>("AircraftId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AircraftId"), 1L, 1);

                    b.Property<int?>("AircraftTasksId")
                        .HasColumnType("int");

                    b.Property<double>("CurrentHours")
                        .HasColumnType("float");

                    b.Property<double>("DailyHours")
                        .HasColumnType("float");

                    b.HasKey("AircraftId");

                    b.HasIndex("AircraftTasksId");

                    b.ToTable("Aircrafts");
                });

            modelBuilder.Entity("FDAPIChallenge.Models.AircraftTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AircraftTasksId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IntervalHours")
                        .HasColumnType("int");

                    b.Property<int?>("IntervalMonths")
                        .HasColumnType("int");

                    b.Property<int>("ItemNumber")
                        .HasColumnType("int");

                    b.Property<DateTime>("LogDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LogHours")
                        .HasColumnType("int");

                    b.Property<DateTime?>("NextDue")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AircraftTasksId");

                    b.ToTable("AircraftTask");
                });

            modelBuilder.Entity("FDAPIChallenge.Models.AircraftTasks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.HasKey("Id");

                    b.ToTable("AircraftTasks");
                });

            modelBuilder.Entity("FDAPIChallenge.Models.Aircraft", b =>
                {
                    b.HasOne("FDAPIChallenge.Models.AircraftTasks", "AircraftTasks")
                        .WithMany()
                        .HasForeignKey("AircraftTasksId");

                    b.Navigation("AircraftTasks");
                });

            modelBuilder.Entity("FDAPIChallenge.Models.AircraftTask", b =>
                {
                    b.HasOne("FDAPIChallenge.Models.AircraftTasks", null)
                        .WithMany("AricraftTaskSet")
                        .HasForeignKey("AircraftTasksId");
                });

            modelBuilder.Entity("FDAPIChallenge.Models.AircraftTasks", b =>
                {
                    b.Navigation("AricraftTaskSet");
                });
#pragma warning restore 612, 618
        }
    }
}
