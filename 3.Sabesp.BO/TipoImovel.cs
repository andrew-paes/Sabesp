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
	public class TipoImovel 
	{
		// Construtor
		public TipoImovel() {}

		// Construtor com identificador
		public TipoImovel(int tipoImovelId) {
			_tipoImovelId = tipoImovelId;
		}

		private int _tipoImovelId;
		private string _tipo;
		private List<FormularioCursoVazamento> _formularioCursoVazamentos;

		public int TipoImovelId {
			get { return _tipoImovelId; }
			set { _tipoImovelId = value; }
		}

		[NotNullValidator]
		[StringLengthValidator(0, 100)]
		public string Tipo {
			get { return _tipo; }
			set { _tipo = value; }
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
            get { return Validation.Validate<TipoImovel>(this).IsValid; }
        }

        /// <summary>
        /// Método que valida e retorna os dados de validação da entidade.
        /// </summary>
        /// <returns>ValidationResults contendo as informações da validação.</returns>
        public ValidationResults Validar()
        {
            return Validation.Validate<TipoImovel>(this);
        }
	}
	
	public struct TipoImovelColunas
	{	
		public static string TipoImovelId = @"tipoImovelId";
		public static string Tipo = @"tipo";
	}
}
		