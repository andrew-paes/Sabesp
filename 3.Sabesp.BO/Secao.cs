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
	public class Secao
	{
		private int _secaoId;
		private Secao _secaoPai;
		private Modelo _modelo;
		private int? _ordem;
		private int? _avaliacaoSomaNotas;
		private int? _avaliacoes;
		private bool? _acessoRapido;
		private string _estadoPublicacao;
		private int? _redirecionaId;
		private bool? _secaoAutenticada;
		private bool? _habilitaBoxRSS;
		private bool? _comentar;
		private bool? _avaliar;
		private bool? _compartilhar;
		private bool? _exibeNoMenu;
		private bool? _exibeNaHome;
		private int? _posicaoHome;
		private List<SecaoIdioma> _secaoIdiomas;


		public int SecaoId
		{
			get { return _secaoId; }
			set { _secaoId = value; }
		}

		public Secao SecaoPai
		{
			get { return _secaoPai; }
			set { _secaoPai = value; }
		}

		public Modelo Modelo
		{
			get { return _modelo; }
			set { _modelo = value; }
		}

		public int? Ordem
		{
			get { return _ordem; }
			set { _ordem = value; }
		}

		public int? AvaliacaoSomaNotas
		{
			get { return _avaliacaoSomaNotas; }
			set { _avaliacaoSomaNotas = value; }
		}

		public int? Avaliacoes
		{
			get { return _avaliacoes; }
			set { _avaliacoes = value; }
		}

		public bool? AcessoRapido
		{
			get { return _acessoRapido; }
			set { _acessoRapido = value; }
		}

		public string EstadoPublicacao
		{
			get { return _estadoPublicacao; }
			set { _estadoPublicacao = value; }
		}

		public int? RedirecionaId
		{
			get { return _redirecionaId; }
			set { _redirecionaId = value; }
		}

		public bool? SecaoAutenticada
		{
			get { return _secaoAutenticada; }
			set { _secaoAutenticada = value; }
		}

		public bool? HabilitaBoxRSS
		{
			get { return _habilitaBoxRSS; }
			set { _habilitaBoxRSS = value; }
		}

		public bool? Comentar
		{
			get { return _comentar; }
			set { _comentar = value; }
		}

		public bool? Avaliar
		{
			get { return _avaliar; }
			set { _avaliar = value; }
		}

		public bool? Compartilhar
		{
			get { return _compartilhar; }
			set { _compartilhar = value; }
		}

		public bool? ExibeNoMenu
		{
			get { return _exibeNoMenu; }
			set { _exibeNoMenu = value; }
		}

		public bool? ExibeNaHome
		{
			get { return _exibeNaHome; }
			set { _exibeNaHome = value; }
		}

		public int? PosicaoHome
		{
			get { return _posicaoHome; }
			set { _posicaoHome = value; }
		}

		public List<SecaoIdioma> SecaoIdiomas
		{
			get { return _secaoIdiomas; }
			set { _secaoIdiomas = value; }
		}

		/// <summary>
		/// Propriedade que informa se a entidade é válida para persistência.
		/// </summary>
		/// <returns>booleano informando se é a entidade é válida ou não.</returns>
		public bool Valido
		{
			get { return Validation.Validate<Secao>(this).IsValid; }
		}

		/// <summary>
		/// Método que valida e retorna os dados de validação da entidade.
		/// </summary>
		/// <returns>ValidationResults contendo as informações da validação.</returns>
		public ValidationResults Validar()
		{
			return Validation.Validate<Secao>(this);
		}
	}

	public struct SecaoColunas
	{
		public static string SecaoId = @"secaoId";
		public static string SecaoIdPai = @"secaoIdPai";
		public static string ModeloId = @"modeloId";
		public static string Ordem = @"ordem";
		public static string AvaliacaoSomaNotas = @"avaliacaoSomaNotas";
		public static string Avaliacoes = @"avaliacoes";
		public static string AcessoRapido = @"acessoRapido";
		public static string EstadoPublicacao = @"estadoPublicacao";
		public static string RedirecionaId = @"redirecionaId";
		public static string SecaoAutenticada = @"secaoAutenticada";
		public static string HabilitaBoxRSS = @"habilitaBoxRSS";
		public static string Comentar = @"comentar";
		public static string Avaliar = @"avaliar";
		public static string Compartilhar = @"compartilhar";
		public static string ExibeNoMenu = @"exibeNoMenu";
		public static string ExibeNaHome = @"exibeNaHome";
		public static string PosicaoHome = @"posicaoHome";
	}
}
