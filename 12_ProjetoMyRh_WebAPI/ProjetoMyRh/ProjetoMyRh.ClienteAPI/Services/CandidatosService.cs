using Microsoft.AspNetCore.ResponseCompression;
using Newtonsoft.Json;
using ProjetoMyRh.ClienteAPI.Models;
using System.Net.Http.Headers;
using System.Text;

namespace ProjetoMyRh.ClienteAPI.Services
{
    public class CandidatosService
    {
        private readonly HttpClient httpClient;

        public CandidatosService(IHttpClientFactory client)
        {
            httpClient = client.CreateClient();

            httpClient.BaseAddress = new Uri("http://localhost:5126/");
            httpClient.DefaultRequestHeaders.Accept.Add(new 
                MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task <IEnumerable<CandidatoClient>> ListarCandidatoAsync()
        {
            try
            {
                var response = await httpClient.GetAsync("api/candidatosapi");
                if (response.IsSuccessStatusCode)
                {
                    var lista = await response.Content.ReadFromJsonAsync<CandidatoClient[]>();
                    return lista!.ToList();
                }
                else
                {
                    throw new Exception("Não foi possível obter a lista de candidatos");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task IncluirCandidatoAsync(CandidatoClient candidato)
        {
            try
            {
                //gerar json
                string json = JsonConvert.SerializeObject(candidato);

                //gerar fluxo de bytes
                HttpContent content =  new StringContent(json, Encoding.Unicode, "application/json");

                //enviando para api
                var response = await httpClient.PostAsync("api/candidatosapi", content);
                if (response.IsSuccessStatusCode)
                {
                    string erro = $"Erro: {response.StatusCode} - {response.ReasonPhrase}";
                    throw new Exception(erro);
                }
                }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
