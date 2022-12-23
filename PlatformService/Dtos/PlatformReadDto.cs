namespace PlatformService.Dtos{

    public class PlatformReadDto{                       /*coped all properties from our internal representation(Model) 
                                                        but took data annotations off, bcoz its only going to read the data, so no need constraints*/


        public int Id { get; set; }                     //here we specify only the props, which we want to the external consumer to read/access

        public string? Name { get; set; }
        
        public string? Publisher { get; set; }

        public string? Cost { get; set; }
                                                        

    }


}