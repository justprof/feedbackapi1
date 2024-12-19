using ProjectHonor1.Dtos.GetCategoryDtos;
using Swashbuckle.AspNetCore.Annotations;
using System.Text.Json.Serialization;

namespace ProjectHonor1.Dtos.GetCategoryDtos
{
    public class CreateCategoryDto
    {
        
        public int id { get; set; }  
        public string? Name { get; set; }
        public string? Description { get; set; }

    }
}
