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
	public class EventoADO : ADOSuper, IEventoDAL
	{
		/// <summary>
		/// Método que persiste um Evento.
		/// </summary>
		/// <param name="entidade">Evento contendo os dados a serem persistidos.</param>	
		public void Inserir(Evento entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de insert.
			sbSQL.Append(" INSERT INTO Evento ");
			sbSQL.Append(" (eventoId, ativo, dataHoraPublicacao, dataHoraEventoInicio, dataHoraEventoFim, arquivoIdThumbGrande, arquivoIdThumbMedio, destaqueEventos, local, destaqueFiquePorDentro) ");
			sbSQL.Append(" VALUES ");
			sbSQL.Append(" (@eventoId, @ativo, @dataHoraPublicacao, @dataHoraEventoInicio, @dataHoraEventoFim, @arquivoIdThumbGrande, @arquivoIdThumbMedio, @destaqueEventos, @local, @destaqueFiquePorDentro) ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@eventoId", DbType.Int32, entidade.Conteudo.ConteudoId);

			_db.AddInParameter(command, "@ativo", DbType.Int32, entidade.Ativo);

			if (entidade.DataHoraPublicacao != null && entidade.DataHoraPublicacao != DateTime.MinValue)
				_db.AddInParameter(command, "@dataHoraPublicacao", DbType.DateTime, entidade.DataHoraPublicacao);
			else
				_db.AddInParameter(command, "@dataHoraPublicacao", DbType.DateTime, null);

			if (entidade.DataHoraEventoInicio != null && entidade.DataHoraEventoInicio != DateTime.MinValue)
				_db.AddInParameter(command, "@dataHoraEventoInicio", DbType.DateTime, entidade.DataHoraEventoInicio);
			else
				_db.AddInParameter(command, "@dataHoraEventoInicio", DbType.DateTime, null);

			if (entidade.DataHoraEventoFim != null && entidade.DataHoraEventoFim != DateTime.MinValue)
				_db.AddInParameter(command, "@dataHoraEventoFim", DbType.DateTime, entidade.DataHoraEventoFim);
			else
				_db.AddInParameter(command, "@dataHoraEventoFim", DbType.DateTime, null);

			if (entidade.ArquivoThumbGrande != null && entidade.ArquivoThumbGrande.ArquivoId > 0)
				_db.AddInParameter(command, "@arquivoIdThumbGrande", DbType.Int32, entidade.ArquivoThumbGrande.ArquivoId);
			else
				_db.AddInParameter(command, "@arquivoIdThumbGrande", DbType.Int32, null);

			if (entidade.ArquivoThumbMedio != null && entidade.ArquivoThumbMedio.ArquivoId > 0)
				_db.AddInParameter(command, "@arquivoIdThumbMedio", DbType.Int32, entidade.ArquivoThumbMedio.ArquivoId);
			else
				_db.AddInParameter(command, "@arquivoIdThumbMedio", DbType.Int32, null);

			_db.AddInParameter(command, "@destaqueEventos", DbType.Int32, entidade.DestaqueEventos);

			if (entidade.Local != null)
				_db.AddInParameter(command, "@local", DbType.String, entidade.Local);
			else
				_db.AddInParameter(command, "@local", DbType.String, null);

			_db.AddInParameter(command, "@destaqueFiquePorDentro", DbType.Int32, entidade.DestaqueFiquePorDentro);

			// Executa a query.
			_db.ExecuteNonQuery(command);
		}

		/// <summary>
		/// Método que persiste um Evento X Categoria.
		/// </summary>
		/// <param name="entidade">Evento contendo os dados a serem persistidos.</param>	
		public void InserirRelacionado(EventoCategoria entidade, int eventoId, int IdiomaId)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de insert.
			sbSQL.Append(" INSERT INTO EventoCategoriaRelacionada ");
			sbSQL.Append(" (eventoId, eventoCategoriaId, idiomaId) ");
			sbSQL.Append(" VALUES ");
			sbSQL.Append(" (@eventoId, @eventoCategoriaId, @idiomaId) ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@eventoId", DbType.Int32, eventoId);
			_db.AddInParameter(command, "@eventoCategoriaId", DbType.Int32, entidade.EventoCategoriaId);
			_db.AddInParameter(command, "@idiomaId", DbType.Int32, IdiomaId);

			// Executa a query.
			_db.ExecuteNonQuery(command);
		}

		/// <summary>
		/// Método que atualiza os dados de um Evento.
		/// </summary>
		/// <param name="entidade">Evento contendo os dados a serem atualizados.</param>
		public void Atualizar(Evento entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			// Monta a string de atualização.
			sbSQL.Append(" UPDATE Evento SET ");
			sbSQL.Append(" ativo=@ativo, dataHoraPublicacao=@dataHoraPublicacao, dataHoraEventoInicio=@dataHoraEventoInicio, dataHoraEventoFim=@dataHoraEventoFim, arquivoIdThumbGrande=@arquivoIdThumbGrande, arquivoIdThumbMedio=@arquivoIdThumbMedio, destaqueEventos=@destaqueEventos, local=@local, destaqueFiquePorDentro=@destaqueFiquePorDentro ");
			sbSQL.Append(" WHERE eventoId=@eventoId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Parâmetros
			_db.AddInParameter(command, "@eventoId", DbType.Int32, entidade.Conteudo.ConteudoId);
			_db.AddInParameter(command, "@ativo", DbType.Int32, entidade.Ativo);
			if (entidade.DataHoraPublicacao != null && entidade.DataHoraPublicacao != DateTime.MinValue)
				_db.AddInParameter(command, "@dataHoraPublicacao", DbType.DateTime, entidade.DataHoraPublicacao);
			else
				_db.AddInParameter(command, "@dataHoraPublicacao", DbType.DateTime, null);
			if (entidade.DataHoraEventoInicio != null && entidade.DataHoraEventoInicio != DateTime.MinValue)
				_db.AddInParameter(command, "@dataHoraEventoInicio", DbType.DateTime, entidade.DataHoraEventoInicio);
			else
				_db.AddInParameter(command, "@dataHoraEventoInicio", DbType.DateTime, null);
			if (entidade.DataHoraEventoFim != null && entidade.DataHoraEventoFim != DateTime.MinValue)
				_db.AddInParameter(command, "@dataHoraEventoFim", DbType.DateTime, entidade.DataHoraEventoFim);
			else
				_db.AddInParameter(command, "@dataHoraEventoFim", DbType.DateTime, null);
			if (entidade.ArquivoThumbGrande != null && entidade.ArquivoThumbGrande.ArquivoId > 0)
				_db.AddInParameter(command, "@arquivoIdThumbGrande", DbType.Int32, entidade.ArquivoThumbGrande.ArquivoId);
			else
				_db.AddInParameter(command, "@arquivoIdThumbGrande", DbType.Int32, null);
			if (entidade.ArquivoThumbMedio != null && entidade.ArquivoThumbMedio.ArquivoId > 0)
				_db.AddInParameter(command, "@arquivoIdThumbMedio", DbType.Int32, entidade.ArquivoThumbMedio.ArquivoId);
			else
				_db.AddInParameter(command, "@arquivoIdThumbMedio", DbType.Int32, null);
			_db.AddInParameter(command, "@destaqueEventos", DbType.Int32, entidade.DestaqueEventos);
			if (entidade.Local != null)
				_db.AddInParameter(command, "@local", DbType.String, entidade.Local);
			else
				_db.AddInParameter(command, "@local", DbType.String, null);
			_db.AddInParameter(command, "@destaqueFiquePorDentro", DbType.Int32, entidade.DestaqueFiquePorDentro);

			// Executa a query.
			_db.ExecuteNonQuery(command);
		}

		/// <summary>
		/// Método que remove um Evento da base de dados.
		/// </summary>
		/// <param name="entidade">Evento a ser excluído (somente o identificador é necessário).</param>		
		public void Excluir(Evento entidade)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			sbSQL.Append("DELETE FROM Evento ");
			sbSQL.Append("WHERE eventoId=@eventoId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@eventoId", DbType.Int32, entidade.Conteudo.ConteudoId);

			_db.ExecuteNonQuery(command);
		}

		/// <summary>
		/// Método que remove um Evento X Categoria da base de dados.
		/// </summary>
		/// <param name="entidade">Evento a ser excluído (somente o identificador é necessário).</param>		
		public void ExcluirRelacionado(int eventoId, int idiomaId)
		{
			StringBuilder sbSQL = new StringBuilder();
			DbCommand command;

			sbSQL.Append("DELETE FROM EventoCategoriaRelacionada ");
			sbSQL.Append("WHERE eventoId=@eventoId and idiomaId=@idiomaId ");

			command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@eventoId", DbType.Int32, eventoId);
			_db.AddInParameter(command, "@idiomaId", DbType.Int32, idiomaId);

			_db.ExecuteNonQuery(command);
		}
		/// <summary>
		/// Método que carrega as eventos mais vistas para exibição do site
		/// </summary>
		/// <param name="qtdEventos"></param>
		/// <returns></returns>
		public List<Evento> CarregarMaisVistos(int qtdEventos)
		{
			List<Evento> entidadesRetorno = new List<Evento>(); ;

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT TOP " + qtdEventos.ToString() + " * FROM dbo.viewEventosMaisVistos ORDER BY dbo.viewEventosMaisVistos.hits DESC");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			IDataReader reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				Evento entidadeRetorno = new Evento();
				PopulaEvento(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}

			reader.Close();

			return entidadesRetorno;
		}

		/// <summary>
		/// Método que carrega as eventos relacionadas com tag exibição do site
		/// </summary>
		/// <param name="qtdEventos"></param>
		/// <returns></returns>
		public List<Evento> CarregarTagged(int tagId)
		{
			List<Evento> entidadesRetorno = new List<Evento>(); ;

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT * FROM dbo.viewEventosTagged WHERE dbo.viewEventosTagged.tagId = @tagId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
			_db.AddInParameter(command, "@tagId", DbType.Int32, tagId);

			IDataReader reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				Evento entidadeRetorno = new Evento();
				PopulaEvento(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}

			reader.Close();

			return entidadesRetorno;
		}

		/// <summary>
		/// Método que carrega as eventos relacionadas com tag exibição do site
		/// </summary>
		/// <param name="qtdEventos"></param>
		/// <returns></returns>
		public List<Evento> CarregarProxEventos(int qtdRegistros)
		{
			List<Evento> entidadesRetorno = new List<Evento>(); ;

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT TOP " + qtdRegistros.ToString() + " * FROM dbo.viewProxEventos ORDER BY dbo.viewProxEventos.dataHoraEventoInicio ASC");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			IDataReader reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				Evento entidadeRetorno = new Evento();
				PopulaEvento(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}

			reader.Close();

			return entidadesRetorno;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="eventoId">Identificador do envento a ser carregado</param>
		/// <returns></returns>
		public Evento CarregarToSite(int eventoId)
		{
			Evento entidadeRetorno = null;

			StringBuilder sbSQL = new StringBuilder();
			//Acessa a view que contem os conteudos publicados
			sbSQL.Append("SELECT * FROM [viewEventosSite] WHERE eventoId=@eventoId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@eventoId", DbType.Int32, eventoId);

			IDataReader reader = _db.ExecuteReader(command);

			if (reader.Read())
			{
				entidadeRetorno = new Evento();
				PopulaEvento(reader, entidadeRetorno);
			}

			reader.Close();

			return entidadeRetorno;
		}

		/// <summary>
		/// Retorna todos os eventos para o site que estao aprovados para publicacao
		/// </summary>
		/// <param name="quantidadeRegistros"></param>
		/// <param name="ordemColunas"></param>
		/// <param name="ordemSentidos"></param>
		/// <param name="filtro"></param>
		/// <returns></returns>
		public List<Evento> CarregarTodosSite(int quantidadeRegistros, string[] ordemColunas, string[] ordemSentidos, IFilterHelper filtro)
		{
			//variavel utilizada para retorna a lista de eventos
			List<Evento> entidadesRetorno = new List<Evento>();

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
					if (sbOrder.Length > 0)
					{
						sbOrder.Append(", ");
					}
					sbOrder.Append(ordemColunas[i] + " " + ordemSentidos[i]);
				}
				if (sbOrder.Length > 0)
				{
					sbOrder.Insert(0, " ORDER BY ");
				}
			}
			else
			{
				sbOrder.Append(" ORDER BY eventoId");
			}

			sbSQL.Append("SELECT ");

			if (quantidadeRegistros > 0)
			{
				sbSQL.Append(String.Concat("TOP ", quantidadeRegistros, " "));
			}
			// Acessa a view de eventos
			sbSQL.Append("* FROM viewEventosSite ");

			if (filtro != null && !filtro.GetWhereString().Equals(String.Empty))
			{
				sbSQL.Append("WHERE" + filtro.GetWhereString() + " ");
			}

			if (sbOrder.Length > 0)
			{
				sbSQL.Append(sbOrder.ToString());
			}

			command = _db.GetSqlStringCommand(sbSQL.ToString());
			reader = _db.ExecuteReader(command);

			// Adiciona na lista
			while (reader.Read())
			{
				Evento entidadeRetorno = new Evento();
				PopulaEvento(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}

			reader.Close();

			return entidadesRetorno;
		}

		/// <summary>
		/// Método que carrega um Evento.
		/// </summary>
		/// <param name="entidade">Evento a ser carregado (somente o identificador é necessário).</param>
		/// <returns>Evento</returns>
		public Evento Carregar(Evento entidade)
		{
			Evento entidadeRetorno = null;

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT * FROM Evento WHERE eventoId=@eventoId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@eventoId", DbType.Int32, entidade.Conteudo.ConteudoId);

			IDataReader reader = _db.ExecuteReader(command);

			if (reader.Read())
			{
				entidadeRetorno = new Evento();
				PopulaEvento(reader, entidadeRetorno);
			}

			reader.Close();

			return entidadeRetorno;
		}

		/// <summary>
		/// Método que retorna uma coleção de Evento.
		/// </summary>
		/// <param name="entidade">EventoCategoria relacionado(a) (somente o identificador é necessário).</param>		
		/// <returns>Retorna uma coleção de Evento.</returns>
		public List<Evento> Carregar(EventoCategoria entidade)
		{
			List<Evento> entidadesRetorno = new List<Evento>();

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT Evento.* FROM Evento INNER JOIN EventoCategoriaRelacionada ON Evento.eventoId=EventoCategoriaRelacionada.eventoId WHERE EventoCategoriaRelacionada.eventoCategoriaId=@eventoCategoriaId");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());
			_db.AddInParameter(command, "@eventoCategoriaId", DbType.Int32, entidade.EventoCategoriaId);

			IDataReader reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				Evento entidadeRetorno = new Evento();
				PopulaEvento(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}
			reader.Close();

			return entidadesRetorno;
		}

		/// <summary>
		/// Método que retorna uma coleção de Evento.
		/// </summary>
		/// <param name="registrosPagina">Número máximo de registros na página.</param>
		/// <param name="numeroPagina">Número da página atual (inicia em 0).</param>
		/// <param name="ordemColunas">Nome das colunas na ordem em que se deseja ordernar os resultados.</param>
		/// <param name="ordemSentidos">Sentidos das respectivas colunas de ordenção informadas no parâmetro ordemColunas (OrderBy.Ascendente ou OrderBy.Descendente).</param>		
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>		
		///  <returns>Retorna um List contendos Evento.</returns>
		public List<Evento> CarregarTodos(int registrosPagina, int numeroPagina, string ordemColunas, string ordemSentidos, IFilterHelper filtro)
		{
			List<Evento> entidadesRetorno = new List<Evento>();

			StringBuilder sbSQL = new StringBuilder();
			StringBuilder sbWhere = new StringBuilder();
			StringBuilder sbOrder = new StringBuilder();
			DbCommand command;
			IDataReader reader;

			// Monta o "OrderBy"
			if (!String.IsNullOrEmpty(ordemColunas))
			{
				string[] arrayordemColunas = ordemColunas.Split(",".ToCharArray());
				string[] arrayOrdemSentidos = ordemSentidos.Split(",".ToCharArray());

				for (int i = 0; i < arrayordemColunas.Length; i++)
				{
					if (sbOrder.Length > 0) { sbOrder.Append(", "); }
					sbOrder.Append(arrayordemColunas[i] + " " + arrayOrdemSentidos[i]);
				}
				if (sbOrder.Length > 0) { sbOrder.Insert(0, " ORDER BY "); }
			}
			else
			{
				sbOrder.Append(" ORDER BY eventoId ");
			}

			if (registrosPagina > 0)
			{

				sbSQL.Append("SELECT * FROM ( ");
				sbSQL.Append("SELECT Evento.*, ROW_NUMBER() OVER (" + sbOrder.ToString() + ") R FROM Evento ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty))
				{
					sbSQL.Append("WHERE" + filtro.GetWhereString() + " ");
				}
			}
			else
			{
				sbSQL.Append("SELECT Evento.* FROM Evento ");
				if (filtro != null && !filtro.GetWhereString().Equals(String.Empty)) { sbSQL.Append("WHERE" + filtro.GetWhereString() + " "); }
				if (sbOrder.Length > 0) { sbSQL.Append(sbOrder.ToString()); }
			}

			command = _db.GetSqlStringCommand(sbSQL.ToString());
			reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				Evento entidadeRetorno = new Evento();
				PopulaEvento(reader, entidadeRetorno);
				entidadesRetorno.Add(entidadeRetorno);
			}

			reader.Close();

			return entidadesRetorno;
		}

		/// <summary>
		/// Método que retorna todas os Evento existentes na base de dados.
		/// </summary>
		public List<Evento> CarregarTodos()
		{
			return CarregarTodos(0, 0, null, null, null);
		}

		/// <summary>
		/// Método que retorna o total de Evento na base de dados.
		/// </summary>
		/// <returns></returns>
		public int TotalRegistros()
		{
			return TotalRegistros(null);
		}

		/// <summary>
		/// Método que retorna o total de Evento na base de dados, aceita filtro.
		/// </summary>
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>
		/// <returns></returns>
		public int TotalRegistros(IFilterHelper filtro)
		{
			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT COUNT(*) AS Total FROM Evento");

			if (filtro != null && !filtro.GetWhereString().Equals(String.Empty))
				sbSQL.Append(" WHERE (" + filtro.GetWhereString() + ")");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Executa a query.
			int resultado = (int)_db.ExecuteScalar(command);

			return resultado;
		}

		/// <summary>
		/// Método que retorna o total de Evento na base de dados, aceita filtro.
		/// </summary>
		/// <param name="filtro">Objeto do tipo IFilter que contém os dados de filtragem.</param>
		/// <returns></returns>
		public int TotalRegistrosRelacionado(int eventoID, int eventoCategoriaId)
		{
			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append(@"SELECT 
								COUNT(*) AS Total 
						FROM 
								EventoCategoriaRelacionada 
						WHERE 
								eventoCategoriaId = " + eventoCategoriaId + " and eventoId = " + eventoID);
			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			// Executa a query.
			int resultado = (int)_db.ExecuteScalar(command);

			return resultado;
		}

		/// <summary>
		/// Método que retorna popula um Evento baseado nos dados de um DataReader.
		/// </summary>
		/// <param name="reader">IDataReader contendo os dados da consulta.</param>
		/// <param name="entidade">Evento a ser populado(.</param>
		public static void PopulaEvento(IDataReader reader, Evento entidade)
		{
			if (reader["ativo"] != DBNull.Value)
				entidade.Ativo = Convert.ToBoolean(reader["ativo"].ToString());

			if (reader["dataHoraPublicacao"] != DBNull.Value)
				entidade.DataHoraPublicacao = Convert.ToDateTime(reader["dataHoraPublicacao"].ToString());

			if (reader["dataHoraEventoInicio"] != DBNull.Value)
				entidade.DataHoraEventoInicio = Convert.ToDateTime(reader["dataHoraEventoInicio"].ToString());

			if (reader["dataHoraEventoFim"] != DBNull.Value)
				entidade.DataHoraEventoFim = Convert.ToDateTime(reader["dataHoraEventoFim"].ToString());

			if (reader["destaqueEventos"] != DBNull.Value)
				entidade.DestaqueEventos = Convert.ToBoolean(reader["destaqueEventos"].ToString());

			if (reader["local"] != DBNull.Value)
				entidade.Local = reader["local"].ToString();

			if (reader["destaqueFiquePorDentro"] != DBNull.Value)
				entidade.DestaqueFiquePorDentro = Convert.ToBoolean(reader["destaqueFiquePorDentro"].ToString());

			if (reader["eventoId"] != DBNull.Value)
			{
				entidade.Conteudo = new Conteudo();
				entidade.Conteudo.ConteudoId = Convert.ToInt32(reader["eventoId"].ToString());
			}

			if (reader["arquivoIdThumbGrande"] != DBNull.Value)
			{
				entidade.ArquivoThumbGrande = new Arquivo();
				entidade.ArquivoThumbGrande.ArquivoId = Convert.ToInt32(reader["arquivoIdThumbGrande"].ToString());
			}

			if (reader["arquivoIdThumbMedio"] != DBNull.Value)
			{
				entidade.ArquivoThumbMedio = new Arquivo();
				entidade.ArquivoThumbMedio.ArquivoId = Convert.ToInt32(reader["arquivoIdThumbMedio"].ToString());
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="qtdEventos"></param>
		/// <param name="regiaoId"></param>
		/// <returns></returns>
		public List<Evento> CarregarPorRegiao(int qtdEventos, int regiaoId)
		{
			List<Evento> entidadeRetorno = new List<Evento>();
			Evento entidade = null;

			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT ");

			if (qtdEventos > 0)
			{
				sbSQL.Append(String.Concat("TOP ", qtdEventos, " "));
			}

			sbSQL.Append("viewEventosSite.* FROM viewEventosSite ");
			sbSQL.Append("INNER JOIN ConteudoRegiao ON viewEventosSite.eventoId = dbo.ConteudoRegiao.conteudoId ");
			sbSQL.Append("WHERE (ConteudoRegiao.regiaoId = @regiaoId)");
			sbSQL.Append("ORDER BY dataHoraPublicacao DESC");

			DbCommand command = _db.GetSqlStringCommand(sbSQL.ToString());

			_db.AddInParameter(command, "@regiaoId", DbType.Int32, regiaoId);

			IDataReader reader = _db.ExecuteReader(command);

			while (reader.Read())
			{
				entidade = new Evento();
				PopulaEvento(reader, entidade);
				entidadeRetorno.Add(entidade);
			}
			reader.Close();

			return entidadeRetorno;
		}
	}
}