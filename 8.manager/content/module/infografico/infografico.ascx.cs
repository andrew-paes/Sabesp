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

public partial class content_module_infografico_infografico : SmartUserControl
{
	#region [ Page Events ]

	protected void Page_Load(object sender, EventArgs e)
	{
		if (this.IdRegistro > 0)
		{
			if (!IsPostBack || this.IdiomaHasChanged)
			{
				this.LoadForm();
			}
		}
	}

	protected void btnExecute_Click(object sender, ImageClickEventArgs e)
	{
		this.Execute();
	}

	#endregion

	#region [ Methods ]

	#region Properties And Form

	protected void ClearForm()
	{
		txtTitulo.Text = string.Empty;
		txtDescricao.Text = string.Empty;
	}

	/// <summary>
	/// 
	/// </summary>
	protected void LoadForm()
	{
		InfograficoService infograficoService = new InfograficoService();
		Infografico infografico = infograficoService.Carregar(new Infografico() { Conteudo = new Conteudo() { ConteudoId = IdRegistro.Value } });

		if (infografico != null)
		{
			InfograficoIdiomaService infograficoIdiomaService = new InfograficoIdiomaService();
			InfograficoIdioma infograficoIdioma = infograficoIdiomaService.Carregar(new InfograficoIdioma() { Infografico = infografico, Idioma = new Idioma() { IdiomaId = IdiomaId } });


			if (infografico.ArquivoIdImagem != null)
			{
				infografico.ArquivoIdImagem = new ArquivoService().Carregar(new Arquivo() { ArquivoId = infografico.ArquivoIdImagem.ArquivoId });

				DataTable dtImagem = new DataTable();
				dtImagem.Columns.Add(new DataColumn("arquivoId", typeof(int)));
				dtImagem.Columns.Add(new DataColumn("nomeArquivo", typeof(string)));

				if (infografico.ArquivoIdImagem != null)
				{
					DataRow drow = dtImagem.NewRow();
					drow["arquivoId"] = infografico.ArquivoIdImagem.ArquivoId;
					drow["nomeArquivo"] = infografico.ArquivoIdImagem.NomeArquivo;

					dtImagem.Rows.Add(drow);
				}

				sfArquivoImagem.DataSource = dtImagem;
				sfArquivoImagem.DataBind();
			}

			if (infograficoIdioma != null)
			{
				txtTitulo.Text = infograficoIdioma.Titulo;
				txtDescricao.Text = infograficoIdioma.Descricao;

				DataTable dtAnimacao = new DataTable();
				dtAnimacao.Columns.Add(new DataColumn("arquivoId", typeof(int)));
				dtAnimacao.Columns.Add(new DataColumn("nomeArquivo", typeof(string)));

				if (infograficoIdioma.ArquivoIdAnimacao != null)
				{
					infograficoIdioma.ArquivoIdAnimacao = new ArquivoService().Carregar(new Arquivo() { ArquivoId = infograficoIdioma.ArquivoIdAnimacao.ArquivoId });

					if (infograficoIdioma.ArquivoIdAnimacao != null)
					{
						DataRow drow = dtAnimacao.NewRow();
						drow["arquivoId"] = infograficoIdioma.ArquivoIdAnimacao.ArquivoId;
						drow["nomeArquivo"] = infograficoIdioma.ArquivoIdAnimacao.NomeArquivo;
						dtAnimacao.Rows.Add(drow);
					}
				}

				sfArquivoAnimacao.DataSource = dtAnimacao;
				sfArquivoAnimacao.DataBind();
			}
		}
	}

	/// <summary>
	/// Pass all prop from the form to service properties
	/// </summary>
	protected InfograficoIdioma FormToLoad()
	{
		InfograficoIdioma infograficoIdioma = new InfograficoIdioma();

		if (!String.IsNullOrEmpty(txtTitulo.Text))
		{
			infograficoIdioma.Titulo = txtTitulo.Text;
		}

		if (!String.IsNullOrEmpty(txtDescricao.Text))
		{
			infograficoIdioma.Descricao = txtDescricao.Text;
		}

		infograficoIdioma.Idioma = new Idioma();
		infograficoIdioma.Idioma.IdiomaId = this.IdiomaId;

		infograficoIdioma.Infografico = new Infografico();

		infograficoIdioma.Infografico.Conteudo = new Conteudo();

		if (IdRegistro > 0)
		{
            infograficoIdioma.Infografico.infograficoId = Convert.ToInt32(IdRegistro);
			infograficoIdioma.Infografico.Conteudo.ConteudoId = Convert.ToInt32(IdRegistro);
		}

		List<Int32> lstImagem = sfArquivoImagem.BuscaPKs();
		foreach (int arquivoId in lstImagem)
		{
			infograficoIdioma.Infografico.ArquivoIdImagem = new Arquivo();
			infograficoIdioma.Infografico.ArquivoIdImagem.ArquivoId = arquivoId;
		}

		List<Int32> lstAnimacao = sfArquivoAnimacao.BuscaPKs();
		foreach (int arquivoId in lstAnimacao)
		{
			infograficoIdioma.ArquivoIdAnimacao = new Arquivo();
			infograficoIdioma.ArquivoIdAnimacao.ArquivoId = arquivoId;
		}

		return infograficoIdioma;
	}

	#endregion

	/// <summary>
	/// 
	/// </summary>
	private void Execute()
	{
		if (!String.IsNullOrEmpty(txtTitulo.Text.Trim()) && !String.IsNullOrEmpty(txtDescricao.Text.Trim()))
		{
			InfograficoIdioma infograficoIdioma = this.FormToLoad();

			if (infograficoIdioma.Infografico != null && infograficoIdioma.Infografico.Conteudo.ConteudoId > 0)
			{
				this.Update(infograficoIdioma);
			}
			else
			{
				this.Save(infograficoIdioma);
			}

			if (infograficoIdioma.Infografico != null && infograficoIdioma.Infografico.Conteudo != null && infograficoIdioma.Infografico.Conteudo.ConteudoId > 0)
			{
				this.SaveWorkflow(infograficoIdioma.Infografico.Conteudo);
			}
		}
		else
		{
			Util.ShowMessage("Por favor, complete os campos obrigatórios.");
		}
	}

	private void SaveWorkflow(Conteudo conteudo)
	{
		if (conteudo != null && conteudo.ConteudoId > 0)
		{
			int wId = WorkflowUtil.SaveWorkflow(this.IdWorkflow, StatusWorkflow1, conteudo.ConteudoId, txtTitulo.Text, this.ModuleName, "Conteudo");

			if (wId > 0)
			{
				if (this.IdRegistro > 0)
				{
					Util.ShowUpdateMessage();
					this.LoadForm();
					StatusWorkflow1.DataBind();
				}
				else
				{
					Util.ShowInsertMessage();
					Response.Redirect(String.Concat("edit.aspx?md=", this.ModuleName, "&id=", conteudo.ConteudoId, "&wid=", wId), false);
				}
			}
			else
			{
				Util.ShowMessage("Erro ao associar workflow");
			}
		}
	}

	/// <summary>
	/// 
	/// </summary>
	protected void Save(InfograficoIdioma infograficoIdioma)
	{
		if (infograficoIdioma.Infografico == null)
		{
			infograficoIdioma.Infografico = new Infografico();            
		}

		if (infograficoIdioma.Infografico.Conteudo == null)
		{
			infograficoIdioma.Infografico.Conteudo = new Conteudo();
		}
		infograficoIdioma.Infografico.Conteudo.DataHoraCadastro = DateTime.Now;
		infograficoIdioma.Infografico.Conteudo.ConteudoTipo = new ConteudoTipo() { ConteudoTipoId = 8 };

		if (this.IdRegistro == 0)
		{
			// Save "Conteudo"            
			new ConteudoService().Inserir(infograficoIdioma.Infografico.Conteudo);

			// Save 
			new InfograficoService().Inserir(infograficoIdioma.Infografico);
		}
		else
		{
			infograficoIdioma.Infografico.Conteudo.ConteudoId = Convert.ToInt32(this.IdRegistro);
		}

		// Save 
		new InfograficoIdiomaService().Inserir(infograficoIdioma);
	}

	/// <summary>
	/// 
	/// </summary>
	protected void Update(InfograficoIdioma infograficoIdioma)
	{
		InfograficoIdiomaService infograficoIdiomaService = new InfograficoIdiomaService();
		InfograficoIdioma check = infograficoIdiomaService.Carregar(infograficoIdioma);

		// Update
		new InfograficoService().Atualizar(infograficoIdioma.Infografico);

		if (check != null)
		{
			// Update 
			infograficoIdiomaService.Atualizar(infograficoIdioma);
		}
		else
		{
			infograficoIdiomaService.Inserir(infograficoIdioma);
		}
	}

	#endregion
}
