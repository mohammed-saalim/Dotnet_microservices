using System.ComponentModel.DataAnnotations;

namespace PlatformService.Models{


    public class Platform{


        [Key]                                                 //By default key is required, so need to explicitly add the [Required] annotation for this property
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Publisher { get; set; }
        
        [Required]
        public string? Cost { get; set; }





    }




}