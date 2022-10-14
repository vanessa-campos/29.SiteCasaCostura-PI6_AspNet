using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using PIE5_VanessaCampos.Models;

namespace PIE5_VanessaCampos.Controllers
{
    public class UsuarioController: Controller
    {       
        private readonly ILogger<UsuarioController> _logger;

        public UsuarioController(ILogger<UsuarioController> logger){
            _logger = logger;
        }

        public IActionResult AdminRequired(){
            Autenticacao.CheckLogin(this);
            return View();
        }

        public IActionResult Cadastro(){
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(Usuario u){    

            UsuarioService usuarioService = new UsuarioService();
            if(u.Id == 0) {
                u.Senha = Encrypt.TextEncrypted(u.Senha);
                u.Tipo = Usuario.PADRAO;
                usuarioService.Cadastrar(u);
                return RedirectToAction("Index", "Home");
            }
            else{
                u.Senha = Encrypt.TextEncrypted(u.Senha);
                usuarioService.Editar(u);           
                if(u.Login != "admin"){
                    return RedirectToAction("Index", "Home");
                }else{
                    return RedirectToAction("Listagem");
                }
            }
        }
        
        public IActionResult MinhaConta(){
            try{
                Autenticacao.CheckLogin(this);            
                int id = HttpContext.Session.GetInt32("Id").Value;            
                UsuarioService us = new UsuarioService();
                Usuario u = us.ObterPorId(id);
                return View(u);
            }catch(Exception e){
                _logger.LogError("Erro: " + e.Message);
                return RedirectToAction("Index", "Home");
            }
        }

	    public IActionResult Edicao(int id){
            Autenticacao.CheckLogin(this);
            UsuarioService us = new UsuarioService();
            Usuario u = us.ObterPorId(id);
            return View(u);
        }

		public IActionResult Listagem(int p=1){
            Autenticacao.CheckLogin(this);
            Autenticacao.CheckIfUserIsAdmin(this);
            int qtPg = 3;            
            UsuarioService usuarioService = new UsuarioService();  
            ICollection<Usuario> list = usuarioService.MaxUsuariosPg(p, qtPg);
            int qtReg = usuarioService.CountItems();
            ViewData["Pages"] = (int)Math.Ceiling((double)qtReg/qtPg);
            return View(list);
        }

	    public IActionResult Excluir(int id){
            Autenticacao.CheckLogin(this);            
            UsuarioService us = new UsuarioService();
            Usuario u = us.ObterPorId(id);
            return View(u);
        }

        [HttpPost]
        public IActionResult Excluir(int id, string escolha){
            Autenticacao.CheckLogin(this);
            UsuarioService us = new UsuarioService();
            Usuario u = us.ObterPorId(id);            
            if(escolha == "s"){
                us.DeletarUsuario(id);
                if(u.Login != "admin"){
                    return RedirectToAction("Index", "Home");
                }else{
                    return RedirectToAction("Listagem");
                }  
            }else{
                if(u.Login != "admin"){
                    return RedirectToAction("MinhaConta");
                }else{
                    return RedirectToAction("Listagem");
                } 
            }
        }
    }
}