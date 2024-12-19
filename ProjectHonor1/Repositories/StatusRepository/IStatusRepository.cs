using ProjectHonor1.Dtos.GetStatusDtos;

namespace ProjectHonor1.Repositories.GetStatusDtos;

public interface IStatusRepository
{
    Task AddAsync(GetStatusDto status);
    Task<GetStatusDto> GetByIdAsync(int id);
    Task<IEnumerable<GetStatusDto>> GetAllAsync();
    Task UpdateAsync(int id, GetStatusDto status);
    Task DeleteAsync(int id);
}
