using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using PIE5_VanessaCampos.Models;

namespace PIE5_VanessaCampos.Controllers
{
    public class CarrinhoController: Controller
    {
        private readonly ILogger<CarrinhoController> _logger;

        public CarrinhoController(ILogger<CarrinhoController> logger){
            _logger = logger;
        }

		public IActionResult Carrinho(int p=1){ 
            Autenticacao.CheckLogin(this);
            CarrinhoService carrinhoService = new CarrinhoService();            
            int qtPg = 5;            
            int userId = HttpContext.Session.GetInt32("Id").Value; 
            ICollection<Carrinho> list = carrinhoService.MaxCarrinhoPg(p, qtPg, userId); 
            int qtReg = carrinhoService.CountItems(userId);
            ViewData["Pages"] = (int)Math.Ceiling((double)qtReg/qtPg);
            return View(list);
        }
        
        public IActionResult Produtos(){
    		CarrinhoService carrinhoService = new CarrinhoService();
		    List<Produto> list = carrinhoService.Listar();
		    return View(list);
        }	

        public IActionResult Exclusivos(){		
    		CarrinhoService carrinhoService = new CarrinhoService();
		    List<Produto> list = carrinhoService.Listar();
            return View(list);
        }
   	
		public IActionResult Adicionar(Carrinho car, string Produto, string Descricao, string Tamanho){  
            try{ 
                Autenticacao.CheckLogin(this);     
                CarrinhoService carrinhoService = new CarrinhoService();  
                int userId = HttpContext.Session.GetInt32("Id").Value;    
                car.ProdutoNome = Produto;
                car.ProdutoDescricao = Descricao;
                car.ProdutoTamanho = Tamanho;
                car.Quantidade = 1;
                car.Usuario = userId;
                carrinhoService.Adicionar(car);
                return RedirectToAction("Carrinho");
            }catch(Exception e){
                _logger.LogError("Erro: " + e.Message);
                return RedirectToAction("Login", "Home");
            }
        }

        public IActionResult Aumentar(int id){            
            CarrinhoService carrinhoService = new CarrinhoService();
            Carrinho car = carrinhoService.ObterPorId(id);
            car.Quantidade = car.Quantidade + 1;
            carrinhoService.Atualizar(car);
            return RedirectToAction("Carrinho");
        }
        public IActionResult Diminuir(int id){       
            CarrinhoService carrinhoService = new CarrinhoService();
            Carrinho car = carrinhoService.ObterPorId(id);
            car.Quantidade = car.Quantidade - 1;
            if(car.Quantidade <= 1){
                car.Quantidade = 1;
            }
            carrinhoService.Atualizar(car);           
            return RedirectToAction("Carrinho");
        }
                
		public IActionResult Excluir(int id){
            Autenticacao.CheckLogin(this);
            CarrinhoService carrinhoService = new CarrinhoService();
            Carrinho car = carrinhoService.ObterPorId(id);
            carrinhoService.Excluir(id);
            return RedirectToAction("Carrinho");
        }

        public IActionResult Orcamento(){            
            Autenticacao.CheckLogin(this);
            CarrinhoService carrinhoService = new CarrinhoService();
            int userId = HttpContext.Session.GetInt32("Id").Value;    
            List<Carrinho> list = carrinhoService.ListarOrc(userId);
            return View();
            // return View(list);
        }

    }
}
