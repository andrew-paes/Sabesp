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
	public class FaqCategoriaIdioma 
	{
		private string _nomeCategoria;
		private FaqCategoria _faqCategoria;
		private Idioma _idioma;
        private int _faqCategoriaId;

		[NotNullValidator]
		[StringLengthValidator(0, 100)]
		public string NomeCategoria {
			get { return _nomeCategoria; }
			set { _nomeCategoria = value; }
		}

		[NotNullValidator]
		public FaqCategoria FaqCategoria {
			get { return _faqCategoria; }
			set { _faqCategoria = value; }
		}

        public int FaqCategoriaId
        {
            get { return _faqCategoriaId; }
            set { _faqCategoriaId = value; }
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
            get { return Validation.Validate<FaqCategoriaIdioma>(this).IsValid; }
        }

        /// <summary>
        /// Método que valida e retorna os dados de validação da entidade.
        /// </summary>
        /// <returns>ValidationResults contendo as informações da validação.</returns>
        public ValidationResults Validar()
        {
            return Validation.Validate<FaqCategoriaIdioma>(this);
        }
	}
	
	public struct FaqCategoriaIdiomaColunas
	{	
		public static string FaqCategoriaId = @"faqCategoriaId";
		public static string NomeCategoria = @"nomeCategoria";
		public static string IdiomaId = @"idiomaId";
	}
}
		