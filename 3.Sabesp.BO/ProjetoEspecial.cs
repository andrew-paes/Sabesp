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
	public class ProjetoEspecial
	{
		// Construtor
		public ProjetoEspecial() { }

		// Construtor com identificador
		public ProjetoEspecial(int projetoEspecialId)
		{
			_projetoEspecialId = projetoEspecialId;
		}

		private int _projetoEspecialId;
		private bool _ativo;
		private string _url;
		private List<ProjetoEspecialIdioma> _projetoEspecialIdiomas;
		private Arquivo _arquivoThumbId;

		public int ProjetoEspecialId
		{
			get { return _projetoEspecialId; }
			set { _projetoEspecialId = value; }
		}

		public bool Ativo
		{
			get { return _ativo; }
			set { _ativo = value; }
		}

		public string Url
		{
			get { return _url; }
			set { _url = value; }
		}

		public List<ProjetoEspecialIdioma> ProjetoEspecialIdiomas
		{
			get { return _projetoEspecialIdiomas; }
			set { _projetoEspecialIdiomas = value; }
		}

		public Arquivo ArquivoThumbId
		{
			get { return _arquivoThumbId; }
			set { _arquivoThumbId = value; }
		}

		/// <summary>
		/// Propriedade que informa se a entidade é válida para persistência.
		/// </summary>
		/// <returns>booleano informando se é a entidade é válida ou não.</returns>
		public bool Valido
		{
			get { return Validation.Validate<ProjetoEspecial>(this).IsValid; }
		}

		/// <summary>
		/// Método que valida e retorna os dados de validação da entidade.
		/// </summary>
		/// <returns>ValidationResults contendo as informações da validação.</returns>
		public ValidationResults Validar()
		{
			return Validation.Validate<ProjetoEspecial>(this);
		}
	}

	public struct ProjetoEspecialColunas
	{
		public static string ProjetoEspecialId = @"projetoEspecialId";
		public static string Ativo = @"ativo";
		public static string Url = @"url";
		public static string ArquivoThumbId = @"arquivoThumbId";
	}
}
