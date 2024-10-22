using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Data.Entities
{
    public class RoomEntity : BaseEntity
    {
        public int HotelId { get; set; }
        public string RoomNumber { get; set; }

        // Relational Property

        public ICollection<ReservationEntity> Reservations { get; set; }
        public HotelEntity Hotel { get; set; }
    }
    public class RoomConfiguration : BaseConfiguration<RoomEntity>
    {
        public override void Configure(EntityTypeBuilder<RoomEntity> builder)
        {
            base.Configure(builder);
        }
    }
}
