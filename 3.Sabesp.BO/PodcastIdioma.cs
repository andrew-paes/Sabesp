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
	public class PodcastIdioma
	{
		private string _tituloPodcast;
		private string _descricaoPodcast;
		private Arquivo _arquivoPodcast;
		private Idioma _idioma;
		private Podcast _podcast;

		[NotNullValidator]
		[StringLengthValidator(0, 200)]
		public string TituloPodcast
		{
			get { return _tituloPodcast; }
			set { _tituloPodcast = value; }
		}

		public string DescricaoPodcast
		{
			get { return _descricaoPodcast; }
			set { _descricaoPodcast = value; }
		}

		[NotNullValidator]
		public Arquivo ArquivoPodcast
		{
			get { return _arquivoPodcast; }
			set { _arquivoPodcast = value; }
		}

		[NotNullValidator]
		public Idioma Idioma
		{
			get { return _idioma; }
			set { _idioma = value; }
		}

		[NotNullValidator]
		public Podcast Podcast
		{
			get { return _podcast; }
			set { _podcast = value; }
		}

		/// <summary>
		/// Propriedade que informa se a entidade é válida para persistência.
		/// </summary>
		/// <returns>booleano informando se é a entidade é válida ou não.</returns>
		public bool Valido
		{
			get { return Validation.Validate<PodcastIdioma>(this).IsValid; }
		}

		/// <summary>
		/// Método que valida e retorna os dados de validação da entidade.
		/// </summary>
		/// <returns>ValidationResults contendo as informações da validação.</returns>
		public ValidationResults Validar()
		{
			return Validation.Validate<PodcastIdioma>(this);
		}
	}

	public struct PodcastIdiomaColunas
	{
		public static string PodcastId = @"podcastId";
		public static string IdiomaId = @"idiomaId";
		public static string TituloPodcast = @"tituloPodcast";
		public static string DescricaoPodcast = @"descricaoPodcast";
		public static string ArquivoIdPodcast = @"arquivoIdPodcast";
	}
}
