﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TerritorialHQ_APIS.Models.Data;

#nullable disable

namespace TerritorialHQ_APIS.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230808210645_ClanLeader")]
    partial class ClanLeader
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("TerritorialHQ_Library.Entities.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Creator")
                        .HasColumnType("longtext");

                    b.Property<ulong>("DiscordId")
                        .HasColumnType("bigint unsigned");

                    b.Property<bool>("Public")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("Role")
                        .HasColumnType("int");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UserName")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("AppUsers");
                });

            modelBuilder.Entity("TerritorialHQ_Library.Entities.Clan", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("BannerFile")
                        .HasColumnType("longtext");

                    b.Property<string>("BotEndpoint")
                        .HasColumnType("longtext");

                    b.Property<string>("Color1")
                        .HasColumnType("longtext");

                    b.Property<string>("Color2")
                        .HasColumnType("longtext");

                    b.Property<string>("Community")
                        .HasColumnType("longtext");

                    b.Property<string>("Creator")
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("DiscordLink")
                        .HasColumnType("longtext");

                    b.Property<string>("Features")
                        .HasColumnType("longtext");

                    b.Property<string>("Foundation")
                        .HasColumnType("longtext");

                    b.Property<string>("Founders")
                        .HasColumnType("longtext");

                    b.Property<string>("GuildId")
                        .HasColumnType("longtext");

                    b.Property<string>("History")
                        .HasColumnType("longtext");

                    b.Property<bool>("InReview")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsPublished")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Leader")
                        .HasColumnType("longtext");

                    b.Property<string>("LogoFile")
                        .HasColumnType("longtext");

                    b.Property<string>("Miscellaneous")
                        .HasColumnType("longtext");

                    b.Property<string>("Motto")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Overview")
                        .HasColumnType("longtext");

                    b.Property<string>("Tag")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("UseColorForPage")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("Clans");
                });

            modelBuilder.Entity("TerritorialHQ_Library.Entities.ClanRelation", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ClanId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Creator")
                        .HasColumnType("longtext");

                    b.Property<int>("DiplomaticRelation")
                        .HasColumnType("int");

                    b.Property<int>("HierachicalRelation")
                        .HasColumnType("int");

                    b.Property<int>("MilitaryRelation")
                        .HasColumnType("int");

                    b.Property<string>("TargetClanId")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("ClanId");

                    b.HasIndex("TargetClanId");

                    b.ToTable("ClanRelation");
                });

            modelBuilder.Entity("TerritorialHQ_Library.Entities.ClanUserRelation", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("AppUserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ClanId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Creator")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("ClanId");

                    b.ToTable("ClanUserRelations");
                });

            modelBuilder.Entity("TerritorialHQ_Library.Entities.ContentCreator", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("BannerFile")
                        .HasColumnType("longtext");

                    b.Property<string>("ChannelLink")
                        .HasColumnType("longtext");

                    b.Property<string>("Creator")
                        .HasColumnType("longtext");

                    b.Property<string>("LogoFile")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("ContentCreators");
                });

            modelBuilder.Entity("TerritorialHQ_Library.Entities.ContentPage", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("BannerImage")
                        .HasColumnType("longtext");

                    b.Property<string>("Content")
                        .HasColumnType("longtext");

                    b.Property<string>("Creator")
                        .HasColumnType("longtext");

                    b.Property<string>("DisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("SidebarContent")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("ContentPages");
                });

            modelBuilder.Entity("TerritorialHQ_Library.Entities.JournalArticle", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Body")
                        .HasColumnType("longtext");

                    b.Property<string>("Creator")
                        .HasColumnType("longtext");

                    b.Property<string>("Image")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsCleared")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsSticky")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("PublishFrom")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("PublishTo")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Subtitle")
                        .HasColumnType("longtext");

                    b.Property<string>("Tags")
                        .HasColumnType("longtext");

                    b.Property<string>("Teaser")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("JournalArticles");
                });

            modelBuilder.Entity("TerritorialHQ_Library.Entities.NavigationEntry", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ContentPageId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Creator")
                        .HasColumnType("longtext");

                    b.Property<string>("ExternalUrl")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<short>("Order")
                        .HasColumnType("smallint");

                    b.Property<string>("ParentId")
                        .HasColumnType("varchar(255)");

                    b.Property<bool>("Public")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Slug")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("ContentPageId");

                    b.HasIndex("ParentId");

                    b.ToTable("NavigationEntries");
                });

            modelBuilder.Entity("TerritorialHQ_Library.Entities.TokenClient", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Creator")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("ReturnUrl")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("TokenClients");
                });

            modelBuilder.Entity("TerritorialHQ_Library.Entities.ClanRelation", b =>
                {
                    b.HasOne("TerritorialHQ_Library.Entities.Clan", "Clan")
                        .WithMany("ClanRelations")
                        .HasForeignKey("ClanId");

                    b.HasOne("TerritorialHQ_Library.Entities.Clan", "TargetClan")
                        .WithMany()
                        .HasForeignKey("TargetClanId");

                    b.Navigation("Clan");

                    b.Navigation("TargetClan");
                });

            modelBuilder.Entity("TerritorialHQ_Library.Entities.ClanUserRelation", b =>
                {
                    b.HasOne("TerritorialHQ_Library.Entities.AppUser", "AppUser")
                        .WithMany()
                        .HasForeignKey("AppUserId");

                    b.HasOne("TerritorialHQ_Library.Entities.Clan", "Clan")
                        .WithMany("ClanUserRelations")
                        .HasForeignKey("ClanId");

                    b.Navigation("AppUser");

                    b.Navigation("Clan");
                });

            modelBuilder.Entity("TerritorialHQ_Library.Entities.NavigationEntry", b =>
                {
                    b.HasOne("TerritorialHQ_Library.Entities.ContentPage", "ContentPage")
                        .WithMany("NavigationEntries")
                        .HasForeignKey("ContentPageId");

                    b.HasOne("TerritorialHQ_Library.Entities.NavigationEntry", "Parent")
                        .WithMany("SubEntries")
                        .HasForeignKey("ParentId");

                    b.Navigation("ContentPage");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("TerritorialHQ_Library.Entities.Clan", b =>
                {
                    b.Navigation("ClanRelations");

                    b.Navigation("ClanUserRelations");
                });

            modelBuilder.Entity("TerritorialHQ_Library.Entities.ContentPage", b =>
                {
                    b.Navigation("NavigationEntries");
                });

            modelBuilder.Entity("TerritorialHQ_Library.Entities.NavigationEntry", b =>
                {
                    b.Navigation("SubEntries");
                });
#pragma warning restore 612, 618
        }
    }
}
