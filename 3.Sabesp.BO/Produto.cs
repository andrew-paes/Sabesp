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
	public class Produto 
	{
		// Construtor
		public Produto() {}

		// Construtor com identificador
		public Produto(int produtoId) {
			_produtoId = produtoId;
		}

		private int _produtoId;
		private bool _ativo;
		private bool _destaqueProdutos;
		private List<ProdutoIdioma> _produtoIdiomas;
		private List<ProdutoImagem> _produtoImagens;
		private Arquivo _arquivoThumb;
		private ProdutoTipo _produtoTipo;

		public int ProdutoId {
			get { return _produtoId; }
			set { _produtoId = value; }
		}

		public bool Ativo {
			get { return _ativo; }
			set { _ativo = value; }
		}

		public bool DestaqueProdutos {
			get { return _destaqueProdutos; }
			set { _destaqueProdutos = value; }
		}

		public List<ProdutoIdioma> ProdutoIdiomas {
			get { return _produtoIdiomas; }
			set { _produtoIdiomas = value; }
		}

		public List<ProdutoImagem> ProdutoImagens {
			get { return _produtoImagens; }
			set { _produtoImagens = value; }
		}

		public Arquivo ArquivoThumb {
			get { return _arquivoThumb; }
			set { _arquivoThumb = value; }
		}

		[NotNullValidator]
		public ProdutoTipo ProdutoTipo {
			get { return _produtoTipo; }
			set { _produtoTipo = value; }
		}

	    /// <summary>
        /// Propriedade que informa se a entidade é válida para persistência.
        /// </summary>
        /// <returns>booleano informando se é a entidade é válida ou não.</returns>
        public bool Valido
        {
            get { return Validation.Validate<Produto>(this).IsValid; }
        }

        /// <summary>
        /// Método que valida e retorna os dados de validação da entidade.
        /// </summary>
        /// <returns>ValidationResults contendo as informações da validação.</returns>
        public ValidationResults Validar()
        {
            return Validation.Validate<Produto>(this);
        }
	}
	
	public struct ProdutoColunas
	{	
		public static string ProdutoId = @"produtoId";
		public static string Ativo = @"ativo";
		public static string DestaqueProdutos = @"destaqueProdutos";
		public static string ArquivoIdThumb = @"arquivoIdThumb";
		public static string ProdutoTipoId = @"produtoTipoId";
	}
}
		