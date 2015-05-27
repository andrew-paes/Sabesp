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
	public class PodcastCategoriaIdioma
	{
		private string _descricao;
		private Idioma _idioma;
		private PodcastCategoria _podcastCategoria;

		[NotNullValidator]
		[StringLengthValidator(0, 200)]
		public string Descricao
		{
			get { return _descricao; }
			set { _descricao = value; }
		}

		[NotNullValidator]
		public Idioma Idioma
		{
			get { return _idioma; }
			set { _idioma = value; }
		}

		[NotNullValidator]
		public PodcastCategoria PodcastCategoria
		{
			get { return _podcastCategoria; }
			set { _podcastCategoria = value; }
		}

		/// <summary>
		/// Propriedade que informa se a entidade é válida para persistência.
		/// </summary>
		/// <returns>booleano informando se é a entidade é válida ou não.</returns>
		public bool Valido
		{
			get { return Validation.Validate<PodcastCategoriaIdioma>(this).IsValid; }
		}

		/// <summary>
		/// Método que valida e retorna os dados de validação da entidade.
		/// </summary>
		/// <returns>ValidationResults contendo as informações da validação.</returns>
		public ValidationResults Validar()
		{
			return Validation.Validate<PodcastCategoriaIdioma>(this);
		}
	}

	public struct PodcastCategoriaIdiomaColunas
	{
		public static string PodcastCategoriaId = @"podcastCategoriaId";
		public static string IdiomaId = @"idiomaId";
		public static string Descricao = @"descricao";
	}
}
