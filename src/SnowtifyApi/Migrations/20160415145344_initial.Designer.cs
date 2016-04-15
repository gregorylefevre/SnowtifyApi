using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using SnowtifyApi.Models;

namespace SnowtifyApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20160415145344_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348");

            modelBuilder.Entity("SnowtifyApi.Models.Follower", b =>
                {
                    b.Property<string>("Id");

                    b.Property<DateTime>("CreationDate");

                    b.Property<DateTime>("LastActivityDate");

                    b.Property<string>("NotificationId");

                    b.Property<string>("PushId");

                    b.Property<string>("PushType");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("SnowtifyApi.Models.Notification", b =>
                {
                    b.Property<string>("Id");

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("LastMessage");

                    b.Property<string>("Notifier");

                    b.Property<string>("SecretKey");

                    b.Property<string>("Title");

                    b.Property<DateTime>("UpdateDate");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("SnowtifyApi.Models.Follower", b =>
                {
                    b.HasOne("SnowtifyApi.Models.Notification")
                        .WithMany()
                        .HasForeignKey("NotificationId");
                });
        }
    }
}
