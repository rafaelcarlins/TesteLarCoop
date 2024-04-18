using TesteLar.Model;

namespace TesteLar.DAL
{
    public class TelefoneRepository
    {
        private static List<Telefone> telefones = new List<Telefone>();

        public void Cadastrartelefone(Telefone telefone)
        {
            telefones.Add(telefone);
        }
        public bool ValidartelefoneCadastrada(string Tipo)
        {
            return telefones.Any(p => p.Tipo == Tipo);
        }
        //public Telefone Obtertelefone(int id)
        //{
        //    foreach (var telefone in telefones)
        //    {
        //        if (telefone.Id == id)
        //        {
        //            return telefone;
        //        }
        //    }

        //    return null;
        //}
        //public void Atualizartelefone(Telefone telefoneAtualizada)
        //{
        //    Telefone p =  new Telefone() ;
        //    p.Nome = telefoneAtualizada.Nome;
        //}

        public void Excluirtelefone(Telefone telefoneParaExcluir)
        {
           telefones.Remove(telefoneParaExcluir);
        }
    }
}
