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
	public class EventoFotoComentario 
	{
		private string _comentarioImagem;
		private EventoFoto _eventoFoto;
		private Idioma _idioma;

		[NotNullValidator]
		[StringLengthValidator(0, 1073741823)]
		public string ComentarioImagem {
			get { return _comentarioImagem; }
			set { _comentarioImagem = value; }
		}

		[NotNullValidator]
		public EventoFoto EventoFoto {
			get { return _eventoFoto; }
			set { _eventoFoto = value; }
		}

		[NotNullValidator]
		public Idioma Idioma {
			get { return _idioma; }
			set { _idioma = value; }
		}

	    /// <summary>
        /// Propriedade que informa se a entidade é válida para persistência.
        /// </summary>
        /// <returns>booleano informando se é a entidade é válida ou não.</returns>
        public bool Valido
        {
            get { return Validation.Validate<EventoFotoComentario>(this).IsValid; }
        }

        /// <summary>
        /// Método que valida e retorna os dados de validação da entidade.
        /// </summary>
        /// <returns>ValidationResults contendo as informações da validação.</returns>
        public ValidationResults Validar()
        {
            return Validation.Validate<EventoFotoComentario>(this);
        }
	}
	
	public struct EventoFotoComentarioColunas
	{	
		public static string EventoFotoId = @"eventoFotoId";
		public static string IdiomaId = @"idiomaId";
		public static string ComentarioImagem = @"comentarioImagem";
	}
}
		