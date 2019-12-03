using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ListingDataServiceV1.Models.DatabaseModels;

namespace ListingDataServiceV1.Data
{
    public class ListingDataServiceV1Context : DbContext
    {
        public ListingDataServiceV1Context (DbContextOptions<ListingDataServiceV1Context> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Listing>()
                .HasOne(list=>list.Item)
                .WithOne(item=>item.Listing)
                .HasForeignKey<Listing>(list => list.ItemId)
                .HasConstraintName("ForeignKey_Listing_Item");

            modelBuilder.Entity<Item>()
                .HasOne(item => item.Listing)
                .WithOne(list => list.Item)
                .HasForeignKey<Item>(item => item.ListingId)
                .HasConstraintName("ForeignKey_Item_Listing");

            modelBuilder.Entity<ItemMeasurement>()
               .HasOne(im => im.Item)
               .WithOne(item => item.measurement)
               .HasForeignKey<ItemMeasurement>(im=>im.ItemId)
               .HasConstraintName("ForeignKey_ItemMeasurement_Item");
            
            modelBuilder.Entity<ItemAttribute>()
               .HasOne(ia => ia.Item)
               .WithMany(it => it.attributes)
               .HasForeignKey(ia => ia.ItemId)
               .HasConstraintName("ForeignKey_ItemAttribute_Item");

        }
        public DbSet<Listing> Listings { get; set; }
        public DbSet<Item> Items{ get; set; }
        public DbSet<ItemMeasurement> ItemMeasurements { get; set; }
        public DbSet<ItemAttribute> ItemAttributes { get; set; }
    }
}
