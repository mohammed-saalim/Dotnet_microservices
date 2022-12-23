using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Controller{



    [Route("api/[controller]")]                         // this regex style [controller] will take name of method "Platforms" as substring, or u can directly hardcode it
    [ApiController]
    public class PlatformsController: ControllerBase{
        private readonly IPlatformRepo _repository;
        private readonly IMapper _mapper;


        public PlatformsController(IPlatformRepo repository, IMapper mapper){       //this is usual pattern for ctor based DI, we create ctor, relevant parameters, and private read only fields will be assigned

            _repository = repository;
            _mapper= mapper;
            
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms(){

            Console.WriteLine(".... Getting Platforms");


            var platformItem = _repository.GetAllPlatforms();   //this will return Models, but we need to map to DTOs




            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platformItem));        //mapping to readDto type from Model type //ok() for returning status 200 response

            
        }


        [HttpGet("{id}", Name="GetPlatformById" )]                     
        public ActionResult<PlatformReadDto> GetPlatformById(int id){   //this time no IEnumerable bcoz only 1 value will be returned, Matching PlatformRepo Method signature

            var platformItem = _repository.GetPlatformById(id);
            if(platformItem!=null){

            return Ok(_mapper.Map<PlatformReadDto>(platformItem)); 

            }
            return NotFound();

        }


        [HttpPost]
        public ActionResult<PlatformReadDto> CreatePlatform(PlatformCreateDto platformCreateDto){

            var platformModel = _mapper.Map<Platform>(platformCreateDto);      //using 2nd method of Profiles (refer notes), this time, mapping to platforms(model) from DTO(platformCreateDto)

            _repository.CreatePlatform(platformModel);
            _repository.SaveChanges();                                         //to save in DB

            var platformReadDto = _mapper.Map<PlatformReadDto>(platformModel);         //using 1st method, this time mapping to PlatformReadDto from model 

            return CreatedAtRoute(nameof(GetPlatformById), new {Id= platformReadDto.Id}, platformReadDto);      //creating new id for the created platform, bcoz user wont pass id, and then passing the whole body
                                                                                                                //createdAtRoute will also return the route(uri) address to where to the resource is located, refer book
                                                                                                                //nameof() refers 42nd line Name="GetPlatformByID"

        }

    }





}