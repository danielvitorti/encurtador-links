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
				
				Criptografia criptografia = new Criptografia();
				
				url.urlCuted = criptografia.Base64(Convert.ToString(urlResult.id));
				 
				
				urlRepository.Save(url);
				
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