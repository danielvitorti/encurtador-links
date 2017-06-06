using System;
using System.Web.Mvc;
using encurtador_links.Repository;
using encurtador_links.Models;
namespace encurtador_links.Controllers
{
	
	
	
	/// <summary>
	/// Description of UrlController.
	/// </summary>
	public class UrlController : Controller
	{
		private UrlRepository urlRepository = new UrlRepository();
	
	
		public ActionResult Index()
		{
			return View(urlRepository.GetAll());
		}

		public ActionResult Details(int id)
		{
			return View();
		}
		
		public ActionResult Create()
		{
			return View();
		}
		
		[HttpPost]
		public ActionResult Create(Url url)
		{
			
			if(ModelState.IsValid)
			{
				urlRepository.Save(url);
				
				return RedirectToAction("index");
			}
			else
			{
				return View(url);
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
		
		/*
		public ActionResult Delete(int id)
		{
			return View();
		} */
		 // POST: Pessoa/Delete/5
	    [HttpPost]
	    public ActionResult Delete(int id)
	    {
	        urlRepository.DeleteById(id);
	        return Json(urlRepository.GetAll());     
			//return View();	        
	    }
	}
}