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
	public class HorarioPreferencia 
	{
		// Construtor
		public HorarioPreferencia() {}

		// Construtor com identificador
		public HorarioPreferencia(int horarioPreferenciaId) {
			_horarioPreferenciaId = horarioPreferenciaId;
		}

		private int _horarioPreferenciaId;
		private string _horario;
		private List<FormularioCursoVazamento> _formularioCursoVazamentos;

		public int HorarioPreferenciaId {
			get { return _horarioPreferenciaId; }
			set { _horarioPreferenciaId = value; }
		}

		[NotNullValidator]
		[StringLengthValidator(0, 50)]
		public string Horario {
			get { return _horario; }
			set { _horario = value; }
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
            get { return Validation.Validate<HorarioPreferencia>(this).IsValid; }
        }

        /// <summary>
        /// Método que valida e retorna os dados de validação da entidade.
        /// </summary>
        /// <returns>ValidationResults contendo as informações da validação.</returns>
        public ValidationResults Validar()
        {
            return Validation.Validate<HorarioPreferencia>(this);
        }
	}
	
	public struct HorarioPreferenciaColunas
	{	
		public static string HorarioPreferenciaId = @"horarioPreferenciaId";
		public static string Horario = @"horario";
	}
}
		