using Microsoft.AspNetCore.Mvc;
using TesteLar.BLL;
using TesteLar.Model;

namespace TesteLar.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TelefoneController : ControllerBase
    {

        //private static List<Telefone> Telefones = new List<Telefone>();

        //[HttpPost]
        //public IActionResult CadastrarTelefone([FromBody] string Tipo)
        //{
        //    Telefones.Add(Telefone);

        //    bool ValidaTelefoneCadastrada = false;

        //    ValidaTelefoneCadastrada = BOTelefone.ValidarTipoTelefoneCadastrada(Tipo);
        //    if (!ValidaTelefoneCadastrada)
        //    {
        //        boTelefone.CadastrarTelefone(Telefone);
        //        return CreatedAtAction(nameof(boTelefone.ObterTelefonePorId), new { id = Telefone.Id }, Telefone);
        //    }
        //    else
        //    {
        //        return Ok(new { mensagem = "Telefone já cadastrada." });
        //    }
        //}
    }
}
