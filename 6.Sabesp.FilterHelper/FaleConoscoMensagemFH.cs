
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
	public class FaleConoscoMensagemFH : IFilterHelper
	{
		private string _faleConoscoMensagemId;
		public string FaleConoscoMensagemId {
			get { return _faleConoscoMensagemId==null?String.Empty:_faleConoscoMensagemId; }
			set { _faleConoscoMensagemId=value; }
		}

		private string _faleConoscoAssuntoId;
		public string FaleConoscoAssuntoId {
			get { return _faleConoscoAssuntoId==null?String.Empty:_faleConoscoAssuntoId; }
			set { _faleConoscoAssuntoId=value; }
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

		private string _telefoneDDD;
		public string TelefoneDDD {
			get { return _telefoneDDD==null?String.Empty:_telefoneDDD; }
			set { _telefoneDDD=value; }
		}

		private string _telefoneComplemento;
		public string TelefoneComplemento {
			get { return _telefoneComplemento==null?String.Empty:_telefoneComplemento; }
			set { _telefoneComplemento=value; }
		}

		private string _estado;
		public string Estado {
			get { return _estado==null?String.Empty:_estado; }
			set { _estado=value; }
		}

		private string _cidade;
		public string Cidade {
			get { return _cidade==null?String.Empty:_cidade; }
			set { _cidade=value; }
		}

		private string _mensagem;
		public string Mensagem {
			get { return _mensagem==null?String.Empty:_mensagem; }
			set { _mensagem=value; }
		}

	
		public string GetWhereString() 
		{			
			StringBuilder sbWhere = new StringBuilder();

			if (!FaleConoscoMensagemId.Equals(String.Empty)) {
				sbWhere.Append(" AND (faleConoscoMensagemId="+FaleConoscoMensagemId+")");
			}

			if (!FaleConoscoAssuntoId.Equals(String.Empty)) {
				sbWhere.Append(" AND (faleConoscoAssuntoId="+FaleConoscoAssuntoId+")");
			}

			if (!Nome.Equals(String.Empty)) {
				sbWhere.Append(" AND (nome LIKE '%"+Nome+"%')");
			}

			if (!Email.Equals(String.Empty)) {
				sbWhere.Append(" AND (email LIKE '%"+Email+"%')");
			}

			if (!TelefoneDDD.Equals(String.Empty)) {
				sbWhere.Append(" AND (telefoneDDD="+TelefoneDDD+")");
			}

			if (!TelefoneComplemento.Equals(String.Empty)) {
				sbWhere.Append(" AND (telefoneComplemento="+TelefoneComplemento+")");
			}

			if (!Estado.Equals(String.Empty)) {
				sbWhere.Append(" AND (estado LIKE '%"+Estado+"%')");
			}

			if (!Cidade.Equals(String.Empty)) {
				sbWhere.Append(" AND (cidade LIKE '%"+Cidade+"%')");
			}

			if (!Mensagem.Equals(String.Empty)) {
				sbWhere.Append(" AND (mensagem LIKE '%"+Mensagem+"%')");
			}

	
			if (sbWhere.Length>0) // Remove o primeiro "AND "
				sbWhere.Remove(0,4);
			return sbWhere.ToString();
		}
	}
}
