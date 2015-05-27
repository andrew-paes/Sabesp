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
	public class Comunicado 
	{
		private bool _ativo;
		private bool _destaqueHome;
		private bool _destaqueFiquePorDentro;
		private DateTime _dataHoraPublicacao;
		private DateTime? _dataExibicaoInicio;
		private DateTime? _dataExibicaoFim;
		private List<ComunicadoIdioma> _comunicadoIdiomas;        
		private Conteudo _conteudo;

		public bool Ativo {
			get { return _ativo; }
			set { _ativo = value; }
		}

		public bool DestaqueHome {
			get { return _destaqueHome; }
			set { _destaqueHome = value; }
		}

		public bool DestaqueFiquePorDentro {
			get { return _destaqueFiquePorDentro; }
			set { _destaqueFiquePorDentro = value; }
		}

		[NotNullValidator]
		public DateTime DataHoraPublicacao {
			get { return _dataHoraPublicacao; }
			set { _dataHoraPublicacao = value; }
		}

		public DateTime? DataExibicaoInicio {
			get { return _dataExibicaoInicio; }
			set { _dataExibicaoInicio = value; }
		}

		public DateTime? DataExibicaoFim {
			get { return _dataExibicaoFim; }
			set { _dataExibicaoFim = value; }
		}

		public List<ComunicadoIdioma> ComunicadoIdiomas {
			get { return _comunicadoIdiomas; }
			set { _comunicadoIdiomas = value; }
		}

		[NotNullValidator]
		public Conteudo Conteudo {
			get { return _conteudo; }
			set { _conteudo = value; }
		}

	    /// <summary>
        /// Propriedade que informa se a entidade é válida para persistência.
        /// </summary>
        /// <returns>booleano informando se é a entidade é válida ou não.</returns>
        public bool Valido
        {
            get { return Validation.Validate<Comunicado>(this).IsValid; }
        }

        /// <summary>
        /// Método que valida e retorna os dados de validação da entidade.
        /// </summary>
        /// <returns>ValidationResults contendo as informações da validação.</returns>
        public ValidationResults Validar()
        {
            return Validation.Validate<Comunicado>(this);
        }
	}
	
	public struct ComunicadoColunas
	{	
		public static string ComunicadoId = @"comunicadoId";
		public static string Ativo = @"ativo";
		public static string DestaqueHome = @"destaqueHome";
		public static string DestaqueFiquePorDentro = @"destaqueFiquePorDentro";
		public static string DataHoraPublicacao = @"dataHoraPublicacao";
		public static string DataExibicaoInicio = @"dataExibicaoInicio";
		public static string DataExibicaoFim = @"dataExibicaoFim";
	}
}
		