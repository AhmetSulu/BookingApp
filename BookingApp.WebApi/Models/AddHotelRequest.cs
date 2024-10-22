using BookingApp.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace BookingApp.WebApi.Models
{
    public class AddHotelRequest
    {
        [Required]
        public string Name { get; set; }
        public int? Stars { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public AccomodationType AccomodationType { get; set; }
        public List<int> FeatureIds { get; set; }
    }
}
