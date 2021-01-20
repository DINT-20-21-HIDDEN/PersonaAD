using Newtonsoft.Json;
using RestSharp;

namespace PersonasAD
{
    public class ApiRestService
    {
        public string ObtenerGenero(string nombre)
        {
            var client = new RestClient(Properties.Settings.Default.apiEndpoint);
            var request = new RestRequest(Method.GET);
            request.AddParameter("name", nombre,ParameterType.QueryString);
            var response = client.Execute(request);
            GenderResponse genero = JsonConvert.DeserializeObject<GenderResponse>(response.Content);
            return (genero.Gender=="male"?"Hombre":"Mujer");
        }
    }

    public class GenderResponse
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public double Probability { get; set; }
        public int Count { get; set; }
    }
}
