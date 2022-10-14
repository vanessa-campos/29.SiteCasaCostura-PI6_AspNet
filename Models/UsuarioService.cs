using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PIE5_VanessaCampos.Models
{
    public class UsuarioService
    {   
		public void Cadastrar(Usuario u){
            using(CasaCosturaContext ccc = new CasaCosturaContext())
            {
                ccc.Usuario.Add(u);
                ccc.SaveChanges();
            }
        }	     

		public void Editar(Usuario u)
        {
            using(CasaCosturaContext ccc = new CasaCosturaContext())
            {
                Usuario user = ccc.Usuario.Find(u.Id);
				user.Tipo = u.Tipo;
                user.Nome = u.Nome;
				user.Login = u.Login;
                user.Senha = u.Senha;
                user.DataNascimento = u.DataNascimento;
                user.Telefone = u.Telefone;
                user.Cep = u.Cep;
                user.Endereco = u.Endereco;

                ccc.SaveChanges();              
            }
        }

        public Usuario ObterPorId(int id)
        {
            using(CasaCosturaContext ccc = new CasaCosturaContext())
            {
                return ccc.Usuario.Find(id);
            }
        }

        public void DeletarUsuario(int id)
        {
            using(CasaCosturaContext ccc = new CasaCosturaContext())
            {
                Usuario user = ccc.Usuario.Find(id);
                user.Deletado = true;
                ccc.SaveChanges();
            }
        }

		public ICollection<Usuario> MaxUsuariosPg(int page, int size){
            
            using(CasaCosturaContext ccc = new CasaCosturaContext()){              

                int pular = (page-1)*size; 
                                             
                IQueryable<Usuario> query = ccc.Usuario;              
                query = query.Where(u => u.Deletado == false); 

                return query.Skip(pular).Take(size).OrderBy(u => u.Nome).ToList();
            }
        }

        public int CountItems(){
            using(CasaCosturaContext ccc = new CasaCosturaContext()){
                
                IQueryable<Usuario> query = ccc.Usuario;              
                query = query.Where(u => u.Deletado == false); 
                return query.Count();
            }
        }

    }
}
 
