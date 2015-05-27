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
	public class PodcastCategoria
	{
		// Construtor
		public PodcastCategoria() { }

		// Construtor com identificador
		public PodcastCategoria(int podcastCategoriaId)
		{
			_podcastCategoriaId = podcastCategoriaId;
		}

		private int _podcastCategoriaId;
		private bool _ativo;
		private List<Podcast> _podcastes;
		private List<PodcastCategoriaIdioma> _podcastCategoriaIdiomas;

		public int PodcastCategoriaId
		{
			get { return _podcastCategoriaId; }
			set { _podcastCategoriaId = value; }
		}

		public bool Ativo
		{
			get { return _ativo; }
			set { _ativo = value; }
		}

		public List<Podcast> Podcastes
		{
			get { return _podcastes; }
			set { _podcastes = value; }
		}

		public List<PodcastCategoriaIdioma> PodcastCategoriaIdiomas
		{
			get { return _podcastCategoriaIdiomas; }
			set { _podcastCategoriaIdiomas = value; }
		}

		/// <summary>
		/// Propriedade que informa se a entidade é válida para persistência.
		/// </summary>
		/// <returns>booleano informando se é a entidade é válida ou não.</returns>
		public bool Valido
		{
			get { return Validation.Validate<PodcastCategoria>(this).IsValid; }
		}

		/// <summary>
		/// Método que valida e retorna os dados de validação da entidade.
		/// </summary>
		/// <returns>ValidationResults contendo as informações da validação.</returns>
		public ValidationResults Validar()
		{
			return Validation.Validate<PodcastCategoria>(this);
		}
	}

	public struct PodcastCategoriaColunas
	{
		public static string PodcastCategoriaId = @"podcastCategoriaId";
		public static string Ativo = @"ativo";
	}
}
