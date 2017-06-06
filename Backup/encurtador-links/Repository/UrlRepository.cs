/*
 * Criado por SharpDevelop.
 * Usuário: Daniel
 * Data: 23/05/2017
 * Hora: 23:14
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 */
using System;
using System.Collections.Generic;
using System.Data;

using encurtador_links.Models;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace encurtador_links.Repository
{
	/// <summary>
	/// Description of UrlRepository.
	/// </summary>
	public class UrlRepository : AbstractRepository<Url, int>
	{
		
		private string StringConnection = "Server=localhost;Database=urlcutdb;Uid=root;Pwd=;";
		
		public UrlRepository()
		{
		}
		
		public override void Delete(Url entity)
		{
			
			using (var conn = new MySqlConnection(this.StringConnection))
	        {
	            string sql = "DELETE from Urls Where Id=@Id";
	            
	            MySqlCommand cmd  = new MySqlCommand(sql,conn);
	            
	            
	            cmd.Parameters.AddWithValue("@Id", entity.id);
	            try
	            {
	                conn.Open();
	                cmd.ExecuteNonQuery();
	            }
	            catch (Exception e)
	            {
	                throw e;
	            }
	        }
		}
		
		
		public override void DeleteById(int id)
	    {
	        using (var conn = new MySqlConnection(this.StringConnection))
	        {
	            string sql = "DELETE from Urls Where Id=@Id";
	            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
	            cmd.Parameters.AddWithValue("@Id", id);
	            try
	            {
	                conn.Open();
	                cmd.ExecuteNonQuery();
	            }
	            catch (Exception e)
	            {
	                throw e;
	            }
	        }
	    }
		
	     public override List<Url> GetAll()
    {
        string sql = "Select * from url order by id desc";
        using (var conn = new  MySql.Data.MySqlClient.MySqlConnection(this.StringConnection))
        {
            var cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
            List<Url> list = new List<Url>();
            Url u = null;
            try
            {
                conn.Open();
                
                using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        
                        u = new Url();
                        u.id = (int)reader["id"];
                        u.urlSite = reader["urlSite"].ToString();
                        u.urlNormal = reader["urlNormal"].ToString();
                        u.urlAcessos = (int)reader["urlAcessos"];
                        list.Add(u);
                       
                    }
                }
            }
            catch(Exception e)
            {
                throw e;
            }
            return list;
        }
    }
				

	
	
	
	public override void Save(Url entity)
	{
		using (var conn = new MySql.Data.MySqlClient.MySqlConnection(this.StringConnection))
        {
			

			
			string sql = "INSERT INTO url (urlNormal, dataCadastro, urlSite, urlUsuario) VALUES (@urlNormal, @dataCadastro, @urlSite, @urlUsuario)";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@urlNormal", entity.urlNormal);
            cmd.Parameters.AddWithValue("@dataCadastro", DateTime.Now);
            cmd.Parameters.AddWithValue("@urlSite", entity.urlSite);
            cmd.Parameters.AddWithValue("@urlUsuario", 23); // deixado fixo por enquanto porque tem que peg
         
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
			
		}
		
	}

		
		public override void Update(Url entity)
		{
			throw new NotImplementedException();
		}
		
		public override Url GetById(int id)
		{
			throw new NotImplementedException();
		}
}

}
	
	
	
	/* public override void Update(url entity)
    {
        using (var conn = new MySql.Data.MySqlClient.MySqlConnection(this.StringConnection))
        {
            string sql = "UPDATE url SET Nome=@Nome, Email=@Email, Cidade=@Cidade, Endereco=@Endereco Where Id=@Id";
            MySql.Data.MySqlClient.MySqlConnection cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", entity.Id);
            cmd.Parameters.AddWithValue("@Nome", entity.Nome);
            cmd.Parameters.AddWithValue("@Email", entity.Email);
            cmd.Parameters.AddWithValue("@Cidade", entity.Cidade);
            cmd.Parameters.AddWithValue("@Endereco", entity.Endereco);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    } */
