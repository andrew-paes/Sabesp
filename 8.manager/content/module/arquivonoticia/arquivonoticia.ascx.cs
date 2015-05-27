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

public partial class content_module_arquivonoticia_arquivonoticia : SmartUserControl
{
	#region [Properties]

	public int NoticiaId
	{
		get
		{
			int _noticiaId = 0;
			if (Request.QueryString["strIdRegistroPai"] != null)
			{
				try
				{
					_noticiaId = Convert.ToInt32(Request.QueryString["strIdRegistroPai"]);
				}
				catch
				{
					_noticiaId = 0;
				}
			}
			return _noticiaId;
		}
	}

	#endregion

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

	protected void btnExecute_Click(object sender, ImageClickEventArgs e)
	{
		this.SaveNoticiaImagem(this.IdRegistro.Value);
	}


	/// <summary>
	/// 
	/// </summary>
	protected void LoadForm(int noticiaImagemId)
	{
		NoticiaImagemService noticiaImagemService = new NoticiaImagemService();
		NoticiaImagem noticiaImagem = noticiaImagemService.Carregar(new NoticiaImagem() { NoticiaImagemId = noticiaImagemId });

		if (noticiaImagem != null && noticiaImagem.Arquivo != null)
		{
			NoticiaImagemComentarioService noticiaImagemComentarioService = new NoticiaImagemComentarioService();
			NoticiaImagemComentario noticiaImagemComentario = noticiaImagemComentarioService.Carregar(new NoticiaImagemComentario() { NoticiaImagem = noticiaImagem, Idioma = new Idioma() { IdiomaId = this.IdiomaId } });

			ArquivoService arquivoService = new ArquivoService();
			noticiaImagem.Arquivo = arquivoService.Carregar(noticiaImagem.Arquivo);

			if (noticiaImagem.Arquivo != null)
			{
				uplField.FileName = noticiaImagem.Arquivo.NomeArquivo;
				hddArquivoId.Value = noticiaImagem.Arquivo.ArquivoId.ToString();
			}

			if (noticiaImagemComentario != null)
			{
				txtDescricao.Text = noticiaImagemComentario.ComentarioImagem;
				txtOrdem.Text = Convert.ToString(noticiaImagem.Ordem);
			}
		}
	}


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

	private void SaveNoticiaImagem(int noticiaImagemId)
	{
		NoticiaImagemService noticiaImagemService = new NoticiaImagemService();
		NoticiaImagem noticiaImagem = null;
		Arquivo arquivo = this.SaveFile();

		if (arquivo != null)
		{
			if (noticiaImagemId > 0)
			{
				noticiaImagem = noticiaImagemService.Carregar(new NoticiaImagem() { NoticiaImagemId = noticiaImagemId });
				noticiaImagem.Arquivo = arquivo;
				noticiaImagem.Noticia = new Noticia() { Conteudo = new Conteudo(this.NoticiaId) };
				noticiaImagem.Ordem = Convert.ToInt32(txtOrdem.Text);
				noticiaImagemService.Atualizar(noticiaImagem);

				Util.ShowMessage("Registro alterado com sucesso!");
			}
			else
			{
				noticiaImagem = new NoticiaImagem();
				noticiaImagem.Arquivo = arquivo;
				noticiaImagem.Noticia = new Noticia() { Conteudo = new Conteudo(this.NoticiaId) };
				noticiaImagem.Ordem = Convert.ToInt32(txtOrdem.Text);
				noticiaImagemService.Inserir(noticiaImagem);

				Util.ShowMessage("Registro salvo com sucesso!");
			}

			if (noticiaImagem != null && noticiaImagem.NoticiaImagemId > 0)
			{
				this.SaveImageComment(noticiaImagem.NoticiaImagemId);

			}
		}
		else
		{
			Util.ShowMessage("Registro não atualizado. Erro ao salvar arquivo.");
		}
	}

	private void SaveImageComment(int noticiaImagemId)
	{
		NoticiaImagemComentarioService noticiaImagemComentarioService = new NoticiaImagemComentarioService();
		NoticiaImagemComentario noticiaImagemComentario = noticiaImagemComentarioService.Carregar(new NoticiaImagemComentario() { NoticiaImagem = new NoticiaImagem() { NoticiaImagemId = noticiaImagemId }, Idioma = new Idioma(this.IdiomaId) });

		if (noticiaImagemComentario != null)
		{
			noticiaImagemComentario.ComentarioImagem = txtDescricao.Text;
			noticiaImagemComentarioService.Atualizar(noticiaImagemComentario);
		}
		else
		{
			if (noticiaImagemId > 0)
			{
				noticiaImagemComentario = new NoticiaImagemComentario();
				noticiaImagemComentario.Idioma = new Idioma(this.IdiomaId);
				noticiaImagemComentario.ComentarioImagem = txtDescricao.Text;
				noticiaImagemComentario.NoticiaImagem = new NoticiaImagem(noticiaImagemId);
				noticiaImagemComentarioService.Inserir(noticiaImagemComentario);
			}
		}
	}


	/// <summary>
	/// Clear the form
	/// </summary>
	protected void ClearForm()
	{
		txtDescricao.Text = string.Empty;
		txtOrdem.Text = string.Empty;
	}

}
