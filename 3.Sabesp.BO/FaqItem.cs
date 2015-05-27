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
	public class FaqItem 
	{
		// Construtor
		public FaqItem() {}

		// Construtor com identificador
		public FaqItem(int faqItemId) {
			_faqItemId = faqItemId;
		}

		private int _faqItemId;
		private bool _ativo;
		private bool _destaque;
		private int _ordemItem;
		private List<FaqItemIdioma> _faqItemIdiomas;
		private FaqCategoria _faqCategoria;

		public int FaqItemId {
			get { return _faqItemId; }
			set { _faqItemId = value; }
		}

		public bool Ativo {
			get { return _ativo; }
			set { _ativo = value; }
		}

		public bool Destaque
		{
			get { return _destaque; }
			set { _destaque = value; }
		}

		public int OrdemItem {
			get { return _ordemItem; }
			set { _ordemItem = value; }
		}

		public List<FaqItemIdioma> FaqItemIdiomas {
			get { return _faqItemIdiomas; }
			set { _faqItemIdiomas = value; }
		}

		[NotNullValidator]
		public FaqCategoria FaqCategoria {
			get { return _faqCategoria; }
			set { _faqCategoria = value; }
		}

	    /// <summary>
        /// Propriedade que informa se a entidade é válida para persistência.
        /// </summary>
        /// <returns>booleano informando se é a entidade é válida ou não.</returns>
        public bool Valido
        {
            get { return Validation.Validate<FaqItem>(this).IsValid; }
        }

        /// <summary>
        /// Método que valida e retorna os dados de validação da entidade.
        /// </summary>
        /// <returns>ValidationResults contendo as informações da validação.</returns>
        public ValidationResults Validar()
        {
            return Validation.Validate<FaqItem>(this);
        }
	}
	
	public struct FaqItemColunas
	{	
		public static string FaqItemId = @"faqItemId";
		public static string Ativo = @"ativo";
		public static string OrdemItem = @"ordemItem";
		public static string FaqCategoriaId = @"faqCategoriaId";
		public static string Destaque = @"destaque";
	}
}
		