using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using PIE5_VanessaCampos.Models;

namespace PIE5_VanessaCampos.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger){
            _logger = logger;
        }

        public IActionResult Index(){
    		CarrinhoService carrinhoService = new CarrinhoService();
		    List<Produto> list = carrinhoService.Listar();
		    return View(list);
        }
        
        public IActionResult Login(){
            return View();
        }

        [HttpPost]
        public IActionResult Login(string login, string senha){            
            try{
                if(Autenticacao.CheckLoginSenha(login, senha, this)){
                    return RedirectToAction("Index");
                } 
                else{
                    ViewData["Erro"] = "Login ou senha inválidos";
                    return View();
                }
            }catch(Exception e){
                _logger.LogError("Erro: " + e.Message);
                ViewData["Erro"] = "Login ou senha inválidos";
                return View();
            }
        }

        public IActionResult Logout(){
			HttpContext.Session.Clear();            
            return RedirectToAction("Index");
	    }
        
        public IActionResult Servicos(){
            return View();
        }

        public IActionResult Contato(){
            return View();
        }
        
        [HttpPost]
        public IActionResult Solicitar(Atendimento atendimento){
                        
            AtendimentoService atendimentoService = new AtendimentoService();
            if(atendimento.Id == 0) {
                atendimentoService.Solicitar(atendimento);                
                return RedirectToAction("Index");
            }else{
                atendimentoService.Atualizar(atendimento);
                return RedirectToAction("Atendimento");
            }
        }

        public IActionResult Atendimento(int p=1){ 
            Autenticacao.CheckLogin(this);
            Autenticacao.CheckIfUserIsAdmin(this);
            AtendimentoService atendimentoService = new AtendimentoService();            
            int qtPg = 5;            
            ICollection<Atendimento> list = atendimentoService.MaxAtendimentosPg(p, qtPg);             
            int qtReg = atendimentoService.CountItems();
            ViewData["Pages"] = (int)Math.Ceiling((double)qtReg/qtPg);
            return View(list);
        }

        public IActionResult Editar(int id){
            Autenticacao.CheckLogin(this);
            AtendimentoService atendimentoService = new AtendimentoService();
            Atendimento at = atendimentoService.ObterPorId(id);      
            return View(at);
        }

    }
}
