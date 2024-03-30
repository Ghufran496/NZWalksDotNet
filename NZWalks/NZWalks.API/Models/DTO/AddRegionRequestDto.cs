namespace NZWalks.API.Models.DTO
{
    public class AddRegionRequestDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
        //to make property nullable use ?.
        public string? RegionImageUrl { get; set; }
    }
}
