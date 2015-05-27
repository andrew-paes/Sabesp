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
	public class FaqCategoria 
	{
		// Construtor
		public FaqCategoria() {}

		// Construtor com identificador
		public FaqCategoria(int faqCategoriaId) {
			_faqCategoriaId = faqCategoriaId;
		}

		private int _faqCategoriaId;
		private int _ordemCategoria;
		private List<FaqCategoriaIdioma> _faqCategoriaIdiomas;
		private List<FaqItem> _faqItens;

		public int FaqCategoriaId {
			get { return _faqCategoriaId; }
			set { _faqCategoriaId = value; }
		}

		public int OrdemCategoria {
			get { return _ordemCategoria; }
			set { _ordemCategoria = value; }
		}

		public List<FaqCategoriaIdioma> FaqCategoriaIdiomas {
			get { return _faqCategoriaIdiomas; }
			set { _faqCategoriaIdiomas = value; }
		}

		public List<FaqItem> FaqItens {
			get { return _faqItens; }
			set { _faqItens = value; }
		}

	    /// <summary>
        /// Propriedade que informa se a entidade é válida para persistência.
        /// </summary>
        /// <returns>booleano informando se é a entidade é válida ou não.</returns>
        public bool Valido
        {
            get { return Validation.Validate<FaqCategoria>(this).IsValid; }
        }

        /// <summary>
        /// Método que valida e retorna os dados de validação da entidade.
        /// </summary>
        /// <returns>ValidationResults contendo as informações da validação.</returns>
        public ValidationResults Validar()
        {
            return Validation.Validate<FaqCategoria>(this);
        }
	}
	
	public struct FaqCategoriaColunas
	{	
		public static string FaqCategoriaId = @"faqCategoriaId";
		public static string OrdemCategoria = @"ordemCategoria";
	}
}
		