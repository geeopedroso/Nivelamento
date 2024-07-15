using Questao2;

public class Program
{
    public static async Task Main()
    {
        string teamName = "Paris Saint-Germain";
        int year = 2013;
        int totalGoals = await getTotalScoredGoals(teamName, year);

        Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);

        teamName = "Chelsea";
        year = 2014;
        totalGoals = await getTotalScoredGoals(teamName, year);

        Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);

        // Output expected:
        // Team Paris Saint - Germain scored 109 goals in 2013
        // Team Chelsea scored 92 goals in 2014
    }

    public static async Task<int> getTotalScoredGoals(string team, int year)
    {
        var jogosService = new JogosService();

        try
        {
            var jogosTask = jogosService.BuscarTodosJogos(team, year, "team1");
            var jogosForaTask = jogosService.BuscarTodosJogos(team, year, "team2");

            await Task.WhenAll(jogosTask, jogosForaTask);

            var jogos = jogosTask.Result;
            var jogosFora = jogosForaTask.Result;

            return jogos.Sum(jogo => Convert.ToInt32(jogo.team1goals)) + 
                        jogosFora.Sum(jogo => Convert.ToInt32(jogo.team2goals));
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Erro na requisição: {e.Message}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Erro: {e.Message}");
        }

        return 0;
    }
}
