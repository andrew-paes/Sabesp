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
	public class ControleIdiomaDado 
	{
		// Construtor
		public ControleIdiomaDado() {}

		// Construtor com identificador
		public ControleIdiomaDado(int controleIdiomaDadoId) {
			_controleIdiomaDadoId = controleIdiomaDadoId;
		}

		private int _controleIdiomaDadoId;
		private string _subtitulo;
		private string _link;
		private string _target;
		private string _imagemNome;
		private string _imagemTexto;
		private string _textoChamada;
		private string _arquivoNome;
		private int? _arquivoTamanho;
		private string _arquivoExtensao;
		private List<ControleIdiomaDadoArquivo> _controleIdiomaDadoArquivos;
		private ControleIdioma _controleIdioma;

		public int ControleIdiomaDadoId {
			get { return _controleIdiomaDadoId; }
			set { _controleIdiomaDadoId = value; }
		}

		public string Subtitulo {
			get { return _subtitulo; }
			set { _subtitulo = value; }
		}

		public string Link {
			get { return _link; }
			set { _link = value; }
		}

		public string Target {
			get { return _target; }
			set { _target = value; }
		}

		public string ImagemNome {
			get { return _imagemNome; }
			set { _imagemNome = value; }
		}

		public string ImagemTexto {
			get { return _imagemTexto; }
			set { _imagemTexto = value; }
		}

		public string TextoChamada {
			get { return _textoChamada; }
			set { _textoChamada = value; }
		}

		public string ArquivoNome {
			get { return _arquivoNome; }
			set { _arquivoNome = value; }
		}

		public int? ArquivoTamanho {
			get { return _arquivoTamanho; }
			set { _arquivoTamanho = value; }
		}

		public string ArquivoExtensao {
			get { return _arquivoExtensao; }
			set { _arquivoExtensao = value; }
		}

		public List<ControleIdiomaDadoArquivo> ControleIdiomaDadoArquivos {
			get { return _controleIdiomaDadoArquivos; }
			set { _controleIdiomaDadoArquivos = value; }
		}

		public ControleIdioma ControleIdioma {
			get { return _controleIdioma; }
			set { _controleIdioma = value; }
		}

	    /// <summary>
        /// Propriedade que informa se a entidade é válida para persistência.
        /// </summary>
        /// <returns>booleano informando se é a entidade é válida ou não.</returns>
        public bool Valido
        {
            get { return Validation.Validate<ControleIdiomaDado>(this).IsValid; }
        }

        /// <summary>
        /// Método que valida e retorna os dados de validação da entidade.
        /// </summary>
        /// <returns>ValidationResults contendo as informações da validação.</returns>
        public ValidationResults Validar()
        {
            return Validation.Validate<ControleIdiomaDado>(this);
        }
	}
	
	public struct ControleIdiomaDadoColunas
	{	
		public static string ControleIdiomaDadoId = @"controleIdiomaDadoId";
		public static string ControleIdiomaId = @"controleIdiomaId";
		public static string Subtitulo = @"subtitulo";
		public static string Link = @"link";
		public static string Target = @"target";
		public static string ImagemNome = @"imagemNome";
		public static string ImagemTexto = @"imagemTexto";
		public static string TextoChamada = @"textoChamada";
		public static string ArquivoNome = @"arquivoNome";
		public static string ArquivoTamanho = @"arquivoTamanho";
		public static string ArquivoExtensao = @"arquivoExtensao";
	}
}
		