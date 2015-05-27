
/*
'===============================================================================
'
'  Template: Gerador Código C#.csgen
'  Script versão: 0.94
'  Script criado por: Leonardo Alves Lindermann (lindermannla@ag2.com.br)
'  Gerado pelo MyGeneration versão # (???)
'
'===============================================================================
*/
using System;
using System.Data;
using System.Data.Common;

using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

using Sabesp.BO;
using Sabesp.FilterHelper;

namespace Sabesp.DAL.ADO
{
	public class FormularioVideoteca1ADO : ADOSuper, IFormularioVideoteca1DAL {
	
	    /// <summary>
        /// Método que persiste um FormularioVideoteca1.
        /// </summary>
        /// <param name="entidade">FormularioVideoteca1 contendo os dados a serem persistidos.</param>	
		public void Inserir(FormularioVideoteca1 entidade) 
		{
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;
			
			// Monta a string de insert.
			sbSQL.Append(" INSERT INTO FormularioVideoteca1 ");
			sbSQL.Append(" (formularioId, dataHoraContato, nome, email, profissao, empresa, cep, estadoId, cidade, bairro, endereco, telefoneDDD, telefoneNumero, interesseGotaBorralheira, interesseAguaNaBoca, interesseAguaVideos, interesseChuaChuagua, interesseTratamento, interesseSuperH20) ");
			sbSQL.Append(" VALUES ");
			sbSQL.Append(" (@formularioId, @dataHoraContato, @nome, @email, @profissao, @empresa, @cep, @estadoId, @cidade, @bairro, @endereco, @telefoneDDD, @telefoneNumero, @interesseGotaBorralheira, @interesseAguaNaBoca, @interesseAguaVideos, @interesseChuaChuagua, @interesseTratamento, @interesseSuperH20) ");											

			sbSQL.Append(" ; SET @formularioVideoteca1Id = SCOPE_IDENTITY(); ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());
			
			_db.AddOutParameter(command, "@formularioVideoteca1Id", DbType.Int32, 8);

			_db.AddInParameter(command, "@formularioId", DbType.Int32, entidade.Formulario.FormularioId);

			_db.AddInParameter(command, "@dataHoraContato", DbType.DateTime, entidade.DataHoraContato);

			_db.AddInParameter(command, "@nome", DbType.String, entidade.Nome);

			_db.AddInParameter(command, "@email", DbType.String, entidade.Email);

			_db.AddInParameter(command, "@profissao", DbType.String, entidade.Profissao);

			if (entidade.Empresa != null ) 
				_db.AddInParameter(command, "@empresa", DbType.String, entidade.Empresa);
			else
				_db.AddInParameter(command, "@empresa", DbType.String, null);

			_db.AddInParameter(command, "@cep", DbType.String, entidade.Cep);

			_db.AddInParameter(command, "@estadoId", DbType.Int32, entidade.Estado.EstadoId);

			_db.AddInParameter(command, "@cidade", DbType.String, entidade.Cidade);

			_db.AddInParameter(command, "@bairro", DbType.String, entidade.Bairro);

			_db.AddInParameter(command, "@endereco", DbType.String, entidade.Endereco);

			if (entidade.TelefoneDDD != null ) 
				_db.AddInParameter(command, "@telefoneDDD", DbType.String, entidade.TelefoneDDD);
			else
				_db.AddInParameter(command, "@telefoneDDD", DbType.String, null);

			if (entidade.TelefoneNumero != null ) 
				_db.AddInParameter(command, "@telefoneNumero", DbType.String, entidade.TelefoneNumero);
			else
				_db.AddInParameter(command, "@telefoneNumero", DbType.String, null);

			_db.AddInParameter(command, "@interesseGotaBorralheira", DbType.Int32, entidade.InteresseGotaBorralheira);

			_db.AddInParameter(command, "@interesseAguaNaBoca", DbType.Int32, entidade.InteresseAguaNaBoca);

			_db.AddInParameter(command, "@interesseAguaVideos", DbType.Int32, entidade.InteresseAguaVideos);

			_db.AddInParameter(command, "@interesseChuaChuagua", DbType.Int32, entidade.InteresseChuaChuagua);

			_db.AddInParameter(command, "@interesseTratamento", DbType.Int32, entidade.InteresseTratamento);

			_db.AddInParameter(command, "@interesseSuperH20", DbType.Int32, entidade.InteresseSuperH20);

						
			// Executa a query.
			_db.ExecuteNonQuery(command);			

			entidade.FormularioVideoteca1Id = Convert.ToInt32(_db.GetParameterValue(command, "@formularioVideoteca1Id"));
			
		}
		
        /// <summary>
        /// Método que atualiza os dados de um FormularioVideoteca1.
        /// </summary>
        /// <param name="entidade">FormularioVideoteca1 contendo os dados a serem atualizados.</param>
		public void Atualizar(FormularioVideoteca1 entidade) {
		
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;
			
			// Monta a string de atualização.
			sbSQL.Append(" UPDATE FormularioVideoteca1 SET ");
			sbSQL.Append(" formularioId=@formularioId, dataHoraContato=@dataHoraContato, nome=@nome, email=@email, profissao=@profissao, empresa=@empresa, cep=@cep, estadoId=@estadoId, cidade=@cidade, bairro=@bairro, endereco=@endereco, telefoneDDD=@telefoneDDD, telefoneNumero=@telefoneNumero, interesseGotaBorralheira=@interesseGotaBorralheira, interesseAguaNaBoca=@interesseAguaNaBoca, interesseAguaVideos=@interesseAguaVideos, interesseChuaChuagua=@interesseChuaChuagua, interesseTratamento=@interesseTratamento, interesseSuperH20=@interesseSuperH20 ");
			sbSQL.Append(" WHERE formularioVideoteca1Id=@formularioVideoteca1Id ");
										       
			command = _db.GetSqlStringCommand(sbSQL.ToString());			
			
			// Parâmetros
			_db.AddInParameter(command, "@formularioVideoteca1Id", DbType.Int32, entidade.FormularioVideoteca1Id);
			_db.AddInParameter(command, "@formularioId", DbType.Int32, entidade.Formulario.FormularioId);
			_db.AddInParameter(command, "@dataHoraContato", DbType.DateTime, entidade.DataHoraContato);
			_db.AddInParameter(command, "@nome", DbType.String, entidade.Nome);
			_db.AddInParameter(command, "@email", DbType.String, entidade.Email);
			_db.AddInParameter(command, "@profissao", DbType.String, entidade.Profissao);
			if (entidade.Empresa != null ) 
				_db.AddInParameter(command, "@empresa", DbType.String, entidade.Empresa);
			else
				_db.AddInParameter(command, "@empresa", DbType.String, null);
			_db.AddInParameter(command, "@cep", DbType.String, entidade.Cep);
			_db.AddInParameter(command, "@estadoId", DbType.Int32, entidade.Estado.EstadoId);
			_db.AddInParameter(command, "@cidade", DbType.String, entidade.Cidade);
			_db.AddInParameter(command, "@bairro", DbType.String, entidade.Bairro);
			_db.AddInParameter(command, "@endereco", DbType.String, entidade.Endereco);
			if (entidade.TelefoneDDD != null ) 
				_db.AddInParameter(command, "@telefoneDDD", DbType.String, entidade.TelefoneDDD);
			else
				_db.AddInParameter(command, "@telefoneDDD", DbType.String, null);
			if (entidade.TelefoneNumero != null ) 
				_db.AddInParameter(command, "@telefoneNumero", DbType.String, entidade.TelefoneNumero);
			else
				_db.AddInParameter(command, "@telefoneNumero", DbType.String, null);
			_db.AddInParameter(command, "@interesseGotaBorralheira", DbType.Int32, entidade.InteresseGotaBorralheira);
			_db.AddInParameter(command, "@interesseAguaNaBoca", DbType.Int32, entidade.InteresseAguaNaBoca);
			_db.AddInParameter(command, "@interesseAguaVideos", DbType.Int32, entidade.InteresseAguaVideos);
			_db.AddInParameter(command, "@interesseChuaChuagua", DbType.Int32, entidade.InteresseChuaChuagua);
			_db.AddInParameter(command, "@interesseTratamento", DbType.Int32, entidade.InteresseTratamento);
			_db.AddInParameter(command, "@interesseSuperH20", DbType.Int32, entidade.InteresseSuperH20);
			
			// Executa a query.
			_db.ExecuteNonQuery(command);			
			
		}
		
        /// <summary>
        /// Método que remove um FormularioVideoteca1 da base de dados.
        /// </summary>
        /// <param name="entidade">FormularioVideoteca1 a ser excluído (somente o identificador é necessário).</param>		
		public void Excluir(FormularioVideoteca1 entidade) 
		{		
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;

			sbSQL.Append("DELETE FROM FormularioVideoteca1 ");
			sbSQL.Append("WHERE formularioVideoteca1Id=@formularioVideoteca1Id ");
			
			command = _db.GetSqlStringCommand(sbSQL.ToString());				
			
			_db.AddInParameter(command, "@formularioVideoteca1Id", DbType.Int32, entidade.FormularioVideoteca1Id);

								
			_db.ExecuteNonQuery(command);
		}
			
		/// <summary>
		/// Método que carrega um FormularioVideoteca1.
		/// </summary>
        /// <param name="entidade">FormularioVideoteca1 a ser carregado (somente o identificador é necessário).</param>
		/// <returns>FormularioVideoteca1</returns>
		public FormularioVideoteca1 Carregar(int formularioVideoteca1Id) {		
			FormularioVideoteca1 entidade = new FormularioVideoteca1();
			entidade.FormularioVideoteca1Id = formularioVideoteca1Id;
			return Carregar(entidade);
		
		}
		

		/// <summary>
		/// Método que carrega um FormularioVideoteca1.
		/// </summary>
        /// <param name="entidade">FormularioVideoteca1 a ser carregado (somente o identificador é necessário).</param>
		/// <returns>FormularioVideoteca1</returns>
		public FormularioVideoteca1 Carregar(FormularioVideoteca1 entidade) {		
		
			FormularioVideoteca1 entidadeRetorno = null;
			
			StringBuilder sbSQL = new StringBuilder();
			
			sbSQL.Append("SELECT * FROM FormularioVideoteca1 WHERE formularioVideoteca1Id=@formularioVideoteca1Id");
			
			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
			
			_db.AddInParameter(command, "@formularioVideoteca1Id", DbType.Int32, entidade.FormularioVideoteca1Id);
			
			IDataReader reader = _db.ExecuteReader(command);
			
			if (reader.Read())
			{
				entidadeRetorno = new FormularioVideoteca1();
				PopulaFormularioVideoteca1(reader, entidadeRetorno);
			}
			
			reader.Close();
			
			return entidadeRetorno;
		}
		
		
		
		/// <summary>
        /// Método que retorna uma coleção de FormularioVideoteca1.
        /// </summary>
        /// <param name="registrosPagina">Número máximo de registros na página.</param>
        /// <param name="numeroPagina">Número da página atual (inicia em 0).</param>
        /// <param name="ordemColunas">Nome das colunas na ordem em que se deseja ordernar os resultados.</param>
        /// <param name="ordemSentidos">Sentidos das respectivas colunas de ordenção informadas no parâmetro ordemColunas (OrderBy.Ascendente ou OrderBy.Descendente).</param>		
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>		
		///  <returns>Retorna um List contendos FormularioVideoteca1.</returns>
		public List<FormularioVideoteca1> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro) {
		
			List<FormularioVideoteca1> entidadesRetorno = new List<FormularioVideoteca1>();
			
			StringBuilder sbSQL = new StringBuilder();
			StringBuilder sbWhere = new StringBuilder();
			StringBuilder sbOrder = new StringBuilder();
			DbCommand command;
			IDataReader reader;
			
			// Monta o "OrderBy"
			if (ordemColunas!=null) {
				for(int i=0; i<ordemColunas.Length; i++) {
					if (sbOrder.Length>0) { sbOrder.Append( ", " ); }
					sbOrder.Append(ordemColunas[i] + " " + ordemSentidos[i]);
				} 
				if (sbOrder.Length > 0) { sbOrder.Insert(0, " ORDER BY "); }				
			} else {
				sbOrder.Append( " ORDER BY formularioVideoteca1Id" );
			}
				
			
			if (registrosPagina>0) {
				
				//sbSQL.Append("SELECT TOP "+registrosPagina+" * FROM FormularioVideoteca1");
				//if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM FormularioVideoteca1 WHERE " + filtro.GetWhereString() + " ORDER BY " + orderBy + ") ");					
				//} else {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM FormularioVideoteca1 ORDER BY " + orderBy + ")");				
			    //}	
				sbSQL.Append("SELECT * FROM ( ");				
				sbSQL.Append("SELECT FormularioVideoteca1.*, ROW_NUMBER() OVER (" + sbOrder.ToString() + ") R FROM FormularioVideoteca1 ");				
				if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) { sbSQL.Append( "WHERE" + filtro.GetWhereString() + " " ); }
				sbSQL.Append(") #Q WHERE R BETWEEN " + (((numeroPagina-1)*registrosPagina)+1).ToString() + " AND " + ((numeroPagina)*registrosPagina).ToString());				
								
			} else {
				sbSQL.Append("SELECT FormularioVideoteca1.* FROM FormularioVideoteca1 ");
				if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) { sbSQL.Append( "WHERE" + filtro.GetWhereString() + " " ); }
				if ( sbOrder.Length > 0 ) { sbSQL.Append(sbOrder.ToString()); }
			}
			
			command = _db.GetSqlStringCommand(sbSQL.ToString());
			reader = _db.ExecuteReader(command);
			
            while (reader.Read())
            {
                FormularioVideoteca1 entidadeRetorno = new FormularioVideoteca1();
                PopulaFormularioVideoteca1(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
            }
			
            reader.Close();

            return entidadesRetorno;
		}	
		
		/// <summary>
        /// Método que retorna todas os FormularioVideoteca1 existentes na base de dados.
        /// </summary>
		public List<FormularioVideoteca1> CarregarTodos() {			
			return CarregarTodos(0, 0, null, null, null);
		}	
		
        /// <summary>
        /// Método que retorna o total de FormularioVideoteca1 na base de dados.
        /// </summary>
        /// <returns></returns>
		public int TotalRegistros() 
		{
			return TotalRegistros(null);
		}	
		
        /// <summary>
        /// Método que retorna o total de FormularioVideoteca1 na base de dados, aceita filtro.
        /// </summary>
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>
		/// <returns></returns>
		public int TotalRegistros(IFilterHelper filtro) 
		{		
			StringBuilder sbSQL = new StringBuilder();
			
			sbSQL.Append("SELECT COUNT(*) AS Total FROM FormularioVideoteca1");
			
			if (filtro!=null && !filtro.GetWhereString().Equals(String.Empty))
					sbSQL.Append(" WHERE (" + filtro.GetWhereString() + ")");			
			
			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
								
			// Executa a query.
			
			int resultado = (int) _db.ExecuteScalar(command);
			
			
			return resultado;	
		}
		
		/// <summary>
        /// Método que retorna popula um FormularioVideoteca1 baseado nos dados de um DataReader.
        /// </summary>
        /// <param name="reader">IDataReader contendo os dados da consulta.</param>
        /// <param name="entidade">FormularioVideoteca1 a ser populado(.</param>
		public static void PopulaFormularioVideoteca1(IDataReader reader, FormularioVideoteca1 entidade) 
		{						
			if (reader["formularioVideoteca1Id"] != DBNull.Value)
				entidade.FormularioVideoteca1Id = Convert.ToInt32(reader["formularioVideoteca1Id"].ToString());
			
			if (reader["dataHoraContato"] != DBNull.Value)
				entidade.DataHoraContato = Convert.ToDateTime(reader["dataHoraContato"].ToString());
			
			if (reader["nome"] != DBNull.Value)
				entidade.Nome = reader["nome"].ToString();
			
			if (reader["email"] != DBNull.Value)
				entidade.Email = reader["email"].ToString();
			
			if (reader["profissao"] != DBNull.Value)
				entidade.Profissao = reader["profissao"].ToString();
			
			if (reader["empresa"] != DBNull.Value)
				entidade.Empresa = reader["empresa"].ToString();
			
			if (reader["cep"] != DBNull.Value)
				entidade.Cep = reader["cep"].ToString();
			
			if (reader["cidade"] != DBNull.Value)
				entidade.Cidade = reader["cidade"].ToString();
			
			if (reader["bairro"] != DBNull.Value)
				entidade.Bairro = reader["bairro"].ToString();
			
			if (reader["endereco"] != DBNull.Value)
				entidade.Endereco = reader["endereco"].ToString();
			
			if (reader["telefoneDDD"] != DBNull.Value)
				entidade.TelefoneDDD = reader["telefoneDDD"].ToString();
			
			if (reader["telefoneNumero"] != DBNull.Value)
				entidade.TelefoneNumero = reader["telefoneNumero"].ToString();
			
			if (reader["interesseGotaBorralheira"] != DBNull.Value)
				entidade.InteresseGotaBorralheira = Convert.ToBoolean(reader["interesseGotaBorralheira"].ToString());
			
			if (reader["interesseAguaNaBoca"] != DBNull.Value)
				entidade.InteresseAguaNaBoca = Convert.ToBoolean(reader["interesseAguaNaBoca"].ToString());
			
			if (reader["interesseAguaVideos"] != DBNull.Value)
				entidade.InteresseAguaVideos = Convert.ToBoolean(reader["interesseAguaVideos"].ToString());
			
			if (reader["interesseChuaChuagua"] != DBNull.Value)
				entidade.InteresseChuaChuagua = Convert.ToBoolean(reader["interesseChuaChuagua"].ToString());
			
			if (reader["interesseTratamento"] != DBNull.Value)
				entidade.InteresseTratamento = Convert.ToBoolean(reader["interesseTratamento"].ToString());
			
			if (reader["interesseSuperH20"] != DBNull.Value)
				entidade.InteresseSuperH20 = Convert.ToBoolean(reader["interesseSuperH20"].ToString());
			
			if (reader["formularioId"] != DBNull.Value) {
				entidade.Formulario = new Formulario();
				entidade.Formulario.FormularioId = Convert.ToInt32(reader["formularioId"].ToString());
			}

			if (reader["estadoId"] != DBNull.Value) {
				entidade.Estado = new Estado();
				entidade.Estado.EstadoId = Convert.ToInt32(reader["estadoId"].ToString());
			}


		}		
		
	}
}
		