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
	public class Cidade 
	{
		// Construtor
		public Cidade() {}

		// Construtor com identificador
		public Cidade(int cidadeId) {
			_cidadeId = cidadeId;
		}

		private int _cidadeId;
		private string _nomeCidade;
		private Estado _estado;

		public int CidadeId {
			get { return _cidadeId; }
			set { _cidadeId = value; }
		}

		[NotNullValidator]
		[StringLengthValidator(0, 150)]
		public string NomeCidade {
			get { return _nomeCidade; }
			set { _nomeCidade = value; }
		}

		[NotNullValidator]
		public Estado Estado {
			get { return _estado; }
			set { _estado = value; }
		}

	    /// <summary>
        /// Propriedade que informa se a entidade é válida para persistência.
        /// </summary>
        /// <returns>booleano informando se é a entidade é válida ou não.</returns>
        public bool Valido
        {
            get { return Validation.Validate<Cidade>(this).IsValid; }
        }

        /// <summary>
        /// Método que valida e retorna os dados de validação da entidade.
        /// </summary>
        /// <returns>ValidationResults contendo as informações da validação.</returns>
        public ValidationResults Validar()
        {
            return Validation.Validate<Cidade>(this);
        }
	}
	
	public struct CidadeColunas
	{	
		public static string CidadeId = @"cidadeId";
		public static string NomeCidade = @"nomeCidade";
		public static string EstadoId = @"estadoId";
	}
}
		