using System;
using System.Web.Mvc;

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
		public ActionResult Create(FormCollection values)
		{
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