using TesteLar.Model;

namespace TesteLar.DAL
{
    public class PessoaRepository
    {
        private static List<Pessoa> pessoas = new List<Pessoa>();

        public void CadastrarPessoa(Pessoa pessoa)
        {
            pessoas.Add(pessoa);
        }
        public bool ValidarPessoaCadastrada(int id)
        {
            return pessoas.Any(p => p.Id == id);
        }
        public Pessoa ObterPessoa(int id)
        {
            foreach (var pessoa in pessoas)
            {
                if (pessoa.Id == id)
                {
                    return pessoa;
                }
            }

            return null;
        }
        public void AtualizarPessoa(Pessoa pessoaAtualizada)
        {
            Pessoa p =  new Pessoa() ;
            p.Nome = pessoaAtualizada.Nome;
            p.CPF = pessoaAtualizada.CPF;
            p.DataNascimento = pessoaAtualizada.DataNascimento;
            p.Ativo = pessoaAtualizada.Ativo;
            p.telefones = pessoaAtualizada.telefones;
        }

        public void ExcluirPessoa(Pessoa pessoaParaExcluir)
        {
           pessoas.Remove(pessoaParaExcluir);
        }
    }
}
