using BookingApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Data.Context
{
    public class BookingAppDbContext : DbContext
    {
        public BookingAppDbContext(DbContextOptions<BookingAppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent Api
            modelBuilder.ApplyConfiguration(new FeatureConfiguration());
            modelBuilder.ApplyConfiguration(new HotelConfiguration());
            modelBuilder.ApplyConfiguration(new HotelFeatureConfiguration());
            modelBuilder.ApplyConfiguration(new ReservationConfiguration());
            modelBuilder.ApplyConfiguration(new RoomConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            

            modelBuilder.Entity<SettingEntity>().HasData(new SettingEntity
            {
                Id = 1,
                MaintenanceMode = false
            });




            base.OnModelCreating(modelBuilder);
        }



        public DbSet<UserEntity> Users => Set<UserEntity>();
        public DbSet<FeatureEntity> Features => Set<FeatureEntity>();
        public DbSet<HotelEntity> Hotels => Set<HotelEntity>();
        public DbSet<HotelFeatureEntity> HotelFeatures => Set<HotelFeatureEntity>();
        public DbSet<ReservationEntity> Reservations => Set<ReservationEntity>();
        public DbSet<RoomEntity> Rooms => Set<RoomEntity>();
        public DbSet<SettingEntity> Settings { get; set; }
    }
}
