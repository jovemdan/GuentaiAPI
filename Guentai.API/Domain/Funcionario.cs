using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guentai.API.Domain
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Username { get; set; }
        public string Senha { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFim { get; set; }
        public int PerfilId { get; set; }
        public Perfil Perfil { get; set; }
    }
}
