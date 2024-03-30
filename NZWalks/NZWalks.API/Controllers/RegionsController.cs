using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Controllers
{
    //https://localhost:portnum/api/Regions
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext dbContext;

        public RegionsController(NZWalksDbContext dbContext)
        {
              this.dbContext = dbContext;
        }


        //Get All Region Url: https://localhost:portnum/api/Regions
        [HttpGet]
        public IActionResult GetAll()
        {
            //accessing from DB using DBContext - Domain Models
            var regionsDomain = dbContext.Regions.ToList();

            //Map these Domain Models to DTOs
            var regionsDto = new List<RegionDto>();
            foreach (var regionDomain in regionsDomain)
            {
                regionsDto.Add(new RegionDto()
                {
                    Id = regionDomain.Id,
                    Name = regionDomain.Name,
                    Code = regionDomain.Code,
                    RegionImageUrl = regionDomain.RegionImageUrl,
                });
            }

            //return DTOs
            return Ok(regionsDto);
            //Hard-coded values
            /*var regions = new List<Region>
            {
                new Region
                {
                    Id = Guid.NewGuid(),
                    Name = "Auckland Region",
                    Code  = "AKL",
                    RegionImageUrl="NULL"
                },
                new Region
                {
                    Id = Guid.NewGuid(),
                    Name = "Welligton Region",
                    Code  = "WLG",
                    RegionImageUrl="NULL"
                }
            };*/



        }


        //Get Region By ID Url: https://localhost:portnum/api/Regions/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            //this takes a primary key so we cannot use this for other properties like code, name etc for that 2nd method
            //var region = dbContext.Regions.Find(id);

            //another method to find id and other like name, code etc.
            //Get region Domain Model from DB
            var regionDomain = dbContext.Regions.FirstOrDefault(x => x.Id == id);

            if (regionDomain == null)
            {
                return NotFound();
            }
            //convert Domain model into DTO
            var regionsDto = new RegionDto
            {
                Id = regionDomain.Id,
                Name = regionDomain.Name,
                Code = regionDomain.Code,
                RegionImageUrl = regionDomain.RegionImageUrl,
            };


            //return Dto to client
            return Ok(regionsDto);


        }

        //post Request
        [HttpPost]
        public IActionResult Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            //convert our Dto into DOmain model
            var regionDomainModel = new Region
            {
                Name = addRegionRequestDto.Name,
                Code = addRegionRequestDto.Code,
                RegionImageUrl = addRegionRequestDto.RegionImageUrl,
            };

            //use domain model to create region
            dbContext.Regions.Add(regionDomainModel);
            dbContext.SaveChanges();

            //Map domain model back to DTO
            var regionDto = new RegionDto
            {
                Id = regionDomainModel.Id,
                Name = regionDomainModel.Name,
                Code = regionDomainModel.Code,
                RegionImageUrl = regionDomainModel.RegionImageUrl,
            };

            //in post we cannot send ok reponse back which is 200. instead we will send 201

            return CreatedAtAction(nameof(GetById), new { id = regionDomainModel.Id }, regionDto);
        }


        [HttpPut]
        [Route("{id:Guid}")]
        public IActionResult Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            // check if region exsist
            var regionDomainModel = dbContext.Regions.FirstOrDefault(x => x.Id == id);


            // If Null then NotFound
            if (regionDomainModel == null)
            {
                return NotFound();
            }
            //map Dto to model
            regionDomainModel.RegionImageUrl = updateRegionRequestDto.RegionImageUrl;
           regionDomainModel.Code = updateRegionRequestDto.Code;
            regionDomainModel.Name = updateRegionRequestDto.Name;

            dbContext.SaveChanges();

            //convert domain model to Dto
            var RegionDto = new RegionDto
            {
                Id = regionDomainModel.Id,
                Name = regionDomainModel.Name,
                Code = regionDomainModel.Code,
                RegionImageUrl = regionDomainModel.RegionImageUrl,
            };

            return Ok(RegionDto);


        }

        //Delete Region
        //Delete Region By ID Url: https://localhost:portnum/api/Regions/{id}

        [HttpDelete]
        [Route("{id:Guid}")]
        public IActionResult Delete([FromRoute] Guid id)
        {

            var regionDomainModel = dbContext.Regions.FirstOrDefault(x => x.Id == id);
            if(regionDomainModel == null)
            {
                return NotFound();
            }

            //delete Region
            dbContext.Regions.Remove(regionDomainModel);
            dbContext.SaveChanges();

            //optional
            //return deleted region back to so; map Domain model to DTO

            var RegionDto = new RegionDto
            {
                Id = regionDomainModel.Id,
                Name = regionDomainModel.Name,
                Code = regionDomainModel.Code,
                RegionImageUrl = regionDomainModel.RegionImageUrl,
            };

            return Ok(RegionDto);



        }




    }
}
