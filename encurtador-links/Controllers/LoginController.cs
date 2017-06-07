using System;
using System.Web.Mvc;
using encurtador_links.Models;
using encurtador_links.Repository;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using encurtador_links.Library;

namespace encurtador_links.Controllers
{
	/// <summary>
	/// Description of LoginController.
	/// </summary>
	public class LoginController : Controller
	{
		
		private UsuarioRepository usuarioRepository = new UsuarioRepository();
		
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult Details(int id)
		{
			return View();
		}
		
		
		[HttpPost]
		public ActionResult Index(FormCollection values)
		{
			
			Usuario usuario = new Usuario();
			Criptografia criptografia = new Criptografia();
			
			usuario.senha = criptografia.RetornarMD5(Request.Form["senha"]);

			usuario.email = Request.Form["email"];
			
 		    var usuarioLogar = usuarioRepository.GetByEmailSenha(usuario);
			 
			if (usuarioLogar != null)
			{
	 	        Session["usuarioId"] = usuarioLogar.id.ToString();
                Session["usuarioNome"] = usuarioLogar.nome;                
                
                return Redirect("/encurtador-links");
        
			}
			else
			{
			 	
			 	return View();
			}
			
			 
		
		}
		
		public ActionResult Edit(int id)
		{
			return View();
		}
		
		[HttpPost]
		public ActionResult Edit(int id, FormCollection values)
		{
			return View();
		}
		
		public ActionResult Delete(int id)
		{
			return View();
		}
		
		public ActionResult logout()
		{
			Session.Clear();
			return Redirect("/encurtador-links");
		}
	}
}