using TesteLar.DAL;
using TesteLar.Model;

namespace TesteLar.BLL
{
    public class BOPessoa
    {
        private readonly PessoaRepository pessoaRepository;

        public BOPessoa(PessoaRepository pessoaRepository)
        {
            this.pessoaRepository = pessoaRepository;
        }

        public void CadastrarPessoa(Pessoa pessoa)
        {
            pessoaRepository.CadastrarPessoa(pessoa);
        }

        public bool ValidarPessoaCadastrada(int id)
        {
            bool validado = false;
            validado = pessoaRepository.ValidarPessoaCadastrada(id);
            return validado;
        }

        public Pessoa ObterPessoaPorId(int id)
        {
            Pessoa pessoaRetorno = pessoaRepository.ObterPessoa(id);
            return pessoaRetorno;
        }
        public void AtualizarPessoa(int id, Pessoa pessoaAtualizada)
        {
            Pessoa pessoaExistente = pessoaRepository.ObterPessoa(id);

            if (pessoaExistente != null)
            {
                pessoaExistente.Nome = pessoaAtualizada.Nome;
                pessoaExistente.Ativo = pessoaAtualizada.Ativo;
                pessoaExistente.CPF = pessoaAtualizada.CPF;
                pessoaExistente.DataNascimento = pessoaAtualizada.DataNascimento;
                pessoaExistente.telefones = new List<Telefone>();

                foreach (var tel in pessoaAtualizada.telefones)
                {
                    pessoaExistente.telefones.Add(tel);
                }

                pessoaRepository.AtualizarPessoa(pessoaExistente);
            }
            else
            {
                throw new Exception("Pessoa não encontrada"); 
            }
        }
        public bool ExcluirPessoa(int id)
        {
            var pessoaExcluir = pessoaRepository.ObterPessoa(id);

            if (pessoaExcluir != null)
            {
                pessoaRepository.ExcluirPessoa(pessoaExcluir);
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
