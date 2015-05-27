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
	public class Arquivo 
	{
		// Construtor
		public Arquivo() {}

		// Construtor com identificador
		public Arquivo(int arquivoId) {
			_arquivoId = arquivoId;
		}

		private int _arquivoId;
		private string _nomeArquivo;
		private int _tamanho;
		private string _extensao;
		private List<Evento> _eventosThumbGrande;
		private List<Evento> _eventosThumbMedio;
		private List<EventoFoto> _eventoFotos;
		private List<MaterialImprensa> _materialImprensasThumb;
		private List<MaterialImprensaIdioma> _materialImprensaIdiomas;
		private List<Noticia> _noticiasThumbGrande;
		private List<Noticia> _noticiasThumbMedio;
		private List<NoticiaImagem> _noticiaImagens;
		private List<PodcastIdioma> _podcastIdiomasPodcast;
		private List<Produto> _produtosThumb;
		private List<ProdutoImagem> _produtoImagens;
		private List<ProdutoTipo> _produtoTiposThumb;
		private List<ProjetoEspecial> _projetoEspeciaisThumbId;
		private List<ReleaseImagem> _releaseImagens;
        private List<SolucaoAmbientalIdioma> _solucoesAmbientais;

		public int ArquivoId {
			get { return _arquivoId; }
			set { _arquivoId = value; }
		}

		[NotNullValidator]
		[StringLengthValidator(0, 200)]
		public string NomeArquivo {
			get { return _nomeArquivo; }
			set { _nomeArquivo = value; }
		}

		public int Tamanho {
			get { return _tamanho; }
			set { _tamanho = value; }
		}

		[NotNullValidator]
		[StringLengthValidator(0, 10)]
		public string Extensao {
			get { return _extensao; }
			set { _extensao = value; }
		}

		public List<Evento> EventosThumbGrande {
			get { return _eventosThumbGrande; }
			set { _eventosThumbGrande = value; }
		}

		public List<Evento> EventosThumbMedio {
			get { return _eventosThumbMedio; }
			set { _eventosThumbMedio = value; }
		}

		public List<EventoFoto> EventoFotos {
			get { return _eventoFotos; }
			set { _eventoFotos = value; }
		}

		public List<MaterialImprensa> MaterialImprensasThumb {
			get { return _materialImprensasThumb; }
			set { _materialImprensasThumb = value; }
		}

		public List<MaterialImprensaIdioma> MaterialImprensaIdiomas {
			get { return _materialImprensaIdiomas; }
			set { _materialImprensaIdiomas = value; }
		}

		public List<Noticia> NoticiasThumbGrande {
			get { return _noticiasThumbGrande; }
			set { _noticiasThumbGrande = value; }
		}

		public List<Noticia> NoticiasThumbMedio {
			get { return _noticiasThumbMedio; }
			set { _noticiasThumbMedio = value; }
		}

		public List<NoticiaImagem> NoticiaImagens {
			get { return _noticiaImagens; }
			set { _noticiaImagens = value; }
		}

		public List<PodcastIdioma> PodcastIdiomasPodcast {
			get { return _podcastIdiomasPodcast; }
			set { _podcastIdiomasPodcast = value; }
		}

		public List<Produto> ProdutosThumb {
			get { return _produtosThumb; }
			set { _produtosThumb = value; }
		}

		public List<ProdutoImagem> ProdutoImagens {
			get { return _produtoImagens; }
			set { _produtoImagens = value; }
		}

		public List<ProdutoTipo> ProdutoTiposThumb {
			get { return _produtoTiposThumb; }
			set { _produtoTiposThumb = value; }
		}

		public List<ProjetoEspecial> ProjetoEspeciaisThumbId
		{
			get { return _projetoEspeciaisThumbId; }
			set { _projetoEspeciaisThumbId = value; }
		}

		public List<ReleaseImagem> ReleaseImagens {
			get { return _releaseImagens; }
			set { _releaseImagens = value; }
		}

        public List<SolucaoAmbientalIdioma> SolucoesAmbientais
        {
            get { return _solucoesAmbientais; }
            set { _solucoesAmbientais = value; }
        }
	    /// <summary>
        /// Propriedade que informa se a entidade é válida para persistência.
        /// </summary>
        /// <returns>booleano informando se é a entidade é válida ou não.</returns>
        public bool Valido
        {
            get { return Validation.Validate<Arquivo>(this).IsValid; }
        }

        /// <summary>
        /// Método que valida e retorna os dados de validação da entidade.
        /// </summary>
        /// <returns>ValidationResults contendo as informações da validação.</returns>
        public ValidationResults Validar()
        {
            return Validation.Validate<Arquivo>(this);
        }
	}
	
	public struct ArquivoColunas
	{	
		public static string ArquivoId = @"arquivoId";
		public static string NomeArquivo = @"nomeArquivo";
		public static string Tamanho = @"tamanho";
		public static string Extensao = @"extensao";
	}
}
		