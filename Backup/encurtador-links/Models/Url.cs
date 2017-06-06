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
	/// Description of Url.
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
		[Display(Name="Nome")]
		[Required(ErrorMessage = "O campo Nome é obrigatório")]
		public string urlSite{get; set;}
		public string urlCuted{get; set;}
		public int urlUsuario{get; set;}
		public int urlAcessos{get;set;}
		
	}
	
	
	
	
	/*
	  * 	urlNormal	text	NO			
	dataCadastro	date	YES			
	urlSite	varchar(100)	YES			
	urlCuted	text	YES			
	urlUsuario	int(11)	NO	MUL		
	urlAcessos	bigint(20)	NO		0	
	  * 
	  * */
}
