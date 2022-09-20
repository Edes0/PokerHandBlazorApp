using Contracts;
using Entities;

namespace DataAccessLibrary.Data
{
    public class HandData : IHandData
    {
        private readonly ISqlDataAccess _db;
        
        public HandData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<List<Hand>> GetHands()
        {
            string sql = "select * from dbo.Hands";

            return _db.LoadData<Hand, dynamic>(sql, new { });
        }

        public Task<Hand> GetHandById(Guid Id)
        {
            string sql = "select * from dbo.Hands" +
                         $"where Id={Id}";

            return _db.LoadOneObject<Hand, dynamic>(sql, new { });
        }

        public async Task InsertHand(Hand hand)
        
        {
            string sql = $"INSERT INTO dbo.Hands (Id, StringOfCards)" +
                $" VALUES (@Id, @StringOfCards)";

            await _db.SaveData(sql, hand);
        }

        public Task RemoveHand(Hand hand)
        {
            string sql = $"DELETE FROM dbo.Hands WHERE ID = {hand.Id}";

            return _db.SaveData(sql, hand);
        }
    }
}
