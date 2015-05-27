
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
	public class ProdutoADO : ADOSuper, IProdutoDAL {
	
	    /// <summary>
        /// Método que persiste um Produto.
        /// </summary>
        /// <param name="entidade">Produto contendo os dados a serem persistidos.</param>	
		public void Inserir(Produto entidade) 
		{
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;
			
			// Monta a string de insert.
			sbSQL.Append(" INSERT INTO Produto ");
			sbSQL.Append(" (ativo, destaqueProdutos, arquivoIdThumb, produtoTipoId) ");
			sbSQL.Append(" VALUES ");
			sbSQL.Append(" (@ativo, @destaqueProdutos, @arquivoIdThumb, @produtoTipoId) ");											

			sbSQL.Append(" ; SET @produtoId = SCOPE_IDENTITY(); ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());
			
			_db.AddOutParameter(command, "@produtoId", DbType.Int32, 8);

			_db.AddInParameter(command, "@ativo", DbType.Int32, entidade.Ativo);

			if (entidade.DestaqueProdutos != null ) 
				_db.AddInParameter(command, "@destaqueProdutos", DbType.Int32, entidade.DestaqueProdutos);
			else
				_db.AddInParameter(command, "@destaqueProdutos", DbType.Int32, null);

            if (entidade.ArquivoThumb != null && entidade.ArquivoThumb.ArquivoId > 0) 
				_db.AddInParameter(command, "@arquivoIdThumb", DbType.Int32, entidade.ArquivoThumb.ArquivoId);
			else
				_db.AddInParameter(command, "@arquivoIdThumb", DbType.Int32, null);

			_db.AddInParameter(command, "@produtoTipoId", DbType.Int32, entidade.ProdutoTipo.ProdutoTipoId);

						
			// Executa a query.
			_db.ExecuteNonQuery(command);			

			entidade.ProdutoId = Convert.ToInt32(_db.GetParameterValue(command, "@produtoId"));
			
		}
		
        /// <summary>
        /// Método que atualiza os dados de um Produto.
        /// </summary>
        /// <param name="entidade">Produto contendo os dados a serem atualizados.</param>
		public void Atualizar(Produto entidade) {
		
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;
			
			// Monta a string de atualização.
			sbSQL.Append(" UPDATE Produto SET ");
			sbSQL.Append(" ativo=@ativo, destaqueProdutos=@destaqueProdutos, arquivoIdThumb=@arquivoIdThumb, produtoTipoId=@produtoTipoId ");
			sbSQL.Append(" WHERE produtoId=@produtoId ");
										       
			command = _db.GetSqlStringCommand(sbSQL.ToString());			
			
			// Parâmetros
			_db.AddInParameter(command, "@produtoId", DbType.Int32, entidade.ProdutoId);
			_db.AddInParameter(command, "@ativo", DbType.Int32, entidade.Ativo);
			if (entidade.DestaqueProdutos != null ) 
				_db.AddInParameter(command, "@destaqueProdutos", DbType.Int32, entidade.DestaqueProdutos);
			else
				_db.AddInParameter(command, "@destaqueProdutos", DbType.Int32, null);
            if (entidade.ArquivoThumb != null && entidade.ArquivoThumb.ArquivoId > 0) 
				_db.AddInParameter(command, "@arquivoIdThumb", DbType.Int32, entidade.ArquivoThumb.ArquivoId);
			else
				_db.AddInParameter(command, "@arquivoIdThumb", DbType.Int32, null);
			_db.AddInParameter(command, "@produtoTipoId", DbType.Int32, entidade.ProdutoTipo.ProdutoTipoId);
			
			// Executa a query.
			_db.ExecuteNonQuery(command);			
			
		}
		
        /// <summary>
        /// Método que remove um Produto da base de dados.
        /// </summary>
        /// <param name="entidade">Produto a ser excluído (somente o identificador é necessário).</param>		
		public void Excluir(Produto entidade) 
		{		
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;

			sbSQL.Append("DELETE FROM Produto ");
			sbSQL.Append("WHERE produtoId=@produtoId ");
			
			command = _db.GetSqlStringCommand(sbSQL.ToString());				
			
			_db.AddInParameter(command, "@produtoId", DbType.Int32, entidade.ProdutoId);

								
			_db.ExecuteNonQuery(command);
		}
			
		/// <summary>
		/// Método que carrega um Produto.
		/// </summary>
        /// <param name="entidade">Produto a ser carregado (somente o identificador é necessário).</param>
		/// <returns>Produto</returns>
		public Produto Carregar(int produtoId) {		
			Produto entidade = new Produto();
			entidade.ProdutoId = produtoId;
			return Carregar(entidade);
		
		}
		

		/// <summary>
		/// Método que carrega um Produto.
		/// </summary>
        /// <param name="entidade">Produto a ser carregado (somente o identificador é necessário).</param>
		/// <returns>Produto</returns>
		public Produto Carregar(Produto entidade) {		
		
			Produto entidadeRetorno = null;
			
			StringBuilder sbSQL = new StringBuilder();
			
			sbSQL.Append("SELECT * FROM Produto WHERE produtoId=@produtoId");
			
			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
			
			_db.AddInParameter(command, "@produtoId", DbType.Int32, entidade.ProdutoId);
			
			IDataReader reader = _db.ExecuteReader(command);
			
			if (reader.Read())
			{
				entidadeRetorno = new Produto();
				PopulaProduto(reader, entidadeRetorno);
			}
			reader.Close();
			
			return entidadeRetorno;
		}
		

		/// <summary>
        /// Método que retorna uma coleção de Produto.
        /// </summary>
        /// <param name="entidade">ProdutoImagem relacionado(a) (somente o identificador é necessário).</param>		
		/// <returns>Retorna uma coleção de Produto.</returns>
		public List<Produto> Carregar(ProdutoImagem entidade)
		{		
			List<Produto> entidadesRetorno = new List<Produto>();
			
			StringBuilder sbSQL = new StringBuilder();
			
			sbSQL.Append("SELECT Produto.* FROM Produto INNER JOIN ProdutoImagem ON Produto.produtoId=ProdutoImagem.produtoId WHERE ProdutoImagem.produtoImagemId=@produtoImagemId");
			
			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
			_db.AddInParameter(command, "@produtoImagemId", DbType.Int32, entidade.ProdutoImagemId);
								
			IDataReader reader = _db.ExecuteReader(command);
			
            while (reader.Read())
            {
                Produto entidadeRetorno = new Produto();
                PopulaProduto(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
            }
            reader.Close();

            return entidadesRetorno;
			
		}
		
		
		/// <summary>
        /// Método que retorna uma coleção de Produto.
        /// </summary>
        /// <param name="registrosPagina">Número máximo de registros na página.</param>
        /// <param name="numeroPagina">Número da página atual (inicia em 0).</param>
        /// <param name="ordemColunas">Nome das colunas na ordem em que se deseja ordernar os resultados.</param>
        /// <param name="ordemSentidos">Sentidos das respectivas colunas de ordenção informadas no parâmetro ordemColunas (OrderBy.Ascendente ou OrderBy.Descendente).</param>		
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>		
		///  <returns>Retorna um List contendos Produto.</returns>
		public List<Produto> CarregarTodos(int registrosPagina, int numeroPagina, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro) {
		
			List<Produto> entidadesRetorno = new List<Produto>();
			
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
				sbOrder.Append( " ORDER BY produtoId" );
			}
				
			
			if (registrosPagina>0) {
				
				//sbSQL.Append("SELECT TOP "+registrosPagina+" * FROM Produto");
				//if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM Produto WHERE " + filtro.GetWhereString() + " ORDER BY " + orderBy + ") ");					
				//} else {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM Produto ORDER BY " + orderBy + ")");				
			    //}	
				sbSQL.Append("SELECT * FROM ( ");				
				sbSQL.Append("SELECT Produto.*, ROW_NUMBER() OVER (" + sbOrder.ToString() + ") R FROM Produto ");				
				if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) { sbSQL.Append( "WHERE" + filtro.GetWhereString() + " " ); }
				sbSQL.Append(") #Q WHERE R BETWEEN " + (((numeroPagina-1)*registrosPagina)+1).ToString() + " AND " + ((numeroPagina)*registrosPagina).ToString());				
								
			} else {
				sbSQL.Append("SELECT Produto.* FROM Produto ");
				if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) { sbSQL.Append( "WHERE" + filtro.GetWhereString() + " " ); }
				if ( sbOrder.Length > 0 ) { sbSQL.Append(sbOrder.ToString()); }
			}
			
			command = _db.GetSqlStringCommand(sbSQL.ToString());
			reader = _db.ExecuteReader(command);
			
            while (reader.Read())
            {
                Produto entidadeRetorno = new Produto();
                PopulaProduto(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
            }
            reader.Close();

            return entidadesRetorno;					
					
		}	
		
		/// <summary>
        /// Método que retorna todas os Produto existentes na base de dados.
        /// </summary>
		public List<Produto> CarregarTodos() {			
			return CarregarTodos(0, 0, null, null, null);
		}	
		
        /// <summary>
        /// Método que retorna o total de Produto na base de dados.
        /// </summary>
        /// <returns></returns>
		public int TotalRegistros() 
		{
			return TotalRegistros(null);
		}	
		
        /// <summary>
        /// Método que retorna o total de Produto na base de dados, aceita filtro.
        /// </summary>
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>
		/// <returns></returns>
		public int TotalRegistros(IFilterHelper filtro) 
		{		
			StringBuilder sbSQL = new StringBuilder();
			
			sbSQL.Append("SELECT COUNT(*) AS Total FROM Produto");
			
			if (filtro!=null && !filtro.GetWhereString().Equals(String.Empty))
					sbSQL.Append(" WHERE (" + filtro.GetWhereString() + ")");			
			
			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
								
			// Executa a query.
			
			int resultado = (int) _db.ExecuteScalar(command);
			
			
			return resultado;	
		}
		
		/// <summary>
        /// Método que retorna popula um Produto baseado nos dados de um DataReader.
        /// </summary>
        /// <param name="reader">IDataReader contendo os dados da consulta.</param>
        /// <param name="entidade">Produto a ser populado(.</param>
		public static void PopulaProduto(IDataReader reader, Produto entidade) 
		{						
			if (reader["produtoId"] != DBNull.Value)
				entidade.ProdutoId = Convert.ToInt32(reader["produtoId"].ToString());
			
			if (reader["ativo"] != DBNull.Value)
				entidade.Ativo = Convert.ToBoolean(reader["ativo"].ToString());
			
			if (reader["destaqueProdutos"] != DBNull.Value)
				entidade.DestaqueProdutos = Convert.ToBoolean(reader["destaqueProdutos"].ToString());
			
			if (reader["arquivoIdThumb"] != DBNull.Value) {
				entidade.ArquivoThumb = new Arquivo();
				entidade.ArquivoThumb.ArquivoId = Convert.ToInt32(reader["arquivoIdThumb"].ToString());
			}

			if (reader["produtoTipoId"] != DBNull.Value) {
				entidade.ProdutoTipo = new ProdutoTipo();
				entidade.ProdutoTipo.ProdutoTipoId = Convert.ToInt32(reader["produtoTipoId"].ToString());
			}


		}		
		
	}
}
		