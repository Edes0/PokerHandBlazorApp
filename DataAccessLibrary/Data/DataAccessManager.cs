using Contracts;

namespace DataAccessLibrary.Data
{
    public sealed class DataAccessManager : IDataAccessManager
    {
        private readonly ISqlDataAccess _sqlDataAccess;
        private readonly Lazy<IHandData> _handData;
        //Add new items from database here if needed

        public DataAccessManager(SqlDbContext sqlDbContext, ISqlDataAccess sqlDataAccess)
        {
            _handData = new Lazy<IHandData>(() => new
            HandData(sqlDataAccess));
            //Add _ExampleData = new Lazy<IHandData>(() => new
            //HandData(_sqlDataAccess));
        }
        public IHandData Hand => _handData.Value;
        //public async Task SaveAsync() => await _sqlDbContext.SaveChangesAsync();
    }

}