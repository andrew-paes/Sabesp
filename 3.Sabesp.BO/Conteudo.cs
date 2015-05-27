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
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using System;
using System.Text;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Sabesp.BO
{

	[Serializable]
	public class Conteudo
	{
		// Construtor
		public Conteudo() { }

		// Construtor com identificador
		public Conteudo(int conteudoId)
		{
			_conteudoId = conteudoId;
		}

		private int _conteudoId;
		private DateTime _dataHoraCadastro;
		private Comunicado _comunicado;
		private List<Tag> _tages;
		private List<Regiao> _conteudoRegiao;
		private Evento _evento;
		private Noticia _noticia;
		private Release _release;
		private Podcast _podcast;
		private Video _video;
		private ConteudoTipo _conteudoTipo;
		private Workflow _workflow;

		public int ConteudoId
		{
			get { return _conteudoId; }
			set { _conteudoId = value; }
		}

		public DateTime DataHoraCadastro
		{
			get { return _dataHoraCadastro; }
			set { _dataHoraCadastro = value; }
		}

		[NotNullValidator]
		public Comunicado Comunicado
		{
			get { return _comunicado; }
			set { _comunicado = value; }
		}

		public List<Tag> Tages
		{
			get { return _tages; }
			set { _tages = value; }
		}

		public List<Regiao> ConteudoRegiao
		{
			get { return _conteudoRegiao; }
			set { _conteudoRegiao = value; }
		}

		[NotNullValidator]
		public Evento Evento
		{
			get { return _evento; }
			set { _evento = value; }
		}

		[NotNullValidator]
		public Noticia Noticia
		{
			get { return _noticia; }
			set { _noticia = value; }
		}

		[NotNullValidator]
		public Release Release
		{
			get { return _release; }
			set { _release = value; }
		}

		[NotNullValidator]
		public Podcast Podcast
		{
			get { return _podcast; }
			set { _podcast = value; }
		}

		[NotNullValidator]
		public Video Video
		{
			get { return _video; }
			set { _video = value; }
		}

		[NotNullValidator]
		public ConteudoTipo ConteudoTipo
		{
			get { return _conteudoTipo; }
			set { _conteudoTipo = value; }
		}

		public Workflow Workflow
		{
			get { return _workflow; }
			set { _workflow = value; }
		}

		/// <summary>
		/// Propriedade que informa se a entidade é válida para persistência.
		/// </summary>
		/// <returns>booleano informando se é a entidade é válida ou não.</returns>
		public bool Valido
		{
			get { return Validation.Validate<Conteudo>(this).IsValid; }
		}

		/// <summary>
		/// Método que valida e retorna os dados de validação da entidade.
		/// </summary>
		/// <returns>ValidationResults contendo as informações da validação.</returns>
		public ValidationResults Validar()
		{
			return Validation.Validate<Conteudo>(this);
		}
	}

	public struct ConteudoColunas
	{
		public static string ConteudoId = @"conteudoId";
		public static string ConteudoTipoId = @"conteudoTipoId";
		public static string DataHoraCadastro = @"dataHoraCadastro";
		public static string WorkflowId = @"workflowId";
	}
}
