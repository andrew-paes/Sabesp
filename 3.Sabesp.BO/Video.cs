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
	public class Video 
	{
		private bool _ativo;
		private bool _destaqueHome;
		private bool _destaqueVideos;
		private bool _destaqueFiquePorDentro;
		private DateTime _dataHoraPublicacao;
		private string _urlYoutube;
		private string _autor;
		private List<VideoIdioma> _videoIdiomas;
		private Conteudo _conteudo;

		public bool Ativo {
			get { return _ativo; }
			set { _ativo = value; }
		}

		public bool DestaqueHome {
			get { return _destaqueHome; }
			set { _destaqueHome = value; }
		}

		public bool DestaqueVideos {
			get { return _destaqueVideos; }
			set { _destaqueVideos = value; }
		}

		public bool DestaqueFiquePorDentro {
			get { return _destaqueFiquePorDentro; }
			set { _destaqueFiquePorDentro = value; }
		}

		[NotNullValidator]
		public DateTime DataHoraPublicacao {
			get { return _dataHoraPublicacao; }
			set { _dataHoraPublicacao = value; }
		}

		public string UrlYoutube {
			get { return _urlYoutube; }
			set { _urlYoutube = value; }
		}

		public string Autor {
			get { return _autor; }
			set { _autor = value; }
		}

		public List<VideoIdioma> VideoIdiomas {
			get { return _videoIdiomas; }
			set { _videoIdiomas = value; }
		}

		[NotNullValidator]
		public Conteudo Conteudo {
			get { return _conteudo; }
			set { _conteudo = value; }
		}

	    /// <summary>
        /// Propriedade que informa se a entidade é válida para persistência.
        /// </summary>
        /// <returns>booleano informando se é a entidade é válida ou não.</returns>
        public bool Valido
        {
            get { return Validation.Validate<Video>(this).IsValid; }
        }

        /// <summary>
        /// Método que valida e retorna os dados de validação da entidade.
        /// </summary>
        /// <returns>ValidationResults contendo as informações da validação.</returns>
        public ValidationResults Validar()
        {
            return Validation.Validate<Video>(this);
        }
	}
	
	public struct VideoColunas
	{	
		public static string VideoId = @"videoId";
		public static string Ativo = @"ativo";
		public static string DestaqueHome = @"destaqueHome";
		public static string DestaqueVideos = @"destaqueVideos";
		public static string DestaqueFiquePorDentro = @"destaqueFiquePorDentro";
		public static string DataHoraPublicacao = @"dataHoraPublicacao";
		public static string UrlYoutube = @"urlYoutube";
		public static string Autor = @"autor";
	}
}
		