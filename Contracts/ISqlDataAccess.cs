namespace Contracts
{
    public interface ISqlDataAccess
    {
        string ConnectionStringName { get; set; }

        Task<List<T>> LoadData<T, U>(string sql, U parameters);
        Task SaveData<T>(string sql, T parameters);
        Task<T> LoadOneObject<T, U>(string sql, U parameter);
        //Task SaveDataQuery(string sql);
    }
}