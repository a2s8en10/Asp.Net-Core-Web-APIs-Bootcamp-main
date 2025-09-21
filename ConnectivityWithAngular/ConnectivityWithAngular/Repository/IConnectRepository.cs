namespace ConnectivityWithAngular.Repository
{
    public interface IConnectRepository
    {
        Task<List<Model.ConnectModel>> GetAllMassageAsync();
    }
}
