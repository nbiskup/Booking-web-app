using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RwaLib.MODELS
{
    [Serializable]
    public class Apartment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        [Required]        
        public string NameEng { get; set; }
        public City City { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int? MaxAdults { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int? MaxChildren { get; set; }
        
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int? TotalRooms { get; set; }
        
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int? Price { get; set; }
        public string Status { get; set; }
        
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int? BeachDistance { get; set; }
        
        [Required]       
        public string Address { get; set; }
        public int NumberOfPictures { get; set; }
        public int OwnerId { get; set; }
        public int StatusId { get; set; }
        public int? CityId { get; set; }
        public int Review { get; set; }

    }
}
