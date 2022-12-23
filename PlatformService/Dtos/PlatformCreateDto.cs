using System.ComponentModel.DataAnnotations;

namespace PlatformService.Dtos{


    public class PlatformCreateDto{       //same as models, but we don't keep ID prop, bcoz we will create that for them ourselves, the concept of secret key comes in here


        [Required]                                         //here we have data annotations,bcoz the inbuilt dotnet will make sure the wrong type of data doesn't come in 
        public string? Name { get; set; }

        [Required]
        public string? Publisher { get; set; }
        
        [Required]
        public string? Cost { get; set; }





    }



}