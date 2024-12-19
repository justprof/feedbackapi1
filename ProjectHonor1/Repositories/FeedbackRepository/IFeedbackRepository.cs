using ProjectHonor1.Dtos.FeedbackDtos;
using ProjectHonor1.Dtos.GetFeedbackDtos;

namespace ProjectHonor1.Repositories.GetFeedbackDtos
{
    public interface IFeedbackRepository
    {
        Task AddAsync(GetFeedbackDto feedback);
        Task<GetFeedbackDto> GetByIdAsync(int id);
        Task<IEnumerable<GetFeedbackDto>>GetAllAsync();
        Task UpdateAsync(int id, GetFeedbackDto feedback);
        Task DeleteAsync(int id);
    }
}
