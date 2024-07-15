using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questao2
{
    public record Jogos(
    string competition,
    int year,
    string round,
    string team1,
    string team2,
    string team1goals,
    string team2goals
    );

    public record Dados(List<Jogos> data, int per_page);
}
