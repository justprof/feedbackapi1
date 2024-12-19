using ProjectHonor1.Dtos.FeedbackDtos;
using Dapper;
using System.Data;
using ProjectHonor1.Repositories.FeedbackRepository;
using ProjectHonor1.Repositories.GetFeedbackDtos;
using ProjectHonor1.Dtos.GetFeedbackDtos;

namespace ProjectHonor1.Repositories.FeedbackRepository
{

    public class FeedbackRepository : IFeedbackRepository


    {
        private readonly IDbConnection _dbConnection;
        public FeedbackRepository(IDbConnection dbConnection)
        {
            _dbConnection=dbConnection;
        }

        public async Task AddAsync(GetFeedbackDto feedback)
        {
            var sql = @"INSERT INTO Feedback(TITLE,Description,CreatedDate)
                        VALUES (@TITLE, @Description, @CreatedDate)";
            var parameters = new { feedback.TITLE, feedback.Description, feedback.CreatedDate };
            await _dbConnection.ExecuteAsync(sql, parameters);
        }

        public async Task<GetFeedbackDto> GetByIdAsync(int id)
        {
            var query = "SELECT * FROM Feedback WHERE Id=@Id";
            return await _dbConnection.QueryFirstOrDefaultAsync<GetFeedbackDto>(query, new { Id = id });
        }

        public async Task<IEnumerable<GetFeedbackDto>> GetAllAsync()
        {
            var query = "Select * FROM feedback";
            return await _dbConnection.QueryAsync<GetFeedbackDto>(query);
        }

        public async Task UpdateAsync(int id, GetFeedbackDto feedback)
        {
            var query = @"UPDATE feedback
                      SET TITLE = @TITLE, Description=@Description, UpdatedDate=@UpdatedDate, UpdatedDate = @UpdatedDate, StatusId = @StatusId,  CategoryId = @CategoryId

                      Where Id = @Id";
            var parameters = new { feedback.TITLE, feedback.Description, feedback.CreatedDate, Id = id };
            await _dbConnection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteAsync(int id)
        {
            var query = "DELETE FROM feedback WHERE Id=@Id";
            await _dbConnection.ExecuteAsync(query, new { Id = id });
        }
    }
}