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
	public class NoticiaTesteIdioma 
	{
		private string _titulo;
		private string _conteudo;
		private Idioma _idioma;
		private NoticiaTeste _noticiaTeste;

		[NotNullValidator]
		[StringLengthValidator(0, 150)]
		public string Titulo {
			get { return _titulo; }
			set { _titulo = value; }
		}

		[NotNullValidator]
		[StringLengthValidator(0, 2147483647)]
		public string Conteudo {
			get { return _conteudo; }
			set { _conteudo = value; }
		}

		[NotNullValidator]
		public Idioma Idioma {
			get { return _idioma; }
			set { _idioma = value; }
		}

		[NotNullValidator]
		public NoticiaTeste NoticiaTeste {
			get { return _noticiaTeste; }
			set { _noticiaTeste = value; }
		}

	    /// <summary>
        /// Propriedade que informa se a entidade é válida para persistência.
        /// </summary>
        /// <returns>booleano informando se é a entidade é válida ou não.</returns>
        public bool Valido
        {
            get { return Validation.Validate<NoticiaTesteIdioma>(this).IsValid; }
        }

        /// <summary>
        /// Método que valida e retorna os dados de validação da entidade.
        /// </summary>
        /// <returns>ValidationResults contendo as informações da validação.</returns>
        public ValidationResults Validar()
        {
            return Validation.Validate<NoticiaTesteIdioma>(this);
        }
	}
	
	public struct NoticiaTesteIdiomaColunas
	{	
		public static string NoticiaTesteId = @"noticiaTesteId";
		public static string IdiomaId = @"idiomaId";
		public static string Titulo = @"titulo";
		public static string Conteudo = @"conteudo";
	}
}
		