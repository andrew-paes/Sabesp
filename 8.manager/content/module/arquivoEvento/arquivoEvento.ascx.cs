using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using Ag2.Manager.Helper;
using Sabesp.Data;
using Sabesp.Data.Services;
using Sabesp.BO;
using Sabesp.FilterHelper;
using System.Collections;

public partial class content_module_arquivoevento_arquivoevento : SmartUserControl
{
	#region [Properties]

	public int EventoId
	{
		get
		{
			int _eventoId = 0;
			if (Request.QueryString["strIdRegistroPai"] != null)
			{
				try
				{
					_eventoId = Convert.ToInt32(Request.QueryString["strIdRegistroPai"]);
				}
				catch
				{
					_eventoId = 0;
				}
			}
			return _eventoId;
		}
	}

	#endregion

	#region [ Page Events ]

	/// <summary>
	/// 
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack || this.IdiomaHasChanged)
		{
			if (this.IdRegistro > 0)
			{
				this.LoadForm(this.IdRegistro.Value);
			}
		}
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void btnExecute_Click(object sender, ImageClickEventArgs e)
	{
		this.SaveEventoFoto(this.IdRegistro.Value);
	}

	#endregion

	#region [ Form ]
	/// <summary>
	/// Clear the form
	/// </summary>
	protected void ClearForm()
	{
		txtDescricao.Text = string.Empty;
		txtOrdem.Text = string.Empty;
	}

	/// <summary>
	/// 
	/// </summary>
	protected void LoadForm(int eventoFotoId)
	{
		EventoFotoService eventoFotoService = new EventoFotoService();
		EventoFoto eventoFoto = eventoFotoService.Carregar(new EventoFoto() { EventoFotoId = eventoFotoId });

		if (eventoFoto != null && eventoFoto.Arquivo != null)
		{
			EventoFotoComentarioService eventoFotoComentarioService = new EventoFotoComentarioService();
			EventoFotoComentario eventoFotoComentario = eventoFotoComentarioService.Carregar(new EventoFotoComentario() { EventoFoto = eventoFoto, Idioma = new Idioma() { IdiomaId = this.IdiomaId } });

			ArquivoService arquivoService = new ArquivoService();
			eventoFoto.Arquivo = arquivoService.Carregar(eventoFoto.Arquivo);

			if (eventoFoto.Arquivo != null)
			{
				uplField.FileName = eventoFoto.Arquivo.NomeArquivo;
				hddArquivoId.Value = eventoFoto.Arquivo.ArquivoId.ToString();
			}

			if (eventoFotoComentario != null)
			{
				txtDescricao.Text = eventoFotoComentario.ComentarioImagem;
				txtOrdem.Text = Convert.ToString(eventoFoto.Ordem);
			}
		}
	} 
	#endregion

	#region [ Save ]

	/// <summary>
	/// 
	/// </summary>
	/// <param name="eventoFotoId"></param>
	private void SaveEventoFoto(int eventoFotoId)
	{
		EventoFotoService eventoFotoService = new EventoFotoService();
		EventoFoto eventoFoto = null;
		Arquivo arquivo = this.SaveFile();

		if (arquivo != null)
		{
			if (eventoFotoId > 0)
			{
				eventoFoto = eventoFotoService.Carregar(new EventoFoto() { EventoFotoId = eventoFotoId });
				eventoFoto.Arquivo = arquivo;
				eventoFoto.Evento = new Evento() { Conteudo = new Conteudo(this.EventoId) };
				eventoFoto.Ordem = Convert.ToInt32(txtOrdem.Text);
				eventoFotoService.Atualizar(eventoFoto);

				Util.ShowMessage("Registro alterado com sucesso!");
			}
			else
			{
				eventoFoto = new EventoFoto();
				eventoFoto.Arquivo = arquivo;
				eventoFoto.Evento = new Evento() { Conteudo = new Conteudo(this.EventoId) };
				eventoFoto.Ordem = Convert.ToInt32(txtOrdem.Text);
				eventoFotoService.Inserir(eventoFoto);

				Util.ShowMessage("Registro salvo com sucesso!");
			}

			if (eventoFoto != null && eventoFoto.EventoFotoId > 0)
			{
				this.SaveImageComment(eventoFoto.EventoFotoId);

			}
		}
		else
		{
			Util.ShowMessage("Registro não atualizado. Erro ao salvar arquivo.");
		}
	}

	/// <summary>
	/// 
	/// </summary>
	/// <returns></returns>
	private Arquivo SaveFile()
	{
		ArquivoService arquivoService = new ArquivoService();
		Arquivo arquivo = new Arquivo();
		if (String.IsNullOrEmpty(hddArquivoId.Value))
		{
			arquivo.NomeArquivo = uplField.FileName;
			arquivo.Tamanho = 0;
			arquivo.Extensao = uplField.FileName.Substring(uplField.FileName.LastIndexOf("."), uplField.FileName.Length - uplField.FileName.LastIndexOf("."));
			arquivoService.Inserir(arquivo);
		}
		else
		{
			arquivo.ArquivoId = Convert.ToInt32(hddArquivoId.Value);
			arquivo.NomeArquivo = uplField.FileName;
			arquivo.Tamanho = 0;
			arquivo.Extensao = uplField.FileName.Substring(uplField.FileName.LastIndexOf("."), uplField.FileName.Length - uplField.FileName.LastIndexOf("."));
			arquivoService.Atualizar(arquivo);
		}

		return arquivo;
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="eventoFotoId"></param>
	private void SaveImageComment(int eventoFotoId)
	{
		EventoFotoComentarioService eventoFotoComentarioService = new EventoFotoComentarioService();
		EventoFotoComentario eventoFotoComentario = eventoFotoComentarioService.Carregar(new EventoFotoComentario() { EventoFoto = new EventoFoto() { EventoFotoId = eventoFotoId }, Idioma = new Idioma(this.IdiomaId) });

		if (eventoFotoComentario != null)
		{
			eventoFotoComentario.ComentarioImagem = txtDescricao.Text;
			eventoFotoComentarioService.Atualizar(eventoFotoComentario);
		}
		else
		{
			if (eventoFotoId > 0)
			{
				eventoFotoComentario = new EventoFotoComentario();
				eventoFotoComentario.Idioma = new Idioma(this.IdiomaId);
				eventoFotoComentario.ComentarioImagem = txtDescricao.Text;
				eventoFotoComentario.EventoFoto = new EventoFoto(eventoFotoId);
				eventoFotoComentarioService.Inserir(eventoFotoComentario);
			}
		}
	}

	#endregion
}