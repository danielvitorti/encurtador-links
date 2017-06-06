/*
 * Criado por SharpDevelop.
 * Usuário: Daniel
 * Data: 05/06/2017
 * Hora: 21:40
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 */
using System;
using System.Web;
using System.Web.Mvc;


namespace encurtador_links.Library
{
	/// <summary>
	/// Description of Sessao.
	/// </summary>
	public class Sessao
	{
		
		
		public Sessao()
		{
		}
		
		
		/// <summary>
		/// verifica se a funcao existe. se nao tiver dados na sessao, joga pra pagina de login
		/// </summary>
		public static void verificaSessao()
		{
			
			if( HttpContext.Current.Session["usuarioId"] == null)
			{
				
				HttpContext.Current.Response.Redirect("/encurtador-links/login");
				
				
			}
		}
		
		
		public static string retornaDadoSessao(string dadoSessao = null)
		{
			var dado = "";
			
			dado = HttpContext.Current.Session[dadoSessao].ToString();
			
			return dado;
		}
	
	}
}
