using ProjectHonor1.Dtos.GetCategoryDtos;

namespace ProjectHonor1.Repositories.GetCategoryDtos
{
    public interface ICategoryRepository
    {
        Task AddAsync(GetCategoryDto category);
        Task<GetCategoryDto> GetByIdAsync(int id);
        Task<IEnumerable<GetCategoryDto>> GetAllAsync();
        Task UpdateAsync(int id , GetCategoryDto category);
        Task DeleteAsync(int id);
    }
}
