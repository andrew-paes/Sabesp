
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
	public class ProdutoTipoIdiomaADO : ADOSuper, IProdutoTipoIdiomaDAL {
	
	    /// <summary>
        /// Método que persiste um ProdutoTipoIdioma.
        /// </summary>
        /// <param name="entidade">ProdutoTipoIdioma contendo os dados a serem persistidos.</param>	
		public void Inserir(ProdutoTipoIdioma entidade) 
		{
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;
			
			// Monta a string de insert.
			sbSQL.Append(" INSERT INTO ProdutoTipoIdioma ");
            sbSQL.Append(" (produtoTipoId, idiomaId, tituloProdutoTipo, textoTipoProduto, chamadaProdutoTipo) ");
			sbSQL.Append(" VALUES ");
            sbSQL.Append(" (@produtoTipoId, @idiomaId, @tituloProdutoTipo, @textoTipoProduto, @chamadaProdutoTipo) ");											

			command = _db.GetSqlStringCommand(sbSQL.ToString());
			
			_db.AddInParameter(command, "@produtoTipoId", DbType.Int32, entidade.ProdutoTipo.ProdutoTipoId);

			_db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);

			_db.AddInParameter(command, "@tituloProdutoTipo", DbType.String, entidade.TituloProdutoTipo);

			if (entidade.TextoTipoProduto != null ) 
				_db.AddInParameter(command, "@textoTipoProduto", DbType.String, entidade.TextoTipoProduto);
			else
				_db.AddInParameter(command, "@textoTipoProduto", DbType.String, null);

            if (entidade.ChamadaProdutoTipo != null)
                _db.AddInParameter(command, "@chamadaProdutoTipo", DbType.String, entidade.ChamadaProdutoTipo);
            else
                _db.AddInParameter(command, "@chamadaProdutoTipo", DbType.String, null);
			
			// Executa a query.
			_db.ExecuteNonQuery(command);			
			
		}
		
        /// <summary>
        /// Método que atualiza os dados de um ProdutoTipoIdioma.
        /// </summary>
        /// <param name="entidade">ProdutoTipoIdioma contendo os dados a serem atualizados.</param>
		public void Atualizar(ProdutoTipoIdioma entidade) {
		
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;
			
			// Monta a string de atualização.
			sbSQL.Append(" UPDATE ProdutoTipoIdioma SET ");
            sbSQL.Append(" tituloProdutoTipo=@tituloProdutoTipo, textoTipoProduto=@textoTipoProduto, chamadaProdutoTipo = @chamadaProdutoTipo ");
			sbSQL.Append(" WHERE produtoTipoId=@produtoTipoId AND idiomaId=@idiomaId ");
										       
			command = _db.GetSqlStringCommand(sbSQL.ToString());			
			
			// Parâmetros
			_db.AddInParameter(command, "@produtoTipoId", DbType.Int32, entidade.ProdutoTipo.ProdutoTipoId);
			_db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);
			_db.AddInParameter(command, "@tituloProdutoTipo", DbType.String, entidade.TituloProdutoTipo);
			
            if (entidade.TextoTipoProduto != null ) 
				_db.AddInParameter(command, "@textoTipoProduto", DbType.String, entidade.TextoTipoProduto);
			else
				_db.AddInParameter(command, "@textoTipoProduto", DbType.String, null);

            if (entidade.ChamadaProdutoTipo != null)
                _db.AddInParameter(command, "@chamadaProdutoTipo", DbType.String, entidade.ChamadaProdutoTipo);
            else
                _db.AddInParameter(command, "@chamadaProdutoTipo", DbType.String, null);
			
			// Executa a query.
			_db.ExecuteNonQuery(command);			
			
		}
		
        /// <summary>
        /// Método que remove um ProdutoTipoIdioma da base de dados.
        /// </summary>
        /// <param name="entidade">ProdutoTipoIdioma a ser excluído (somente o identificador é necessário).</param>		
		public void Excluir(ProdutoTipoIdioma entidade) 
		{		
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;

			sbSQL.Append("DELETE FROM ProdutoTipoIdioma ");
			sbSQL.Append("WHERE produtoTipoId=@produtoTipoId AND idiomaId=@idiomaId ");
			
			command = _db.GetSqlStringCommand(sbSQL.ToString());				
			
			_db.AddInParameter(command, "@produtoTipoId", DbType.Int32, entidade.ProdutoTipo.ProdutoTipoId);
			_db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);

								
			_db.ExecuteNonQuery(command);
		}
		

		/// <summary>
		/// Método que carrega um ProdutoTipoIdioma.
		/// </summary>
        /// <param name="entidade">ProdutoTipoIdioma a ser carregado (somente o identificador é necessário).</param>
		/// <returns>ProdutoTipoIdioma</returns>
		public ProdutoTipoIdioma Carregar(ProdutoTipoIdioma entidade) {		
		
			ProdutoTipoIdioma entidadeRetorno = null;
			
			StringBuilder sbSQL = new StringBuilder();
			
			sbSQL.Append("SELECT * FROM ProdutoTipoIdioma WHERE produtoTipoId=@produtoTipoId AND idiomaId=@idiomaId");
			
			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
			
			_db.AddInParameter(command, "@produtoTipoId", DbType.Int32, entidade.ProdutoTipo.ProdutoTipoId);
			_db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);
			
			IDataReader reader = _db.ExecuteReader(command);
			
			if (reader.Read())
			{
				entidadeRetorno = new ProdutoTipoIdioma();
				PopulaProdutoTipoIdioma(reader, entidadeRetorno);
			}
			reader.Close();
			
			return entidadeRetorno;
		}
		
		
		
		/// <summary>
        /// Método que retorna uma coleção de ProdutoTipoIdioma.
        /// </summary>
        /// <param name="registrosPagina">Número máximo de registros na página.</param>
        /// <param name="numeroPagina">Número da página atual (inicia em 0).</param>
        /// <param name="ordemColunas">Nome das colunas na ordem em que se deseja ordernar os resultados.</param>
        /// <param name="ordemSentidos">Sentidos das respectivas colunas de ordenção informadas no parâmetro ordemColunas (OrderBy.Ascendente ou OrderBy.Descendente).</param>		
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>		
		///  <returns>Retorna um List contendos ProdutoTipoIdioma.</returns>
		public List<ProdutoTipoIdioma> CarregarTodos(int registrosPagina, int numeroPagina, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro) {
		
			List<ProdutoTipoIdioma> entidadesRetorno = new List<ProdutoTipoIdioma>();
			
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
				sbOrder.Append( " ORDER BY produtoTipoId, idiomaId" );
			}
				
			
			if (registrosPagina>0) {
				
				//sbSQL.Append("SELECT TOP "+registrosPagina+" * FROM ProdutoTipoIdioma");
				//if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM ProdutoTipoIdioma WHERE " + filtro.GetWhereString() + " ORDER BY " + orderBy + ") ");					
				//} else {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM ProdutoTipoIdioma ORDER BY " + orderBy + ")");				
			    //}	
				sbSQL.Append("SELECT * FROM ( ");				
				sbSQL.Append("SELECT ProdutoTipoIdioma.*, ROW_NUMBER() OVER (" + sbOrder.ToString() + ") R FROM ProdutoTipoIdioma ");				
				if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) { sbSQL.Append( "WHERE" + filtro.GetWhereString() + " " ); }
				sbSQL.Append(") #Q WHERE R BETWEEN " + (((numeroPagina-1)*registrosPagina)+1).ToString() + " AND " + ((numeroPagina)*registrosPagina).ToString());				
								
			} else {
				sbSQL.Append("SELECT ProdutoTipoIdioma.* FROM ProdutoTipoIdioma ");
				if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) { sbSQL.Append( "WHERE" + filtro.GetWhereString() + " " ); }
				if ( sbOrder.Length > 0 ) { sbSQL.Append(sbOrder.ToString()); }
			}
			
			command = _db.GetSqlStringCommand(sbSQL.ToString());
			reader = _db.ExecuteReader(command);
			
            while (reader.Read())
            {
                ProdutoTipoIdioma entidadeRetorno = new ProdutoTipoIdioma();
                PopulaProdutoTipoIdioma(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
            }
            reader.Close();

            return entidadesRetorno;					
					
		}	
		
		/// <summary>
        /// Método que retorna todas os ProdutoTipoIdioma existentes na base de dados.
        /// </summary>
		public List<ProdutoTipoIdioma> CarregarTodos() {			
			return CarregarTodos(0, 0, null, null, null);
		}	
		
        /// <summary>
        /// Método que retorna o total de ProdutoTipoIdioma na base de dados.
        /// </summary>
        /// <returns></returns>
		public int TotalRegistros() 
		{
			return TotalRegistros(null);
		}	
		
        /// <summary>
        /// Método que retorna o total de ProdutoTipoIdioma na base de dados, aceita filtro.
        /// </summary>
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>
		/// <returns></returns>
		public int TotalRegistros(IFilterHelper filtro) 
		{		
			StringBuilder sbSQL = new StringBuilder();
			
			sbSQL.Append("SELECT COUNT(*) AS Total FROM ProdutoTipoIdioma");
			
			if (filtro!=null && !filtro.GetWhereString().Equals(String.Empty))
					sbSQL.Append(" WHERE (" + filtro.GetWhereString() + ")");			
			
			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
								
			// Executa a query.
			
			int resultado = (int) _db.ExecuteScalar(command);
			
			
			return resultado;	
		}
		
		/// <summary>
        /// Método que retorna popula um ProdutoTipoIdioma baseado nos dados de um DataReader.
        /// </summary>
        /// <param name="reader">IDataReader contendo os dados da consulta.</param>
        /// <param name="entidade">ProdutoTipoIdioma a ser populado(.</param>
		public static void PopulaProdutoTipoIdioma(IDataReader reader, ProdutoTipoIdioma entidade) 
		{						
			if (reader["tituloProdutoTipo"] != DBNull.Value)
				entidade.TituloProdutoTipo = reader["tituloProdutoTipo"].ToString();
			
			if (reader["textoTipoProduto"] != DBNull.Value)
				entidade.TextoTipoProduto = reader["textoTipoProduto"].ToString();

            if (reader["chamadaProdutoTipo"] != DBNull.Value)
                entidade.ChamadaProdutoTipo = reader["chamadaProdutoTipo"].ToString();
            			
			if (reader["produtoTipoId"] != DBNull.Value) {
				entidade.ProdutoTipo = new ProdutoTipo();
				entidade.ProdutoTipo.ProdutoTipoId = Convert.ToInt32(reader["produtoTipoId"].ToString());
			}

			if (reader["idiomaId"] != DBNull.Value) {
				entidade.Idioma = new Idioma();
				entidade.Idioma.IdiomaId = Convert.ToInt32(reader["idiomaId"].ToString());
			}


		}		
		
	}
}
		