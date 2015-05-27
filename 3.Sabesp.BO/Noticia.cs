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
	public class Noticia
	{
		private bool _ativa;
		private string _autor;
		private bool _destaqueHome;
		private bool _destaqueNoticias;
		private bool _destaqueFiquePorDentro;
		private bool _destaqueUltimasNoticias;
		private string _fonte;
		private string _fonteUrl;
		private DateTime? _dataHoraPublicacao;
		private DateTime? _dataExibicaoInicio;
		private DateTime? _dataExibicaoFim;
		private List<NoticiaIdioma> _noticiaIdiomas;
		private List<NoticiaImagem> _noticiaImagens;
		private Arquivo _arquivoThumbGrande;
		private Arquivo _arquivoThumbMedio;
		private Conteudo _conteudo;

		public bool Ativa
		{
			get { return _ativa; }
			set { _ativa = value; }
		}

		public string Autor
		{
			get { return _autor; }
			set { _autor = value; }
		}

		public bool DestaqueHome
		{
			get { return _destaqueHome; }
			set { _destaqueHome = value; }
		}

		public bool DestaqueNoticias
		{
			get { return _destaqueNoticias; }
			set { _destaqueNoticias = value; }
		}

		public bool DestaqueUltimasNoticias
		{
			get { return _destaqueUltimasNoticias; }
			set { _destaqueUltimasNoticias = value; }
		}

		public bool DestaqueFiquePorDentro
		{
			get { return _destaqueFiquePorDentro; }
			set { _destaqueFiquePorDentro = value; }
		}

		public string Fonte
		{
			get { return _fonte; }
			set { _fonte = value; }
		}

		public string FonteUrl
		{
			get { return _fonteUrl; }
			set { _fonteUrl = value; }
		}

		public DateTime? DataHoraPublicacao
		{
			get { return _dataHoraPublicacao; }
			set { _dataHoraPublicacao = value; }
		}

		public DateTime? DataExibicaoInicio
		{
			get { return _dataExibicaoInicio; }
			set { _dataExibicaoInicio = value; }
		}

		public DateTime? DataExibicaoFim
		{
			get { return _dataExibicaoFim; }
			set { _dataExibicaoFim = value; }
		}

		public List<NoticiaIdioma> NoticiaIdiomas
		{
			get { return _noticiaIdiomas; }
			set { _noticiaIdiomas = value; }
		}

		public List<NoticiaImagem> NoticiaImagens
		{
			get { return _noticiaImagens; }
			set { _noticiaImagens = value; }
		}

		public Arquivo ArquivoThumbGrande
		{
			get { return _arquivoThumbGrande; }
			set { _arquivoThumbGrande = value; }
		}

		public Arquivo ArquivoThumbMedio
		{
			get { return _arquivoThumbMedio; }
			set { _arquivoThumbMedio = value; }
		}

		[NotNullValidator]
		public Conteudo Conteudo
		{
			get { return _conteudo; }
			set { _conteudo = value; }
		}

		/// <summary>
		/// Propriedade que informa se a entidade é válida para persistência.
		/// </summary>
		/// <returns>booleano informando se é a entidade é válida ou não.</returns>
		public bool Valido
		{
			get { return Validation.Validate<Noticia>(this).IsValid; }
		}

		/// <summary>
		/// Método que valida e retorna os dados de validação da entidade.
		/// </summary>
		/// <returns>ValidationResults contendo as informações da validação.</returns>
		public ValidationResults Validar()
		{
			return Validation.Validate<Noticia>(this);
		}
	}

	public struct NoticiaColunas
	{
		public static string NoticiaId = @"noticiaId";
		public static string Ativa = @"ativa";
		public static string Autor = @"autor";
		public static string DestaqueHome = @"destaqueHome";
		public static string DestaqueNoticias = @"destaqueNoticias";
		public static string DestaqueFiquePorDentro = @"destaqueFiquePorDentro";
		public static string DestaqueUltimasNoticias = @"destaqueUltimasNoticias";
		public static string Fonte = @"fonte";
		public static string FonteUrl = @"fonteUrl";
		public static string DataHoraPublicacao = @"dataHoraPublicacao";
		public static string DataExibicaoInicio = @"dataExibicaoInicio";
		public static string DataExibicaoFim = @"dataExibicaoFim";
		public static string ArquivoIdThumbGrande = @"arquivoIdThumbGrande";
		public static string ArquivoIdThumbMedio = @"arquivoIdThumbMedio";
	}
}
