/*
'===============================================================================
'
'  Template: Gerador Código C#.csgen
'  Script versão: 0.93
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

namespace Sabesp.BO
{	
	
	[Serializable]
	public class ReleaseIdioma 
	{
		private string _tituloRelease;
		private string _chamadaRelease;
		private string _textoRelease;
		private Idioma _idioma;
		private Release _release;

		[NotNullValidator]
		[StringLengthValidator(0, 200)]
		public string TituloRelease {
			get { return _tituloRelease; }
			set { _tituloRelease = value; }
		}

		public string ChamadaRelease {
			get { return _chamadaRelease; }
			set { _chamadaRelease = value; }
		}

		public string TextoRelease {
			get { return _textoRelease; }
			set { _textoRelease = value; }
		}

		[NotNullValidator]
		public Idioma Idioma {
			get { return _idioma; }
			set { _idioma = value; }
		}

		[NotNullValidator]
		public Release Release {
			get { return _release; }
			set { _release = value; }
		}

	    /// <summary>
        /// Propriedade que informa se a entidade é válida para persistência.
        /// </summary>
        /// <returns>booleano informando se é a entidade é válida ou não.</returns>
        public bool Valido
        {
            get { return Validation.Validate<ReleaseIdioma>(this).IsValid; }
        }

        /// <summary>
        /// Método que valida e retorna os dados de validação da entidade.
        /// </summary>
        /// <returns>ValidationResults contendo as informações da validação.</returns>
        public ValidationResults Validar()
        {
            return Validation.Validate<ReleaseIdioma>(this);
        }
	}
	
	public struct ReleaseIdiomaColunas
	{	
		public static string ReleaseId = @"releaseId";
		public static string IdiomaId = @"idiomaId";
		public static string TituloRelease = @"tituloRelease";
		public static string ChamadaRelease = @"chamadaRelease";
		public static string TextoRelease = @"textoRelease";
	}
}
		