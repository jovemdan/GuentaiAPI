using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guentai.API.Data
{
    public class ClienteMesa
    {
        public int Id { get; set; }
        public int? ClienteId { get; set; }
        public int? MesaId { get; set; }
        public int? FuncionarioId { get; set; }
        public string Status { get; set; }


        public Cliente Cliente { get; set; }
        public Mesa Mesa { get; set; }
        public Funcionario Funcionario { get; set; }
    }
}
