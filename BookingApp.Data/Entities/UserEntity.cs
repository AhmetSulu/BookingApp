using BookingApp.Data.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Data.Entities
{
    public class UserEntity : BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public UserType UserType { get; set; }

        // Relational Property

        public ICollection<ReservationEntity> Reservations { get; set; }
    }
    public class UserConfiguration : BaseConfiguration<UserEntity>
    {
        public override void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.Property(e => e.FirstName)
                   .IsRequired()
                   .HasMaxLength(40);
            builder.Property(e => e.LastName)
                   .IsRequired()
                   .HasMaxLength(40);

            base.Configure(builder);
        }
    }
}
