/*
 * Criado por SharpDevelop.
 * Usuário: Daniel
 * Data: 23/05/2017
 * Hora: 23:00
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 */
using System;
using System.ComponentModel.DataAnnotations;



namespace encurtador_links.Models
{
	/// <summary>
	/// classe de entidade URL
	/// </summary>
	public class Url
	{
		public Url()
		{
			this.dataCadastro = DateTime.Now;
		}
		
		public int id{get; set;}
		
		[Display(Name="Link")]
		[Required(ErrorMessage = "O campo Link é obrigatório")]
		public string urlNormal{get; set;}
		
		public DateTime dataCadastro {get; set;}
		[Display(Name="Identificacao")]
		[Required(ErrorMessage = "O campo obrigatório")]
		public string urlSite{get; set;}
		
		[Display(Name="Link encurtado")]
		public string urlCuted{get; set;}
		[Display(Name="Usuário")]
		public int urlUsuario{get; set;}
		[Display(Name="Acessos")]
		public int urlAcessos{get;set;}
		
	}
	
	
}
