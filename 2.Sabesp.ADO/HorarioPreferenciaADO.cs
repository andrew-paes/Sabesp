
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
	public class HorarioPreferenciaADO : ADOSuper, IHorarioPreferenciaDAL
	{

		/// <summary>
		/// Método que persiste um HorarioPreferencia.
		/// </summary>
		/// <param name="entidade">HorarioPreferencia contendo os dados a serem persistidos.</param>	
		public void Inserir(HorarioPreferencia entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de insert.
			sbSQL.Append(" INSERT INTO HorarioPreferencia ");
			sbSQL.Append(" (horarioPreferenciaId, horario) ");
			sbSQL.Append(" VALUES ");
			sbSQL.Append(" (@horarioPreferenciaId, @horario) ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@horarioPreferenciaId", DbType.Int32, entidade.HorarioPreferenciaId);

			_db.AddInParameter(command, "@horario", DbType.String, entidade.Horario);


			// Executa a query.
			_db.ExecuteNonQuery(command);

		}

		/// <summary>
		/// Método que atualiza os dados de um HorarioPreferencia.
		/// </summary>
		/// <param name="entidade">HorarioPreferencia contendo os dados a serem atualizados.</param>
		public void Atualizar(HorarioPreferencia entidade)
		{

			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de atualização.
			sbSQL.Append(" UPDATE HorarioPreferencia SET ");
			sbSQL.Append(" horario=@horario ");
			sbSQL.Append(" WHERE horarioPreferenciaId=@horarioPreferenciaId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Parâmetros
			_db.AddInParameter(command, "@horarioPreferenciaId", DbType.Int32, entidade.HorarioPreferenciaId);
			_db.AddInParameter(command, "@horario", DbType.String, entidade.Horario);

			// Executa a query.
			_db.ExecuteNonQuery(command);

		}

		/// <summary>
		/// Método que remove um HorarioPreferencia da base de dados.
		/// </summary>
		/// <param name="entidade">HorarioPreferencia a ser excluído (somente o identificador é necessário).</param>		
		public void Excluir(HorarioPreferencia entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			sbSQL.Append("DELETE FROM HorarioPreferencia ");
			sbSQL.Append("WHERE horarioPreferenciaId=@horarioPreferenciaId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@horarioPreferenciaId", DbType.Int32, entidade.HorarioPreferenciaId);


			_db.ExecuteNonQuery(command);
		}

		/// <summary>
		/// Método que carrega um HorarioPreferencia.
		/// </summary>
		/// <param name="entidade">HorarioPreferencia a ser carregado (somente o identificador é necessário).</param>
		/// <returns>HorarioPreferencia</returns>
		public HorarioPreferencia Carregar(int horarioPreferenciaId)
		{
			HorarioPreferencia entidade = new HorarioPreferencia();
			entidade.HorarioPreferenciaId = horarioPreferenciaId;
			return Carregar(entidade);

		}


		/// <summary>
		/// Método que carrega um HorarioPreferencia.
		/// </summary>
		/// <param name="entidade">HorarioPreferencia a ser carregado (somente o identificador é necessário).</param>
		/// <returns>HorarioPreferencia</returns>
		public HorarioPreferencia Carregar(HorarioPreferencia entidade)
		{

			HorarioPreferencia entidadeRetorno = null;

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT * FROM HorarioPreferencia WHERE horarioPreferenciaId=@horarioPreferenciaId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@horarioPreferenciaId", DbType.Int32, entidade.HorarioPreferenciaId);

			IDataReader reader = _db.ExecuteReader(command);

			if (reader.Read())
			{
				entidadeRetorno = new HorarioPreferencia();
				PopulaHorarioPreferencia(reader, entidadeRetorno);
			}

			reader.Close();

			return entidadeRetorno;
		}


		/// <summary>
		/// Método que retorna uma coleção de HorarioPreferencia.
		/// </summary>
		/// <param name="entidade">FormularioCursoVazamento relacionado(a) (somente o identificador é necessário).</param>		
		/// <returns>Retorna uma coleção de HorarioPreferencia.</returns>
		public List<HorarioPreferencia> Carregar(FormularioCursoVazamento entidade)
		{
			List<HorarioPreferencia> entidadesRetorno = new List<HorarioPreferencia>();

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT HorarioPreferencia.* FROM HorarioPreferencia INNER JOIN FormularioCursoVazamento ON HorarioPreferencia.horarioPreferenciaId=FormularioCursoVazamento.horarioPreferenciaId WHERE FormularioCursoVazamento.formularioCursoVazamentoId=@formularioCursoVazamentoId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
			_db.AddInParameter(command, "@formularioCursoVazamentoId", DbType.Int32, entidade.FormularioCursoVazamentoId);

			IDataReader reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				HorarioPreferencia entidadeRetorno = new HorarioPreferencia();
				PopulaHorarioPreferencia(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}

			reader.Close();

			return entidadesRetorno;
		}


		/// <summary>
		/// Método que retorna uma coleção de HorarioPreferencia.
		/// </summary>
		/// <param name="registrosPagina">Número máximo de registros na página.</param>
		/// <param name="numeroPagina">Número da página atual (inicia em 0).</param>
		/// <param name="ordemColunas">Nome das colunas na ordem em que se deseja ordernar os resultados.</param>
		/// <param name="ordemSentidos">Sentidos das respectivas colunas de ordenção informadas no parâmetro ordemColunas (OrderBy.Ascendente ou OrderBy.Descendente).</param>		
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>		
		///  <returns>Retorna um List contendos HorarioPreferencia.</returns>
		public List<HorarioPreferencia> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro)
		{

			List<HorarioPreferencia> entidadesRetorno = new List<HorarioPreferencia>();

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
				sbOrder.Append(" ORDER BY horarioPreferenciaId");
			}


			if (registrosPagina > 0)
			{

				//sbSQL.Append("SELECT TOP "+registrosPagina+" * FROM HorarioPreferencia");
				//if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM HorarioPreferencia WHERE " + filtro.GetWhereString() + " ORDER BY " + orderBy + ") ");					
				//} else {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM HorarioPreferencia ORDER BY " + orderBy + ")");				
				//}	
				sbSQL.Append("SELECT * FROM ( ");
				sbSQL.Append("SELECT HorarioPreferencia.*, ROW_NUMBER() OVER (" + sbOrder.ToString() + ") R FROM HorarioPreferencia ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				sbSQL.Append(") #Q WHERE R BETWEEN " + (((numeroPagina - 1) * registrosPagina) + 1).ToString() + " AND " + ((numeroPagina) * registrosPagina).ToString());

			}
			else
			{
				sbSQL.Append("SELECT HorarioPreferencia.* FROM HorarioPreferencia ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				if (sbOrder.Length > 0) { sbSQL.Append(sbOrder.ToString()); }
			}

			command = _db.GetSqlStringCommand(sbSQL.ToString());
			reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				HorarioPreferencia entidadeRetorno = new HorarioPreferencia();
				PopulaHorarioPreferencia(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}

			reader.Close();

			return entidadesRetorno;
		}

		/// <summary>
		/// Método que retorna todas os HorarioPreferencia existentes na base de dados.
		/// </summary>
		public List<HorarioPreferencia> CarregarTodos()
		{
			return CarregarTodos(0, 0, null, null, null);
		}

		/// <summary>
		/// Método que retorna o total de HorarioPreferencia na base de dados.
		/// </summary>
		/// <returns></returns>
		public int TotalRegistros()
		{
			return TotalRegistros(null);
		}

		/// <summary>
		/// Método que retorna o total de HorarioPreferencia na base de dados, aceita filtro.
		/// </summary>
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>
		/// <returns></returns>
		public int TotalRegistros(IFilterHelper filtro)
		{
			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT COUNT(*) AS Total FROM HorarioPreferencia");

			if (filtro != null && !filtro.GetWhereString().Equals(String.Empty))
				sbSQL.Append(" WHERE (" + filtro.GetWhereString() + ")");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Executa a query.

			int resultado = (int)_db.ExecuteScalar(command);


			return resultado;
		}

		/// <summary>
		/// Método que retorna popula um HorarioPreferencia baseado nos dados de um DataReader.
		/// </summary>
		/// <param name="reader">IDataReader contendo os dados da consulta.</param>
		/// <param name="entidade">HorarioPreferencia a ser populado(.</param>
		public static void PopulaHorarioPreferencia(IDataReader reader, HorarioPreferencia entidade)
		{
			if (reader["horarioPreferenciaId"] != DBNull.Value)
				entidade.HorarioPreferenciaId = Convert.ToInt32(reader["horarioPreferenciaId"].ToString());

			if (reader["horario"] != DBNull.Value)
				entidade.Horario = reader["horario"].ToString();


		}

	}
}
