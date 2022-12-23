using AutoMapper;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Profiles{


    public class PlatformsProfile: Profile{


            public PlatformsProfile(){                          //inside ctor the mapping is done


                //Source -> Target                                         
                CreateMap<Platform, PlatformReadDto>();                    //from models(source) to read dto(target) we are mapping
                                                                            /*As the names of both props of source and target are same, 
                                                                            the automapper will automatically map them*/
                
                CreateMap<PlatformCreateDto, Platform>();                 // this is for when source is create Dto and target is Platform(model) 

            }




    }





}