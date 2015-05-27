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
	public class Idioma 
	{
		// Construtor
		public Idioma() {}

		// Construtor com identificador
		public Idioma(int idiomaId) {
			_idiomaId = idiomaId;
		}

		private int _idiomaId;
		private string _name;
		private bool _active;
		private bool _default;
		private string _flag;
		private List<ComunicadoIdioma> _comunicadoIdiomas;
		private List<ControleIdioma> _controleIdiomas;
		private List<EventoCategoriaIdioma> _eventoCategoriaIdiomas;
		
		private List<EventoFotoComentario> _eventoFotoComentarios;
		private List<EventoIdioma> _eventoIdiomas;
		private List<FaqCategoriaIdioma> _faqCategoriaIdiomas;
		private List<FaqItemIdioma> _faqItemIdiomas;
		private List<GlossarioIdioma> _glossarioIdiomas;
		private List<InfograficoIdioma> _infograficoIdiomas;
		private List<MaterialImprensaIdioma> _materialImprensaIdiomas;
		private List<NoticiaIdioma> _noticiaIdiomas;
		private List<NoticiaImagemComentario> _noticiaImagemComentarios;
		private NoticiaTesteIdioma _noticiaTesteIdioma;
		private List<PodcastIdioma> _podcastIdiomas;
		private List<ProdutoIdioma> _produtoIdiomas;
		private List<ProdutoTipoIdioma> _produtoTipoIdiomas;
		private List<ProjetoEspecialIdioma> _projetoEspecialIdiomas;
		private List<ReleaseIdioma> _releaseIdiomas;
		private List<ReleaseImagemComentario> _releaseImagemComentarios;
		private List<SecaoIdioma> _secaoIdiomas;
        private List<SolucaoAmbientalIdioma> _solucoesAmbientais;
		private List<Tag> _tages;

		private List<VideoIdioma> _videoIdiomas;

		public int IdiomaId {
			get { return _idiomaId; }
			set { _idiomaId = value; }
		}

		[NotNullValidator]
		[StringLengthValidator(0, 50)]
		public string Name {
			get { return _name; }
			set { _name = value; }
		}

		public bool Active {
			get { return _active; }
			set { _active = value; }
		}

		public bool Default {
			get { return _default; }
			set { _default = value; }
		}

		public string Flag {
			get { return _flag; }
			set { _flag = value; }
		}

		public List<ComunicadoIdioma> ComunicadoIdiomas {
			get { return _comunicadoIdiomas; }
			set { _comunicadoIdiomas = value; }
		}

		public List<ControleIdioma> ControleIdiomas {
			get { return _controleIdiomas; }
			set { _controleIdiomas = value; }
		}

		public List<EventoCategoriaIdioma> EventoCategoriaIdiomas {
			get { return _eventoCategoriaIdiomas; }
			set { _eventoCategoriaIdiomas = value; }
		}

		
		public List<EventoFotoComentario> EventoFotoComentarios {
			get { return _eventoFotoComentarios; }
			set { _eventoFotoComentarios = value; }
		}

		public List<EventoIdioma> EventoIdiomas {
			get { return _eventoIdiomas; }
			set { _eventoIdiomas = value; }
		}

		public List<FaqCategoriaIdioma> FaqCategoriaIdiomas {
			get { return _faqCategoriaIdiomas; }
			set { _faqCategoriaIdiomas = value; }
		}

		public List<FaqItemIdioma> FaqItemIdiomas {
			get { return _faqItemIdiomas; }
			set { _faqItemIdiomas = value; }
		}

		public List<GlossarioIdioma> GlossarioIdiomas {
			get { return _glossarioIdiomas; }
			set { _glossarioIdiomas = value; }
		}

		public List<InfograficoIdioma> InfograficoIdiomas {
			get { return _infograficoIdiomas; }
			set { _infograficoIdiomas = value; }
		}

		public List<MaterialImprensaIdioma> MaterialImprensaIdiomas {
			get { return _materialImprensaIdiomas; }
			set { _materialImprensaIdiomas = value; }
		}

		public List<NoticiaIdioma> NoticiaIdiomas {
			get { return _noticiaIdiomas; }
			set { _noticiaIdiomas = value; }
		}

		public List<NoticiaImagemComentario> NoticiaImagemComentarios {
			get { return _noticiaImagemComentarios; }
			set { _noticiaImagemComentarios = value; }
		}

		[NotNullValidator]
		public NoticiaTesteIdioma NoticiaTesteIdioma {
			get { return _noticiaTesteIdioma; }
			set { _noticiaTesteIdioma = value; }
		}

		public List<PodcastIdioma> PodcastIdiomas {
			get { return _podcastIdiomas; }
			set { _podcastIdiomas = value; }
		}

		public List<ProdutoIdioma> ProdutoIdiomas {
			get { return _produtoIdiomas; }
			set { _produtoIdiomas = value; }
		}

		public List<ProdutoTipoIdioma> ProdutoTipoIdiomas {
			get { return _produtoTipoIdiomas; }
			set { _produtoTipoIdiomas = value; }
		}

		public List<ProjetoEspecialIdioma> ProjetoEspecialIdiomas {
			get { return _projetoEspecialIdiomas; }
			set { _projetoEspecialIdiomas = value; }
		}

		public List<ReleaseIdioma> ReleaseIdiomas {
			get { return _releaseIdiomas; }
			set { _releaseIdiomas = value; }
		}

		public List<ReleaseImagemComentario> ReleaseImagemComentarios {
			get { return _releaseImagemComentarios; }
			set { _releaseImagemComentarios = value; }
		}

		public List<SecaoIdioma> SecaoIdiomas {
			get { return _secaoIdiomas; }
			set { _secaoIdiomas = value; }
		}
        public List<SolucaoAmbientalIdioma> SolucoesAmbientais
        {
            get { return _solucoesAmbientais; }
            set { _solucoesAmbientais = value; }
        }
		public List<Tag> Tages {
			get { return _tages; }
			set { _tages = value; }
		}

		public List<VideoIdioma> VideoIdiomas {
			get { return _videoIdiomas; }
			set { _videoIdiomas = value; }
		}

	    /// <summary>
        /// Propriedade que informa se a entidade é válida para persistência.
        /// </summary>
        /// <returns>booleano informando se é a entidade é válida ou não.</returns>
        public bool Valido
        {
            get { return Validation.Validate<Idioma>(this).IsValid; }
        }

        /// <summary>
        /// Método que valida e retorna os dados de validação da entidade.
        /// </summary>
        /// <returns>ValidationResults contendo as informações da validação.</returns>
        public ValidationResults Validar()
        {
            return Validation.Validate<Idioma>(this);
        }
	}
	
	public struct IdiomaColunas
	{	
		public static string IdiomaId = @"idiomaId";
		public static string Name = @"name";
		public static string Active = @"active";
		public static string Default = @"default";
		public static string Flag = @"flag";
	}
}
		