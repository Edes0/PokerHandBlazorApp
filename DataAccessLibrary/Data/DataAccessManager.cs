using Contracts;

namespace DataAccessLibrary.Data
{
    /// <summary>
    /// Manager for all repositories. Implement this instead of handData etc.
    /// Can also add new repositories in the future.
    /// </summary>
    public sealed class DataAccessManager : IDataAccessManager
    {
        private readonly ISqlDataAccess _sqlDataAccess;

        private readonly Lazy<IHandData> _handData;
        //Add new items from database here if needed

        public DataAccessManager(ISqlDataAccess sqlDataAccess)
        {
            _sqlDataAccess = sqlDataAccess;

            _handData = new Lazy<IHandData>(() => new
            HandData(_sqlDataAccess));
        }
        public IHandData Hand => _handData.Value;
    }
}