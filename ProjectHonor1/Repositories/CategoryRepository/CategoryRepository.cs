using Dapper;
using ProjectHonor1.Dtos.FeedbackDtos;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using ProjectHonor1.Dtos.GetCategoryDtos;
using ProjectHonor1.Repositories.GetCategoryDtos;

namespace ProjectHonor1.Repositories.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IDbConnection _dbConnection;

        public CategoryRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }



        public async Task AddAsync(GetCategoryDto category)

        {
            var sql = "INSERT INTO Category(Name,Description) VALUES (@Name, @Description)";
            await _dbConnection.ExecuteAsync(sql, category);
            //Veriye göre sorgu çalıştır
        }
        public async Task <GetCategoryDto> GetByIdAsync(int id) 
        {
            var sql = "SELECT * FROM Category WHERE Id=@Id";
            return await _dbConnection.QueryFirstOrDefaultAsync<GetCategoryDto>(sql, new { Id = id });
            //Belirtilen Id'deki kategoriyi döndür.
        }
        public async Task<IEnumerable<GetCategoryDto>> GetAllAsync()
        {
            var sql = "SELECT * FROM Category"; //tüm kategoriyi döndür
            return await _dbConnection.QueryAsync<GetCategoryDto> (sql);
        }
        public async Task UpdateAsync(int id, GetCategoryDto category)
        {
            var sql = "UPDATE Category SET Name = @Name, Description= @Description WHERE Id=@Id";
            await _dbConnection.ExecuteAsync(sql, new { category.Name, category.Description, Id = id });
        }

        public async Task DeleteAsync(int id)
        {
            var sql = "DELETE FROM Category Where Id=@Id";
            await _dbConnection.ExecuteAsync(sql, new {Id=id});
        }

    }
}
