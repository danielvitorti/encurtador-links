﻿/*
 * Criado por SharpDevelop.
 * Usuário: Daniel
 * Data: 23/05/2017
 * Hora: 22:34
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 */
using System;
using System.Web.Mvc;
using encurtador_links.Library;

namespace encurtador_links.Controllers
{
	public class HomeController : Controller
	{
		
		
			
		public ActionResult Index()
		{
			
			
			Sessao.verificaSessao();
			 
			
			return View();
			
		}
		
		public ActionResult Contact()
		{
			Sessao.verificaSessao();
			return View();
		}
	}
}
