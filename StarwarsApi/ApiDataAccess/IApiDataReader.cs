using StarwarsApi.ApiDataAccess;


namespace StarwarsApi.ApiDataAccess;
public interface IApiDataReader
{
    Task<string> Read(string baseAddress, string requestUri);
}