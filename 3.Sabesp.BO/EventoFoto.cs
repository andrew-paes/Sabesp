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
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using System;
using System.Text;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Xml.Linq;

namespace Sabesp.BO
{

	[Serializable]
	public class EventoFoto
	{
		// Construtor
		public EventoFoto() { }

		// Construtor com identificador
		public EventoFoto(int eventoFotoId)
		{
			_eventoFotoId = eventoFotoId;
		}

		private int _eventoFotoId;
		private int _ordem;
		private List<EventoFotoComentario> _eventoFotoComentarios;
		private Arquivo _arquivo;
		private Evento _evento;

		public int EventoFotoId
		{
			get { return _eventoFotoId; }
			set { _eventoFotoId = value; }
		}

		public int Ordem
		{
			get { return _ordem; }
			set { _ordem = value; }
		}

		public List<EventoFotoComentario> EventoFotoComentarios
		{
			get { return _eventoFotoComentarios; }
			set { _eventoFotoComentarios = value; }
		}

		[NotNullValidator]
		public Arquivo Arquivo
		{
			get { return _arquivo; }
			set { _arquivo = value; }
		}

		[NotNullValidator]
		public Evento Evento
		{
			get { return _evento; }
			set { _evento = value; }
		}

		/// <summary>
		/// Propriedade que informa se a entidade é válida para persistência.
		/// </summary>
		/// <returns>booleano informando se é a entidade é válida ou não.</returns>
		public bool Valido
		{
			get { return Validation.Validate<EventoFoto>(this).IsValid; }
		}

		/// <summary>
		/// Método que valida e retorna os dados de validação da entidade.
		/// </summary>
		/// <returns>ValidationResults contendo as informações da validação.</returns>
		public ValidationResults Validar()
		{
			return Validation.Validate<EventoFoto>(this);
		}
	}

	public struct EventoFotoColunas
	{
		public static string EventoFotoId = @"eventoFotoId";
		public static string ArquivoId = @"arquivoId";
		public static string EventoId = @"eventoId";
		public static string Ordem = @"ordem";
	}
}
