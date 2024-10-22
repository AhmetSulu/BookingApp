using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Data.Entities
{
    public class BaseEntity
    {
        //public BaseEntity()
        //{
        //    CreatedDate = DateTime.Now;
        //}
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
    public abstract class BaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasQueryFilter(x => x.IsDeleted == false);
            //Bu veritabanı üzerinde yapılacak bütün sorgulamalarda ve diğer linq işlemlerinde gecerli olucak bir filtreleme yazdık.Böylelikle hiç bir zaman bir daha soft delete atılmış verilerle uğraşmayacağız.

            builder.Property(x => x.ModifiedDate)
                   .IsRequired(false);
        }
    }
}
