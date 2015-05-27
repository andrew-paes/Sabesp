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

public partial class content_module_release_release : SmartUserControl
{
	#region [Properties]
	/// <summary>
	/// Business Object for "Conteudo" fields
	/// </summary>
	protected Conteudo conteudo;
	/// <summary>
	/// Business Object for "Release" fields
	/// </summary>
	protected Release entidadeRelease;
	/// <summary>
	/// Business Object for "ReleaseIdioma" fields
	/// </summary>
	protected ReleaseIdioma entidadeReleaseIdioma;
	/// <summary>
	/// Business Object for "ReleaseImagemComentario" fields
	/// </summary>
	protected ReleaseImagemComentario entidadeReleaseImagemComentario;
	/// <summary>
	/// Business Object for "Arquivo" fields
	/// </summary>
	protected Arquivo entidadeArquivo;
	/// <summary>
	/// Business Object for "Release Imagem" fields
	/// </summary>
	protected ReleaseImagem entidadeReleaseImagem;
	/// <summary>
	/// Business Object for "Tag" fields
	/// </summary>
	protected Tag entidadeTag;
	/// <summary>
	/// Business Object for "Região" fields
	/// </summary>
	protected Regiao entidadeRegiao;
	/// <summary>
	///   Service for "ReleaseService" 
	/// </summary>
	protected ReleaseService releaseService;
	/// <summary>
	///   Service for "ReleaseIdiomaService" 
	/// </summary>
	protected ReleaseIdiomaService releaseIdiomaService;
	/// <summary>
	///   Service for "ReleaseImagemComentarioService" 
	/// </summary>
	protected ReleaseImagemComentarioService releaseImagemComentarioService;
	/// <summary>
	///   Service for "ArquivoService" 
	/// </summary>
	protected ArquivoService arquivoService;
	/// <summary>
	///   Service for "ReleaseImagemService" 
	/// </summary>
	protected ReleaseImagemService releaseImagemService;
	/// <summary>
	///   Service for "ConteudoService" 
	/// </summary>
	protected ConteudoService conteudoService;
	/// <summary>
	///   Service for "TagService" 
	/// </summary>
	protected TagService tagService;
	/// <summary>
	///   Service for "ConteudoTagService" 
	/// </summary>
	protected ConteudoTagService conteudoTagService;
	/// <summary>
	///   Service for "RegiaoService" 
	/// </summary>
	protected RegiaoService regiaoService;
	/// <summary>
	///  Filter for "ConteudoTagFH" to search BO for tags
	/// </summary>
	protected ConteudoTagFH conteudoTagFH;
	/// <summary>
	///  Filter for "ReleaseImagemFH" to search BO for tags
	/// </summary>
	protected ReleaseImagemFH releaseImagemFH;
	/// <summary>
	///  Filter for "ReleaseFH" to search BO for tags
	/// </summary>
	protected ReleaseFH releaseFH;
	/// <summary>
	///  Filter for "ReleaseIdiomaFH" to search BO for tags
	/// </summary>
	protected ReleaseIdiomaFH releaseIdiomaFH;
	/// <summary>
	///  Filter for "ArquivoFH" to search BO for tags
	/// </summary>
	protected ArquivoFH arquivoFH;
	/// <summary>
	///  Filter for "RegiaoFH" to search BO for tags
	/// </summary>
	protected RegiaoFH regiaoFH;

	#endregion

	#region [ Page Events ]

	/// <summary>
	/// 
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void Page_Load(object sender, EventArgs e)
	{
		this.DefineProperties();

		if (!Page.IsPostBack)
			LoadCheckBox();

		if (this.IdRegistro > 0)
		{
			if (!IsPostBack || this.IdiomaHasChanged)
			{
				this.LoadProperties();
				this.LoadForm();

				pnlRelacionado.Visible = true;
			}
		}
		else
		{
			pnlRelacionado.Visible = false;
		}
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void btnExecute_Click(object sender, ImageClickEventArgs e)
	{
		this.Execute();
	}

	#endregion

	#region [ Methods ]

	#region Properties and Form

	/// <summary>
	/// Define all services to all properties
	/// </summary>
	private void DefineProperties()
	{
		// Ini service to "conteudo"
		conteudo = new Conteudo();
		conteudo.Release = new Release();

		// Ini service to "Release"
		entidadeRelease = new Release();
		entidadeRelease.Conteudo = new Conteudo();

		// Ini service to "ReleaseIdioma"
		entidadeReleaseIdioma = new ReleaseIdioma();
		entidadeReleaseIdioma.Release = new Release();
		entidadeReleaseIdioma.Release.Conteudo = new Conteudo();
		entidadeReleaseIdioma.Idioma = new Idioma();

		// Ini service to "ReleaseImagem"
		entidadeReleaseImagem = new ReleaseImagem();
		entidadeReleaseImagem.Release = new Release();
		entidadeReleaseImagem.Release.Conteudo = new Conteudo();
		entidadeReleaseImagem.Release.ReleaseIdiomas = new List<ReleaseIdioma>();
		releaseImagemFH = new ReleaseImagemFH();

		// Ini service to "Arquivo"
		entidadeArquivo = new Arquivo();
		entidadeArquivo.ReleaseImagens = new List<ReleaseImagem>();

		// Ini service to "tag"
		entidadeTag = new Tag();
		conteudoTagService = new ConteudoTagService();
		conteudoTagFH = new ConteudoTagFH();

		releaseService = new ReleaseService();
		releaseIdiomaService = new ReleaseIdiomaService();
		conteudoService = new ConteudoService();
	}

	/// <summary>
	/// Load all properties
	/// </summary>
	private void LoadProperties()
	{
		// Ini service to find and add "conteudo"
		conteudo = new Conteudo();
		conteudo.ConteudoId = Convert.ToInt32(IdRegistro);
		conteudo = new ConteudoService().Carregar(conteudo);

		// Ini "Release"
		entidadeRelease = new Release();
		entidadeRelease.Conteudo = new Conteudo();
		entidadeRelease.Conteudo.ConteudoId = conteudo.ConteudoId;

		// Ini and define "ReleaseIdioma"
		entidadeReleaseIdioma = new ReleaseIdioma();
		entidadeReleaseIdioma.Release = new Release();
		entidadeReleaseIdioma.Release.Conteudo = new Conteudo();
		entidadeReleaseIdioma.Release.Conteudo.ConteudoId = conteudo.ConteudoId;
		entidadeReleaseIdioma.Idioma = new Idioma();
		entidadeReleaseIdioma.Idioma.IdiomaId = this.IdiomaId;

		conteudo.Tages = new List<Tag>();

		// Search all "ConteudoTag" by ID of "Conteudo"
		IList<ConteudoTag> conteudoTagList = new List<ConteudoTag>();
		conteudoTagFH.ConteudoId = Convert.ToString(conteudo.ConteudoId);
		conteudoTagList = new ConteudoTagService().RetornaTodos(0, 0, "", "", conteudoTagFH);

		foreach (ConteudoTag conteudoTag in conteudoTagList)
		{
			entidadeTag = new Tag();
			entidadeTag = new TagService().Carregar(conteudoTag.Tag.TagId);
			if (entidadeTag != null)
			{
				conteudo.Tages.Add(entidadeTag);
			}
		}

		#region ReleaseImagem

		// Search all news by "noticiaId"
		string[] ordenacao = { "ordem" };
		string[] orientacao = { "ASC" };
		releaseImagemFH = new ReleaseImagemFH();
		releaseImagemFH.ReleaseId = Convert.ToString(conteudo.ConteudoId);
		IList<ReleaseImagem> entidadeReleaseImagemList = new List<ReleaseImagem>();
		entidadeReleaseImagemList = new ReleaseImagemService().RetornaTodos(0, 0, ordenacao, orientacao, releaseImagemFH);

		DataTable dt = new DataTable();
		dt.Columns.Add(new DataColumn("arquivoId", typeof(int)));
		dt.Columns.Add(new DataColumn("nomeArquivo", typeof(string)));
		for (int img = 0; img < entidadeReleaseImagemList.Count; img++)
		{
			DataRow dr = dt.NewRow();
			Arquivo entidadeArquivo = new Arquivo();
			entidadeArquivo = new ArquivoService().Carregar(entidadeReleaseImagemList[img].Arquivo);
			dr["arquivoId"] = entidadeArquivo.ArquivoId;
			dr["NomeArquivo"] = entidadeArquivo.NomeArquivo;

			dt.Rows.Add(dr);
		}

		sfArquivo.DataSource = dt;
		sfArquivo.DataBind();

		#endregion

		// Search all news by "ReleaseId"
		releaseImagemFH = new ReleaseImagemFH();
		releaseImagemFH.ReleaseId = Convert.ToString(conteudo.ConteudoId);

		// Ini service to find "Release"
		releaseService = new ReleaseService();
		entidadeRelease = releaseService.Carregar(entidadeRelease);

		// Ini service to find "ReleaseIdioma"
		releaseIdiomaService = new ReleaseIdiomaService();
		entidadeRelease.ReleaseIdiomas = new List<ReleaseIdioma>();

		// Add "ReleaseIdioma"
		entidadeRelease.ReleaseIdiomas.Add(releaseIdiomaService.Carregar(entidadeReleaseIdioma));

		// Add "Release" to "conteudo"
		conteudo.Release = new Release();
		conteudo.Release = entidadeRelease;
		// Add "ReleaseIdioma" to "Release"
		conteudo.Release = new ReleaseService().Carregar(entidadeRelease);
		conteudo.Release.ReleaseIdiomas = entidadeRelease.ReleaseIdiomas;
	}

	/// <summary>
	/// Clear the form
	/// </summary>
	protected void ClearForm()
	{
		txtTitulo.Text = string.Empty;
		//uplThumbMédio.FileName = string.Empty;
		txtAutor.Text = string.Empty;
		txtChamadaRelease.Text = string.Empty;
		txtConteudo.Text = string.Empty;
		txtdtPublicacao.Text = string.Empty;
		txtHoraPublicacao.Text = string.Empty;
		txtTags.Text = string.Empty;

		chbAtivo.Checked = false;
	}

	/// <summary>
	/// 
	/// </summary>
	protected void LoadForm()
	{
		if (conteudo != null
			&& conteudo.Release != null
			&& conteudo.Release.ReleaseIdiomas != null
			&& conteudo.Release.ReleaseIdiomas.Count > 0)
		{
			if (conteudo.Release.ReleaseIdiomas.Count > 0)
			{
				if (conteudo.Release.ReleaseIdiomas[0] != null)
				{
					txtTitulo.Text = conteudo.Release.ReleaseIdiomas[0].TituloRelease.ToString();
					txtConteudo.Text = conteudo.Release.ReleaseIdiomas[0].TextoRelease.ToString();
					txtChamadaRelease.Text = conteudo.Release.ReleaseIdiomas[0].ChamadaRelease.ToString();
				}
			}

			txtdtPublicacao.Text = Convert.ToDateTime(conteudo.Release.DataHoraPublicacao).ToString("dd/MM/yyyy");
			txtHoraPublicacao.Text = Convert.ToDateTime(conteudo.Release.DataHoraPublicacao).ToString("HH:mm");

			if (entidadeReleaseImagem.Release.ReleaseImagens != null && entidadeReleaseImagem.Release.ReleaseImagens.Count > 0)
			{
				//uplThumbMédio
			}

			txtAutor.Text = conteudo.Release.Autor;

			if (conteudo.Tages != null && conteudo.Tages.Count > 0)
			{
				string strTag = string.Empty;

				string[] parts = new string[conteudo.Tages.Count];
				int i = 0;

				foreach (Tag tag in conteudo.Tages)
				{
					if (!String.IsNullOrEmpty(tag.Palavra))
					{
						parts[i] = tag.Palavra;
						i++;
					}
				}

				strTag = String.Join(", ", parts) + ".";

				txtTags.Text = strTag;
			}

			if (conteudo.Release.Ativa)
			{
				chbAtivo.Checked = true;
			}
			else
			{
				chbAtivo.Checked = false;
			}

			if (conteudo.Release.DestaqueHome)
			{
				chbDestaqueHome.Checked = true;
			}
			else
			{
				chbDestaqueHome.Checked = false;
			}
		}
	}

	/// <summary>
	/// 
	/// </summary>
	protected void LoadCheckBox()
	{
		entidadeRegiao = new Regiao();

		regiaoService = new RegiaoService();

		IList<Regiao> entidadeRegiaoList = new List<Regiao>();

		entidadeRegiaoList = regiaoService.RetornaTodos();

		chbRegiao.DataSource = entidadeRegiaoList;
		chbRegiao.DataTextField = "nomeRegiao";
		chbRegiao.DataValueField = "regiaoId";
		chbRegiao.DataBind();

		if (this.IdRegistro != 0 || this.IdRegistro != null)
		{
			for (int i = 0; i < chbRegiao.Items.Count; i++)
			{
				int cont = new RegiaoService().TotalRegistrosRelacionadoConteudo(Convert.ToInt32(chbRegiao.Items[i].Value), Convert.ToInt32(this.IdRegistro));

				if (cont > 0)
					chbRegiao.Items[i].Selected = true;
				else
					chbRegiao.Items[i].Selected = false;
			}
		}

	}

	/// <summary>
	/// Pass all prop from the form to service properties
	/// </summary>
	protected void FormToLoad()
	{
		// Carrega "Conteudo"
		conteudo.DataHoraCadastro = DateTime.Now;
		conteudo.ConteudoTipo = new ConteudoTipo();
		conteudo.ConteudoTipo.ConteudoTipoId = 6;

		// Carrega "Release"        
		if (!String.IsNullOrEmpty(txtdtPublicacao.Text))
		{
			if (!String.IsNullOrEmpty(txtHoraPublicacao.Text))
			{
				entidadeRelease.DataHoraPublicacao = Convert.ToDateTime(String.Concat(txtdtPublicacao.Text, " ", txtHoraPublicacao.Text));
			}
			else
			{
				entidadeRelease.DataHoraPublicacao = Convert.ToDateTime(txtdtPublicacao.Text);
			}
		}

		if (!String.IsNullOrEmpty(txtAutor.Text))
			entidadeRelease.Autor = txtAutor.Text;

		entidadeRelease.Ativa = true;

		entidadeRelease.DestaqueHome = chbDestaqueHome.Checked;

		// Carrega "ReleaseIdioma"
		if (!String.IsNullOrEmpty(txtTitulo.Text))
			entidadeReleaseIdioma.TituloRelease = txtTitulo.Text;

		if (!String.IsNullOrEmpty(txtConteudo.Text))
			entidadeReleaseIdioma.TextoRelease = txtConteudo.Text;

		if (!String.IsNullOrEmpty(txtChamadaRelease.Text))
			entidadeReleaseIdioma.ChamadaRelease = txtChamadaRelease.Text;

		entidadeReleaseIdioma.Idioma.IdiomaId = this.IdiomaId;

		if (IdRegistro > 0)
		{
			conteudo.ConteudoId = Convert.ToInt32(IdRegistro);
			entidadeRelease.Conteudo.ConteudoId = conteudo.ConteudoId;
			entidadeReleaseIdioma.Release.Conteudo.ConteudoId = conteudo.ConteudoId;
		}

		entidadeTag = new Tag();
		conteudo.Tages = new List<Tag>();
		if (!String.IsNullOrEmpty(Convert.ToString(txtTags)))
		{
			string[] tags = new string[] { };
			tags = txtTags.Text.Split(',');
			foreach (string tag in tags)
			{
				entidadeTag = new Tag();
				entidadeTag.Palavra = tag.Trim().Replace(".", "");
				entidadeTag.Idioma = new Idioma();
				entidadeTag.Idioma.IdiomaId = this.IdiomaId;

				conteudo.Tages.Add(entidadeTag);
			}
		}

		conteudo.ConteudoRegiao = new List<Regiao>();
		for (int i = 0; i < chbRegiao.Items.Count; i++)
		{
			entidadeRegiao = new Regiao();
			if (chbRegiao.Items[i].Selected)
			{
				entidadeRegiao.RegiaoId = Convert.ToInt32(chbRegiao.Items[i].Value);
				conteudo.ConteudoRegiao.Add(entidadeRegiao);
			}
		}
	}

	/// <summary>
	/// 
	/// </summary>
	protected void addListArquivo()
	{
		// Add List "EventoImagem" and "Arquivo"        
		entidadeRelease.ReleaseImagens = new List<ReleaseImagem>();

		List<Int32> lstImagens = sfArquivo.BuscaPKs();
		foreach (int arquivoId in lstImagens)
		{
			entidadeReleaseImagem = new ReleaseImagem();
			entidadeReleaseImagem.Arquivo = new Arquivo();
			entidadeReleaseImagem.Arquivo.ArquivoId = arquivoId;
			entidadeReleaseImagem.Release = entidadeRelease;

			entidadeRelease.ReleaseImagens.Add(entidadeReleaseImagem);
		}
	}

	#endregion

	#region Execute, Save and Update

	/// <summary>
	/// 
	/// </summary>
	private void Execute()
	{
		this.FormToLoad();

		int cont = 0;

		if (this.IdRegistro > 0)
		{
			releaseIdiomaFH = new ReleaseIdiomaFH();
			releaseIdiomaFH.IdiomaId = this.IdiomaId.ToString();
			releaseIdiomaFH.ReleaseId = this.IdRegistro.ToString();
			cont = new ReleaseIdiomaService().TotalRegistros(releaseIdiomaFH);
		}

		try
		{
			if (!String.IsNullOrEmpty(this.txtdtPublicacao.Text) && Ag2.Manager.Helper.Util.IsDate(this.txtdtPublicacao.Text))
			{

				// set values to properties
				this.FormToLoad();

				// Check if update or delete command
				if (conteudo != null && conteudo.ConteudoId > 0 && cont > 0)
				{
					this.Update();
				}
				else
				{
					this.Save();
				}

				if (this.conteudo.Release != null && this.conteudo.ConteudoId > 0)
				{
					this.SaveWorkflow(); // Update "conteudo"
				}

				Util.ShowMessage("Registro salvo com sucesso!");

			}
			else
			{
				Util.ShowMessage("Deve ser inserido data de publicação válida!");
			}
		}
		catch (Exception e)
		{
			string execption = string.Empty;
			Util.ShowMessage("Registro não atualizado. Por favor tente mais tarde" + execption);
		}
	}

	/// <summary>
	/// save Release
	/// </summary>
	protected void Save()
	{
		if (this.IdRegistro == 0)
		{
			// Save "Conteudo"
			new ConteudoService().Inserir(conteudo);
		}
		else
		{
			conteudo.ConteudoId = Convert.ToInt32(this.IdRegistro);
		}

		if (conteudo != null && conteudo.ConteudoId > 0)
		{
			entidadeRelease.Conteudo.ConteudoId = conteudo.ConteudoId;
			entidadeReleaseIdioma.Release.Conteudo.ConteudoId = conteudo.ConteudoId;

			try
			{
				addListArquivo();

				if (this.IdRegistro == 0)
				{
					// Save "Release"
					new ReleaseService().Inserir(entidadeRelease);

					// Insert the Tag
					new TagService().Relacionar(conteudo);

					// Save "ConteudoRegiao"
					for (int i = 0; i < conteudo.ConteudoRegiao.Count; i++)
					{
						new ConteudoService().InserirRelacionado(conteudo, Convert.ToInt32(conteudo.ConteudoRegiao[i].RegiaoId));
					}
				}

				// Save "ReleaseIdioma"
				new ReleaseIdiomaService().Inserir(entidadeReleaseIdioma);

				if (entidadeRelease.ReleaseImagens.Count > 0)
				{
					// save "NoticiaImagem"
					for (int img = 0; img < entidadeRelease.ReleaseImagens.Count; img++)
					{
						new ReleaseImagemService().Inserir(entidadeRelease.ReleaseImagens[img]);
					}
				}
			}
			catch
			{
				new ConteudoService().Excluir(conteudo);
			}
		}
	}

	/// <summary>
	/// update Release
	/// </summary>
	protected void Update()
	{
		addListArquivo();

		// Update "Release"
		releaseService.Atualizar(entidadeRelease);

		// Update "ReleaseIdioma"
		releaseIdiomaService.Atualizar(entidadeReleaseIdioma);

		// Insert the Tag
		new TagService().Relacionar(conteudo);

		//Exclui o relacionamento entre Conteudo e Regiao para inserir atualizado
		new ConteudoService().ExcluirRelacionado(conteudo);

		for (int i = 0; i < conteudo.ConteudoRegiao.Count; i++)
		{
			new ConteudoService().InserirRelacionado(conteudo, Convert.ToInt32(conteudo.ConteudoRegiao[i].RegiaoId));
		}

		new ReleaseImagemService().ExcluirRelacionado(entidadeRelease);

		if (entidadeRelease.ReleaseImagens.Count > 0)
		{
			// save "NoticiaImagem"
			for (int img = 0; img < entidadeRelease.ReleaseImagens.Count; img++)
			{
				new ReleaseImagemService().Inserir(entidadeRelease.ReleaseImagens[img]);
			}
		}
	}

	/// <summary>
	/// update workflow
	/// </summary>
	private void SaveWorkflow()
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

	#endregion

	#endregion
}