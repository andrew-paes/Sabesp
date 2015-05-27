
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

using Sabesp.DAL;
using Sabesp.BO;
using Sabesp.FilterHelper;

namespace Sabesp.DAL.ADO
{
	public class RegiaoADO : ADOSuper, IRegiaoDAL
	{

		/// <summary>
		/// Método que persiste um Regiao.
		/// </summary>
		/// <param name="entidade">Regiao contendo os dados a serem persistidos.</param>	
		public void Inserir(Regiao entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de insert.
			sbSQL.Append(" INSERT INTO Regiao ");
			sbSQL.Append(" (nomeRegiao) ");
			sbSQL.Append(" VALUES ");
			sbSQL.Append(" (@nomeRegiao) ");

			sbSQL.Append(" ; SET @regiaoId = SCOPE_IDENTITY(); ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			//_db.AddInParameter(command, "@regiaoId", DbType.Int32, entidade.RegiaoId);

			_db.AddOutParameter(command, "@regiaoId", DbType.Int32, 8);

			_db.AddInParameter(command, "@nomeRegiao", DbType.String, entidade.NomeRegiao);


			// Executa a query.
			_db.ExecuteNonQuery(command);

			entidade.RegiaoId = Convert.ToInt32(_db.GetParameterValue(command, "@regiaoId"));
		}

		/// <summary>
		/// Método que atualiza os dados de um Regiao.
		/// </summary>
		/// <param name="entidade">Regiao contendo os dados a serem atualizados.</param>
		public void Atualizar(Regiao entidade)
		{

			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de atualização.
			sbSQL.Append(" UPDATE Regiao SET ");
			sbSQL.Append(" nomeRegiao=@nomeRegiao ");
			sbSQL.Append(" WHERE  regiaoId = @regiaoId");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Parâmetros
			_db.AddInParameter(command, "@regiaoId", DbType.Int32, entidade.RegiaoId);
			_db.AddInParameter(command, "@nomeRegiao", DbType.String, entidade.NomeRegiao);

			// Executa a query.
			_db.ExecuteNonQuery(command);

		}

		/// <summary>
		/// Método que remove um Regiao da base de dados.
		/// </summary>
		/// <param name="entidade">Regiao a ser excluído (somente o identificador é necessário).</param>		
		public void Excluir(Regiao entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			sbSQL.Append("DELETE FROM Regiao ");
			sbSQL.Append("WHERE regiaoId = @regiaoId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@regiaoId", DbType.Int32, entidade.RegiaoId);

			_db.ExecuteNonQuery(command);
		}

		/// <summary>
		/// Método que carrega um Regiao.
		/// </summary>
		/// <param name="entidade">Regiao a ser carregado (somente o identificador é necessário).</param>
		/// <returns>Regiao</returns>
		public Regiao Carregar(Regiao entidade)
		{

			Regiao entidadeRetorno = null;

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT * FROM Regiao WHERE regiaoId = @regiaoId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@regiaoId", DbType.Int32, entidade.RegiaoId);

			IDataReader reader = _db.ExecuteReader(command);

			if (reader.Read())
			{
				entidadeRetorno = new Regiao();
				PopulaRegiao(reader, entidadeRetorno);
			}
			reader.Close();

			return entidadeRetorno;
		}

		/// <summary>
		/// Método que retorna uma coleção de Regiao.
		/// </summary>
		/// <param name="registrosPagina">Número máximo de registros na página.</param>
		/// <param name="numeroPagina">Número da página atual (inicia em 0).</param>
		/// <param name="ordemColunas">Nome das colunas na ordem em que se deseja ordernar os resultados.</param>
		/// <param name="ordemSentidos">Sentidos das respectivas colunas de ordenção informadas no parâmetro ordemColunas (OrderBy.Ascendente ou OrderBy.Descendente).</param>		
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>		
		///  <returns>Retorna um List contendos Regiao.</returns>
		public List<Regiao> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro)
		{

			List<Regiao> entidadesRetorno = new List<Regiao>();

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
				sbOrder.Append(" ORDER BY ");
			}


			if (registrosPagina > 0)
			{

				//sbSQL.Append("SELECT TOP "+registrosPagina+" * FROM Regiao");
				//if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM Regiao WHERE " + filtro.GetWhereString() + " ORDER BY " + orderBy + ") ");					
				//} else {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM Regiao ORDER BY " + orderBy + ")");				
				//}	
				sbSQL.Append("SELECT * FROM ( ");
				sbSQL.Append("SELECT Regiao.*, ROW_NUMBER() OVER (" + sbOrder.ToString() + ") R FROM Regiao ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				sbSQL.Append(") #Q WHERE R BETWEEN " + (((numeroPagina - 1) * registrosPagina) + 1).ToString() + " AND " + ((numeroPagina) * registrosPagina).ToString());

			}
			else
			{
				sbSQL.Append("SELECT Regiao.* FROM Regiao ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				//if ( sbOrder.Length > 0 ) { sbSQL.Append(sbOrder.ToString()); }
			}

			command = _db.GetSqlStringCommand(sbSQL.ToString());
			reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				Regiao entidadeRetorno = new Regiao();
				PopulaRegiao(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}
			reader.Close();

			return entidadesRetorno;

		}

		/// <summary>
		/// Método que retorna todas os Regiao existentes na base de dados.
		/// </summary>
		public List<Regiao> CarregarTodos()
		{
			return CarregarTodos(0, 0, null, null, null);
		}

		/// <summary>
		/// Método que retorna o total de Regiao na base de dados.
		/// </summary>
		/// <returns></returns>
		public int TotalRegistros()
		{
			return TotalRegistros(null);
		}

		/// <summary>
		/// Método que retorna o total de Regiao na base de dados, aceita filtro.
		/// </summary>
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>
		/// <returns></returns>
		public int TotalRegistros(IFilterHelper filtro)
		{
			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT COUNT(*) AS Total FROM Regiao");

			if (filtro != null && !filtro.GetWhereString().Equals(String.Empty))
				sbSQL.Append(" WHERE (" + filtro.GetWhereString() + ")");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Executa a query.

			int resultado = (int)_db.ExecuteScalar(command);


			return resultado;
		}

		/// <summary>
		/// Método que retorna popula um Regiao baseado nos dados de um DataReader.
		/// </summary>
		/// <param name="reader">IDataReader contendo os dados da consulta.</param>
		/// <param name="entidade">Regiao a ser populado(.</param>
		public static void PopulaRegiao(IDataReader reader, Regiao entidade)
		{
			if (reader["regiaoId"] != DBNull.Value)
				entidade.RegiaoId = Convert.ToInt32(reader["regiaoId"].ToString());

			if (reader["nomeRegiao"] != DBNull.Value)
				entidade.NomeRegiao = reader["nomeRegiao"].ToString();
		}

		public List<Municipio> GetMunicipios(int regiaoId)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;
			IDataReader reader;
			List<Municipio> municipios = new List<Municipio>();

			sbSQL.Append("SELECT Municipio.municipioId, Municipio.nome, Municipio.imagem, Municipio.texto ");
			sbSQL.Append("FROM Municipio INNER JOIN RegiaoMunicipio ON Municipio.municipioId = RegiaoMunicipio.municipioId ");
			sbSQL.Append("WHERE (RegiaoMunicipio.regiaoId = @regiaoId) ");
			sbSQL.Append("ORDER BY Municipio.nome");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@regiaoId", DbType.Int32, regiaoId);


			reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				Municipio entidadeRetorno = new Municipio();
				MunicipioADO.PopulaMunicipio(reader, entidadeRetorno);
				municipios.Add(entidadeRetorno);
			}
			reader.Close();

			return municipios;
		}

		/// <summary>
		/// Método que persiste Municipio X Regiao.
		/// </summary>
		/// <param name="entidade">Regiao contendo os dados a serem persistidos.</param>	
		public void InserirRelacionado(Regiao entidade, int idMunicipio)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de insert.
			sbSQL.Append(" INSERT INTO RegiaoMunicipio ");
			sbSQL.Append(" (regiaoId, municipioId) ");
			sbSQL.Append(" VALUES ");
			sbSQL.Append(" (@regiaoId, @municipioId) ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@regiaoId", DbType.Int32, entidade.RegiaoId);

			_db.AddInParameter(command, "@municipioId", DbType.Int32, idMunicipio);


			// Executa a query.
			_db.ExecuteNonQuery(command);

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="municipioId"></param>
		/// <returns></returns>
		public List<Regiao> CarregarPorMunicipio(int municipioId)
		{
			Regiao entidade;
			List<Regiao> entidadeRetorno = new List<Regiao>();

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT Regiao.regiaoId, Regiao.nomeRegiao ");
			sbSQL.Append("FROM Regiao ");
			sbSQL.Append("INNER JOIN RegiaoMunicipio ON Regiao.regiaoId = RegiaoMunicipio.regiaoId ");
			sbSQL.Append("WHERE (RegiaoMunicipio.municipioId = @municipioId)");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@municipioId", DbType.Int32, municipioId);

			IDataReader reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				entidade = new Regiao();
				PopulaRegiao(reader, entidade);

				entidadeRetorno.Add(entidade);
			}
			reader.Close();

			return entidadeRetorno;
		}

		/// <summary>
		/// Método que remove todos os Municipios X Regiao da base de dados.
		/// </summary>
		/// <param name="entidade">Regiao a ser excluída (somente o identificador é necessário).</param>		
		public void ExcluirRelacionado(int entidade)
		{
			Regiao regiaoBO = new Regiao();
			regiaoBO.RegiaoId = entidade;

			this.ExcluirRelacionados(regiaoBO);
		}

		/// <summary>
		/// Método que remove um RegiaoMunicipio da base de dados.
		/// </summary>
		/// <param name="entidade">RegiaoMunicipio a ser excluído (somente o identificador é necessário).</param>		
		public void ExcluirRelacionados(Regiao entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			sbSQL.Append("DELETE FROM RegiaoMunicipio ");
			sbSQL.Append("WHERE regiaoId=@regiaoId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@regiaoId", DbType.Int32, entidade.RegiaoId);

			_db.ExecuteNonQuery(command);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="entidade"></param>
		public void ExcluirConteudoRelacionado(Regiao entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			sbSQL.Append("DELETE FROM ConteudoRegiao ");
			sbSQL.Append("WHERE regiaoId=@regiaoId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@regiaoId", DbType.Int32, entidade.RegiaoId);

			_db.ExecuteNonQuery(command);
		}

		/// <summary>
		/// Método que retorna o total de Regiões X municipios na base de dados, aceita filtro.
		/// </summary>        
		/// <returns></returns>
		public int TotalRegistrosRelacionado(int regiaoId, int municipioId)
		{
			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append(@"SELECT COUNT(*) AS Total FROM RegiaoMunicipio
                            where regiaoId = " + regiaoId + " and municipioId = " + municipioId);

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Executa a query.

			int resultado = (int)_db.ExecuteScalar(command);


			return resultado;
		}

		/// <summary>
		/// Método que retorna o total de Regiões X conteudo na base de dados, aceita filtro.
		/// </summary>        
		/// <returns></returns>
		public int TotalRegistrosRelacionadoConteudo(int regiaoId, int conteudoId)
		{
			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append(@"SELECT COUNT(*) AS Total FROM ConteudoRegiao
                            where regiaoId = " + regiaoId + " and conteudoId = " + conteudoId);

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Executa a query.

			int resultado = (int)_db.ExecuteScalar(command);


			return resultado;
		}
	}
}