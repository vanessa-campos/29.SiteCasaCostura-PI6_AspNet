using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PIE5_VanessaCampos.Models;

namespace PIE5_VanessaCampos.Controllers
{
    public class Autenticacao
    {
        public static void CheckLogin(Controller controller)
        {   
            if(string.IsNullOrEmpty(controller.HttpContext.Session.GetString("Login")))
            {
                controller.Request.HttpContext.Response.Redirect("/Home/Login");
            }
        }

        public static bool CheckLoginSenha(string login, string senha, Controller controller){
            using (CasaCosturaContext ccc = new CasaCosturaContext()){
                CheckIfUserAdminExist(ccc);
                
                senha = Encrypt.TextEncrypted(senha);

                IQueryable<Usuario> usuarioEncontrado = ccc.Usuario.Where(u => u.Login == login && u.Senha == senha);
                List<Usuario> ListaUsuariosEncontrados = usuarioEncontrado.ToList();

                if(ListaUsuariosEncontrados.Count == 0){
                    return false;
                }else{
                    //registrando na sessão os dados do usuário encontrado
                    controller.HttpContext.Session.SetString("Login", ListaUsuariosEncontrados[0].Login);
                    controller.HttpContext.Session.SetString("Nome", ListaUsuariosEncontrados[0].Nome);
                    controller.HttpContext.Session.SetInt32("Tipo", ListaUsuariosEncontrados[0].Tipo);
                    controller.HttpContext.Session.SetInt32("Id", ListaUsuariosEncontrados[0].Id);
                    return true;
                }
            }
        }

        public static void CheckIfUserAdminExist(CasaCosturaContext ccc){
            IQueryable<Usuario> usuarioEncontrado = ccc.Usuario.Where(u => u.Login == "admin");

            //Se não existir será criado o usuário admin 
            if(usuarioEncontrado.ToList().Count==0){
                Usuario admin = new Usuario();
                admin.Login = "admin";
                admin.Senha = Encrypt.TextEncrypted("123");
                admin.Tipo = Usuario.ADMIN;
                admin.Nome = "Administrador";

                ccc.Usuario.Add(admin);
                ccc.SaveChanges();
            }
        }

        public static void CheckIfUserIsAdmin(Controller controller){
            if(!(controller.HttpContext.Session.GetInt32("Tipo") == Usuario.ADMIN)){
                controller.Request.HttpContext.Response.Redirect("/Usuario/AdminRequired");   
            }
        }
    }
}