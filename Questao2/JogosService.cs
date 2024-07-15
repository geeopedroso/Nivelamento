using System.Net.Http.Json;

namespace Questao2
{
    public class JogosService
    {
        private readonly HttpClient _httpClient;

        public JogosService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<Jogos>> BuscarTodosJogos(string team, int year, string teamPos)
        {
            var jogos = new List<Jogos>();
            int currentPage = 1;
            bool hasMorePage = true;

            while (hasMorePage)
            {
                string url = GetUrl(team, year, teamPos, currentPage);
                Dados dados = await _httpClient.GetFromJsonAsync<Dados>(url);

                if (dados?.data.Count > 0)
                {
                    jogos.AddRange(dados.data);

                    hasMorePage = dados.data.Count == dados.per_page;

                    if (hasMorePage) currentPage++;
                }
                else
                {
                    hasMorePage = false;
                }
            }

            return jogos;
        }

        private static string GetUrl(string team, int year, string teamPos, int currentPage)
        {
            var teamName = team.Replace(" ", "+");
            var url = $"https://jsonmock.hackerrank.com/api/football_matches?year={year}&{teamPos}={teamName}&page={currentPage}";

            return url;
        }
    }
}
