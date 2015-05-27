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
	public class Escolaridade 
	{
		// Construtor
		public Escolaridade() {}

		// Construtor com identificador
		public Escolaridade(int escolaridadeId) {
			_escolaridadeId = escolaridadeId;
		}

		private int _escolaridadeId;
		private string _nomeEscolaridade;
		private List<FormularioCursoVazamento> _formularioCursoVazamentos;

		public int EscolaridadeId {
			get { return _escolaridadeId; }
			set { _escolaridadeId = value; }
		}

		[NotNullValidator]
		[StringLengthValidator(0, 50)]
		public string NomeEscolaridade {
			get { return _nomeEscolaridade; }
			set { _nomeEscolaridade = value; }
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
            get { return Validation.Validate<Escolaridade>(this).IsValid; }
        }

        /// <summary>
        /// Método que valida e retorna os dados de validação da entidade.
        /// </summary>
        /// <returns>ValidationResults contendo as informações da validação.</returns>
        public ValidationResults Validar()
        {
            return Validation.Validate<Escolaridade>(this);
        }
	}
	
	public struct EscolaridadeColunas
	{	
		public static string EscolaridadeId = @"escolaridadeId";
		public static string NomeEscolaridade = @"nomeEscolaridade";
	}
}
		