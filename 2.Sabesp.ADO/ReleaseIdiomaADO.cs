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
	public class ReleaseIdiomaADO : ADOSuper, IReleaseIdiomaDAL
	{
		/// <summary>
		/// Método que persiste um ReleaseIdioma.
		/// </summary>
		/// <param name="entidade">ReleaseIdioma contendo os dados a serem persistidos.</param>	
		public void Inserir(ReleaseIdioma entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de insert.
			sbSQL.Append(" INSERT INTO ReleaseIdioma ");
			sbSQL.Append(" (releaseId, idiomaId, tituloRelease, chamadaRelease, textoRelease) ");
			sbSQL.Append(" VALUES ");
			sbSQL.Append(" (@releaseId, @idiomaId, @tituloRelease, @chamadaRelease, @textoRelease) ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@releaseId", DbType.Int32, entidade.Release.Conteudo.ConteudoId);

			_db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);

			_db.AddInParameter(command, "@tituloRelease", DbType.String, entidade.TituloRelease);

			if (entidade.ChamadaRelease != null)
				_db.AddInParameter(command, "@chamadaRelease", DbType.String, entidade.ChamadaRelease);
			else
				_db.AddInParameter(command, "@chamadaRelease", DbType.String, null);

			if (entidade.TextoRelease != null)
				_db.AddInParameter(command, "@textoRelease", DbType.String, entidade.TextoRelease);
			else
				_db.AddInParameter(command, "@textoRelease", DbType.String, null);

			// Executa a query.
			_db.ExecuteNonQuery(command);
		}

		/// <summary>
		/// Método que atualiza os dados de um ReleaseIdioma.
		/// </summary>
		/// <param name="entidade">ReleaseIdioma contendo os dados a serem atualizados.</param>
		public void Atualizar(ReleaseIdioma entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de atualização.
			sbSQL.Append(" UPDATE ReleaseIdioma SET ");
			sbSQL.Append(" tituloRelease=@tituloRelease, chamadaRelease=@chamadaRelease, textoRelease=@textoRelease ");
			sbSQL.Append(" WHERE releaseId=@releaseId AND idiomaId=@idiomaId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Parâmetros
			_db.AddInParameter(command, "@releaseId", DbType.Int32, entidade.Release.Conteudo.ConteudoId);
			_db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);
			_db.AddInParameter(command, "@tituloRelease", DbType.String, entidade.TituloRelease);
			if (entidade.ChamadaRelease != null)
				_db.AddInParameter(command, "@chamadaRelease", DbType.String, entidade.ChamadaRelease);
			else
				_db.AddInParameter(command, "@chamadaRelease", DbType.String, null);
			if (entidade.TextoRelease != null)
				_db.AddInParameter(command, "@textoRelease", DbType.String, entidade.TextoRelease);
			else
				_db.AddInParameter(command, "@textoRelease", DbType.String, null);

			// Executa a query.
			_db.ExecuteNonQuery(command);
		}

		/// <summary>
		/// Método que remove um ReleaseIdioma da base de dados.
		/// </summary>
		/// <param name="entidade">ReleaseIdioma a ser excluído (somente o identificador é necessário).</param>		
		public void Excluir(ReleaseIdioma entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			sbSQL.Append("DELETE FROM ReleaseIdioma ");
			sbSQL.Append("WHERE releaseId=@releaseId AND idiomaId=@idiomaId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@releaseId", DbType.Int32, entidade.Release.Conteudo.ConteudoId);
			_db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);

			_db.ExecuteNonQuery(command);
		}


		/// <summary>
		/// Método que carrega um ReleaseIdioma.
		/// </summary>
		/// <param name="entidade">ReleaseIdioma a ser carregado (somente o identificador é necessário).</param>
		/// <returns>ReleaseIdioma</returns>
		public ReleaseIdioma Carregar(ReleaseIdioma entidade)
		{
			ReleaseIdioma entidadeRetorno = null;

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT * FROM ReleaseIdioma WHERE releaseId=@releaseId AND idiomaId=@idiomaId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@releaseId", DbType.Int32, entidade.Release.Conteudo.ConteudoId);
			_db.AddInParameter(command, "@idiomaId", DbType.Int32, entidade.Idioma.IdiomaId);

			IDataReader reader = _db.ExecuteReader(command);

			if (reader.Read())
			{
				entidadeRetorno = new ReleaseIdioma();
				PopulaReleaseIdioma(reader, entidadeRetorno);
			}

			reader.Close();

			return entidadeRetorno;
		}



		/// <summary>
		/// Método que retorna uma coleção de ReleaseIdioma.
		/// </summary>
		/// <param name="registrosPagina">Número máximo de registros na página.</param>
		/// <param name="numeroPagina">Número da página atual (inicia em 0).</param>
		/// <param name="ordemColunas">Nome das colunas na ordem em que se deseja ordernar os resultados.</param>
		/// <param name="ordemSentidos">Sentidos das respectivas colunas de ordenção informadas no parâmetro ordemColunas (OrderBy.Ascendente ou OrderBy.Descendente).</param>		
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>		
		///  <returns>Retorna um List contendos ReleaseIdioma.</returns>
		public List<ReleaseIdioma> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro)
		{
			List<ReleaseIdioma> entidadesRetorno = new List<ReleaseIdioma>();

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
				sbOrder.Append(" ORDER BY releaseId, idiomaId");
			}

			if (registrosPagina > 0)
			{
				//sbSQL.Append("SELECT TOP "+registrosPagina+" * FROM ReleaseIdioma");
				//if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM ReleaseIdioma WHERE " + filtro.GetWhereString() + " ORDER BY " + orderBy + ") ");					
				//} else {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM ReleaseIdioma ORDER BY " + orderBy + ")");				
				//}	
				sbSQL.Append("SELECT * FROM ( ");
				sbSQL.Append("SELECT ReleaseIdioma.*, ROW_NUMBER() OVER (" + sbOrder.ToString() + ") R FROM ReleaseIdioma ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				sbSQL.Append(") #Q WHERE R BETWEEN " + (((numeroPagina - 1) * registrosPagina) + 1).ToString() + " AND " + ((numeroPagina) * registrosPagina).ToString());
			}
			else
			{
				sbSQL.Append("SELECT ReleaseIdioma.* FROM ReleaseIdioma ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				if (sbOrder.Length > 0) { sbSQL.Append(sbOrder.ToString()); }
			}

			command = _db.GetSqlStringCommand(sbSQL.ToString());
			reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				ReleaseIdioma entidadeRetorno = new ReleaseIdioma();
				PopulaReleaseIdioma(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}

			reader.Close();

			return entidadesRetorno;
		}

		/// <summary>
		/// Método que retorna todas os ReleaseIdioma existentes na base de dados.
		/// </summary>
		public List<ReleaseIdioma> CarregarTodos()
		{
			return CarregarTodos(0, 0, null, null, null);
		}

		/// <summary>
		/// Método que retorna o total de ReleaseIdioma na base de dados.
		/// </summary>
		/// <returns></returns>
		public int TotalRegistros()
		{
			return TotalRegistros(null);
		}

		/// <summary>
		/// Método que retorna o total de ReleaseIdioma na base de dados, aceita filtro.
		/// </summary>
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>
		/// <returns></returns>
		public int TotalRegistros(IFilterHelper filtro)
		{
			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT COUNT(*) AS Total FROM ReleaseIdioma");

			if (filtro != null && !filtro.GetWhereString().Equals(String.Empty))
				sbSQL.Append(" WHERE (" + filtro.GetWhereString() + ")");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Executa a query.
			int resultado = (int)_db.ExecuteScalar(command);

			return resultado;
		}

		/// <summary>
		/// Método que retorna popula um ReleaseIdioma baseado nos dados de um DataReader.
		/// </summary>
		/// <param name="reader">IDataReader contendo os dados da consulta.</param>
		/// <param name="entidade">ReleaseIdioma a ser populado(.</param>
		public static void PopulaReleaseIdioma(IDataReader reader, ReleaseIdioma entidade)
		{
			if (reader["tituloRelease"] != DBNull.Value)
				entidade.TituloRelease = reader["tituloRelease"].ToString();

			if (reader["chamadaRelease"] != DBNull.Value)
				entidade.ChamadaRelease = reader["chamadaRelease"].ToString();

			if (reader["textoRelease"] != DBNull.Value)
				entidade.TextoRelease = reader["textoRelease"].ToString();

			if (reader["releaseId"] != DBNull.Value)
			{
				entidade.Release = new Release();
				entidade.Release.Conteudo = new Conteudo();
				entidade.Release.Conteudo.ConteudoId = Convert.ToInt32(reader["releaseId"].ToString());
			}

			if (reader["idiomaId"] != DBNull.Value)
			{
				entidade.Idioma = new Idioma();
				entidade.Idioma.IdiomaId = Convert.ToInt32(reader["idiomaId"].ToString());
			}
		}
	}
}