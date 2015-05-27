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
	public class ProdutoTipo 
	{
		// Construtor
		public ProdutoTipo() {}

		// Construtor com identificador
		public ProdutoTipo(int produtoTipoId) {
			_produtoTipoId = produtoTipoId;
		}

		private int _produtoTipoId;
		private bool _destaqueHome;
		private List<Produto> _produtos;
		private List<ProdutoTipoIdioma> _produtoTipoIdiomas;
		private Arquivo _arquivoThumb;

		public int ProdutoTipoId {
			get { return _produtoTipoId; }
			set { _produtoTipoId = value; }
		}

		public bool DestaqueHome {
			get { return _destaqueHome; }
			set { _destaqueHome = value; }
		}

		public List<Produto> Produtos {
			get { return _produtos; }
			set { _produtos = value; }
		}

		public List<ProdutoTipoIdioma> ProdutoTipoIdiomas {
			get { return _produtoTipoIdiomas; }
			set { _produtoTipoIdiomas = value; }
		}

		public Arquivo ArquivoThumb {
			get { return _arquivoThumb; }
			set { _arquivoThumb = value; }
		}

	    /// <summary>
        /// Propriedade que informa se a entidade é válida para persistência.
        /// </summary>
        /// <returns>booleano informando se é a entidade é válida ou não.</returns>
        public bool Valido
        {
            get { return Validation.Validate<ProdutoTipo>(this).IsValid; }
        }

        /// <summary>
        /// Método que valida e retorna os dados de validação da entidade.
        /// </summary>
        /// <returns>ValidationResults contendo as informações da validação.</returns>
        public ValidationResults Validar()
        {
            return Validation.Validate<ProdutoTipo>(this);
        }
	}
	
	public struct ProdutoTipoColunas
	{	
		public static string ProdutoTipoId = @"produtoTipoId";
		public static string DestaqueHome = @"destaqueHome";
		public static string ArquivoIdThumb = @"arquivoIdThumb";
	}
}
		