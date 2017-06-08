using System;
using System.Web.Mvc;
using encurtador_links.Library;
using encurtador_links.Models;
using encurtador_links.Repository;

namespace encurtador_links.Controllers
{
	/// <summary>
	/// Description of UController.
	/// </summary>
	public class UController : Controller
	{
		
		public ActionResult i(string codigoUrl)
		{
			Sessao.verificaSessao();
			
			
			UrlRepository urlRepository = new UrlRepository();
			Criptografia criptografia = new Criptografia();
			
			
			var url = urlRepository.GetById(Convert.ToInt32(criptografia.Base64Decode(codigoUrl)));
			
			                                                
			return Redirect(url.urlNormal);
		}
	}
}