using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TesteLar.BLL;
using TesteLar.DAL;
using TesteLar.Model;
using static TesteLar.Controllers.PessoaController;


namespace TesteLar.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoaController : ControllerBase
    {
        #region propriedades
        private static List<Pessoa> pessoas = new List<Pessoa>();
        private readonly BOPessoa boPessoa;
        
        #endregion

        #region construtor
        public PessoaController(BOPessoa BOPessoa)
        {
            boPessoa = BOPessoa;
        }
        #endregion

        #region eventos
        //as variaveis de tipoTel e numeroTel estão discriminadas para facilitar pegá-las no swagger
        [HttpPost]
        public IActionResult CadastrarPessoa([FromQuery] Pessoa input, string TipoTelCelular = "Celular", int numeroTelCelular = 0, string TipoTelResidencial = "Residencial", 
            int numeroTelResidencial = 0, string TipoTelComercial = "Comercial", int numeroTelComercial = 0)
        {
            Pessoa pessoa = new Pessoa();
 
            pessoa.Id = pessoas.Count + 1;
            pessoa.Nome = input.Nome;
            pessoa.CPF = input.CPF;
            pessoa.DataNascimento = input.DataNascimento;
            pessoa.Ativo = input.Ativo;
            //pegando as variáveis de telefone para transformá-las em lista, foi realizado assim para facilitar a parte do swagger
            List<Telefone> telefones = new List<Telefone>();
            telefones = TelefoneEmLista(TipoTelCelular, numeroTelCelular, TipoTelResidencial, numeroTelResidencial, TipoTelComercial, numeroTelComercial);

            foreach (var tel in telefones)
            {
                pessoa.telefones.Add(tel);
            }

            pessoas.Add(pessoa);

            bool ValidaPessoaCadastrada = false;

            ValidaPessoaCadastrada = boPessoa.ValidarPessoaCadastrada(pessoa.Id);
            if (!ValidaPessoaCadastrada)
            {
                boPessoa.CadastrarPessoa(pessoa);
                return Ok(new { mensagem = "Pessoa cadastrada com sucesso" });
            }
            else
            {
                return Ok(new { mensagem = "Pessoa já cadastrada." });
            }            
        }
        [HttpGet]
        public IActionResult ObterPessoa(int id)
        {
            Pessoa pessoa = boPessoa.ObterPessoaPorId(id);
            if (pessoa == null)
            {
                return NotFound(new { mensagem = "Pessoa não cadastrada." });
            }

            return Ok(pessoa);
        }
        //as variaveis de tipoTel e numeroTel estão discriminadas para facilitar pegá-las no swagger
        [HttpPut]
        public IActionResult AlterarPessoa([FromQuery] Pessoa input, string TipoTelCelular="Celular", int numeroTelCelular=0, string TipoTelResidencial = "Residencial",
            int numeroTelResidencial = 0, string TipoTelComercial = "Comercial", int numeroTelComercial=0)
        {
            Pessoa pessoaExistente = boPessoa.ObterPessoaPorId(input.Id);

            if (pessoaExistente == null)
            {
                return NotFound(new { mensagem = "Pessoa não cadastrada." });
            }

            Pessoa pessoa = new Pessoa();

            pessoa.Nome = input.Nome;
            pessoa.CPF = input.CPF;
            pessoa.DataNascimento = input.DataNascimento;
            pessoa.Ativo = input.Ativo;

            //pegando as variáveis de telefone para transformá-las em lista, foi realizado assim para facilitar a parte do swagger
            List<Telefone> telefones = new List<Telefone>();
            telefones = TelefoneEmLista(TipoTelCelular, numeroTelCelular, TipoTelResidencial, numeroTelResidencial, TipoTelComercial, numeroTelComercial);

            foreach (var tel in telefones)
            {
                pessoa.telefones.Add(tel);
            }

            pessoas.Add(pessoa);

            boPessoa.AtualizarPessoa(pessoaExistente.Id, pessoa);

            return Ok(pessoaExistente);

        }
        [HttpDelete("{id}")]
        public IActionResult ExcluirPessoa(int id)
        {
            try
            {
                bool excluirPessoa = boPessoa.ExcluirPessoa(id);
                if (excluirPessoa)
                {
                    return Ok(new { mensagem = "Pessoa excluída com sucesso" });
                }
                else
                {
                    return StatusCode(500, "Pessoa não excluída");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao excluir a pessoa: {ex.Message}");
            }
        }
        #endregion
        #region Metodos
        private List<Telefone> TelefoneEmLista(string TipoTelCelular, int numeroTelCelular, string TipoTelResidencial,
            int numeroTelResidencial, string TipoTelComercial, int numeroTelComercial)
        {
            List<Telefone> telefones = new List<Telefone>();
            Telefone telefone = new Telefone();

            if (TipoTelCelular != string.Empty)
            {
                telefone.Tipo = TipoTelCelular;
            }
            if (numeroTelCelular != 0)
            {
                telefone.Numero = numeroTelCelular;
            }
            if (telefone != null)
            {
                telefones.Add(telefone);
            }
            
            telefone = new Telefone();
           
            if (TipoTelResidencial != string.Empty)
            {
                telefone.Tipo = TipoTelResidencial;
            }
            if (numeroTelResidencial != 0)
            {
                telefone.Numero = numeroTelResidencial;
            }
            if (telefone != null)
            {
                telefones.Add(telefone);
            }

            telefone = new Telefone();

            if (TipoTelComercial != string.Empty)
            {
                telefone.Tipo = TipoTelComercial;
            }
            if (numeroTelComercial != 0)
            {
                telefone.Numero = numeroTelComercial;
            }
            if (telefone != null)
            {
                telefones.Add(telefone);
            }

            return telefones;

        }
        #endregion
    }
}
