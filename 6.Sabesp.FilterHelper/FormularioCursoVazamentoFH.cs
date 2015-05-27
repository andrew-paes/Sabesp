
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
using System;
using System.Text;

namespace Sabesp.FilterHelper
{
	public class FormularioCursoVazamentoFH : IFilterHelper
	{
		private string _formularioCursoVazamentoId;
		public string FormularioCursoVazamentoId {
			get { return _formularioCursoVazamentoId==null?String.Empty:_formularioCursoVazamentoId; }
			set { _formularioCursoVazamentoId=value; }
		}

		private string _formularioId;
		public string FormularioId {
			get { return _formularioId==null?String.Empty:_formularioId; }
			set { _formularioId=value; }
		}

		private string _dataHoraContatoPeriodoInicial;
		/// <summary>
		/// Formato da string contendo data: YYYY/MM/DD.
		/// </summary>
		public string DataHoraContatoPeriodoInicial {
			get { return _dataHoraContatoPeriodoInicial==null?String.Empty:_dataHoraContatoPeriodoInicial; }
			set { _dataHoraContatoPeriodoInicial=value; }
		}
		private string _dataHoraContatoPeriodoFinal;
		/// <summary>
		/// Formato da string contendo data: YYYY/MM/DD.
		/// </summary>
		public string DataHoraContatoPeriodoFinal {
			get { return _dataHoraContatoPeriodoFinal==null?String.Empty:_dataHoraContatoPeriodoFinal; }
			set { _dataHoraContatoPeriodoFinal=value; }
		}

		private string _nome;
		public string Nome {
			get { return _nome==null?String.Empty:_nome; }
			set { _nome=value; }
		}

		private string _email;
		public string Email {
			get { return _email==null?String.Empty:_email; }
			set { _email=value; }
		}

		private string _cep;
		public string Cep {
			get { return _cep==null?String.Empty:_cep; }
			set { _cep=value; }
		}

		private string _estadoId;
		public string EstadoId {
			get { return _estadoId==null?String.Empty:_estadoId; }
			set { _estadoId=value; }
		}

		private string _cidade;
		public string Cidade {
			get { return _cidade==null?String.Empty:_cidade; }
			set { _cidade=value; }
		}

		private string _bairro;
		public string Bairro {
			get { return _bairro==null?String.Empty:_bairro; }
			set { _bairro=value; }
		}

		private string _endereco;
		public string Endereco {
			get { return _endereco==null?String.Empty:_endereco; }
			set { _endereco=value; }
		}

		private string _telefoneDDD;
		public string TelefoneDDD {
			get { return _telefoneDDD==null?String.Empty:_telefoneDDD; }
			set { _telefoneDDD=value; }
		}

		private string _telefoneNumero;
		public string TelefoneNumero {
			get { return _telefoneNumero==null?String.Empty:_telefoneNumero; }
			set { _telefoneNumero=value; }
		}

		private string _escolaridadeId;
		public string EscolaridadeId {
			get { return _escolaridadeId==null?String.Empty:_escolaridadeId; }
			set { _escolaridadeId=value; }
		}

		private string _escolaridadeOutro;
		public string EscolaridadeOutro {
			get { return _escolaridadeOutro==null?String.Empty:_escolaridadeOutro; }
			set { _escolaridadeOutro=value; }
		}

		private string _tipoImovelId;
		public string TipoImovelId {
			get { return _tipoImovelId==null?String.Empty:_tipoImovelId; }
			set { _tipoImovelId=value; }
		}

		private string _tipoImovelOutro;
		public string TipoImovelOutro {
			get { return _tipoImovelOutro==null?String.Empty:_tipoImovelOutro; }
			set { _tipoImovelOutro=value; }
		}

		private string _indicacaoId;
		public string IndicacaoId {
			get { return _indicacaoId==null?String.Empty:_indicacaoId; }
			set { _indicacaoId=value; }
		}

		private string _indicacaoOutro;
		public string IndicacaoOutro {
			get { return _indicacaoOutro==null?String.Empty:_indicacaoOutro; }
			set { _indicacaoOutro=value; }
		}

		private string _localCursoId;
		public string LocalCursoId {
			get { return _localCursoId==null?String.Empty:_localCursoId; }
			set { _localCursoId=value; }
		}

		private string _horarioPreferenciaId;
		public string HorarioPreferenciaId {
			get { return _horarioPreferenciaId==null?String.Empty:_horarioPreferenciaId; }
			set { _horarioPreferenciaId=value; }
		}

	
		public string GetWhereString() 
		{			
			StringBuilder sbWhere = new StringBuilder();

			if (!FormularioCursoVazamentoId.Equals(String.Empty)) {
				sbWhere.Append(" AND (formularioCursoVazamentoId="+FormularioCursoVazamentoId+")");
			}

			if (!FormularioId.Equals(String.Empty)) {
				sbWhere.Append(" AND (formularioId="+FormularioId+")");
			}

			if( !DataHoraContatoPeriodoInicial.Equals(String.Empty) && !DataHoraContatoPeriodoFinal.Equals(String.Empty)) {
				sbWhere.Append(" AND (dataHoraContato >='"+DataHoraContatoPeriodoInicial+"'");
				sbWhere.Append(" AND dataHoraContato <='"+DataHoraContatoPeriodoFinal+"')");
			} else if (!DataHoraContatoPeriodoInicial.Equals(String.Empty) ) {
				sbWhere.Append(" AND (dataHoraContato >='"+DataHoraContatoPeriodoInicial+"')");
			} else if (!DataHoraContatoPeriodoFinal.Equals(String.Empty) ) {
				sbWhere.Append(" AND (dataHoraContato <='"+DataHoraContatoPeriodoFinal+"')");
			}

			if (!Nome.Equals(String.Empty)) {
				sbWhere.Append(" AND (nome LIKE '%"+Nome+"%')");
			}

			if (!Email.Equals(String.Empty)) {
				sbWhere.Append(" AND (email LIKE '%"+Email+"%')");
			}

			if (!Cep.Equals(String.Empty)) {
				sbWhere.Append(" AND (cep LIKE '%"+Cep+"%')");
			}

			if (!EstadoId.Equals(String.Empty)) {
				sbWhere.Append(" AND (estadoId="+EstadoId+")");
			}

			if (!Cidade.Equals(String.Empty)) {
				sbWhere.Append(" AND (cidade LIKE '%"+Cidade+"%')");
			}

			if (!Bairro.Equals(String.Empty)) {
				sbWhere.Append(" AND (bairro LIKE '%"+Bairro+"%')");
			}

			if (!Endereco.Equals(String.Empty)) {
				sbWhere.Append(" AND (endereco LIKE '%"+Endereco+"%')");
			}

			if (!TelefoneDDD.Equals(String.Empty)) {
				sbWhere.Append(" AND (telefoneDDD LIKE '%"+TelefoneDDD+"%')");
			}

			if (!TelefoneNumero.Equals(String.Empty)) {
				sbWhere.Append(" AND (telefoneNumero LIKE '%"+TelefoneNumero+"%')");
			}

			if (!EscolaridadeId.Equals(String.Empty)) {
				sbWhere.Append(" AND (escolaridadeId="+EscolaridadeId+")");
			}

			if (!EscolaridadeOutro.Equals(String.Empty)) {
				sbWhere.Append(" AND (escolaridadeOutro LIKE '%"+EscolaridadeOutro+"%')");
			}

			if (!TipoImovelId.Equals(String.Empty)) {
				sbWhere.Append(" AND (tipoImovelId="+TipoImovelId+")");
			}

			if (!TipoImovelOutro.Equals(String.Empty)) {
				sbWhere.Append(" AND (tipoImovelOutro LIKE '%"+TipoImovelOutro+"%')");
			}

			if (!IndicacaoId.Equals(String.Empty)) {
				sbWhere.Append(" AND (indicacaoId="+IndicacaoId+")");
			}

			if (!IndicacaoOutro.Equals(String.Empty)) {
				sbWhere.Append(" AND (indicacaoOutro LIKE '%"+IndicacaoOutro+"%')");
			}

			if (!LocalCursoId.Equals(String.Empty)) {
				sbWhere.Append(" AND (localCursoId="+LocalCursoId+")");
			}

			if (!HorarioPreferenciaId.Equals(String.Empty)) {
				sbWhere.Append(" AND (horarioPreferenciaId="+HorarioPreferenciaId+")");
			}

	
			if (sbWhere.Length>0) // Remove o primeiro "AND "
				sbWhere.Remove(0,4);
			return sbWhere.ToString();
		}
	}
}
