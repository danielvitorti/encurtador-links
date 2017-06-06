/*
 * Criado por SharpDevelop.
 * Usuário: Daniel
 * Data: 23/05/2017
 * Hora: 23:10
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 */
using System;
using System.Management.Instrumentation;
using System.Collections.Generic;


namespace encurtador_links.Repository
{
	/// <summary>
	/// Description of UrlRepository.
	/// </summary>
	public abstract class AbstractRepository<TEntity, TKey> where TEntity: class
	{
		
		//protected string StringConnection { get; } = WebConfigurationManager.ConnectionStrings["DatabaseCrud"].ConnectionString;


		
		//protected string StringConnection { get; } = WebConfigurationManager.ConnectionStrings["ConexaoEncurtadorLinks"].ConnectionString;


		
		public abstract List<TEntity> GetAll();
	    public abstract TEntity GetById(TKey id);
	    public abstract void Save(TEntity entity);
	    public abstract void Update(TEntity entity);
	    public abstract void Delete(TEntity entity);
	    public abstract void DeleteById(TKey id);
	    
	}
}
