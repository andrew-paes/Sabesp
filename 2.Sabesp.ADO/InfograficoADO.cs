
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
	public class InfograficoADO : ADOSuper, IInfograficoDAL {
	
	    /// <summary>
        /// Método que persiste um Infografico.
        /// </summary>
        /// <param name="entidade">Infografico contendo os dados a serem persistidos.</param>	
        public void Inserir(Infografico entidade)
        {
            StringBuilder sbSQL = new StringBuilder();
            DbCommand command;

            // Monta a string de insert.
            sbSQL.Append(" INSERT INTO Infografico ");
            sbSQL.Append(" (infograficoId, arquivoIdImagem) ");
            sbSQL.Append(" VALUES ");
            sbSQL.Append(" (@infograficoId, @arquivoIdImagem) ");

            command = _db.GetSqlStringCommand(sbSQL.ToString());

            _db.AddInParameter(command, "@infograficoId", DbType.Int32, entidade.Conteudo.ConteudoId);

            if (entidade.ArquivoIdImagem != null)
                _db.AddInParameter(command, "@arquivoIdImagem", DbType.Int32, entidade.ArquivoIdImagem.ArquivoId);
            else
                _db.AddInParameter(command, "@arquivoIdImagem", DbType.Int32, null);


            // Executa a query.
            _db.ExecuteNonQuery(command);

        }
		
        /// <summary>
        /// Método que atualiza os dados de um Infografico.
        /// </summary>
        /// <param name="entidade">Infografico contendo os dados a serem atualizados.</param>
		public void Atualizar(Infografico entidade) {
		
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;
			
			// Monta a string de atualização.
			sbSQL.Append(" UPDATE Infografico SET ");
			sbSQL.Append(" arquivoIdImagem=@arquivoIdImagem ");
			sbSQL.Append(" WHERE infograficoId=@infograficoId ");
										       
			command = _db.GetSqlStringCommand(sbSQL.ToString());			
			
			// Parâmetros
			_db.AddInParameter(command, "@infograficoId", DbType.Int32, entidade.infograficoId);
			if (entidade.ArquivoIdImagem != null ) 
				_db.AddInParameter(command, "@arquivoIdImagem", DbType.Int32, entidade.ArquivoIdImagem.ArquivoId);
			else
				_db.AddInParameter(command, "@arquivoIdImagem", DbType.Int32, null);
			
			// Executa a query.
			_db.ExecuteNonQuery(command);			
			
		}
		
        /// <summary>
        /// Método que remove um Infografico da base de dados.
        /// </summary>
        /// <param name="entidade">Infografico a ser excluído (somente o identificador é necessário).</param>		
		public void Excluir(Infografico entidade) 
		{		
			StringBuilder sbSQL = new StringBuilder();			
			DbCommand command;

			sbSQL.Append("DELETE FROM Infografico ");
			sbSQL.Append("WHERE infograficoId=@infograficoId ");
			
			command = _db.GetSqlStringCommand(sbSQL.ToString());				
			
			_db.AddInParameter(command, "@infograficoId", DbType.Int32, entidade.infograficoId);

								
			_db.ExecuteNonQuery(command);
		}
		

		/// <summary>
		/// Método que carrega um Infografico.
		/// </summary>
        /// <param name="entidade">Infografico a ser carregado (somente o identificador é necessário).</param>
		/// <returns>Infografico</returns>
		public Infografico Carregar(Infografico entidade) {		
		
			Infografico entidadeRetorno = null;
			
			StringBuilder sbSQL = new StringBuilder();
			
			sbSQL.Append("SELECT * FROM Infografico WHERE infograficoId=@infograficoId");
			
			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
			
			_db.AddInParameter(command, "@infograficoId", DbType.Int32, entidade.Conteudo.ConteudoId);
			
			IDataReader reader = _db.ExecuteReader(command);
			
			if (reader.Read())
			{
				entidadeRetorno = new Infografico();
				PopulaInfografico(reader, entidadeRetorno);
			}
			reader.Close();
			
			return entidadeRetorno;
		}
		
		
		
		/// <summary>
        /// Método que retorna uma coleção de Infografico.
        /// </summary>
        /// <param name="registrosPagina">Número máximo de registros na página.</param>
        /// <param name="numeroPagina">Número da página atual (inicia em 0).</param>
        /// <param name="ordemColunas">Nome das colunas na ordem em que se deseja ordernar os resultados.</param>
        /// <param name="ordemSentidos">Sentidos das respectivas colunas de ordenção informadas no parâmetro ordemColunas (OrderBy.Ascendente ou OrderBy.Descendente).</param>		
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>		
		///  <returns>Retorna um List contendos Infografico.</returns>
		public List<Infografico> CarregarTodos(int registrosPagina, int numeroPagina, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro) {
		
			List<Infografico> entidadesRetorno = new List<Infografico>();
			
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
				sbOrder.Append( " ORDER BY infograficoId" );
			}
				
			
			if (registrosPagina>0) {
				
				//sbSQL.Append("SELECT TOP "+registrosPagina+" * FROM Infografico");
				//if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM Infografico WHERE " + filtro.GetWhereString() + " ORDER BY " + orderBy + ") ");					
				//} else {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM Infografico ORDER BY " + orderBy + ")");				
			    //}	
				sbSQL.Append("SELECT * FROM ( ");				
				sbSQL.Append("SELECT Infografico.*, ROW_NUMBER() OVER (" + sbOrder.ToString() + ") R FROM Infografico ");				
				if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) { sbSQL.Append( "WHERE" + filtro.GetWhereString() + " " ); }
				sbSQL.Append(") #Q WHERE R BETWEEN " + (((numeroPagina-1)*registrosPagina)+1).ToString() + " AND " + ((numeroPagina)*registrosPagina).ToString());				
								
			} else {
				sbSQL.Append("SELECT Infografico.* FROM Infografico ");
				if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) { sbSQL.Append( "WHERE" + filtro.GetWhereString() + " " ); }
				if ( sbOrder.Length > 0 ) { sbSQL.Append(sbOrder.ToString()); }
			}
			
			command = _db.GetSqlStringCommand(sbSQL.ToString());
			reader = _db.ExecuteReader(command);
			
            while (reader.Read())
            {
                Infografico entidadeRetorno = new Infografico();
                PopulaInfografico(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
            }
            reader.Close();

            return entidadesRetorno;					
					
		}	
		
		/// <summary>
        /// Método que retorna todas os Infografico existentes na base de dados.
        /// </summary>
		public List<Infografico> CarregarTodos() {			
			return CarregarTodos(0, 0, null, null, null);
		}
        /// <summary>
        /// Método que carrega uma Infografico para exibição do site
        /// </summary>
        /// <param name="entidade"></param>
        /// <returns></returns>
        public Infografico CarregarToSite(int infograficoId)
        {
            Infografico entidadeRetorno = null;

            StringBuilder sbSQL = new StringBuilder();

            sbSQL.Append("SELECT * FROM viewInfograficosSite WHERE infograficoId=@infograficoId");


            DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

            _db.AddInParameter(command, "@infograficoId", DbType.Int32, infograficoId);

            IDataReader reader = _db.ExecuteReader(command);

            if (reader.Read())
            {
                entidadeRetorno = new Infografico();
                PopulaInfografico(reader, entidadeRetorno);
            }
            reader.Close();

            return entidadeRetorno;
        }
        public List<Infografico> RetornaTodosSite(int quantidadeRegistros, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro)
        {
            List<Infografico> entidadesRetorno = new List<Infografico>();

            StringBuilder sbSQL = new StringBuilder();
            StringBuilder sbWhere = new StringBuilder();
            StringBuilder sbOrder = new StringBuilder();
            DbCommand command;
            IDataReader reader;

            // Monta o "OrderBy"
            if (ordemColunas != null)
            {
                for (int i = 0; i < ordemColunas.Length; i++)
                {
                    if (sbOrder.Length > 0) { sbOrder.Append(", "); }
                    sbOrder.Append(ordemColunas[i] + " " + ordemSentidos[i]);
                }
                if (sbOrder.Length > 0) { sbOrder.Insert(0, " ORDER BY "); }
            }
            else
            {
                sbOrder.Append(" ORDER BY infograficoId");
            }


            sbSQL.Append("SELECT ");

            if (quantidadeRegistros > 0)
            {
                sbSQL.Append(String.Concat("TOP ", quantidadeRegistros, " "));
            }

            sbSQL.Append("* FROM viewInfograficosSite ");
            if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
            if (sbOrder.Length > 0) { sbSQL.Append(sbOrder.ToString()); }

            command = _db.GetSqlStringCommand(sbSQL.ToString());
            reader = _db.ExecuteReader(command);

            while (reader.Read())
            {
                Infografico entidadeRetorno = new Infografico();
                PopulaInfografico(reader, entidadeRetorno);
                entidadesRetorno.Add(entidadeRetorno);
            }
            reader.Close();

            return entidadesRetorno;
        }
        /// <summary>
        /// Método que retorna o total de Infografico na base de dados.
        /// </summary>
        /// <returns></returns>
		public int TotalRegistros() 
		{
			return TotalRegistros(null);
		}	
		
        /// <summary>
        /// Método que retorna o total de Infografico na base de dados, aceita filtro.
        /// </summary>
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>
		/// <returns></returns>
		public int TotalRegistros(IFilterHelper filtro) 
		{		
			StringBuilder sbSQL = new StringBuilder();
			
			sbSQL.Append("SELECT COUNT(*) AS Total FROM Infografico");
			
			if (filtro!=null && !filtro.GetWhereString().Equals(String.Empty))
					sbSQL.Append(" WHERE (" + filtro.GetWhereString() + ")");			
			
			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
								
			// Executa a query.
			
			int resultado = (int) _db.ExecuteScalar(command);
			
			
			return resultado;	
		}
		
		/// <summary>
        /// Método que retorna popula um Infografico baseado nos dados de um DataReader.
        /// </summary>
        /// <param name="reader">IDataReader contendo os dados da consulta.</param>
        /// <param name="entidade">Infografico a ser populado(.</param>
		public static void PopulaInfografico(IDataReader reader, Infografico entidade) 
		{
            if (reader["infograficoId"] != DBNull.Value)
            {
                entidade.infograficoId = Convert.ToInt32(reader["infograficoId"].ToString());

                entidade.Conteudo = new Conteudo();
                entidade.Conteudo.ConteudoId = Convert.ToInt32(reader["infograficoId"].ToString());

            }

            if (reader["arquivoIdImagem"] != DBNull.Value)
            {
                entidade.ArquivoIdImagem = new Arquivo();
                entidade.ArquivoIdImagem.ArquivoId = Convert.ToInt32(reader["arquivoIdImagem"].ToString());
            }

		
		}		
		
	}
}
		