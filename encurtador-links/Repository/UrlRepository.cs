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
using encurtador_links.Repository;
using encurtador_links.Library;
using System.Text;

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
			
			 var url = this.GetById(entity.id);
			 
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
			string sql = "Select * from urls order by id desc";
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
							u.id = Convert.ToInt16(reader["id"]);
							u.urlSite = reader["urlSite"].ToString();
							u.urlNormal = reader["urlNormal"].ToString();
							u.urlAcessos = Convert.ToInt16(reader["urlAcessos"]);
							u.urlCuted = Convert.ToString(Convert.ToBase64String(Encoding.UTF8.GetBytes(Convert.ToString(reader["id"]))));
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
				

				
				string sql = "INSERT INTO urls (urlNormal, dataCadastro, urlSite, urlUsuario) VALUES (@urlNormal, @dataCadastro, @urlSite, @urlUsuario)";
				MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
				cmd.Parameters.AddWithValue("@urlNormal", entity.urlNormal);
				cmd.Parameters.AddWithValue("@dataCadastro", entity.dataCadastro);
				cmd.Parameters.AddWithValue("@urlSite", entity.urlSite);
				cmd.Parameters.AddWithValue("@urlUsuario",entity.urlUsuario); // deixado fixo por enquanto porque tem que peg
				
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

		
		
		public override Url GetMaxId(Url entity)
		{
			using (var conn = new MySqlConnection(this.StringConnection))
			{
				string sql = " Select max(Id) as max_id from Urls ";
				MySqlCommand cmd = new MySqlCommand(sql, conn);
				
				Url u = null;
				
				try
				{
					conn.Open();
					using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
					{
						if (reader.HasRows)
						{
							if (reader.Read())
							{
								u = new Url();
								u.id = Convert.ToInt16(reader["max_id"]);
								
								
							}
						}
					}
					///return u;
				}
				
				
				
				catch(Exception e)
				{
					throw e;
					
					//return null;
				}
				
				return u;
				
			}
			
			
		}
	
		
	
	public override Url GetById(int id)
	{
		
		using (var conn = new MySqlConnection(this.StringConnection))
		{
			string sql = "Select * FROM Urls WHERE Id=@Id";
			
			MySqlCommand cmd = new MySqlCommand(sql, conn);
			
			cmd.Parameters.AddWithValue("@Id", id);
			
			Url u = null;
			
			try
			{
				
				conn.Open();
				using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
				{
					if (reader.HasRows)
					{
						if (reader.Read())
						{
							
							u = new Url();
							u.id = Convert.ToInt16(reader["id"]);
							u.urlSite = reader["urlSite"].ToString();
							u.urlNormal = reader["urlNormal"].ToString();
							u.urlAcessos = Convert.ToInt16(reader["urlAcessos"]);
							u.urlCuted = reader["urlCuted"].ToString();
						}
					}
				}
			}
			catch (Exception e)
			{
				throw e;
			}
			return u;
		}
		
		
	}
	
	
	public override void Update(Url entity)
	{
		using (var conn = new MySqlConnection(StringConnection))
        {
			
            string sql = "UPDATE Urls SET urlNormal=@urlNormal, urlSite=@urlSite, urlCuted=@urlCuted, urlUsuario=@urlUsuario Where Id=@Id";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", entity.id);
            cmd.Parameters.AddWithValue("@urlNormal", entity.urlNormal);
            cmd.Parameters.AddWithValue("@urlSite", entity.urlSite);
            cmd.Parameters.AddWithValue("@urlCuted", entity.urlCuted);
            cmd.Parameters.AddWithValue("@urlUsuario", entity.urlUsuario);
            
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
	
	
	
}

}
	
