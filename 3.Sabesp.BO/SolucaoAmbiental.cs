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
	public class SolucaoAmbientalIdioma 
	{
		private string _tituloPrincipal;
		private string _tituloChamada1;
		private string _tituloChamada2;
		private string _tituloChamada3;
		private string _textoChamada1;
		private string _textoChamada2;
		private string _textoChamada3;
		private string _link1;
		private string _link2;
		private string _link3;
		private string _linkImagem;
		private Arquivo _arquivoFoto;
		private Idioma _idioma;

		public string TituloPrincipal {
			get { return _tituloPrincipal; }
			set { _tituloPrincipal = value; }
		}

		public string TituloChamada1 {
			get { return _tituloChamada1; }
			set { _tituloChamada1 = value; }
		}

		public string TituloChamada2 {
			get { return _tituloChamada2; }
			set { _tituloChamada2 = value; }
		}

		public string TituloChamada3 {
			get { return _tituloChamada3; }
			set { _tituloChamada3 = value; }
		}

		public string TextoChamada1 {
			get { return _textoChamada1; }
			set { _textoChamada1 = value; }
		}

		public string TextoChamada2 {
			get { return _textoChamada2; }
			set { _textoChamada2 = value; }
		}

		public string TextoChamada3 {
			get { return _textoChamada3; }
			set { _textoChamada3 = value; }
		}

		public string Link1 {
			get { return _link1; }
			set { _link1 = value; }
		}

		public string Link2 {
			get { return _link2; }
			set { _link2 = value; }
		}

		public string Link3 {
			get { return _link3; }
			set { _link3 = value; }
		}

		public string LinkImagem {
			get { return _linkImagem; }
			set { _linkImagem = value; }
		}

		public Arquivo ArquivoFoto {
			get { return _arquivoFoto; }
			set { _arquivoFoto = value; }
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
            get { return Validation.Validate<SolucaoAmbientalIdioma>(this).IsValid; }
        }

        /// <summary>
        /// Método que valida e retorna os dados de validação da entidade.
        /// </summary>
        /// <returns>ValidationResults contendo as informações da validação.</returns>
        public ValidationResults Validar()
        {
            return Validation.Validate<SolucaoAmbientalIdioma>(this);
        }
	}
	
	public struct SolucaoAmbientalIdiomaColunas
	{	
		public static string ArquivoIdFoto = @"arquivoIdFoto";
		public static string TituloPrincipal = @"tituloPrincipal";
		public static string TituloChamada1 = @"tituloChamada1";
		public static string TituloChamada2 = @"tituloChamada2";
		public static string TituloChamada3 = @"tituloChamada3";
		public static string TextoChamada1 = @"textoChamada1";
		public static string TextoChamada2 = @"textoChamada2";
		public static string TextoChamada3 = @"textoChamada3";
		public static string Link1 = @"link1";
		public static string Link2 = @"link2";
		public static string Link3 = @"link3";
		public static string LinkImagem = @"linkImagem";
		public static string IdiomaId = @"idiomaId";
	}
}
		