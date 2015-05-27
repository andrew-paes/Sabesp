/*
'===============================================================================
'
'  Template: Gerador Código C#.csgen
'  Script versão: 0.93
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
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Sabesp.BO;
using Sabesp.FilterHelper;

namespace Sabesp.DAL.ADO
{
	public class NoticiaIdiomaADO : ADOSuper, INoticiaIdiomaDAL
	{
		/// <summary>
		/// Método que persiste um NoticiaIdioma.
		/// </summary>
		/// <param name="entidade">NoticiaIdioma contendo os dados a serem persistidos.</param>	
		public void Inserir(NoticiaIdioma entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de insert.
			sbSQL.Append(" INSERT INTO NoticiaIdioma ");
			sbSQL.Append(" (noticiaId, idiomaId, tituloNoticia, chamadaNoticia, textoNoticia) ");
			sbSQL.Append(" VALUES ");
			sbSQL.Append(" (@noticiaId, @idiomaId, @tituloNoticia, @chamadaNoticia, @textoNoticia) ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@noticiaId", DbType.Int32, entidade.Noticia.Conteudo.ConteudoId);

			_db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);

			_db.AddInParameter(command, "@tituloNoticia", DbType.String, entidade.TituloNoticia);

			if (entidade.ChamadaNoticia != null)
				_db.AddInParameter(command, "@chamadaNoticia", DbType.String, entidade.ChamadaNoticia);
			else
				_db.AddInParameter(command, "@chamadaNoticia", DbType.String, null);

			_db.AddInParameter(command, "@textoNoticia", DbType.String, entidade.TextoNoticia);


			// Executa a query.
			_db.ExecuteNonQuery(command);
		}

		/// <summary>
		/// Método que atualiza os dados de um NoticiaIdioma.
		/// </summary>
		/// <param name="entidade">NoticiaIdioma contendo os dados a serem atualizados.</param>
		public void Atualizar(NoticiaIdioma entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de atualização.
			sbSQL.Append(" UPDATE NoticiaIdioma SET ");
			sbSQL.Append(" tituloNoticia=@tituloNoticia, chamadaNoticia=@chamadaNoticia, textoNoticia=@textoNoticia ");
			sbSQL.Append(" WHERE noticiaId=@noticiaId AND idiomaId=@idiomaId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Parâmetros
			_db.AddInParameter(command, "@noticiaId", DbType.Int32, entidade.Noticia.Conteudo.ConteudoId);
			_db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);
			_db.AddInParameter(command, "@tituloNoticia", DbType.String, entidade.TituloNoticia);
			if (entidade.ChamadaNoticia != null)
				_db.AddInParameter(command, "@chamadaNoticia", DbType.String, entidade.ChamadaNoticia);
			else
				_db.AddInParameter(command, "@chamadaNoticia", DbType.String, null);
			_db.AddInParameter(command, "@textoNoticia", DbType.String, entidade.TextoNoticia);

			// Executa a query.
			_db.ExecuteNonQuery(command);
		}

		/// <summary>
		/// Método que remove um NoticiaIdioma da base de dados.
		/// </summary>
		/// <param name="entidade">NoticiaIdioma a ser excluído (somente o identificador é necessário).</param>		
		public void Excluir(NoticiaIdioma entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			sbSQL.Append("DELETE FROM NoticiaIdioma ");
			sbSQL.Append("WHERE noticiaId=@noticiaId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@noticiaId", DbType.Int32, entidade.Noticia.Conteudo.ConteudoId);
			_db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);

			_db.ExecuteNonQuery(command);
		}

		/// <summary>
		/// Método que carrega um NoticiaIdioma.
		/// </summary>
		/// <param name="entidade">NoticiaIdioma a ser carregado (somente o identificador é necessário).</param>
		/// <returns>NoticiaIdioma</returns>
		public NoticiaIdioma Carregar(NoticiaIdioma entidade)
		{
			NoticiaIdioma entidadeRetorno = null;

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT * FROM NoticiaIdioma WHERE noticiaId=@noticiaId AND idiomaId=@idiomaId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@noticiaId", DbType.Int32, entidade.Noticia.Conteudo.ConteudoId);
			_db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);

			IDataReader reader = _db.ExecuteReader(command);

			if (reader.Read())
			{
				entidadeRetorno = new NoticiaIdioma();
				PopulaNoticiaIdioma(reader, entidadeRetorno);
			}
			reader.Close();

			return entidadeRetorno;
		}

		/// <summary>
		/// Método que retorna uma coleção de NoticiaIdioma.
		/// </summary>
		/// <param name="registrosPagina">Número máximo de registros na página.</param>
		/// <param name="numeroPagina">Número da página atual (inicia em 0).</param>
		/// <param name="ordemColunas">Nome das colunas na ordem em que se deseja ordernar os resultados.</param>
		/// <param name="ordemSentidos">Sentidos das respectivas colunas de ordenção informadas no parâmetro ordemColunas (OrderBy.Ascendente ou OrderBy.Descendente).</param>		
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>		
		///  <returns>Retorna um List contendos NoticiaIdioma.</returns>
		public List<NoticiaIdioma> CarregarTodos(int registrosPagina, int numeroPagina, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro)
		{
			List<NoticiaIdioma> entidadesRetorno = new List<NoticiaIdioma>();

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
				sbOrder.Append(" ORDER BY noticiaId, idiomaId");
			}

			if (registrosPagina > 0)
			{
				//sbSQL.Append("SELECT TOP "+registrosPagina+" * FROM NoticiaIdioma");
				//if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM NoticiaIdioma WHERE " + filtro.GetWhereString() + " ORDER BY " + orderBy + ") ");					
				//} else {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM NoticiaIdioma ORDER BY " + orderBy + ")");				
				//}	
				sbSQL.Append("SELECT * FROM ( ");
				sbSQL.Append("SELECT NoticiaIdioma.*, ROW_NUMBER() OVER (" + sbOrder.ToString() + ") R FROM NoticiaIdioma ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				sbSQL.Append(") #Q WHERE R BETWEEN " + (((numeroPagina - 1) * registrosPagina) + 1).ToString() + " AND " + ((numeroPagina) * registrosPagina).ToString());
			}
			else
			{
				sbSQL.Append("SELECT NoticiaIdioma.* FROM NoticiaIdioma ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				if (sbOrder.Length > 0) { sbSQL.Append(sbOrder.ToString()); }
			}

			command = _db.GetSqlStringCommand(sbSQL.ToString());
			reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				NoticiaIdioma entidadeRetorno = new NoticiaIdioma();
				PopulaNoticiaIdioma(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}

			reader.Close();

			return entidadesRetorno;
		}

		/// <summary>
		/// Método que retorna todas os NoticiaIdioma existentes na base de dados.
		/// </summary>
		public List<NoticiaIdioma> CarregarTodos()
		{
			return CarregarTodos(0, 0, null, null, null);
		}

		/// <summary>
		/// Método que retorna o total de NoticiaIdioma na base de dados.
		/// </summary>
		/// <returns></returns>
		public int TotalRegistros()
		{
			return TotalRegistros(null);
		}

		/// <summary>
		/// Método que retorna o total de NoticiaIdioma na base de dados, aceita filtro.
		/// </summary>
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>
		/// <returns></returns>
		public int TotalRegistros(IFilterHelper filtro)
		{
			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT COUNT(*) AS Total FROM NoticiaIdioma");

			if (filtro != null && !filtro.GetWhereString().Equals(String.Empty))
				sbSQL.Append(" WHERE (" + filtro.GetWhereString() + ")");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Executa a query.
			int resultado = (int)_db.ExecuteScalar(command);

			return resultado;
		}

		/// <summary>
		/// Método que retorna popula um NoticiaIdioma baseado nos dados de um DataReader.
		/// </summary>
		/// <param name="reader">IDataReader contendo os dados da consulta.</param>
		/// <param name="entidade">NoticiaIdioma a ser populado(.</param>
		public static void PopulaNoticiaIdioma(IDataReader reader, NoticiaIdioma entidade)
		{
			if (reader["tituloNoticia"] != DBNull.Value)
				entidade.TituloNoticia = reader["tituloNoticia"].ToString();

			if (reader["chamadaNoticia"] != DBNull.Value)
				entidade.ChamadaNoticia = reader["chamadaNoticia"].ToString();

			if (reader["textoNoticia"] != DBNull.Value)
				entidade.TextoNoticia = reader["textoNoticia"].ToString();

			if (reader["noticiaId"] != DBNull.Value)
			{
				entidade.Noticia = new Noticia();
				entidade.Noticia.Conteudo = new Conteudo();
				entidade.Noticia.Conteudo.ConteudoId = Convert.ToInt32(reader["noticiaId"].ToString());
			}

			if (reader["idiomaId"] != DBNull.Value)
			{
				entidade.Idioma = new Idioma();
				entidade.Idioma.IdiomaId = Convert.ToInt32(reader["idiomaId"].ToString());
			}
		}
	}
}