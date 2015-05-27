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
	public class FaqItemIdioma 
	{
		private string _pergunta;
		private string _resposta;
		private FaqItem _faqItem;
		private Idioma _idioma;

		[NotNullValidator]
		[StringLengthValidator(0, 1073741823)]
		public string Pergunta {
			get { return _pergunta; }
			set { _pergunta = value; }
		}

		[NotNullValidator]
		[StringLengthValidator(0, 1073741823)]
		public string Resposta {
			get { return _resposta; }
			set { _resposta = value; }
		}

		[NotNullValidator]
		public FaqItem FaqItem {
			get { return _faqItem; }
			set { _faqItem = value; }
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
            get { return Validation.Validate<FaqItemIdioma>(this).IsValid; }
        }

        /// <summary>
        /// Método que valida e retorna os dados de validação da entidade.
        /// </summary>
        /// <returns>ValidationResults contendo as informações da validação.</returns>
        public ValidationResults Validar()
        {
            return Validation.Validate<FaqItemIdioma>(this);
        }
	}
	
	public struct FaqItemIdiomaColunas
	{	
		public static string FaqItemId = @"faqItemId";
		public static string IdiomaId = @"idiomaId";
		public static string Pergunta = @"pergunta";
		public static string Resposta = @"resposta";
	}
}
		