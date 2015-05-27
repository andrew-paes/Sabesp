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
	public class Controle
	{
		// Construtor
		public Controle() { }

		// Construtor com identificador
		public Controle(int controleId)
		{
			_controleId = controleId;
		}

		private int _controleId;
		private string _nome;
		private bool? _ativo;
		private List<ControleIdioma> _controleIdiomas;
		private List<ControleSessao> _controleSessoes;
		private ControleTipo _controleTipo;

		public int ControleId
		{
			get { return _controleId; }
			set { _controleId = value; }
		}

		public string Nome
		{
			get { return _nome; }
			set { _nome = value; }
		}

		public bool? Ativo
		{
			get { return _ativo; }
			set { _ativo = value; }
		}

		public List<ControleIdioma> ControleIdiomas
		{
			get { return _controleIdiomas; }
			set { _controleIdiomas = value; }
		}

		public List<ControleSessao> ControleSessoes
		{
			get { return _controleSessoes; }
			set { _controleSessoes = value; }
		}

		[NotNullValidator]
		public ControleTipo ControleTipo
		{
			get { return _controleTipo; }
			set { _controleTipo = value; }
		}

		/// <summary>
		/// Propriedade que informa se a entidade é válida para persistência.
		/// </summary>
		/// <returns>booleano informando se é a entidade é válida ou não.</returns>
		public bool Valido
		{
			get { return Validation.Validate<Controle>(this).IsValid; }
		}

		/// <summary>
		/// Método que valida e retorna os dados de validação da entidade.
		/// </summary>
		/// <returns>ValidationResults contendo as informações da validação.</returns>
		public ValidationResults Validar()
		{
			return Validation.Validate<Controle>(this);
		}
	}

	public struct ControleColunas
	{
		public static string ControleId = @"controleId";
		public static string ControleTipoId = @"controleTipoId";
		public static string Nome = @"nome";
		public static string Ativo = @"ativo";
	}
}
