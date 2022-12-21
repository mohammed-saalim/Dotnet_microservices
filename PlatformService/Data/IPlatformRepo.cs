using PlatformService.Models;

namespace PlatformService.Data
{

    //this is interface / repository interface, we shud create concrete instance of repos interface/ Implementation class for this interface, to use them
    public interface IPlatformRepo{ 

        bool SaveChanges();

        IEnumerable<Platform> GetAllPlatforms();
        Platform GetPlatformById(int id);
        void CreatePlatform(Platform plat);
        

    }

    
}