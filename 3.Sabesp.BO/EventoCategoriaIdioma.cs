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
	public class EventoCategoriaIdioma 
	{
		private string _categoriaEvento;
		private EventoCategoria _eventoCategoria;
		private Idioma _idioma;
        private int _eventoCategoriaId;

		[NotNullValidator]
		[StringLengthValidator(0, 100)]
		public string CategoriaEvento {
			get { return _categoriaEvento; }
			set { _categoriaEvento = value; }
		}

		[NotNullValidator]
		public EventoCategoria EventoCategoria {
			get { return _eventoCategoria; }
			set { _eventoCategoria = value; }
		}

		[NotNullValidator]
		public Idioma Idioma {
			get { return _idioma; }
			set { _idioma = value; }
		}

        [NotNullValidator]
        public int EventoCategoriaId
        {
            get { return _eventoCategoriaId; }
            set { _eventoCategoriaId = value; }
        }

	    /// <summary>
        /// Propriedade que informa se a entidade é válida para persistência.
        /// </summary>
        /// <returns>booleano informando se é a entidade é válida ou não.</returns>
        public bool Valido
        {
            get { return Validation.Validate<EventoCategoriaIdioma>(this).IsValid; }
        }

        /// <summary>
        /// Método que valida e retorna os dados de validação da entidade.
        /// </summary>
        /// <returns>ValidationResults contendo as informações da validação.</returns>
        public ValidationResults Validar()
        {
            return Validation.Validate<EventoCategoriaIdioma>(this);
        }
	}
	
	public struct EventoCategoriaIdiomaColunas
	{	
		public static string EventoCategoriaId = @"eventoCategoriaId";
		public static string CategoriaEvento = @"categoriaEvento";
		public static string IdiomaId = @"idiomaId";
	}
}
		