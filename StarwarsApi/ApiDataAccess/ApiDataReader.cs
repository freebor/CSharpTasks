namespace StarwarsApi.ApiDataAccess;

class ApiDataReader : IApiDataReader
{
    public async Task<string> Read(string baseAddress, string requestUri)
    {
        using var client = new HttpClient();
        client.BaseAddress = new Uri(baseAddress);

        //to extract the Json string from the response use "HttpResponseMessage"
        HttpResponseMessage response = await client.GetAsync(requestUri);

        //this would throw an error if getting the data from the Api was impossible
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync();

    }
}