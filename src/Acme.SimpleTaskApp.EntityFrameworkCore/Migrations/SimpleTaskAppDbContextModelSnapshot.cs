﻿// <auto-generated />
using System;
using Acme.SimpleTaskApp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Acme.SimpleTaskApp.Migrations
{
    [DbContext(typeof(SimpleTaskAppDbContext))]
    partial class SimpleTaskAppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Acme.SimpleTaskApp.People.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationTime");

                    b.Property<long?>("CreatorUserId");

                    b.Property<DateTime?>("LastModificationTime");

                    b.Property<long?>("LastModifierUserId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.HasKey("Id");

                    b.ToTable("AppPersons");
                });

            modelBuilder.Entity("Acme.SimpleTaskApp.Tasks.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid?>("AssignedPersonId");

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("Description")
                        .HasMaxLength(65536);

                    b.Property<byte>("State");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("AssignedPersonId");

                    b.ToTable("AppTasks");
                });

            modelBuilder.Entity("Acme.SimpleTaskApp.Tasks.Task", b =>
                {
                    b.HasOne("Acme.SimpleTaskApp.People.Person", "AssignedPerson")
                        .WithMany()
                        .HasForeignKey("AssignedPersonId");
                });
#pragma warning restore 612, 618
        }
    }
}
