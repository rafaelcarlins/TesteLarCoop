
using NSwag.Annotations;

namespace TesteLar.Model
{
    public class PessoaInput
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool Ativo { get; set;}
        public List<Telefone> telefones { get; set; } = new List<Telefone>();
    }
}
 