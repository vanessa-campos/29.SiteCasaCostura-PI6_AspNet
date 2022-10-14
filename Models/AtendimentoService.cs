using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PIE5_VanessaCampos.Models
{
    public class AtendimentoService
    {

        public void Solicitar(Atendimento at){
            using(CasaCosturaContext ccc = new CasaCosturaContext())
            {
                ccc.Atendimento.Add(at);
                ccc.SaveChanges();
            }
        }

        public Atendimento ObterPorId(int id)
        {
            using(CasaCosturaContext ccc = new CasaCosturaContext())
            {
                return ccc.Atendimento.Find(id);
            }
        }

        public void Atualizar(Atendimento at)
        {
            using(CasaCosturaContext ccc = new CasaCosturaContext())
            {
                Atendimento atendimento = ccc.Atendimento.Find(at.Id);
                atendimento.Nome = at.Nome;
                atendimento.Email = at.Email;
                atendimento.Telefone = at.Telefone;
                atendimento.Mensagem = at.Mensagem;
                atendimento.Atendido = at.Atendido;                
                ccc.SaveChanges();
            }
        }

        public ICollection<Atendimento> MaxAtendimentosPg(int page, int size){
            
            using(CasaCosturaContext ccc = new CasaCosturaContext())
            {
                int pular = (page-1)*size; 
                                             
                IQueryable<Atendimento> query = ccc.Atendimento;                
                query = query.Where(a => a.Atendido == false); 

                return query.Skip(pular).Take(size).OrderBy(a => a.Nome).ToList();
            }
        }

        public int CountItems(){
            using(CasaCosturaContext ccc = new CasaCosturaContext()){
                
                IQueryable<Atendimento> query = ccc.Atendimento;                
                query = query.Where(a => a.Atendido == false); 

                return query.Count();
            }
        }
    }
}