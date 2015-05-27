
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
	public class FaleConoscoMensagemADO : ADOSuper, IFaleConoscoMensagemDAL
	{

		/// <summary>
		/// Método que persiste um FaleConoscoMensagem.
		/// </summary>
		/// <param name="entidade">FaleConoscoMensagem contendo os dados a serem persistidos.</param>	
		public void Inserir(FaleConoscoMensagem entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de insert.
			sbSQL.Append(" INSERT INTO FaleConoscoMensagem ");
			sbSQL.Append(" (faleConoscoAssuntoId, nome, email, telefoneDDD, telefoneComplemento, regiaoId, estadoId, cidadeId, mensagem, atendido) ");
			sbSQL.Append(" VALUES ");
			sbSQL.Append(" (@faleConoscoAssuntoId, @nome, @email, @telefoneDDD, @telefoneComplemento, @regiaoId, @estadoId, @cidadeId, @mensagem, @atendido) ");

			sbSQL.Append(" ; SET @faleConoscoMensagemId = SCOPE_IDENTITY(); ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddOutParameter(command, "@faleConoscoMensagemId", DbType.Int32, 8);

			_db.AddInParameter(command, "@faleConoscoAssuntoId", DbType.Int32, entidade.FaleConoscoAssunto.FaleConoscoAssuntoId);

			_db.AddInParameter(command, "@nome", DbType.String, entidade.Nome);

			_db.AddInParameter(command, "@email", DbType.String, entidade.Email);

			_db.AddInParameter(command, "@telefoneDDD", DbType.Int32, entidade.TelefoneDDD);

			_db.AddInParameter(command, "@telefoneComplemento", DbType.Int32, entidade.TelefoneComplemento);

			if (entidade.Regiao != null && entidade.Regiao.RegiaoId > 0)
			{
				_db.AddInParameter(command, "@regiaoId", DbType.Int32, entidade.Regiao.RegiaoId);
			}
			else
			{
				_db.AddInParameter(command, "@regiaoId", DbType.Int32, null);
			}

			if (entidade.Estado != null && entidade.Estado.EstadoId > 0)
			{
				_db.AddInParameter(command, "@estadoId", DbType.Int32, entidade.Estado.EstadoId);
			}
			else
			{
				_db.AddInParameter(command, "@estadoId", DbType.Int32, null);
			}

			if (entidade.Cidade != null && entidade.Cidade.CidadeId > 0)
			{
				_db.AddInParameter(command, "@cidadeId", DbType.Int32, entidade.Cidade.CidadeId);
			}
			else
			{
				_db.AddInParameter(command, "@cidadeId", DbType.Int32, null);
			}

			_db.AddInParameter(command, "@mensagem", DbType.String, entidade.Mensagem);

			_db.AddInParameter(command, "@atendido", DbType.String, entidade.Atendido);

			// Executa a query.
			_db.ExecuteNonQuery(command);

			entidade.FaleConoscoMensagemId = Convert.ToInt32(_db.GetParameterValue(command, "@faleConoscoMensagemId"));

		}

		/// <summary>
		/// Método que atualiza os dados de um FaleConoscoMensagem.
		/// </summary>
		/// <param name="entidade">FaleConoscoMensagem contendo os dados a serem atualizados.</param>
		public void Atualizar(FaleConoscoMensagem entidade)
		{

			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de atualização.
			sbSQL.Append(" UPDATE FaleConoscoMensagem SET ");
			sbSQL.Append(" faleConoscoAssuntoId=@faleConoscoAssuntoId, nome=@nome, email=@email, telefoneDDD=@telefoneDDD, telefoneComplemento=@telefoneComplemento, regiaoId=@regiaoId, estadoId=@estadoId, cidadeId=@cidadeId, mensagem=@mensagem, atendido=@atendido ");
			sbSQL.Append(" WHERE faleConoscoMensagemId=@faleConoscoMensagemId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Parâmetros
			_db.AddInParameter(command, "@faleConoscoMensagemId", DbType.Int32, entidade.FaleConoscoMensagemId);
			_db.AddInParameter(command, "@faleConoscoAssuntoId", DbType.Int32, entidade.FaleConoscoAssunto.FaleConoscoAssuntoId);
			_db.AddInParameter(command, "@nome", DbType.String, entidade.Nome);
			_db.AddInParameter(command, "@email", DbType.String, entidade.Email);
			_db.AddInParameter(command, "@telefoneDDD", DbType.Int32, entidade.TelefoneDDD);
			_db.AddInParameter(command, "@telefoneComplemento", DbType.Int32, entidade.TelefoneComplemento);
			_db.AddInParameter(command, "@regiaoId", DbType.String, entidade.Regiao.RegiaoId);
			_db.AddInParameter(command, "@estadoId", DbType.String, entidade.Estado.EstadoId);
			_db.AddInParameter(command, "@cidadeId", DbType.String, entidade.Cidade.CidadeId);
			_db.AddInParameter(command, "@mensagem", DbType.String, entidade.Mensagem);
			_db.AddInParameter(command, "@atendido", DbType.String, entidade.Atendido);

			// Executa a query.
			_db.ExecuteNonQuery(command);

		}

		/// <summary>
		/// Método que remove um FaleConoscoMensagem da base de dados.
		/// </summary>
		/// <param name="entidade">FaleConoscoMensagem a ser excluído (somente o identificador é necessário).</param>		
		public void Excluir(FaleConoscoMensagem entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			sbSQL.Append("DELETE FROM FaleConoscoMensagem ");
			sbSQL.Append("WHERE faleConoscoMensagemId=@faleConoscoMensagemId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@faleConoscoMensagemId", DbType.Int32, entidade.FaleConoscoMensagemId);


			_db.ExecuteNonQuery(command);
		}

		/// <summary>
		/// Método que carrega um FaleConoscoMensagem.
		/// </summary>
		/// <param name="entidade">FaleConoscoMensagem a ser carregado (somente o identificador é necessário).</param>
		/// <returns>FaleConoscoMensagem</returns>
		public FaleConoscoMensagem Carregar(int faleConoscoMensagemId)
		{
			FaleConoscoMensagem entidade = new FaleConoscoMensagem();
			entidade.FaleConoscoMensagemId = faleConoscoMensagemId;
			return Carregar(entidade);

		}


		/// <summary>
		/// Método que carrega um FaleConoscoMensagem.
		/// </summary>
		/// <param name="entidade">FaleConoscoMensagem a ser carregado (somente o identificador é necessário).</param>
		/// <returns>FaleConoscoMensagem</returns>
		public FaleConoscoMensagem Carregar(FaleConoscoMensagem entidade)
		{

			FaleConoscoMensagem entidadeRetorno = null;

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT * FROM FaleConoscoMensagem WHERE faleConoscoMensagemId=@faleConoscoMensagemId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@faleConoscoMensagemId", DbType.Int32, entidade.FaleConoscoMensagemId);

			IDataReader reader = _db.ExecuteReader(command);

			if (reader.Read())
			{
				entidadeRetorno = new FaleConoscoMensagem();
				PopulaFaleConoscoMensagem(reader, entidadeRetorno);
			}
			reader.Close();

			return entidadeRetorno;
		}



		/// <summary>
		/// Método que retorna uma coleção de FaleConoscoMensagem.
		/// </summary>
		/// <param name="registrosPagina">Número máximo de registros na página.</param>
		/// <param name="numeroPagina">Número da página atual (inicia em 0).</param>
		/// <param name="ordemColunas">Nome das colunas na ordem em que se deseja ordernar os resultados.</param>
		/// <param name="ordemSentidos">Sentidos das respectivas colunas de ordenção informadas no parâmetro ordemColunas (OrderBy.Ascendente ou OrderBy.Descendente).</param>		
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>		
		///  <returns>Retorna um List contendos FaleConoscoMensagem.</returns>
		public List<FaleConoscoMensagem> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro)
		{

			List<FaleConoscoMensagem> entidadesRetorno = new List<FaleConoscoMensagem>();

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
				sbOrder.Append(" ORDER BY faleConoscoMensagemId");
			}


			if (registrosPagina > 0)
			{

				//sbSQL.Append("SELECT TOP "+registrosPagina+" * FROM FaleConoscoMensagem");
				//if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM FaleConoscoMensagem WHERE " + filtro.GetWhereString() + " ORDER BY " + orderBy + ") ");					
				//} else {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM FaleConoscoMensagem ORDER BY " + orderBy + ")");				
				//}	
				sbSQL.Append("SELECT * FROM ( ");
				sbSQL.Append("SELECT FaleConoscoMensagem.*, ROW_NUMBER() OVER (" + sbOrder.ToString() + ") R FROM FaleConoscoMensagem ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				sbSQL.Append(") #Q WHERE R BETWEEN " + (((numeroPagina - 1) * registrosPagina) + 1).ToString() + " AND " + ((numeroPagina) * registrosPagina).ToString());

			}
			else
			{
				sbSQL.Append("SELECT FaleConoscoMensagem.* FROM FaleConoscoMensagem ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				if (sbOrder.Length > 0) { sbSQL.Append(sbOrder.ToString()); }
			}

			command = _db.GetSqlStringCommand(sbSQL.ToString());
			reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				FaleConoscoMensagem entidadeRetorno = new FaleConoscoMensagem();
				PopulaFaleConoscoMensagem(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}
			reader.Close();

			return entidadesRetorno;

		}

		/// <summary>
		/// Método que retorna todas os FaleConoscoMensagem existentes na base de dados.
		/// </summary>
		public List<FaleConoscoMensagem> CarregarTodos()
		{
			return CarregarTodos(0, 0, null, null, null);
		}

		/// <summary>
		/// Método que retorna o total de FaleConoscoMensagem na base de dados.
		/// </summary>
		/// <returns></returns>
		public int TotalRegistros()
		{
			return TotalRegistros(null);
		}

		/// <summary>
		/// Método que retorna o total de FaleConoscoMensagem na base de dados, aceita filtro.
		/// </summary>
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>
		/// <returns></returns>
		public int TotalRegistros(IFilterHelper filtro)
		{
			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT COUNT(*) AS Total FROM FaleConoscoMensagem");

			if (filtro != null && !filtro.GetWhereString().Equals(String.Empty))
				sbSQL.Append(" WHERE (" + filtro.GetWhereString() + ")");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Executa a query.

			int resultado = (int)_db.ExecuteScalar(command);


			return resultado;
		}

		/// <summary>
		/// Método que retorna popula um FaleConoscoMensagem baseado nos dados de um DataReader.
		/// </summary>
		/// <param name="reader">IDataReader contendo os dados da consulta.</param>
		/// <param name="entidade">FaleConoscoMensagem a ser populado(.</param>
		public static void PopulaFaleConoscoMensagem(IDataReader reader, FaleConoscoMensagem entidade)
		{
			if (reader["faleConoscoMensagemId"] != DBNull.Value)
				entidade.FaleConoscoMensagemId = Convert.ToInt32(reader["faleConoscoMensagemId"].ToString());

			if (reader["nome"] != DBNull.Value)
				entidade.Nome = reader["nome"].ToString();

			if (reader["email"] != DBNull.Value)
				entidade.Email = reader["email"].ToString();

			if (reader["telefoneDDD"] != DBNull.Value)
				entidade.TelefoneDDD = Convert.ToInt32(reader["telefoneDDD"].ToString());

			if (reader["telefoneComplemento"] != DBNull.Value)
				entidade.TelefoneComplemento = Convert.ToInt32(reader["telefoneComplemento"].ToString());

			if (reader["regiaoId"] != DBNull.Value)
			{
				entidade.Regiao = new Regiao();
				entidade.Regiao.RegiaoId = Convert.ToInt32(reader["regiaoId"]);
			}

			if (reader["estadoId"] != DBNull.Value)
			{
				entidade.Estado = new Estado();
				entidade.Estado.EstadoId = Convert.ToInt32(reader["estadoId"]);
			}

			if (reader["cidadeId"] != DBNull.Value)
			{
				entidade.Cidade = new Cidade();
				entidade.Cidade.CidadeId = Convert.ToInt32(reader["cidadeId"]);
			}

			if (reader["mensagem"] != DBNull.Value)
				entidade.Mensagem = reader["mensagem"].ToString();

			if (reader["faleConoscoAssuntoId"] != DBNull.Value)
			{
				entidade.FaleConoscoAssunto = new FaleConoscoAssunto();
				entidade.FaleConoscoAssunto.FaleConoscoAssuntoId = Convert.ToInt32(reader["faleConoscoAssuntoId"].ToString());
			}

			if (reader["atendido"] != DBNull.Value)
				entidade.Atendido = Convert.ToBoolean(reader["atendido"]);
		}
	}
}
