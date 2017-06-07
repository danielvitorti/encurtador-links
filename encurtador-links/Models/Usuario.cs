/*
 * Criado por SharpDevelop.
 * Usuário: Daniel
 * Data: 04/06/2017
 * Hora: 16:17
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 */
using System;
using System.ComponentModel.DataAnnotations;

namespace encurtador_links.Models
{
	/// <summary>
	/// Description of Usuario.
	/// </summary>
	public class Usuario
	{
		public Usuario()
		{
			this.dataCadastro = DateTime.Now;
			this.status = "1";
		}
		
		
		
		public int id{get; set;}
		
		[Display(Name="Nome")]
		[Required(ErrorMessage = "Campo obrigatorio")]
		public string nome{get; set;}
		
		[Display(Name="E-mail")]
		[DataType(DataType.EmailAddress,ErrorMessage = "Endereço de e-mail inválido")]
		[Required(ErrorMessage = "Campo obrigatorio")]
		public string email{get; set;}
		
		[Display(Name="Senha")]
		[Required(ErrorMessage = "Campo obrigatorio")]
		[DataType(DataType.Password)]
		public string senha{get; set;}
		
		
		
		[Display(Name="Confirmar senha")]
		[Required(ErrorMessage = "Campo obrigatorio")]		
		[DataType(DataType.Password)]
		[Compare("senha",ErrorMessage = "As senhas devem ser iguais.")]
		public string confirmarSenha{get; set;}
		
		
		public DateTime dataCadastro{get; set;}
		
		
		public string status{get; set;}
		
	}
}
