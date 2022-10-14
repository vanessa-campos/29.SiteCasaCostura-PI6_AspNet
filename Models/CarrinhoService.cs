using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PIE5_VanessaCampos.Models
{
    public class CarrinhoService
    {
		public void Adicionar(Carrinho car){
            using(CasaCosturaContext ccc = new CasaCosturaContext())
            {
                ccc.Carrinho.Add(car);
                ccc.SaveChanges();
            }
        }		

		public List<Produto> Listar()
        {
            using(CasaCosturaContext ccc = new CasaCosturaContext())
            {
                IQueryable<Produto> query;
                query = ccc.Produto;              
                return query.OrderBy(c => c.Id).ToList();
            }
        }

		public void Excluir(int id)
        {
            using(CasaCosturaContext ccc = new CasaCosturaContext())
            {
                Carrinho c = ccc.Carrinho.Find(id);
                ccc.Carrinho.Remove(c);
                ccc.SaveChanges();
            }
        }
        
		public Carrinho ObterPorId(int id)
        {
            using(CasaCosturaContext ccc = new CasaCosturaContext())
            {
                return ccc.Carrinho.Find(id);
            }
        }

		public void Atualizar(Carrinho car)
        {
            using(CasaCosturaContext ccc = new CasaCosturaContext())
            {
                Carrinho carrinho = ccc.Carrinho.Find(car.Id);
                carrinho.Quantidade = car.Quantidade;
                carrinho.Concluido = car.Concluido;
                ccc.SaveChanges();              
            }
        }
		                                                                                                                            
		public ICollection<Carrinho> MaxCarrinhoPg(int page, int size, int userId){
            
            using(CasaCosturaContext ccc = new CasaCosturaContext())
            {
                int pular = (page-1)*size; 
                                             
                IQueryable<Carrinho> query = ccc.Carrinho.Where(c => c.Usuario == userId).Where(c => c.Concluido == false);
                return query.Skip(pular).Take(size).OrderBy(c => c.Id).ToList();
            }
        }

        public int CountItems(int userId){
            using(CasaCosturaContext ccc = new CasaCosturaContext()){                
                IQueryable<Carrinho> query = ccc.Carrinho.Where(c => c.Usuario == userId).Where(c => c.Concluido == false); 
                return query.Count();
            }
        }

        public List<Carrinho> ListarOrc(int userId)
        {
            using(CasaCosturaContext ccc = new CasaCosturaContext())
            {
                IQueryable<Carrinho> query = ccc.Carrinho.Where(c => c.Usuario == userId);
                foreach (Carrinho car in query)
                {
                    car.Concluido = true;
                    Atualizar(car);
                }
                query = ccc.Carrinho.Where(c => c.Concluido == true);
                return query.OrderBy(c => c.Id).ToList();
            }
        }
    }
}