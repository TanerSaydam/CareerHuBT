﻿// <auto-generated />
using System;
using BookStoreWebApi.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookStoreWebApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231013160847_mg4")]
    partial class mg4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookStoreWebApi.Models.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("IdentityNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NameLastname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RefreshTokenExpires")
                        .HasColumnType("datetime2");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BookStoreWebApi.Models.Book", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Summary")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("BookStoreWebApi.Models.Exception", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("InnerException")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StackTrace")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Exceptions");
                });

            modelBuilder.Entity("BookStoreWebApi.Models.RentedBook", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BookId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DeliveryDate")
                        .HasColumnType("date");

                    b.Property<DateTime>("RentedDate")
                        .HasColumnType("date");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("RentedBooks");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("BookStoreWebApi.Models.Book", b =>
                {
                    b.OwnsOne("BookStoreWebApi.ValueObjects.Money", "DailyPrice", b1 =>
                        {
                            b1.Property<string>("BookId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("money");

                            b1.Property<string>("Currency")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("BookId");

                            b1.ToTable("Books");

                            b1.WithOwner()
                                .HasForeignKey("BookId");
                        });

                    b.Navigation("DailyPrice");
                });

            modelBuilder.Entity("BookStoreWebApi.Models.RentedBook", b =>
                {
                    b.HasOne("BookStoreWebApi.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId");

                    b.HasOne("BookStoreWebApi.Models.AppUser", "AppUser")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.OwnsOne("BookStoreWebApi.ValueObjects.Money", "Payment", b1 =>
                        {
                            b1.Property<string>("RentedBookId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("money");

                            b1.Property<string>("Currency")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("RentedBookId");

                            b1.ToTable("RentedBooks");

                            b1.WithOwner()
                                .HasForeignKey("RentedBookId");
                        });

                    b.OwnsOne("BookStoreWebApi.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<string>("RentedBookId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("City")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Country")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("OpenAddress")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Street")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("ZipCode")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("RentedBookId");

                            b1.ToTable("RentedBooks");

                            b1.WithOwner()
                                .HasForeignKey("RentedBookId");
                        });

                    b.OwnsOne("BookStoreWebApi.ValueObjects.CreditCard", "CreditCard", b1 =>
                        {
                            b1.Property<string>("RentedBookId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("CardHolderName")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("CardNumber")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Cvv")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("ExpirationDate")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("RentedBookId");

                            b1.ToTable("RentedBooks");

                            b1.WithOwner()
                                .HasForeignKey("RentedBookId");
                        });

                    b.Navigation("Address");

                    b.Navigation("AppUser");

                    b.Navigation("Book");

                    b.Navigation("CreditCard");

                    b.Navigation("Payment");
                });
#pragma warning restore 612, 618
        }
    }
}
