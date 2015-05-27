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
	public class CategoriaArquivo 
	{
		// Construtor
		public CategoriaArquivo() {}

		// Construtor com identificador
		public CategoriaArquivo(int categoriaArquivoId) {
			_categoriaArquivoId = categoriaArquivoId;
		}

		private int _categoriaArquivoId;
		private string _titulo;
		private List<Arquivo> _arquivos;

		public int CategoriaArquivoId {
			get { return _categoriaArquivoId; }
			set { _categoriaArquivoId = value; }
		}

		public string Titulo {
			get { return _titulo; }
			set { _titulo = value; }
		}

		public List<Arquivo> Arquivos {
			get { return _arquivos; }
			set { _arquivos = value; }
		}

	    /// <summary>
        /// Propriedade que informa se a entidade é válida para persistência.
        /// </summary>
        /// <returns>booleano informando se é a entidade é válida ou não.</returns>
        public bool Valido
        {
            get { return Validation.Validate<CategoriaArquivo>(this).IsValid; }
        }

        /// <summary>
        /// Método que valida e retorna os dados de validação da entidade.
        /// </summary>
        /// <returns>ValidationResults contendo as informações da validação.</returns>
        public ValidationResults Validar()
        {
            return Validation.Validate<CategoriaArquivo>(this);
        }
	}
	
	public struct CategoriaArquivoColunas
	{	
		public static string CategoriaArquivoId = @"categoriaArquivoId";
		public static string Titulo = @"titulo";
	}
}
		