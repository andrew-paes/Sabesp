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
	public class ControleIdiomaDadoArquivo 
	{
		// Construtor
		public ControleIdiomaDadoArquivo() {}

		// Construtor com identificador
		public ControleIdiomaDadoArquivo(int controleIdiomaDadoArquivoId) {
			_controleIdiomaDadoArquivoId = controleIdiomaDadoArquivoId;
		}

		private int _controleIdiomaDadoArquivoId;
		private string _nome;
		private int? _tamanho;
		private string _extensao;
		private ControleIdiomaDado _controleIdiomaDado;

		public int ControleIdiomaDadoArquivoId {
			get { return _controleIdiomaDadoArquivoId; }
			set { _controleIdiomaDadoArquivoId = value; }
		}

		public string Nome {
			get { return _nome; }
			set { _nome = value; }
		}

		public int? Tamanho {
			get { return _tamanho; }
			set { _tamanho = value; }
		}

		public string Extensao {
			get { return _extensao; }
			set { _extensao = value; }
		}

		public ControleIdiomaDado ControleIdiomaDado {
			get { return _controleIdiomaDado; }
			set { _controleIdiomaDado = value; }
		}

	    /// <summary>
        /// Propriedade que informa se a entidade é válida para persistência.
        /// </summary>
        /// <returns>booleano informando se é a entidade é válida ou não.</returns>
        public bool Valido
        {
            get { return Validation.Validate<ControleIdiomaDadoArquivo>(this).IsValid; }
        }

        /// <summary>
        /// Método que valida e retorna os dados de validação da entidade.
        /// </summary>
        /// <returns>ValidationResults contendo as informações da validação.</returns>
        public ValidationResults Validar()
        {
            return Validation.Validate<ControleIdiomaDadoArquivo>(this);
        }
	}
	
	public struct ControleIdiomaDadoArquivoColunas
	{	
		public static string ControleIdiomaDadoArquivoId = @"controleIdiomaDadoArquivoId";
		public static string ControleIdiomaDadoId = @"controleIdiomaDadoId";
		public static string Nome = @"nome";
		public static string Tamanho = @"tamanho";
		public static string Extensao = @"extensao";
	}
}
		