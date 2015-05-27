
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
	public class CategoriaArquivoADO : ADOSuper, ICategoriaArquivoDAL {
	
	    /// <summary>
        /// Método que persiste um CategoriaArquivo.
        /// </summary>
        /// <param name="entidade">CategoriaArquivo contendo os dados a serem persistidos.</param>	
		public void Inserir(CategoriaArquivo entidade) 
		{
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;
			
			// Monta a string de insert.
			sbSQL.Append(" INSERT INTO CategoriaArquivo ");
			sbSQL.Append(" (categoriaArquivoId, titulo) ");
			sbSQL.Append(" VALUES ");
			sbSQL.Append(" (@categoriaArquivoId, @titulo) ");											

			command = _db.GetSqlStringCommand(sbSQL.ToString());
			
			_db.AddInParameter(command, "@categoriaArquivoId", DbType.Int32, entidade.CategoriaArquivoId);

			if (entidade.Titulo != null ) 
				_db.AddInParameter(command, "@titulo", DbType.String, entidade.Titulo);
			else
				_db.AddInParameter(command, "@titulo", DbType.String, null);

						
			// Executa a query.
			_db.ExecuteNonQuery(command);			
			
		}
		
        /// <summary>
        /// Método que atualiza os dados de um CategoriaArquivo.
        /// </summary>
        /// <param name="entidade">CategoriaArquivo contendo os dados a serem atualizados.</param>
		public void Atualizar(CategoriaArquivo entidade) {
		
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;
			
			// Monta a string de atualização.
			sbSQL.Append(" UPDATE CategoriaArquivo SET ");
			sbSQL.Append(" titulo=@titulo ");
			sbSQL.Append(" WHERE categoriaArquivoId=@categoriaArquivoId ");
										       
			command = _db.GetSqlStringCommand(sbSQL.ToString());			
			
			// Parâmetros
			_db.AddInParameter(command, "@categoriaArquivoId", DbType.Int32, entidade.CategoriaArquivoId);
			if (entidade.Titulo != null ) 
				_db.AddInParameter(command, "@titulo", DbType.String, entidade.Titulo);
			else
				_db.AddInParameter(command, "@titulo", DbType.String, null);
			
			// Executa a query.
			_db.ExecuteNonQuery(command);			
			
		}
		
        /// <summary>
        /// Método que remove um CategoriaArquivo da base de dados.
        /// </summary>
        /// <param name="entidade">CategoriaArquivo a ser excluído (somente o identificador é necessário).</param>		
		public void Excluir(CategoriaArquivo entidade) 
		{		
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;

			sbSQL.Append("DELETE FROM CategoriaArquivo ");
			sbSQL.Append("WHERE categoriaArquivoId=@categoriaArquivoId ");
			
			command = _db.GetSqlStringCommand(sbSQL.ToString());				
			
			_db.AddInParameter(command, "@categoriaArquivoId", DbType.Int32, entidade.CategoriaArquivoId);

								
			_db.ExecuteNonQuery(command);
		}
			
		/// <summary>
		/// Método que carrega um CategoriaArquivo.
		/// </summary>
        /// <param name="entidade">CategoriaArquivo a ser carregado (somente o identificador é necessário).</param>
		/// <returns>CategoriaArquivo</returns>
		public CategoriaArquivo Carregar(int categoriaArquivoId) {		
			CategoriaArquivo entidade = new CategoriaArquivo();
			entidade.CategoriaArquivoId = categoriaArquivoId;
			return Carregar(entidade);
		
		}
		

		/// <summary>
		/// Método que carrega um CategoriaArquivo.
		/// </summary>
        /// <param name="entidade">CategoriaArquivo a ser carregado (somente o identificador é necessário).</param>
		/// <returns>CategoriaArquivo</returns>
		public CategoriaArquivo Carregar(CategoriaArquivo entidade) {		
		
			CategoriaArquivo entidadeRetorno = null;
			
			StringBuilder sbSQL = new StringBuilder();
			
			sbSQL.Append("SELECT * FROM CategoriaArquivo WHERE categoriaArquivoId=@categoriaArquivoId");
			
			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
			
			_db.AddInParameter(command, "@categoriaArquivoId", DbType.Int32, entidade.CategoriaArquivoId);
			
			IDataReader reader = _db.ExecuteReader(command);
			
			if (reader.Read())
			{
				entidadeRetorno = new CategoriaArquivo();
				PopulaCategoriaArquivo(reader, entidadeRetorno);
			}
			reader.Close();
			
			return entidadeRetorno;
		}
		

		/// <summary>
        /// Método que retorna uma coleção de CategoriaArquivo.
        /// </summary>
        /// <param name="entidade">Arquivo relacionado(a) (somente o identificador é necessário).</param>		
		/// <returns>Retorna uma coleção de CategoriaArquivo.</returns>
		public List<CategoriaArquivo> Carregar(Arquivo entidade)
		{		
			List<CategoriaArquivo> entidadesRetorno = new List<CategoriaArquivo>();
			
			StringBuilder sbSQL = new StringBuilder();
			
			sbSQL.Append("SELECT CategoriaArquivo.* FROM CategoriaArquivo INNER JOIN Arquivo ON CategoriaArquivo.categoriaArquivoId=Arquivo.categoriaArquivoId WHERE Arquivo.arquivoId=@arquivoId");
			
			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
			_db.AddInParameter(command, "@arquivoId", DbType.Int32, entidade.ArquivoId);
								
			IDataReader reader = _db.ExecuteReader(command);
			
            while (reader.Read())
            {
                CategoriaArquivo entidadeRetorno = new CategoriaArquivo();
                PopulaCategoriaArquivo(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
            }
            reader.Close();

            return entidadesRetorno;
			
		}
		
		
		/// <summary>
        /// Método que retorna uma coleção de CategoriaArquivo.
        /// </summary>
        /// <param name="registrosPagina">Número máximo de registros na página.</param>
        /// <param name="numeroPagina">Número da página atual (inicia em 0).</param>
        /// <param name="ordemColunas">Nome das colunas na ordem em que se deseja ordernar os resultados.</param>
        /// <param name="ordemSentidos">Sentidos das respectivas colunas de ordenção informadas no parâmetro ordemColunas (OrderBy.Ascendente ou OrderBy.Descendente).</param>		
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>		
		///  <returns>Retorna um List contendos CategoriaArquivo.</returns>
		public List<CategoriaArquivo> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro) {
		
			List<CategoriaArquivo> entidadesRetorno = new List<CategoriaArquivo>();
			
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
				sbOrder.Append( " ORDER BY categoriaArquivoId" );
			}
				
			
			if (registrosPagina>0) {
				
				//sbSQL.Append("SELECT TOP "+registrosPagina+" * FROM CategoriaArquivo");
				//if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM CategoriaArquivo WHERE " + filtro.GetWhereString() + " ORDER BY " + orderBy + ") ");					
				//} else {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM CategoriaArquivo ORDER BY " + orderBy + ")");				
			    //}	
				sbSQL.Append("SELECT * FROM ( ");				
				sbSQL.Append("SELECT CategoriaArquivo.*, ROW_NUMBER() OVER (" + sbOrder.ToString() + ") R FROM CategoriaArquivo ");				
				if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) { sbSQL.Append( "WHERE" + filtro.GetWhereString() + " " ); }
				sbSQL.Append(") #Q WHERE R BETWEEN " + (((numeroPagina-1)*registrosPagina)+1).ToString() + " AND " + ((numeroPagina)*registrosPagina).ToString());				
								
			} else {
				sbSQL.Append("SELECT CategoriaArquivo.* FROM CategoriaArquivo ");
				if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) { sbSQL.Append( "WHERE" + filtro.GetWhereString() + " " ); }
				if ( sbOrder.Length > 0 ) { sbSQL.Append(sbOrder.ToString()); }
			}
			
			command = _db.GetSqlStringCommand(sbSQL.ToString());
			reader = _db.ExecuteReader(command);
			
            while (reader.Read())
            {
                CategoriaArquivo entidadeRetorno = new CategoriaArquivo();
                PopulaCategoriaArquivo(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
            }
            reader.Close();

            return entidadesRetorno;					
					
		}	
		
		/// <summary>
        /// Método que retorna todas os CategoriaArquivo existentes na base de dados.
        /// </summary>
		public List<CategoriaArquivo> CarregarTodos() {			
			return CarregarTodos(0, 0, null, null, null);
		}	
		
        /// <summary>
        /// Método que retorna o total de CategoriaArquivo na base de dados.
        /// </summary>
        /// <returns></returns>
		public int TotalRegistros() 
		{
			return TotalRegistros(null);
		}	
		
        /// <summary>
        /// Método que retorna o total de CategoriaArquivo na base de dados, aceita filtro.
        /// </summary>
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>
		/// <returns></returns>
		public int TotalRegistros(IFilterHelper filtro) 
		{		
			StringBuilder sbSQL = new StringBuilder();
			
			sbSQL.Append("SELECT COUNT(*) AS Total FROM CategoriaArquivo");
			
			if (filtro!=null && !filtro.GetWhereString().Equals(String.Empty))
					sbSQL.Append(" WHERE (" + filtro.GetWhereString() + ")");			
			
			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
								
			// Executa a query.
			
			int resultado = (int) _db.ExecuteScalar(command);
			
			
			return resultado;	
		}
		
		/// <summary>
        /// Método que retorna popula um CategoriaArquivo baseado nos dados de um DataReader.
        /// </summary>
        /// <param name="reader">IDataReader contendo os dados da consulta.</param>
        /// <param name="entidade">CategoriaArquivo a ser populado(.</param>
		public static void PopulaCategoriaArquivo(IDataReader reader, CategoriaArquivo entidade) 
		{						
			if (reader["categoriaArquivoId"] != DBNull.Value)
				entidade.CategoriaArquivoId = Convert.ToInt32(reader["categoriaArquivoId"].ToString());
			
			if (reader["titulo"] != DBNull.Value)
				entidade.Titulo = reader["titulo"].ToString();
			

		}		
		
	}
}
		