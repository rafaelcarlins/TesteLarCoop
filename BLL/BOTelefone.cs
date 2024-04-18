using TesteLar.DAL;
using TesteLar.Model;

namespace TesteLar.BLL
{
    public class BOTelefone
    {
        private readonly TelefoneRepository telefoneRepository;

        public BOTelefone(TelefoneRepository telefoneRepository)
        {
            this.telefoneRepository = telefoneRepository;
        }

        public void Cadastrartelefone(Telefone telefone)
        {
            telefoneRepository.Cadastrartelefone(telefone);
        }

        public bool ValidarTipoTelefoneCadastrada(string Tipo)
        {
            bool validado = false;
            validado = telefoneRepository.ValidartelefoneCadastrada(Tipo);
            return validado;
        }

        //public Telefone ObtertelefonePorId(int id)
        //{
        //    Telefone telefoneRetorno = telefoneRepository.Obtertelefone(id);
        //    return telefoneRetorno;
        //}
        private List<Telefone> telefones = new List<Telefone>();
        public void Atualizartelefone(int id, Telefone telefoneAtualizada)
        {
            //var telefoneExistente = telefones.FirstOrDefault(p => p.Id == telefoneAtualizada.Id);

            //if (telefoneExistente != null)
            //{
            //    telefoneExistente.Tipo = telefoneAtualizada.Tipo;
            //    telefoneExistente.numero = telefoneAtualizada.Numero;
            //}
            //else
            //{
            //    throw new Exception("telefone não encontrada"); 
            //}
        }
        public void Excluirtelefone(int id)
        {
            //var telefoneExcluir = telefones.FirstOrDefault(p => p.Id == id);

            //if (telefoneExcluir != null)
            //{
            //    telefoneRepository.Excluirtelefone(telefoneExcluir);
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }

    }
}
