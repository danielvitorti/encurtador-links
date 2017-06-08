using System;
using System.Web.Mvc;
using encurtador_links.Models;
using System.Security.Cryptography;
using encurtador_links.Library;
using encurtador_links.Repository;

namespace encurtador_links.Controllers
{
	/// <summary>
	/// Description of UsuarioController.
	/// </summary>
	public class UsuarioController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult Details(int id)
		{
			return View();
		}
		
		public ActionResult cadastrar()
		{
			return View();
		}
		
		
		
		[HttpPost]
		public ActionResult cadastrar(Usuario usuario,FormCollection values)
		{
			
			Criptografia criptografia = new Criptografia();
			
			usuario.nome = Request.Form["nome"];
			usuario.email = Request.Form["email"];
			usuario.senha = criptografia.RetornarMD5(Request.Form["senha"]);
			usuario.status = "1"; // -- Pode cadastrar o usuario como inativo, só que aí tem que implementar a tela de ativaçao, que é a que vai por email pro cara ativar o cadastro
			
			
			
			
			if(ModelState.IsValid)
			{
				
				UsuarioRepository usuarioRepository = new UsuarioRepository();
				
				if(usuarioRepository.verificaExisteEmailUsuario(usuario) == false)
				{
					usuarioRepository.Save(usuario);
					
					return Redirect("/encurtador-links/login");
					
				}
				else
				{
					
					ViewBag.Error = "Este e-mail já se encontra cadastrado!";
					return View();
				}
			}
			return View();
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
	}
}