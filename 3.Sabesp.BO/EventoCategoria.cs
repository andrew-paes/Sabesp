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
	public class EventoCategoria 
	{
		// Construtor
		public EventoCategoria() {}

		// Construtor com identificador
		public EventoCategoria(int eventoCategoriaId) {
			_eventoCategoriaId = eventoCategoriaId;
		}

		private int _eventoCategoriaId;
		private string _arquivoIcone;
		private List<EventoCategoriaIdioma> _eventoCategoriaIdiomas;

		public int EventoCategoriaId {
			get { return _eventoCategoriaId; }
			set { _eventoCategoriaId = value; }
		}

		public string ArquivoIcone {
			get { return _arquivoIcone; }
			set { _arquivoIcone = value; }
		}

		public List<EventoCategoriaIdioma> EventoCategoriaIdiomas {
			get { return _eventoCategoriaIdiomas; }
			set { _eventoCategoriaIdiomas = value; }
		}

	    /// <summary>
        /// Propriedade que informa se a entidade é válida para persistência.
        /// </summary>
        /// <returns>booleano informando se é a entidade é válida ou não.</returns>
        public bool Valido
        {
            get { return Validation.Validate<EventoCategoria>(this).IsValid; }
        }

        /// <summary>
        /// Método que valida e retorna os dados de validação da entidade.
        /// </summary>
        /// <returns>ValidationResults contendo as informações da validação.</returns>
        public ValidationResults Validar()
        {
            return Validation.Validate<EventoCategoria>(this);
        }
	}
	
	public struct EventoCategoriaColunas
	{	
		public static string EventoCategoriaId = @"eventoCategoriaId";
		public static string ArquivoIcone = @"arquivoIcone";
	}
}
		