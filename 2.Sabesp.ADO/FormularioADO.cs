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
	public class FormularioADO : ADOSuper, IFormularioDAL
	{
		/// <summary>
		/// Método que persiste um Formulario.
		/// </summary>
		/// <param name="entidade">Formulario contendo os dados a serem persistidos.</param>	
		public void Inserir(Formulario entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de insert.
			sbSQL.Append(" INSERT INTO Formulario ");
			sbSQL.Append(" (formularioId, nomeFormulario, ativo) ");
			sbSQL.Append(" VALUES ");
			sbSQL.Append(" (@formularioId, @nomeFormulario, @ativo) ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@formularioId", DbType.Int32, entidade.FormularioId);

			_db.AddInParameter(command, "@nomeFormulario", DbType.String, entidade.NomeFormulario);

			if (entidade.Ativo != null)
				_db.AddInParameter(command, "@ativo", DbType.Int32, entidade.Ativo);
			else
				_db.AddInParameter(command, "@ativo", DbType.Int32, null);


			// Executa a query.
			_db.ExecuteNonQuery(command);
		}

		/// <summary>
		/// Método que atualiza os dados de um Formulario.
		/// </summary>
		/// <param name="entidade">Formulario contendo os dados a serem atualizados.</param>
		public void Atualizar(Formulario entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de atualização.
			sbSQL.Append(" UPDATE Formulario SET ");
			sbSQL.Append(" nomeFormulario=@nomeFormulario, ativo=@ativo ");
			sbSQL.Append(" WHERE formularioId=@formularioId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Parâmetros
			_db.AddInParameter(command, "@formularioId", DbType.Int32, entidade.FormularioId);
			_db.AddInParameter(command, "@nomeFormulario", DbType.String, entidade.NomeFormulario);
			if (entidade.Ativo != null)
				_db.AddInParameter(command, "@ativo", DbType.Int32, entidade.Ativo);
			else
				_db.AddInParameter(command, "@ativo", DbType.Int32, null);

			// Executa a query.
			_db.ExecuteNonQuery(command);
		}

		/// <summary>
		/// Método que remove um Formulario da base de dados.
		/// </summary>
		/// <param name="entidade">Formulario a ser excluído (somente o identificador é necessário).</param>		
		public void Excluir(Formulario entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			sbSQL.Append("DELETE FROM Formulario ");
			sbSQL.Append("WHERE formularioId=@formularioId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@formularioId", DbType.Int32, entidade.FormularioId);

			_db.ExecuteNonQuery(command);
		}

		/// <summary>
		/// Método que carrega um Formulario.
		/// </summary>
		/// <param name="entidade">Formulario a ser carregado (somente o identificador é necessário).</param>
		/// <returns>Formulario</returns>
		public Formulario Carregar(int formularioId)
		{
			Formulario entidade = new Formulario();
			entidade.FormularioId = formularioId;
			return Carregar(entidade);
		}

		/// <summary>
		/// Método que carrega um Formulario.
		/// </summary>
		/// <param name="entidade">Formulario a ser carregado (somente o identificador é necessário).</param>
		/// <returns>Formulario</returns>
		public Formulario Carregar(Formulario entidade)
		{
			Formulario entidadeRetorno = null;

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT * FROM Formulario WHERE formularioId=@formularioId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@formularioId", DbType.Int32, entidade.FormularioId);

			IDataReader reader = _db.ExecuteReader(command);

			if (reader.Read())
			{
				entidadeRetorno = new Formulario();
				PopulaFormulario(reader, entidadeRetorno);
			}

			reader.Close();

			return entidadeRetorno;
		}


		/// <summary>
		/// Método que retorna uma coleção de Formulario.
		/// </summary>
		/// <param name="entidade">FormularioApoioInstitucional relacionado(a) (somente o identificador é necessário).</param>		
		/// <returns>Retorna uma coleção de Formulario.</returns>
		public List<Formulario> Carregar(FormularioApoioInstitucional entidade)
		{
			List<Formulario> entidadesRetorno = new List<Formulario>();

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT Formulario.* FROM Formulario INNER JOIN FormularioApoioInstitucional ON Formulario.formularioId=FormularioApoioInstitucional.formularioId WHERE FormularioApoioInstitucional.formularioApoioInstitucionalId=@formularioApoioInstitucionalId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
			_db.AddInParameter(command, "@formularioApoioInstitucionalId", DbType.Int32, entidade.FormularioApoioInstitucionalId);

			IDataReader reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				Formulario entidadeRetorno = new Formulario();
				PopulaFormulario(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}

			reader.Close();

			return entidadesRetorno;
		}

		/// <summary>
		/// Método que retorna uma coleção de Formulario.
		/// </summary>
		/// <param name="entidade">FormularioCicloConferencia relacionado(a) (somente o identificador é necessário).</param>		
		/// <returns>Retorna uma coleção de Formulario.</returns>
		public List<Formulario> Carregar(FormularioCicloConferencia entidade)
		{
			List<Formulario> entidadesRetorno = new List<Formulario>();

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT Formulario.* FROM Formulario INNER JOIN FormularioCicloConferencia ON Formulario.formularioId=FormularioCicloConferencia.formularioId WHERE FormularioCicloConferencia.formularioCicloConferenciaId=@formularioCicloConferenciaId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
			_db.AddInParameter(command, "@formularioCicloConferenciaId", DbType.Int32, entidade.FormularioCicloConferenciaId);

			IDataReader reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				Formulario entidadeRetorno = new Formulario();
				PopulaFormulario(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}

			reader.Close();

			return entidadesRetorno;
		}

		/// <summary>
		/// Método que retorna uma coleção de Formulario.
		/// </summary>
		/// <param name="entidade">Contato relacionado(a) (somente o identificador é necessário).</param>		
		/// <returns>Retorna uma coleção de Formulario.</returns>
		public List<Formulario> Carregar(Contato entidade)
		{
			List<Formulario> entidadesRetorno = new List<Formulario>();

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT Formulario.* FROM Formulario INNER JOIN FormularioContato ON Formulario.formularioId=FormularioContato.formularioId WHERE FormularioContato.contatoId=@contatoId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
			_db.AddInParameter(command, "@contatoId", DbType.Int32, entidade.ContatoId);

			IDataReader reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				Formulario entidadeRetorno = new Formulario();
				PopulaFormulario(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}

			reader.Close();

			return entidadesRetorno;
		}

		/// <summary>
		/// Método que retorna uma coleção de Formulario.
		/// </summary>
		/// <param name="entidade">FormularioCursoVazamento relacionado(a) (somente o identificador é necessário).</param>		
		/// <returns>Retorna uma coleção de Formulario.</returns>
		public List<Formulario> Carregar(FormularioCursoVazamento entidade)
		{
			List<Formulario> entidadesRetorno = new List<Formulario>();

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT Formulario.* FROM Formulario INNER JOIN FormularioCursoVazamento ON Formulario.formularioId=FormularioCursoVazamento.formularioId WHERE FormularioCursoVazamento.formularioCursoVazamentoId=@formularioCursoVazamentoId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
			_db.AddInParameter(command, "@formularioCursoVazamentoId", DbType.Int32, entidade.FormularioCursoVazamentoId);

			IDataReader reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				Formulario entidadeRetorno = new Formulario();
				PopulaFormulario(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}

			reader.Close();

			return entidadesRetorno;
		}

		/// <summary>
		/// Método que retorna uma coleção de Formulario.
		/// </summary>
		/// <param name="entidade">FormularioImprensa relacionado(a) (somente o identificador é necessário).</param>		
		/// <returns>Retorna uma coleção de Formulario.</returns>
		public List<Formulario> Carregar(FormularioImprensa entidade)
		{
			List<Formulario> entidadesRetorno = new List<Formulario>();

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT Formulario.* FROM Formulario INNER JOIN FormularioImprensa ON Formulario.formularioId=FormularioImprensa.formularioId WHERE FormularioImprensa.formularioImprensaId=@formularioImprensaId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
			_db.AddInParameter(command, "@formularioImprensaId", DbType.Int32, entidade.FormularioImprensaId);

			IDataReader reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				Formulario entidadeRetorno = new Formulario();
				PopulaFormulario(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}

			reader.Close();

			return entidadesRetorno;
		}

		/// <summary>
		/// Método que retorna uma coleção de Formulario.
		/// </summary>
		/// <param name="entidade">FormularioInvestidor relacionado(a) (somente o identificador é necessário).</param>		
		/// <returns>Retorna uma coleção de Formulario.</returns>
		public List<Formulario> Carregar(FormularioInvestidor entidade)
		{
			List<Formulario> entidadesRetorno = new List<Formulario>();

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT Formulario.* FROM Formulario INNER JOIN FormularioInvestidor ON Formulario.formularioId=FormularioInvestidor.formularioId WHERE FormularioInvestidor.formularioInvestidorId=@formularioInvestidorId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
			_db.AddInParameter(command, "@formularioInvestidorId", DbType.Int32, entidade.FormularioInvestidorId);

			IDataReader reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				Formulario entidadeRetorno = new Formulario();
				PopulaFormulario(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}

			reader.Close();

			return entidadesRetorno;
		}

		/// <summary>
		/// Método que retorna uma coleção de Formulario.
		/// </summary>
		/// <param name="entidade">FormularioSegurancaTrabalho relacionado(a) (somente o identificador é necessário).</param>		
		/// <returns>Retorna uma coleção de Formulario.</returns>
		public List<Formulario> Carregar(FormularioSegurancaTrabalho entidade)
		{
			List<Formulario> entidadesRetorno = new List<Formulario>();

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT Formulario.* FROM Formulario INNER JOIN FormularioSegurancaTrabalho ON Formulario.formularioId=FormularioSegurancaTrabalho.formularioId WHERE FormularioSegurancaTrabalho.formularioSegurancaTrabalhoId=@formularioSegurancaTrabalhoId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
			_db.AddInParameter(command, "@formularioSegurancaTrabalhoId", DbType.Int32, entidade.FormularioSegurancaTrabalhoId);

			IDataReader reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				Formulario entidadeRetorno = new Formulario();
				PopulaFormulario(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}

			reader.Close();

			return entidadesRetorno;
		}

		/// <summary>
		/// Método que retorna uma coleção de Formulario.
		/// </summary>
		/// <param name="entidade">FormularioVideoteca relacionado(a) (somente o identificador é necessário).</param>		
		/// <returns>Retorna uma coleção de Formulario.</returns>
		public List<Formulario> Carregar(FormularioVideoteca entidade)
		{
			List<Formulario> entidadesRetorno = new List<Formulario>();

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT Formulario.* FROM Formulario INNER JOIN FormularioVideoteca ON Formulario.formularioId=FormularioVideoteca.formularioId WHERE FormularioVideoteca.formularioVideotecaId=@formularioVideotecaId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
			_db.AddInParameter(command, "@formularioVideotecaId", DbType.Int32, entidade.FormularioVideotecaId);

			IDataReader reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				Formulario entidadeRetorno = new Formulario();
				PopulaFormulario(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}

			reader.Close();

			return entidadesRetorno;
		}

		/// <summary>
		/// Método que retorna uma coleção de Formulario.
		/// </summary>
		/// <param name="entidade">FormularioVideoteca1 relacionado(a) (somente o identificador é necessário).</param>		
		/// <returns>Retorna uma coleção de Formulario.</returns>
		public List<Formulario> Carregar(FormularioVideoteca1 entidade)
		{
			List<Formulario> entidadesRetorno = new List<Formulario>();

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT Formulario.* FROM Formulario INNER JOIN FormularioVideoteca1 ON Formulario.formularioId=FormularioVideoteca1.formularioId WHERE FormularioVideoteca1.formularioVideoteca1Id=@formularioVideoteca1Id");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
			_db.AddInParameter(command, "@formularioVideoteca1Id", DbType.Int32, entidade.FormularioVideoteca1Id);

			IDataReader reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				Formulario entidadeRetorno = new Formulario();
				PopulaFormulario(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}

			reader.Close();

			return entidadesRetorno;
		}


		/// <summary>
		/// Método que retorna uma coleção de Formulario.
		/// </summary>
		/// <param name="registrosPagina">Número máximo de registros na página.</param>
		/// <param name="numeroPagina">Número da página atual (inicia em 0).</param>
		/// <param name="ordemColunas">Nome das colunas na ordem em que se deseja ordernar os resultados.</param>
		/// <param name="ordemSentidos">Sentidos das respectivas colunas de ordenção informadas no parâmetro ordemColunas (OrderBy.Ascendente ou OrderBy.Descendente).</param>		
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>		
		///  <returns>Retorna um List contendos Formulario.</returns>
		public List<Formulario> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro)
		{
			List<Formulario> entidadesRetorno = new List<Formulario>();

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
				sbOrder.Append(" ORDER BY formularioId");
			}


			if (registrosPagina > 0)
			{

				//sbSQL.Append("SELECT TOP "+registrosPagina+" * FROM Formulario");
				//if ( filtro!=null && !filtro.GetWhereString().Equals(String.Empty) ) {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM Formulario WHERE " + filtro.GetWhereString() + " ORDER BY " + orderBy + ") ");					
				//} else {
				//	sbWhere.Append(" NOT IN (SELECT TOP "+((numeroPagina-1)*registrosPagina)+"  FROM Formulario ORDER BY " + orderBy + ")");				
				//}	
				sbSQL.Append("SELECT * FROM ( ");
				sbSQL.Append("SELECT Formulario.*, ROW_NUMBER() OVER (" + sbOrder.ToString() + ") R FROM Formulario ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				sbSQL.Append(") #Q WHERE R BETWEEN " + (((numeroPagina - 1) * registrosPagina) + 1).ToString() + " AND " + ((numeroPagina) * registrosPagina).ToString());

			}
			else
			{
				sbSQL.Append("SELECT Formulario.* FROM Formulario ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				if (sbOrder.Length > 0) { sbSQL.Append(sbOrder.ToString()); }
			}

			command = _db.GetSqlStringCommand(sbSQL.ToString());
			reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				Formulario entidadeRetorno = new Formulario();
				PopulaFormulario(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}
			reader.Close();

			return entidadesRetorno;

		}

		/// <summary>
		/// Método que retorna todas os Formulario existentes na base de dados.
		/// </summary>
		public List<Formulario> CarregarTodos()
		{
			return CarregarTodos(0, 0, null, null, null);
		}

		/// <summary>
		/// Método que retorna o total de Formulario na base de dados.
		/// </summary>
		/// <returns></returns>
		public int TotalRegistros()
		{
			return TotalRegistros(null);
		}

		/// <summary>
		/// Método que retorna o total de Formulario na base de dados, aceita filtro.
		/// </summary>
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>
		/// <returns></returns>
		public int TotalRegistros(IFilterHelper filtro)
		{
			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT COUNT(*) AS Total FROM Formulario");

			if (filtro != null && !filtro.GetWhereString().Equals(String.Empty))
				sbSQL.Append(" WHERE (" + filtro.GetWhereString() + ")");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Executa a query.

			int resultado = (int)_db.ExecuteScalar(command);


			return resultado;
		}

		/// <summary>
		/// Método que retorna popula um Formulario baseado nos dados de um DataReader.
		/// </summary>
		/// <param name="reader">IDataReader contendo os dados da consulta.</param>
		/// <param name="entidade">Formulario a ser populado(.</param>
		public static void PopulaFormulario(IDataReader reader, Formulario entidade)
		{
			if (reader["formularioId"] != DBNull.Value)
				entidade.FormularioId = Convert.ToInt32(reader["formularioId"].ToString());

			if (reader["nomeFormulario"] != DBNull.Value)
				entidade.NomeFormulario = reader["nomeFormulario"].ToString();

			if (reader["ativo"] != DBNull.Value)
				entidade.Ativo = Convert.ToBoolean(reader["ativo"].ToString());

		}

		/// <summary>
		/// Método que retorna o total de Contato X Formulario na base de dados
		/// </summary>        
		/// <returns></returns>
		public int TotalRegistrosRelacionado(int contatoId, int formularioId)
		{
			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append(@"SELECT 
								COUNT(*) AS Total 
							FROM 
								FormularioContato
                            WHERE 
								contatoId = @contatoId 
								AND formularioId = @formularioId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
			_db.AddInParameter(command, "@contatoId", DbType.Int32, contatoId);
			_db.AddInParameter(command, "@formularioId", DbType.Int32, formularioId);

			// Executa a query
			int resultado = (int)_db.ExecuteScalar(command);

			return resultado;
		}

		/// <summary>
		/// Método que persiste Municipio X Regiao.
		/// </summary>
		/// <param name="entidade">Regiao contendo os dados a serem persistidos.</param>	
		public void InserirRelacionado(int contatoId, int formularioId)
		{
			StringBuilder sbSQL = new StringBuilder();

			DbCommand command;

			// Monta a string de insert.
			sbSQL.Append(" INSERT INTO FormularioContato ");
			sbSQL.Append(" (contatoId, formularioId) ");
			sbSQL.Append(" VALUES ");
			sbSQL.Append(" (@contatoId, @formularioId) ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@contatoId", DbType.Int32, contatoId);

			_db.AddInParameter(command, "@formularioId", DbType.Int32, formularioId);

			// Executa a query.
			_db.ExecuteNonQuery(command);
		}

		/// <summary>
		/// Método que remove todos os Formulario X Contato da base de dados.
		/// </summary>
		/// <param name="entidade">Relacionamento a ser excluído (somente o identificador de Contato é necessário).</param>		
		public void ExcluirRelacionado(int entidade)
		{
			Contato contatoBO = new Contato();
			contatoBO.ContatoId = entidade;

			this.ExcluirRelacionados(contatoBO);
		}

		/// <summary>
		/// Método que remove um FormularioContato da base de dados.
		/// </summary>
		/// <param name="entidade">Relacionamento a ser excluído (somente o identificador de Contato é necessário).</param>		
		public void ExcluirRelacionados(Contato entidade)
		{
			StringBuilder sbSQL = new StringBuilder();

			DbCommand command;

			sbSQL.Append(@"DELETE FROM 
								FormularioContato 
							WHERE 
								contatoId=@contatoId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@contatoId", DbType.Int32, entidade.ContatoId);

			_db.ExecuteNonQuery(command);
		}
	}
}