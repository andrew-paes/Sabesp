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
	public class ProdutoTipoIdioma 
	{
		private string _tituloProdutoTipo;
		private string _textoTipoProduto;
		private Idioma _idioma;
		private ProdutoTipo _produtoTipo;
        private string _chamadaProdutoTipo;

		[NotNullValidator]
		[StringLengthValidator(0, 150)]
		public string TituloProdutoTipo {
			get { return _tituloProdutoTipo; }
			set { _tituloProdutoTipo = value; }
		}
        [NotNullValidator]
		[StringLengthValidator(0, 130)]
        public string ChamadaProdutoTipo
        {
            get { return _chamadaProdutoTipo; }
            set { _chamadaProdutoTipo = value; }
		}
        

		public string TextoTipoProduto {
			get { return _textoTipoProduto; }
			set { _textoTipoProduto = value; }
		}

		[NotNullValidator]
		public Idioma Idioma {
			get { return _idioma; }
			set { _idioma = value; }
		}

		[NotNullValidator]
		public ProdutoTipo ProdutoTipo {
			get { return _produtoTipo; }
			set { _produtoTipo = value; }
		}

        [NotNullValidator]
        public int ProdutoTipoId
        {
			get { return _produtoTipo.ProdutoTipoId ; }
            set { _produtoTipo.ProdutoTipoId = value; }
		}

        

	    /// <summary>
        /// Propriedade que informa se a entidade é válida para persistência.
        /// </summary>
        /// <returns>booleano informando se é a entidade é válida ou não.</returns>
        public bool Valido
        {
            get { return Validation.Validate<ProdutoTipoIdioma>(this).IsValid; }
        }

        /// <summary>
        /// Método que valida e retorna os dados de validação da entidade.
        /// </summary>
        /// <returns>ValidationResults contendo as informações da validação.</returns>
        public ValidationResults Validar()
        {
            return Validation.Validate<ProdutoTipoIdioma>(this);
        }
	}
	
	public struct ProdutoTipoIdiomaColunas
	{	
		public static string ProdutoTipoId = @"produtoTipoId";
		public static string IdiomaId = @"idiomaId";
		public static string TituloProdutoTipo = @"tituloProdutoTipo";
		public static string TextoTipoProduto = @"textoTipoProduto";
        public static string chamadaProdutoTipo = @"chamadaProdutoTipo";
       
	}
}
		