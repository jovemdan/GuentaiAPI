using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Guentai.API.Domain;
using Microsoft.AspNetCore.Authorization;
using Guentai.API.Services;

namespace Guentai.API.Controllers
{
  [Route("api/account")]
  public class FuncionarioLoginController : Controller
  {
    private readonly GuentaiDbContext _context;

    public FuncionarioLoginController(GuentaiDbContext context)
    {
      _context = context;
    }

    [HttpPost]
    [Route("login")]
    [AllowAnonymous]
    public async Task<ActionResult<dynamic>> Authenticate([FromBody] Funcionario model)
    {
      var funcionario = await _context.Funcionarios.ToListAsync();
      var user = funcionario.Find(q => q.Username == model.Username && q.Senha == model.Senha);
      if (user == null)
        return NotFound(new { message = "Usuário ou senha inválidos" });

      var token = TokenService.GenerateToken(user);
      user.Senha = "";
      return new
      {
        user = user,
        token = token
      };
    }
    [HttpGet]
    [Route("anonymous")]
    [AllowAnonymous]
    public string Anonymous() => "Anônimo";

    [HttpGet]
    [Route("authenticated")]
    [Authorize]
    public string Authenticated() => String.Format("Autenticado - {0}", User.Identity.Name);

    [HttpGet]
    [Route("employee")]
    [Authorize(Roles = "1,2")] //adm,garçom
    public string Employee() => "Garçom";

    [HttpGet]
    [Route("manager")]
    [Authorize(Roles = "1")] //adm
    public string Manager() => "ADM";
  }
}