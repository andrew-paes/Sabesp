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
	public class ReleaseImagemComentario 
	{
		private string _comentarioImagem;
		private Idioma _idioma;
		private ReleaseImagem _releaseImagem;

		[NotNullValidator]
		[StringLengthValidator(0, 1073741823)]
		public string ComentarioImagem {
			get { return _comentarioImagem; }
			set { _comentarioImagem = value; }
		}

		[NotNullValidator]
		public Idioma Idioma {
			get { return _idioma; }
			set { _idioma = value; }
		}

		[NotNullValidator]
		public ReleaseImagem ReleaseImagem {
			get { return _releaseImagem; }
			set { _releaseImagem = value; }
		}

	    /// <summary>
        /// Propriedade que informa se a entidade é válida para persistência.
        /// </summary>
        /// <returns>booleano informando se é a entidade é válida ou não.</returns>
        public bool Valido
        {
            get { return Validation.Validate<ReleaseImagemComentario>(this).IsValid; }
        }

        /// <summary>
        /// Método que valida e retorna os dados de validação da entidade.
        /// </summary>
        /// <returns>ValidationResults contendo as informações da validação.</returns>
        public ValidationResults Validar()
        {
            return Validation.Validate<ReleaseImagemComentario>(this);
        }
	}
	
	public struct ReleaseImagemComentarioColunas
	{	
		public static string ReleaseImagemId = @"releaseImagemId";
		public static string IdiomaId = @"idiomaId";
		public static string ComentarioImagem = @"comentarioImagem";
	}
}
		