﻿// <auto-generated />
using System;
using BetterTravel.DataAccess.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BetterTravel.DataAccess.EF.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BetterTravel.DataAccess.Abstraction.Entities.Chat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ChatID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("ChatId")
                        .HasColumnName("TelegramChatID")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Chat","dbo");
                });

            modelBuilder.Entity("BetterTravel.DataAccess.Abstraction.Entities.ChatSettings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ChatSettingsID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsSubscribed")
                        .HasColumnType("bit");

                    b.Property<int>("SettingsOfChatId")
                        .HasColumnName("SettingsOfChatID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SettingsOfChatId")
                        .IsUnique();

                    b.ToTable("ChatSettings");
                });

            modelBuilder.Entity("BetterTravel.DataAccess.Abstraction.Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("CountryID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Country","dbo");
                });

            modelBuilder.Entity("BetterTravel.DataAccess.Abstraction.Entities.DepartureLocation", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("DepartureLocationID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DepartureLocation","dbo");
                });

            modelBuilder.Entity("BetterTravel.DataAccess.Abstraction.Entities.HotTour", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("HotTourID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int?>("CountryId")
                        .HasColumnType("int");

                    b.Property<int?>("DepartureLocationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CountryId");

                    b.HasIndex("DepartureLocationId");

                    b.ToTable("HotTour","dbo");
                });

            modelBuilder.Entity("BetterTravel.DataAccess.Abstraction.Entities.HotelCategory", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("HotelCategoryID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("HotelCategory","dbo");
                });

            modelBuilder.Entity("BetterTravel.DataAccess.Abstraction.Entities.SettingsCountry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("SettingsCountryID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CountryId")
                        .HasColumnType("int");

                    b.Property<int?>("SettingsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("SettingsId");

                    b.ToTable("SettingsCountry","dbo");
                });

            modelBuilder.Entity("BetterTravel.DataAccess.Abstraction.Entities.Chat", b =>
                {
                    b.OwnsOne("BetterTravel.DataAccess.Abstraction.ValueObjects.ChatInfo", "Info", b1 =>
                        {
                            b1.Property<int>("ChatId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Description")
                                .HasColumnName("Description")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Title")
                                .HasColumnName("Title")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int>("Type")
                                .HasColumnName("Type")
                                .HasColumnType("int");

                            b1.HasKey("ChatId");

                            b1.ToTable("Chat");

                            b1.WithOwner()
                                .HasForeignKey("ChatId");
                        });
                });

            modelBuilder.Entity("BetterTravel.DataAccess.Abstraction.Entities.ChatSettings", b =>
                {
                    b.HasOne("BetterTravel.DataAccess.Abstraction.Entities.Chat", "Chat")
                        .WithOne("Settings")
                        .HasForeignKey("BetterTravel.DataAccess.Abstraction.Entities.ChatSettings", "SettingsOfChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BetterTravel.DataAccess.Abstraction.Entities.HotTour", b =>
                {
                    b.HasOne("BetterTravel.DataAccess.Abstraction.Entities.HotelCategory", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("BetterTravel.DataAccess.Abstraction.Entities.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");

                    b.HasOne("BetterTravel.DataAccess.Abstraction.Entities.DepartureLocation", "DepartureLocation")
                        .WithMany()
                        .HasForeignKey("DepartureLocationId");

                    b.OwnsOne("BetterTravel.DataAccess.Abstraction.ValueObjects.Duration", "Duration", b1 =>
                        {
                            b1.Property<int>("HotTourId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<int>("Count")
                                .HasColumnName("DurationCount")
                                .HasColumnType("int");

                            b1.Property<int>("Type")
                                .HasColumnName("DurationType")
                                .HasColumnType("int");

                            b1.HasKey("HotTourId");

                            b1.ToTable("HotTour");

                            b1.WithOwner()
                                .HasForeignKey("HotTourId");
                        });

                    b.OwnsOne("BetterTravel.DataAccess.Abstraction.ValueObjects.HotTourInfo", "Info", b1 =>
                        {
                            b1.Property<int>("HotTourId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<DateTime>("DepartureDate")
                                .HasColumnName("DepartureDate")
                                .HasColumnType("datetime2");

                            b1.Property<string>("DetailsUri")
                                .HasColumnName("DetailsLink")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("ImageUri")
                                .HasColumnName("ImageLink")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Name")
                                .HasColumnName("Name")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("HotTourId");

                            b1.ToTable("HotTour");

                            b1.WithOwner()
                                .HasForeignKey("HotTourId");
                        });

                    b.OwnsOne("BetterTravel.DataAccess.Abstraction.ValueObjects.Price", "Price", b1 =>
                        {
                            b1.Property<int>("HotTourId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<int>("Amount")
                                .HasColumnName("PriceAmount")
                                .HasColumnType("int");

                            b1.Property<int>("Type")
                                .HasColumnName("PriceType")
                                .HasColumnType("int");

                            b1.HasKey("HotTourId");

                            b1.ToTable("HotTour");

                            b1.WithOwner()
                                .HasForeignKey("HotTourId");
                        });

                    b.OwnsOne("BetterTravel.DataAccess.Abstraction.ValueObjects.Resort", "Resort", b1 =>
                        {
                            b1.Property<int>("HotTourId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Name")
                                .HasColumnName("ResortName")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("HotTourId");

                            b1.ToTable("HotTour");

                            b1.WithOwner()
                                .HasForeignKey("HotTourId");
                        });
                });

            modelBuilder.Entity("BetterTravel.DataAccess.Abstraction.Entities.SettingsCountry", b =>
                {
                    b.HasOne("BetterTravel.DataAccess.Abstraction.Entities.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");

                    b.HasOne("BetterTravel.DataAccess.Abstraction.Entities.ChatSettings", "Settings")
                        .WithMany("SettingsCountries")
                        .HasForeignKey("SettingsId");
                });
#pragma warning restore 612, 618
        }
    }
}
