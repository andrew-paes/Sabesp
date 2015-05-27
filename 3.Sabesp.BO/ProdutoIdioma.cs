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
	public class ProdutoIdioma 
	{
		private string _tituloProduto;
		private string _textoProduto;
        private string _chamadaProduto;
		private Idioma _idioma;
		private Produto _produto;

		[NotNullValidator]
		[StringLengthValidator(0, 150)]
		public string TituloProduto {
			get { return _tituloProduto; }
			set { _tituloProduto = value; }
		}

        [StringLengthValidator(0, 130)]
        public string ChamadaProduto
        {
            get { return _chamadaProduto; }
            set { _chamadaProduto = value; }
        }

		[NotNullValidator]
		[StringLengthValidator(0, 1073741823)]
		public string TextoProduto {
			get { return _textoProduto; }
			set { _textoProduto = value; }
		}

		[NotNullValidator]
		public Idioma Idioma {
			get { return _idioma; }
			set { _idioma = value; }
		}

		[NotNullValidator]
		public Produto Produto {
			get { return _produto; }
			set { _produto = value; }
		}

	    /// <summary>
        /// Propriedade que informa se a entidade é válida para persistência.
        /// </summary>
        /// <returns>booleano informando se é a entidade é válida ou não.</returns>
        public bool Valido
        {
            get { return Validation.Validate<ProdutoIdioma>(this).IsValid; }
        }

        /// <summary>
        /// Método que valida e retorna os dados de validação da entidade.
        /// </summary>
        /// <returns>ValidationResults contendo as informações da validação.</returns>
        public ValidationResults Validar()
        {
            return Validation.Validate<ProdutoIdioma>(this);
        }
	}
	
	public struct ProdutoIdiomaColunas
	{	
		public static string ProdutoId = @"produtoId";
		public static string IdiomaId = @"idiomaId";
		public static string TituloProduto = @"tituloProduto";
		public static string TextoProduto = @"textoProduto";
        public static string ChamadaProduto = @"chamadaProduto";
	}
}
		