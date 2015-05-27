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
	public class Estado 
	{
		// Construtor
		public Estado() {}

		// Construtor com identificador
		public Estado(int estadoId) {
			_estadoId = estadoId;
		}

		private int _estadoId;
		private string _uf;
		private string _nomeEstado;
		private List<Cidade> _cidades;

		public int EstadoId {
			get { return _estadoId; }
			set { _estadoId = value; }
		}

		[NotNullValidator]
		[StringLengthValidator(0, 2)]
		public string Uf {
			get { return _uf; }
			set { _uf = value; }
		}

		[NotNullValidator]
		[StringLengthValidator(0, 150)]
		public string NomeEstado {
			get { return _nomeEstado; }
			set { _nomeEstado = value; }
		}

		public List<Cidade> Cidades {
			get { return _cidades; }
			set { _cidades = value; }
		}

	    /// <summary>
        /// Propriedade que informa se a entidade é válida para persistência.
        /// </summary>
        /// <returns>booleano informando se é a entidade é válida ou não.</returns>
        public bool Valido
        {
            get { return Validation.Validate<Estado>(this).IsValid; }
        }

        /// <summary>
        /// Método que valida e retorna os dados de validação da entidade.
        /// </summary>
        /// <returns>ValidationResults contendo as informações da validação.</returns>
        public ValidationResults Validar()
        {
            return Validation.Validate<Estado>(this);
        }
	}
	
	public struct EstadoColunas
	{	
		public static string EstadoId = @"estadoId";
		public static string Uf = @"uf";
		public static string NomeEstado = @"nomeEstado";
	}
}
		