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
	public class VideoIdioma 
	{
		private string _tituloVideo;
		private string _descricaoVideo;
		private Idioma _idioma;
		private Video _video;

		[NotNullValidator]
		[StringLengthValidator(0, 200)]
		public string TituloVideo {
			get { return _tituloVideo; }
			set { _tituloVideo = value; }
		}

		public string DescricaoVideo {
			get { return _descricaoVideo; }
			set { _descricaoVideo = value; }
		}

		[NotNullValidator]
		public Idioma Idioma {
			get { return _idioma; }
			set { _idioma = value; }
		}

		[NotNullValidator]
		public Video Video {
			get { return _video; }
			set { _video = value; }
		}

	    /// <summary>
        /// Propriedade que informa se a entidade é válida para persistência.
        /// </summary>
        /// <returns>booleano informando se é a entidade é válida ou não.</returns>
        public bool Valido
        {
            get { return Validation.Validate<VideoIdioma>(this).IsValid; }
        }

        /// <summary>
        /// Método que valida e retorna os dados de validação da entidade.
        /// </summary>
        /// <returns>ValidationResults contendo as informações da validação.</returns>
        public ValidationResults Validar()
        {
            return Validation.Validate<VideoIdioma>(this);
        }
	}
	
	public struct VideoIdiomaColunas
	{	
		public static string VideoId = @"videoId";
		public static string IdiomaId = @"idiomaId";
		public static string TituloVideo = @"tituloVideo";
		public static string DescricaoVideo = @"descricaoVideo";
	}
}
		