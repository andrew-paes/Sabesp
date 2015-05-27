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
	public class Formulario
	{
		// Construtor
		public Formulario() { }

		// Construtor com identificador
		public Formulario(int formularioId)
		{
			_formularioId = formularioId;
		}

		private int _formularioId;
		private string _nomeFormulario;
		private bool? _ativo;
		private List<FormularioApoioInstitucional> _formularioApoioInstitucionais;
		private List<FormularioCicloConferencia> _formularioCicloConferencias;
		private List<Contato> _contatos;
		private List<FormularioCursoVazamento> _formularioCursoVazamentos;
		private List<FormularioImprensa> _formularioImprensas;
		private List<FormularioInvestidor> _formularioInvestidores;
		private List<FormularioSegurancaTrabalho> _formularioSegurancaTrabalhos;
		private List<FormularioVideoteca> _formularioVideotecas;
		private List<FormularioVideoteca1> _formularioVideoteca1es;

		public int FormularioId
		{
			get { return _formularioId; }
			set { _formularioId = value; }
		}

		[NotNullValidator]
		[StringLengthValidator(0, 100)]
		public string NomeFormulario
		{
			get { return _nomeFormulario; }
			set { _nomeFormulario = value; }
		}

		public bool? Ativo
		{
			get { return _ativo; }
			set { _ativo = value; }
		}

		public List<FormularioApoioInstitucional> FormularioApoioInstitucionais
		{
			get { return _formularioApoioInstitucionais; }
			set { _formularioApoioInstitucionais = value; }
		}

		public List<FormularioCicloConferencia> FormularioCicloConferencias
		{
			get { return _formularioCicloConferencias; }
			set { _formularioCicloConferencias = value; }
		}

		public List<Contato> Contatos
		{
			get { return _contatos; }
			set { _contatos = value; }
		}

		public List<FormularioCursoVazamento> FormularioCursoVazamentos
		{
			get { return _formularioCursoVazamentos; }
			set { _formularioCursoVazamentos = value; }
		}

		public List<FormularioImprensa> FormularioImprensas
		{
			get { return _formularioImprensas; }
			set { _formularioImprensas = value; }
		}

		public List<FormularioInvestidor> FormularioInvestidores
		{
			get { return _formularioInvestidores; }
			set { _formularioInvestidores = value; }
		}

		public List<FormularioSegurancaTrabalho> FormularioSegurancaTrabalhos
		{
			get { return _formularioSegurancaTrabalhos; }
			set { _formularioSegurancaTrabalhos = value; }
		}

		public List<FormularioVideoteca> FormularioVideotecas
		{
			get { return _formularioVideotecas; }
			set { _formularioVideotecas = value; }
		}

		public List<FormularioVideoteca1> FormularioVideoteca1es
		{
			get { return _formularioVideoteca1es; }
			set { _formularioVideoteca1es = value; }
		}

		/// <summary>
		/// Propriedade que informa se a entidade é válida para persistência.
		/// </summary>
		/// <returns>booleano informando se é a entidade é válida ou não.</returns>
		public bool Valido
		{
			get { return Validation.Validate<Formulario>(this).IsValid; }
		}

		/// <summary>
		/// Método que valida e retorna os dados de validação da entidade.
		/// </summary>
		/// <returns>ValidationResults contendo as informações da validação.</returns>
		public ValidationResults Validar()
		{
			return Validation.Validate<Formulario>(this);
		}
	}

	public struct FormularioColunas
	{
		public static string FormularioId = @"formularioId";
		public static string NomeFormulario = @"nomeFormulario";
		public static string Ativo = @"ativo";
	}
}
