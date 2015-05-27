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
	public class Evento 
	{
		private bool _ativo;
		private DateTime? _dataHoraPublicacao;
		private DateTime? _dataHoraEventoInicio;
		private DateTime? _dataHoraEventoFim;
		private bool _destaqueEventos;
		private string _local;
		private bool _destaqueFiquePorDentro;
		private List<EventoCategoria> _eventoCategorias;
		private List<EventoFoto> _eventoFotos;
		private List<EventoIdioma> _eventoIdiomas;
		private Arquivo _arquivoThumbGrande;
		private Arquivo _arquivoThumbMedio;
		private Conteudo _conteudo;

		public bool Ativo {
			get { return _ativo; }
			set { _ativo = value; }
		}

		public DateTime? DataHoraPublicacao {
			get { return _dataHoraPublicacao; }
			set { _dataHoraPublicacao = value; }
		}

		public DateTime? DataHoraEventoInicio {
			get { return _dataHoraEventoInicio; }
			set { _dataHoraEventoInicio = value; }
		}

		public DateTime? DataHoraEventoFim {
			get { return _dataHoraEventoFim; }
			set { _dataHoraEventoFim = value; }
		}

		public bool DestaqueEventos {
			get { return _destaqueEventos; }
			set { _destaqueEventos = value; }
		}

		public string Local {
			get { return _local; }
			set { _local = value; }
		}

		public bool DestaqueFiquePorDentro {
			get { return _destaqueFiquePorDentro; }
			set { _destaqueFiquePorDentro = value; }
		}

		public List<EventoCategoria> EventoCategorias {
			get { return _eventoCategorias; }
			set { _eventoCategorias = value; }
		}

		public List<EventoFoto> EventoFotos {
			get { return _eventoFotos; }
			set { _eventoFotos = value; }
		}

		public List<EventoIdioma> EventoIdiomas {
			get { return _eventoIdiomas; }
			set { _eventoIdiomas = value; }
		}

		public Arquivo ArquivoThumbGrande {
			get { return _arquivoThumbGrande; }
			set { _arquivoThumbGrande = value; }
		}

		public Arquivo ArquivoThumbMedio {
			get { return _arquivoThumbMedio; }
			set { _arquivoThumbMedio = value; }
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
            get { return Validation.Validate<Evento>(this).IsValid; }
        }

        /// <summary>
        /// Método que valida e retorna os dados de validação da entidade.
        /// </summary>
        /// <returns>ValidationResults contendo as informações da validação.</returns>
        public ValidationResults Validar()
        {
            return Validation.Validate<Evento>(this);
        }
	}
	
	public struct EventoColunas
	{	
		public static string EventoId = @"eventoId";
		public static string Ativo = @"ativo";
		public static string DataHoraPublicacao = @"dataHoraPublicacao";
		public static string DataHoraEventoInicio = @"dataHoraEventoInicio";
		public static string DataHoraEventoFim = @"dataHoraEventoFim";
		public static string ArquivoIdThumbGrande = @"arquivoIdThumbGrande";
		public static string ArquivoIdThumbMedio = @"arquivoIdThumbMedio";
		public static string DestaqueEventos = @"destaqueEventos";
		public static string Local = @"local";
		public static string DestaqueFiquePorDentro = @"destaqueFiquePorDentro";
	}
}
		