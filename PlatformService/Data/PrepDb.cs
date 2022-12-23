using PlatformService.Models;

namespace PlatformService.Data{

    public static class PrepDb{

        public static void PrepPopulation(IApplicationBuilder app){

            using(var serviceScope = app.ApplicationServices.CreateScope()){


                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());

            }




        }


        private static void SeedData(AppDbContext context){

            
            if(!context.Platforms.Any()){                    //we'll check if there is any data in Platforms(AppDbContext.cs file ka method) service
                Console.WriteLine("--> Seeding Data...");

                context.Platforms.AddRange(
                    new Platform() {Name="Dot Net", Publisher="Microsoft", Cost="Free"},
                    new Platform() {Name="SQL Server Express", Publisher="Microsoft",  Cost="Free"},
                    new Platform() {Name="Kubernetes", Publisher="Cloud Native Computing Foundation",  Cost="Free"}
                );

                context.SaveChanges();        //addRange will add data, but unless u do this line, it wont save there in the db


            }
            else{

                Console.WriteLine("there is already some data");         //as long as we r using InMemory DB, this wont come here, bcoz when we start the app, it will start fresh.

            }




        }


    }





}