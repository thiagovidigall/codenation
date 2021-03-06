﻿// <auto-generated />
using System;
using Codenation.Challenge.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Source.Migrations
{
    [DbContext(typeof(CodenationContext))]
    [Migration("20200607201729_ChallengeFist")]
    partial class ChallengeFist
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Codenation.Challenge.Models.Acceleration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Challenge_Id")
                        .HasColumnName("challenge_id");

                    b.Property<DateTime>("Created_At")
                        .HasColumnName("created_at");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasMaxLength(100);

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnName("slug")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("Challenge_Id");

                    b.ToTable("acceleration");
                });

            modelBuilder.Entity("Codenation.Challenge.Models.Candidate", b =>
                {
                    b.Property<int>("User_Id")
                        .HasColumnName("user_id");

                    b.Property<int>("Acceleration_Id")
                        .HasColumnName("acceleration_id");

                    b.Property<int>("Company_Id")
                        .HasColumnName("company_id");

                    b.Property<DateTime>("Created_At")
                        .HasColumnName("created_at");

                    b.Property<int>("Status")
                        .HasColumnName("status");

                    b.HasKey("User_Id", "Acceleration_Id", "Company_Id");

                    b.HasIndex("Acceleration_Id");

                    b.HasIndex("Company_Id");

                    b.ToTable("candidate");
                });

            modelBuilder.Entity("Codenation.Challenge.Models.Challenge", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created_At")
                        .HasColumnName("created_at");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasMaxLength(100);

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnName("slug")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("challenge");
                });

            modelBuilder.Entity("Codenation.Challenge.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created_At")
                        .HasColumnName("created_at");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasMaxLength(100);

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnName("slug")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("company");
                });

            modelBuilder.Entity("Codenation.Challenge.Models.Submission", b =>
                {
                    b.Property<int>("User_Id")
                        .HasColumnName("user_id");

                    b.Property<int>("Challenge_Id")
                        .HasColumnName("challenge_id");

                    b.Property<DateTime>("Created_At")
                        .HasColumnName("created_at");

                    b.Property<decimal>("Score")
                        .HasColumnName("score")
                        .HasColumnType("decimal(9,2)");

                    b.HasKey("User_Id", "Challenge_Id");

                    b.HasIndex("Challenge_Id");

                    b.ToTable("submission");
                });

            modelBuilder.Entity("Codenation.Challenge.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created_At")
                        .HasColumnName("created_at");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasMaxLength(100);

                    b.Property<string>("Full_Name")
                        .IsRequired()
                        .HasColumnName("full_name")
                        .HasMaxLength(100);

                    b.Property<string>("NickName")
                        .IsRequired()
                        .HasColumnName("nickname")
                        .HasMaxLength(50);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("password")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("user");
                });

            modelBuilder.Entity("Codenation.Challenge.Models.Acceleration", b =>
                {
                    b.HasOne("Codenation.Challenge.Models.Challenge", "Challenge")
                        .WithMany("Accelerations")
                        .HasForeignKey("Challenge_Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Codenation.Challenge.Models.Candidate", b =>
                {
                    b.HasOne("Codenation.Challenge.Models.Acceleration", "Acceleration")
                        .WithMany("Candidates")
                        .HasForeignKey("Acceleration_Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Codenation.Challenge.Models.Company", "Company")
                        .WithMany("Candidates")
                        .HasForeignKey("Company_Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Codenation.Challenge.Models.User", "User")
                        .WithMany("Candidates")
                        .HasForeignKey("User_Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Codenation.Challenge.Models.Submission", b =>
                {
                    b.HasOne("Codenation.Challenge.Models.Challenge", "Challenge")
                        .WithMany("Submissions")
                        .HasForeignKey("Challenge_Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Codenation.Challenge.Models.User", "User")
                        .WithMany("Submissions")
                        .HasForeignKey("User_Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
