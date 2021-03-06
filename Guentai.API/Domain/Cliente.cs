using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guentai.API.Domain
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int QtdPessoas { get; set; }
        public string Status { get; set; }
        public int FuncionarioId { get; set; }
        public Funcionario Funcionario { get; set; }
        public IEnumerable<ClienteMesa> ClienteMesa { get; set; }
    }
}
