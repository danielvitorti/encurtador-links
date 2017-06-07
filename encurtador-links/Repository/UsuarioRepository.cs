/*
 * Criado por SharpDevelop.
 * Usuário: Daniel
 * Data: 04/06/2017
 * Hora: 16:12
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
	/// Description of UsuarioRepository.
	/// </summary>
	public class UsuarioRepository: AbstractRepository<Usuario, int>
	{
		
		private string StringConnection = "Server=localhost;Database=urlcutdb;Uid=root;Pwd=;";
		
		
		public UsuarioRepository()
		{
		}
		
		
		
		
	
		
		
		
		 
		
		
		
		public override void DeleteById(int id)
		{
			using (var conn = new MySqlConnection(this.StringConnection))
			{
				string sql = "DELETE from Usuarios Where Id=@Id";
				
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
		
		
	public override Usuario GetById(int id)
	{
		
		using (var conn = new MySqlConnection(this.StringConnection))
		{
			string sql = "Select * FROM Usuarios WHERE Id=@Id";
			
			MySqlCommand cmd = new MySqlCommand(sql, conn);
			
			cmd.Parameters.AddWithValue("@Id", id);
			
			Usuario u = null;
			
			try
			{
				
				conn.Open();
				using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
				{
					if (reader.HasRows)
					{
						if (reader.Read())
						{
							
							u = new Usuario();
							u.id = Convert.ToInt16(reader["id"]);
							u.nome = reader["nome"].ToString();
							u.email = reader["email"].ToString();
							
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
	
		
		
	
		
		
	public override Usuario GetMaxId(Usuario entity)
	{
		throw new NotImplementedException();
	}
	
	public override List<Usuario> GetAll()
	{
		throw new NotImplementedException();
	}
	
		
		
		
		public override void Update(Usuario entity)
		{
			
			using (var conn = new MySqlConnection(StringConnection))
	        {
				
	            string sql = "UPDATE Usuarios SET nome=@nome, email=@email Where Id=@Id";
	            MySqlCommand cmd = new MySqlCommand(sql, conn);
	            cmd.Parameters.AddWithValue("@Id", entity.id);
	            cmd.Parameters.AddWithValue("@nome", entity.nome);
	            cmd.Parameters.AddWithValue("@email", entity.email);
	
	            
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
		
		public override void Save(Usuario entity)
		{
			using (var conn = new MySql.Data.MySqlClient.MySqlConnection(this.StringConnection))
			{
				

				
				string sql = "insert into usuarios(nome,email,senha,dataCadastro,status) values(@nome,@email,@senha,@dataCadastro,@status)";
				MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
				cmd.Parameters.AddWithValue("@nome", entity.nome);
				cmd.Parameters.AddWithValue("@email", entity.email);
				cmd.Parameters.AddWithValue("@senha", entity.senha);
				cmd.Parameters.AddWithValue("@dataCadastro", entity.dataCadastro); // deixado fixo por enquanto porque tem que peg
				cmd.Parameters.AddWithValue("@status",entity.status);
				
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
		
		public override void Delete(Usuario entity)
		{
				
			using (var conn = new MySqlConnection(this.StringConnection))
			{
				string sql = "DELETE from usuarios Where Id=@Id";
				
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
		
		
		
		
		
		public Usuario GetByEmailSenha(Usuario usuario)
	{
		
		using (var conn = new MySqlConnection(this.StringConnection))
		{
			string sql = "Select Id, nome FROM Usuarios WHERE email=@email and senha=@senha";
			
			MySqlCommand cmd = new MySqlCommand(sql, conn);
			
			cmd.Parameters.AddWithValue("@email", usuario.email);
			cmd.Parameters.AddWithValue("@senha", usuario.senha); 
			
			
			Usuario u = null;
			
			try
			{
				
				conn.Open();
				using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
				{
					if (reader.HasRows)
					{
						if (reader.Read())
						{
							
							u = new Usuario();
							u.id = Convert.ToInt16(reader["id"]);
							u.nome = reader["nome"].ToString();
							
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
		
		
		/*
		  * 
		  * public Usuario GetByEmailSenha(Usuario usuario)
	{
		
		using (var conn = new MySqlConnection(this.StringConnection))
		{
			string sql = "Select Id, nome FROM Usuarios WHERE email=@email and senha=@senha";
			
			MySqlCommand cmd = new MySqlCommand(sql, conn);
			
			cmd.Parameters.AddWithValue("@email", usuario.email);
			cmd.Parameters.AddWithValue("@senha", usuario.senha); 
			
			
			Usuario u = null;
			
			try
			{
				
				conn.Open();
				using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
				{
					if (reader.HasRows)
					{
						if (reader.Read())
						{
							
							u = new Usuario();
							u.id = Convert.ToInt16(reader["id"]);
							u.nome = reader["nome"].ToString();
							
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
		
		  * */
	

 
		 public bool verificaExisteEmailUsuario(Usuario usuario)
		 {
		 		
				bool retorno = false;
				using (var conn = new MySqlConnection(this.StringConnection))
				{
					
					string sql = "Select email from usuarios where email=@email";
					
					MySqlCommand cmd = new MySqlCommand(sql, conn);
			
					cmd.Parameters.AddWithValue("@email", usuario.email);
					
					
					try
					{
						
		 				conn.Open();
						using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
						{
							if (reader.HasRows)
							{
								if (reader.Read())
								{
									
									retorno = true;
									
								}
								
							}
							
						}
		 				
					}
					catch(Exception e)
					{
						throw e;
						
						
					}
				}
				
				
				return retorno;
		 		
		 }
		
		
	}
	
	
	
	
	
}
