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
	public class Infografico
	{
		private Arquivo _arquivoIdImagem;
		private List<InfograficoIdioma> _infograficoIdiomas;
		private Conteudo _conteudo;
        private int _infograficoId;
		public Arquivo ArquivoIdImagem
		{
			get { return _arquivoIdImagem; }
			set { _arquivoIdImagem = value; }
		}

		public List<InfograficoIdioma> InfograficoIdiomas
		{
			get { return _infograficoIdiomas; }
			set { _infograficoIdiomas = value; }
		}
        public int infograficoId
        {
            get { return _infograficoId; }
            set { _infograficoId = value; }
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
			get { return Validation.Validate<Infografico>(this).IsValid; }
		}

		/// <summary>
		/// Método que valida e retorna os dados de validação da entidade.
		/// </summary>
		/// <returns>ValidationResults contendo as informações da validação.</returns>
		public ValidationResults Validar()
		{
			return Validation.Validate<Infografico>(this);
		}
	}

	public struct InfograficoColunas
	{
		public static string InfograficoId = @"infograficoId";
		public static string ArquivoIdImagem = @"arquivoIdImagem";
	}
}
