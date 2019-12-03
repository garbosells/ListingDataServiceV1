﻿// <auto-generated />
using System;
using ListingDataServiceV1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ListingDataServiceV1.Migrations
{
    [DbContext(typeof(ListingDataServiceV1Context))]
    [Migration("20191130085730_new_schema")]
    partial class new_schema
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ListingDataServiceV1.Models.Item", b =>
                {
                    b.Property<long?>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<long>("ListingId")
                        .HasColumnType("bigint");

                    b.Property<string>("LongDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("SubcategoryId")
                        .HasColumnType("bigint");

                    b.Property<long>("createdByUserId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("createdDateTime")
                        .HasColumnType("datetime2");

                    b.Property<long>("eraId")
                        .HasColumnType("bigint");

                    b.Property<long>("materialId")
                        .HasColumnType("bigint");

                    b.Property<long>("primaryColorId")
                        .HasColumnType("bigint");

                    b.Property<long>("secondaryColorId")
                        .HasColumnType("bigint");

                    b.Property<long>("sizeTypeId")
                        .HasColumnType("bigint");

                    b.Property<long>("sizeValueId")
                        .HasColumnType("bigint");

                    b.Property<long>("updatedByUserId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("updatedDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ItemId");

                    b.HasIndex("ListingId")
                        .IsUnique();

                    b.ToTable("Items");
                });

            modelBuilder.Entity("ListingDataServiceV1.Models.ItemAttribute", b =>
                {
                    b.Property<long?>("itemAttributeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("ItemId")
                        .HasColumnType("bigint");

                    b.Property<long?>("attributeRecommendationId")
                        .HasColumnType("bigint");

                    b.Property<string>("itemAttributeValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("subcategoryAttributeId")
                        .HasColumnType("bigint");

                    b.HasKey("itemAttributeId");

                    b.HasIndex("ItemId");

                    b.ToTable("item_attribute");
                });

            modelBuilder.Entity("ListingDataServiceV1.Models.ItemMeasurement", b =>
                {
                    b.Property<long?>("itemMeasurementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("ItemId")
                        .HasColumnType("bigint");

                    b.Property<long>("categoryMeasurementId")
                        .HasColumnType("bigint");

                    b.Property<double>("itemMeasurementValue")
                        .HasColumnType("float");

                    b.HasKey("itemMeasurementId");

                    b.HasIndex("ItemId");

                    b.ToTable("item_measurement");
                });

            modelBuilder.Entity("ListingDataServiceV1.Models.Listing", b =>
                {
                    b.Property<long>("ListingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("ItemId")
                        .HasColumnType("bigint");

                    b.HasKey("ListingId");

                    b.ToTable("Listings");
                });

            modelBuilder.Entity("ListingDataServiceV1.Models.Item", b =>
                {
                    b.HasOne("ListingDataServiceV1.Models.Listing", "Listing")
                        .WithOne("Item")
                        .HasForeignKey("ListingDataServiceV1.Models.Item", "ListingId")
                        .HasConstraintName("ForeignKey_Item_Listing")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ListingDataServiceV1.Models.ItemAttribute", b =>
                {
                    b.HasOne("ListingDataServiceV1.Models.Item", "Item")
                        .WithMany("attributes")
                        .HasForeignKey("ItemId")
                        .HasConstraintName("ForeignKey_ItemAttribute_Item")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ListingDataServiceV1.Models.ItemMeasurement", b =>
                {
                    b.HasOne("ListingDataServiceV1.Models.Item", "Item")
                        .WithMany("measurements")
                        .HasForeignKey("ItemId")
                        .HasConstraintName("ForeignKey_ItemMeasurement_Item")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}