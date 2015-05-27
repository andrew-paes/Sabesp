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
	public class NoticiaIdioma 
	{
		private string _tituloNoticia;
		private string _chamadaNoticia;
		private string _textoNoticia;
		private Idioma _idioma;
		private Noticia _noticia;

		[NotNullValidator]
		[StringLengthValidator(0, 100)]
		public string TituloNoticia {
			get { return _tituloNoticia; }
			set { _tituloNoticia = value; }
		}

		public string ChamadaNoticia {
			get { return _chamadaNoticia; }
			set { _chamadaNoticia = value; }
		}

		[NotNullValidator]
		[StringLengthValidator(0, 1073741823)]
		public string TextoNoticia {
			get { return _textoNoticia; }
			set { _textoNoticia = value; }
		}

		[NotNullValidator]
		public Idioma Idioma {
			get { return _idioma; }
			set { _idioma = value; }
		}

		[NotNullValidator]
		public Noticia Noticia {
			get { return _noticia; }
			set { _noticia = value; }
		}

	    /// <summary>
        /// Propriedade que informa se a entidade é válida para persistência.
        /// </summary>
        /// <returns>booleano informando se é a entidade é válida ou não.</returns>
        public bool Valido
        {
            get { return Validation.Validate<NoticiaIdioma>(this).IsValid; }
        }

        /// <summary>
        /// Método que valida e retorna os dados de validação da entidade.
        /// </summary>
        /// <returns>ValidationResults contendo as informações da validação.</returns>
        public ValidationResults Validar()
        {
            return Validation.Validate<NoticiaIdioma>(this);
        }
	}
	
	public struct NoticiaIdiomaColunas
	{	
		public static string NoticiaId = @"noticiaId";
		public static string IdiomaId = @"idiomaId";
		public static string TituloNoticia = @"tituloNoticia";
		public static string ChamadaNoticia = @"chamadaNoticia";
		public static string TextoNoticia = @"textoNoticia";
	}
}
		