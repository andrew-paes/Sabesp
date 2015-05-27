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
	public class InfograficoIdioma
	{
		private string _titulo;
		private string _descricao;
		private Arquivo _arquivoIdAnimacao;
		private Idioma _idioma;
		private Infografico _infografico;

		public string Titulo
		{
			get { return _titulo; }
			set { _titulo = value; }
		}

		public string Descricao
		{
			get { return _descricao; }
			set { _descricao = value; }
		}

		public Arquivo ArquivoIdAnimacao
		{
			get { return _arquivoIdAnimacao; }
			set { _arquivoIdAnimacao = value; }
		}

		[NotNullValidator]
		public Idioma Idioma
		{
			get { return _idioma; }
			set { _idioma = value; }
		}

		[NotNullValidator]
		public Infografico Infografico
		{
			get { return _infografico; }
			set { _infografico = value; }
		}

		/// <summary>
		/// Propriedade que informa se a entidade é válida para persistência.
		/// </summary>
		/// <returns>booleano informando se é a entidade é válida ou não.</returns>
		public bool Valido
		{
			get { return Validation.Validate<InfograficoIdioma>(this).IsValid; }
		}

		/// <summary>
		/// Método que valida e retorna os dados de validação da entidade.
		/// </summary>
		/// <returns>ValidationResults contendo as informações da validação.</returns>
		public ValidationResults Validar()
		{
			return Validation.Validate<InfograficoIdioma>(this);
		}
	}

	public struct InfograficoIdiomaColunas
	{
		public static string InfograficoId = @"infograficoId";
		public static string IdiomaId = @"IdiomaId";
		public static string Titulo = @"titulo";
		public static string Descricao = @"descricao";
		public static string ArquivoIdAnimacao = @"arquivoIdAnimacao";
	}
}
