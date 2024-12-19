using System.Data;
using Dapper;
using ProjectHonor1.Dtos.GetStatusDtos;
using ProjectHonor1.Repositories.GetStatusDtos;



namespace ProjectHonor1.Repositories.StatusRepository

{
    public class StatusRepository : IStatusRepository
    {
        private readonly IDbConnection _dbConnection;
        public StatusRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public async Task AddAsync(GetStatusDto status)

        {
            var sql = "INSERT INTO Status(Name,Description) VALUES (@Name, @Description)";
            await _dbConnection.ExecuteAsync(sql, status);
            //Veriye göre sorgu çalıştır
        }

        public async Task<GetStatusDto> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM Status WHERE Id=@Id";
            return await _dbConnection.QueryFirstOrDefaultAsync<GetStatusDto>(sql, new { Id = id });
            //Belirtilen Id'deki kategoriyi döndür.
        }
        public async Task<IEnumerable<GetStatusDto>> GetAllAsync()
        {
            var sql = "SELECT  FROM Status"; //tüm kategoriyi döndür
            return await _dbConnection.QueryAsync<GetStatusDto>(sql);
        }
        public async Task UpdateAsync(int id, GetStatusDto status)
        {
            var sql = "UPDATE Status SET Name = @Name, Description= @Description WHERE Id=@Id";
            await _dbConnection.ExecuteAsync(sql, new { status.Name, status.Description, Id = id });
        }

        public async Task DeleteAsync(int id)
        {
            var sql = "DELETE FROM Status Where Id=@Id";
            await _dbConnection.ExecuteAsync(sql, new { Id = id });
        }
    }
}




