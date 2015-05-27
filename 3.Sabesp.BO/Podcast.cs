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
using System.Xml.Linq;

namespace Sabesp.BO
{

	[Serializable]
	public class Podcast
	{
		private bool _ativo;
		private DateTime _dataHoraPublicacao;
		private bool _destaqueHome;
		private bool _destaqueFiquePorDentro;
		private bool _destaquePodcasts;
		private bool _bancoAudio;
		private string _autor;
		private List<PodcastIdioma> _podcastIdiomas;
		private Conteudo _conteudo;
		private PodcastCategoria _podcastCategoria;

		public bool Ativo
		{
			get { return _ativo; }
			set { _ativo = value; }
		}

		[NotNullValidator]
		public DateTime DataHoraPublicacao
		{
			get { return _dataHoraPublicacao; }
			set { _dataHoraPublicacao = value; }
		}

		public bool DestaqueHome
		{
			get { return _destaqueHome; }
			set { _destaqueHome = value; }
		}

		public bool DestaqueFiquePorDentro
		{
			get { return _destaqueFiquePorDentro; }
			set { _destaqueFiquePorDentro = value; }
		}

		public bool DestaquePodcasts
		{
			get { return _destaquePodcasts; }
			set { _destaquePodcasts = value; }
		}

		public bool BancoAudio
		{
			get { return _bancoAudio; }
			set { _bancoAudio = value; }
		}

		public string Autor
		{
			get { return _autor; }
			set { _autor = value; }
		}

		public List<PodcastIdioma> PodcastIdiomas
		{
			get { return _podcastIdiomas; }
			set { _podcastIdiomas = value; }
		}

		[NotNullValidator]
		public Conteudo Conteudo
		{
			get { return _conteudo; }
			set { _conteudo = value; }
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
			get { return Validation.Validate<Podcast>(this).IsValid; }
		}

		/// <summary>
		/// Método que valida e retorna os dados de validação da entidade.
		/// </summary>
		/// <returns>ValidationResults contendo as informações da validação.</returns>
		public ValidationResults Validar()
		{
			return Validation.Validate<Podcast>(this);
		}
	}

	public struct PodcastColunas
	{
		public static string PodcastId = @"podcastId";
		public static string Ativo = @"ativo";
		public static string DataHoraPublicacao = @"dataHoraPublicacao";
		public static string DestaqueHome = @"destaqueHome";
		public static string DestaqueFiquePorDentro = @"destaqueFiquePorDentro";
		public static string DestaquePodcasts = @"destaquePodcasts";
		public static string Autor = @"autor";
		public static string BancoAudio = @"bancoAudio";
		public static string PodcastCategoriaId = @"podcastCategoriaId";
	}
}
