using System;
using System.Web.Mvc;
using encurtador_links.Repository;
using encurtador_links.Models;
using System.Text;
using encurtador_links.Library;

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
			Sessao.verificaSessao();
			return View(urlRepository.GetAll());
		}

		public ActionResult Details(int id)
		{
			Sessao.verificaSessao();
			return View();
		}
		
		public ActionResult encurtar()
		{
			Sessao.verificaSessao();
			return View();
		}
		
		[HttpPost]
		public ActionResult encurtar(Url url)
		{
			Sessao.verificaSessao();
			url.urlNormal = Request.Form["urlNormal"];
			url.urlSite = Request.Form["urlSite"];
			url.urlUsuario = Convert.ToInt16(Sessao.retornaDadoSessao("usuarioId")); // teste apenas
			
			
			if(ModelState.IsValid)
			{
				
				var urlResult = urlRepository.GetMaxId(url);
				
				url.urlCuted = Convert.ToString(Convert.ToBase64String(Encoding.UTF8.GetBytes(Convert.ToString(urlResult.id)))); // -- Converter aqui para base 64
				
				urlRepository.Save(url);
				
				
				// -- tem que encurtar agora 
				
				
				/*Url urlAlterar = new Url();
				
				urlAlterar.urlCuted = Convert.ToString(Convert.ToBase64String(Encoding.UTF8.GetBytes(Convert.ToString(urlResult.id)))); // -- Converter aqui para base 64
				urlAlterar.urlNormal = url.urlNormal;
				urlAlterar.urlSite = url.urlSite;
				url.urlUsuario = Convert.ToInt16(Sessao.retornaDadoSessao("usuarioId"));
				
		
				urlRepository.Update(urlAlterar); */
				
				return RedirectToAction("index");
			}
			else
			{
				return View(url);
			}
			
			
		}
		
		public ActionResult alterar(int id)
		{
			Sessao.verificaSessao();
			var url = urlRepository.GetById(id);

	        if (url == null)
	        {
	            return HttpNotFound();
	        }
			return View(url);
		}
		
		[HttpPost]
		public ActionResult alterar(Url url, FormCollection values)
		{
			
			Sessao.verificaSessao();
	        if (ModelState.IsValid)
	        {
	            urlRepository.Update(url);
	            return RedirectToAction("index");
	        }
	        else
	        {
	            return View(url);
	        }
		}
		
	    [HttpGet]
	    public ActionResult Delete(int id)
	    {
	    	Sessao.verificaSessao();
	        urlRepository.DeleteById(id);
        	return Json(urlRepository.GetAll(),JsonRequestBehavior.AllowGet);          
	    }
	    
	    
	   
	}
}