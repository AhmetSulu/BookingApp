using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Data.Entities
{
    //Hangi odayı hangi müşteri rezerve etti?
    public class ReservationEntity : BaseEntity
    {
        public int RoomId { get; set; }
        public int UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int GuestCount { get; set; }

        // Relational Property

        public UserEntity User { get; set; }
        public RoomEntity Room { get; set; }
    }
    public class ReservationConfiguration : BaseConfiguration<ReservationEntity>
    {
        public override void Configure(EntityTypeBuilder<ReservationEntity> builder)
        {
            base.Configure(builder);
        }
    }
}
