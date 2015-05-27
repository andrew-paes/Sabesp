
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
	public class FormularioVideoteca1FH : IFilterHelper
	{
		private string _formularioVideoteca1Id;
		public string FormularioVideoteca1Id {
			get { return _formularioVideoteca1Id==null?String.Empty:_formularioVideoteca1Id; }
			set { _formularioVideoteca1Id=value; }
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

		private string _profissao;
		public string Profissao {
			get { return _profissao==null?String.Empty:_profissao; }
			set { _profissao=value; }
		}

		private string _empresa;
		public string Empresa {
			get { return _empresa==null?String.Empty:_empresa; }
			set { _empresa=value; }
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

		private string _interesseGotaBorralheira;
		public string InteresseGotaBorralheira {
			get { return _interesseGotaBorralheira==null?String.Empty:_interesseGotaBorralheira; }
			set { _interesseGotaBorralheira=value; }
		}

		private string _interesseAguaNaBoca;
		public string InteresseAguaNaBoca {
			get { return _interesseAguaNaBoca==null?String.Empty:_interesseAguaNaBoca; }
			set { _interesseAguaNaBoca=value; }
		}

		private string _interesseAguaVideos;
		public string InteresseAguaVideos {
			get { return _interesseAguaVideos==null?String.Empty:_interesseAguaVideos; }
			set { _interesseAguaVideos=value; }
		}

		private string _interesseChuaChuagua;
		public string InteresseChuaChuagua {
			get { return _interesseChuaChuagua==null?String.Empty:_interesseChuaChuagua; }
			set { _interesseChuaChuagua=value; }
		}

		private string _interesseTratamento;
		public string InteresseTratamento {
			get { return _interesseTratamento==null?String.Empty:_interesseTratamento; }
			set { _interesseTratamento=value; }
		}

		private string _interesseSuperH20;
		public string InteresseSuperH20 {
			get { return _interesseSuperH20==null?String.Empty:_interesseSuperH20; }
			set { _interesseSuperH20=value; }
		}

	
		public string GetWhereString() 
		{			
			StringBuilder sbWhere = new StringBuilder();

			if (!FormularioVideoteca1Id.Equals(String.Empty)) {
				sbWhere.Append(" AND (formularioVideoteca1Id="+FormularioVideoteca1Id+")");
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

			if (!Profissao.Equals(String.Empty)) {
				sbWhere.Append(" AND (profissao LIKE '%"+Profissao+"%')");
			}

			if (!Empresa.Equals(String.Empty)) {
				sbWhere.Append(" AND (empresa LIKE '%"+Empresa+"%')");
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

			if (!InteresseGotaBorralheira.Equals(String.Empty)) {
				sbWhere.Append(" AND (interesseGotaBorralheira LIKE '%"+InteresseGotaBorralheira+"%')");
			}

			if (!InteresseAguaNaBoca.Equals(String.Empty)) {
				sbWhere.Append(" AND (interesseAguaNaBoca LIKE '%"+InteresseAguaNaBoca+"%')");
			}

			if (!InteresseAguaVideos.Equals(String.Empty)) {
				sbWhere.Append(" AND (interesseAguaVideos LIKE '%"+InteresseAguaVideos+"%')");
			}

			if (!InteresseChuaChuagua.Equals(String.Empty)) {
				sbWhere.Append(" AND (interesseChuaChuagua LIKE '%"+InteresseChuaChuagua+"%')");
			}

			if (!InteresseTratamento.Equals(String.Empty)) {
				sbWhere.Append(" AND (interesseTratamento LIKE '%"+InteresseTratamento+"%')");
			}

			if (!InteresseSuperH20.Equals(String.Empty)) {
				sbWhere.Append(" AND (interesseSuperH20 LIKE '%"+InteresseSuperH20+"%')");
			}

	
			if (sbWhere.Length>0) // Remove o primeiro "AND "
				sbWhere.Remove(0,4);
			return sbWhere.ToString();
		}
	}
}
