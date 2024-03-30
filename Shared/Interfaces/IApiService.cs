namespace Shared.Interfaces;
public interface IApiService : IDataService
{
    public Task<bool> ConnectionTest();

}
