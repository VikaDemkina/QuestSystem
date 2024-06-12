﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using QuestSystem.Infrastructure;

#nullable disable

namespace QuestSystem.Infrastructure.Data.Migrations
{
    [DbContext(typeof(QuestDbContext))]
    partial class QuestDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("QuestSystem.Domain.Aggregates.Booking", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("QuestSystem.Domain.Aggregates.Quest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Quests");
                });

            modelBuilder.Entity("QuestSystem.Domain.Aggregates.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("QuestSystem.Domain.Aggregates.UserQuest", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("QuestId")
                        .HasColumnType("uuid");

                    b.HasKey("UserId", "QuestId");

                    b.HasIndex("QuestId");

                    b.ToTable("UserQuests");
                });

            modelBuilder.Entity("QuestSystem.Domain.Aggregates.Booking", b =>
                {
                    b.OwnsOne("DateTime", "DateBooking", b1 =>
                        {
                            b1.Property<Guid>("BookingId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)")
                                .HasColumnName("DateBooking");

                            b1.HasKey("BookingId");

                            b1.ToTable("Bookings");

                            b1.WithOwner()
                                .HasForeignKey("BookingId");
                        });

                    b.OwnsOne("FinalPrice", "Price", b1 =>
                        {
                            b1.Property<Guid>("BookingId")
                                .HasColumnType("uuid");

                            b1.Property<decimal>("Value")
                                .HasColumnType("numeric")
                                .HasColumnName("Price");

                            b1.HasKey("BookingId");

                            b1.ToTable("Bookings");

                            b1.WithOwner()
                                .HasForeignKey("BookingId");
                        });

                    b.OwnsOne("OrderNumber", "OrderNumber", b1 =>
                        {
                            b1.Property<Guid>("BookingId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)")
                                .HasColumnName("OrderNumber");

                            b1.HasKey("BookingId");

                            b1.ToTable("Bookings");

                            b1.WithOwner()
                                .HasForeignKey("BookingId");
                        });

                    b.OwnsOne("Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("BookingId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)")
                                .HasColumnName("Address");

                            b1.HasKey("BookingId");

                            b1.ToTable("Bookings");

                            b1.WithOwner()
                                .HasForeignKey("BookingId");
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("DateBooking")
                        .IsRequired();

                    b.Navigation("OrderNumber")
                        .IsRequired();

                    b.Navigation("Price")
                        .IsRequired();
                });

            modelBuilder.Entity("QuestSystem.Domain.Aggregates.Quest", b =>
                {
                    b.OwnsOne("Price", "Price", b1 =>
                        {
                            b1.Property<Guid>("QuestId")
                                .HasColumnType("uuid");

                            b1.Property<decimal>("Value")
                                .HasColumnType("numeric")
                                .HasColumnName("Price");

                            b1.HasKey("QuestId");

                            b1.ToTable("Quests");

                            b1.WithOwner()
                                .HasForeignKey("QuestId");
                        });

                    b.OwnsOne("Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("QuestId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("Address");

                            b1.HasKey("QuestId");

                            b1.ToTable("Quests");

                            b1.WithOwner()
                                .HasForeignKey("QuestId");
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Price")
                        .IsRequired();
                });

            modelBuilder.Entity("QuestSystem.Domain.Aggregates.User", b =>
                {
                    b.OwnsOne("EmailAddress", "Email", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Email")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("character varying(50)")
                                .HasColumnName("Email");

                            b1.HasKey("UserId");

                            b1.ToTable("User");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("UserName", "UserName", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uuid");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("character varying(50)")
                                .HasColumnName("FirstName");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("character varying(50)")
                                .HasColumnName("LastName");

                            b1.HasKey("UserId");

                            b1.ToTable("User");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("Email")
                        .IsRequired();

                    b.Navigation("UserName")
                        .IsRequired();
                });

            modelBuilder.Entity("QuestSystem.Domain.Aggregates.UserQuest", b =>
                {
                    b.HasOne("QuestSystem.Domain.Aggregates.Quest", "Quest")
                        .WithMany("VisitedUsers")
                        .HasForeignKey("QuestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuestSystem.Domain.Aggregates.User", "User")
                        .WithMany("VisitedQuests")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Quest");

                    b.Navigation("User");
                });

            modelBuilder.Entity("QuestSystem.Domain.Aggregates.Quest", b =>
                {
                    b.Navigation("VisitedUsers");
                });

            modelBuilder.Entity("QuestSystem.Domain.Aggregates.User", b =>
                {
                    b.Navigation("VisitedQuests");
                });
#pragma warning restore 612, 618
        }
    }
}
