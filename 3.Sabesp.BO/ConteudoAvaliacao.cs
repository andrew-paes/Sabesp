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
	public class ConteudoAvaliacao 
	{
		// Construtor
		public ConteudoAvaliacao() {}

		// Construtor com identificador
		public ConteudoAvaliacao(int conteudoId) {
			_conteudoId = conteudoId;
		}

		private int _conteudoId;
		private int _totalPositivo;
		private int _totalNegativo;

		public int ConteudoId {
			get { return _conteudoId; }
			set { _conteudoId = value; }
		}

		public int TotalPositivo {
			get { return _totalPositivo; }
			set { _totalPositivo = value; }
		}

		public int TotalNegativo {
			get { return _totalNegativo; }
			set { _totalNegativo = value; }
		}

	    /// <summary>
        /// Propriedade que informa se a entidade é válida para persistência.
        /// </summary>
        /// <returns>booleano informando se é a entidade é válida ou não.</returns>
        public bool Valido
        {
            get { return Validation.Validate<ConteudoAvaliacao>(this).IsValid; }
        }

        /// <summary>
        /// Método que valida e retorna os dados de validação da entidade.
        /// </summary>
        /// <returns>ValidationResults contendo as informações da validação.</returns>
        public ValidationResults Validar()
        {
            return Validation.Validate<ConteudoAvaliacao>(this);
        }
	}
	
	public struct ConteudoAvaliacaoColunas
	{	
		public static string ConteudoId = @"conteudoId";
		public static string TotalPositivo = @"totalPositivo";
		public static string TotalNegativo = @"totalNegativo";
	}
}
		