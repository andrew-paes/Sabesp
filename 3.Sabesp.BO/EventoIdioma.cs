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
	public class EventoIdioma 
	{
		private string _nomeEvento;
		private string _descricaoEvento;
		private string _chamadaEvento;
		private Evento _evento;
		private Idioma _idioma;

		[NotNullValidator]
		[StringLengthValidator(0, 200)]
		public string NomeEvento {
			get { return _nomeEvento; }
			set { _nomeEvento = value; }
		}

		public string DescricaoEvento {
			get { return _descricaoEvento; }
			set { _descricaoEvento = value; }
		}

		public string ChamadaEvento {
			get { return _chamadaEvento; }
			set { _chamadaEvento = value; }
		}

		[NotNullValidator]
		public Evento Evento {
			get { return _evento; }
			set { _evento = value; }
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
            get { return Validation.Validate<EventoIdioma>(this).IsValid; }
        }

        /// <summary>
        /// Método que valida e retorna os dados de validação da entidade.
        /// </summary>
        /// <returns>ValidationResults contendo as informações da validação.</returns>
        public ValidationResults Validar()
        {
            return Validation.Validate<EventoIdioma>(this);
        }
	}
	
	public struct EventoIdiomaColunas
	{	
		public static string EventoId = @"eventoId";
		public static string IdiomaId = @"idiomaId";
		public static string NomeEvento = @"nomeEvento";
		public static string DescricaoEvento = @"descricaoEvento";
		public static string ChamadaEvento = @"chamadaEvento";
	}
}
		