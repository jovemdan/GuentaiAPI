using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guentai.API.Data
{
    public class Mesa
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int QtdCadeiras { get; set; }
        public string Status { get; set; }
        public int FuncionarioId { get; set; }
        public Funcionario Funcionario { get; set; }
        public IEnumerable<ClienteMesa> ClienteMesa { get; set; }
    }
}
