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
	public class FormularioInvestidorQualificacao 
	{
		// Construtor
		public FormularioInvestidorQualificacao() {}

		// Construtor com identificador
		public FormularioInvestidorQualificacao(int formularioInvestidorQualificacaoId) {
			_formularioInvestidorQualificacaoId = formularioInvestidorQualificacaoId;
		}

		private int _formularioInvestidorQualificacaoId;
		private string _qualificacao;
		private List<FormularioInvestidor> _formularioInvestidores;

		public int FormularioInvestidorQualificacaoId {
			get { return _formularioInvestidorQualificacaoId; }
			set { _formularioInvestidorQualificacaoId = value; }
		}

		[NotNullValidator]
		[StringLengthValidator(0, 100)]
		public string Qualificacao {
			get { return _qualificacao; }
			set { _qualificacao = value; }
		}

		public List<FormularioInvestidor> FormularioInvestidores {
			get { return _formularioInvestidores; }
			set { _formularioInvestidores = value; }
		}

	    /// <summary>
        /// Propriedade que informa se a entidade é válida para persistência.
        /// </summary>
        /// <returns>booleano informando se é a entidade é válida ou não.</returns>
        public bool Valido
        {
            get { return Validation.Validate<FormularioInvestidorQualificacao>(this).IsValid; }
        }

        /// <summary>
        /// Método que valida e retorna os dados de validação da entidade.
        /// </summary>
        /// <returns>ValidationResults contendo as informações da validação.</returns>
        public ValidationResults Validar()
        {
            return Validation.Validate<FormularioInvestidorQualificacao>(this);
        }
	}
	
	public struct FormularioInvestidorQualificacaoColunas
	{	
		public static string FormularioInvestidorQualificacaoId = @"formularioInvestidorQualificacaoId";
		public static string Qualificacao = @"qualificacao";
	}
}
		