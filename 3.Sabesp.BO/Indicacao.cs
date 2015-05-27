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
	public class Indicacao 
	{
		// Construtor
		public Indicacao() {}

		// Construtor com identificador
		public Indicacao(int indicacaoId) {
			_indicacaoId = indicacaoId;
		}

		private int _indicacaoId;
		private string _meio;
		private List<FormularioCursoVazamento> _formularioCursoVazamentos;

		public int IndicacaoId {
			get { return _indicacaoId; }
			set { _indicacaoId = value; }
		}

		[NotNullValidator]
		[StringLengthValidator(0, 100)]
		public string Meio {
			get { return _meio; }
			set { _meio = value; }
		}

		public List<FormularioCursoVazamento> FormularioCursoVazamentos {
			get { return _formularioCursoVazamentos; }
			set { _formularioCursoVazamentos = value; }
		}

	    /// <summary>
        /// Propriedade que informa se a entidade é válida para persistência.
        /// </summary>
        /// <returns>booleano informando se é a entidade é válida ou não.</returns>
        public bool Valido
        {
            get { return Validation.Validate<Indicacao>(this).IsValid; }
        }

        /// <summary>
        /// Método que valida e retorna os dados de validação da entidade.
        /// </summary>
        /// <returns>ValidationResults contendo as informações da validação.</returns>
        public ValidationResults Validar()
        {
            return Validation.Validate<Indicacao>(this);
        }
	}
	
	public struct IndicacaoColunas
	{	
		public static string IndicacaoId = @"indicacaoId";
		public static string Meio = @"meio";
	}
}
		