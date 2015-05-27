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
	public class ProjetoEspecialIdioma
	{
		private string _tituloProjeto;
		private string _chamadaProjeto;
		private Idioma _idioma;
		private ProjetoEspecial _projetoEspecial;

		public string TituloProjeto
		{
			get { return _tituloProjeto; }
			set { _tituloProjeto = value; }
		}

		public string ChamadaProjeto
		{
			get { return _chamadaProjeto; }
			set { _chamadaProjeto = value; }
		}

		[NotNullValidator]
		public Idioma Idioma
		{
			get { return _idioma; }
			set { _idioma = value; }
		}

		[NotNullValidator]
		public ProjetoEspecial ProjetoEspecial
		{
			get { return _projetoEspecial; }
			set { _projetoEspecial = value; }
		}

		/// <summary>
		/// Propriedade que informa se a entidade é válida para persistência.
		/// </summary>
		/// <returns>booleano informando se é a entidade é válida ou não.</returns>
		public bool Valido
		{
			get { return Validation.Validate<ProjetoEspecialIdioma>(this).IsValid; }
		}

		/// <summary>
		/// Método que valida e retorna os dados de validação da entidade.
		/// </summary>
		/// <returns>ValidationResults contendo as informações da validação.</returns>
		public ValidationResults Validar()
		{
			return Validation.Validate<ProjetoEspecialIdioma>(this);
		}
	}

	public struct ProjetoEspecialIdiomaColunas
	{
		public static string ProjetoEspecialId = @"projetoEspecialId";
		public static string IdiomaId = @"idiomaId";
		public static string TituloProjeto = @"tituloProjeto";
		public static string ChamadaProjeto = @"chamadaProjeto";
	}
}
