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

public partial class content_module_bancoAudio_bancoAudio : SmartUserControl
{
	#region [ Properties ]

	/// <summary>
	/// Business Object for "Conteudo" fields
	/// </summary>
	protected Conteudo conteudo;
	/// <summary>
	/// Business Object for "Podcast" fields
	/// </summary>
	protected Podcast entidadePodcast;
	/// <summary>
	/// Business Object for "PodcastIdioma" fields
	/// </summary>
	protected PodcastIdioma entidadePodcastIdioma;
	/// <summary>
	/// Business Object for "Arquivo" fields
	/// </summary>
	protected Arquivo entidadeArquivo;
	/// <summary>
	/// Business Object for "Tag" fields
	/// </summary>
	protected Tag entidadeTag;
	/// <summary>
	/// Business Object for "Regiao" fields
	/// </summary>
	protected Regiao entidadeRegiao;
	/// <summary>
	///  Service for "PodcastService"
	/// </summary>
	protected PodcastService podcastService;
	/// <summary>
	///  Service for "PodcastIdiomaService"
	/// </summary>
	protected PodcastIdiomaService podcastIdiomaService;
	/// <summary>
	///  Service for "ArquivoService"
	/// </summary>
	protected ArquivoService arquivoService;
	/// <summary>
	///  Service for "ConteudoService"
	/// </summary>
	protected ConteudoService conteudoService;
	/// <summary>
	///  Service for "TagService"
	/// </summary>
	protected TagService tagService;
	/// <summary>
	///  Service for "ConteudoTagService"
	/// </summary>
	protected ConteudoTagService conteudoTagService;
	/// <summary>
	///  Service for "RegiaoService"
	/// </summary>
	protected RegiaoService regiaoService;
	/// <summary>
	///  Filter for "conteudoTagFH" to search BO for tags
	/// </summary>
	protected ConteudoTagFH conteudoTagFH;
	/// <summary>
	///  Filter for "podcastFH" to search BO for tags
	/// </summary>
	protected PodcastFH podcastFH;
	/// <summary>
	///  Filter for "podcastIdiomaFH" to search BO for tags
	/// </summary>
	protected PodcastIdiomaFH podcastIdiomaFH;
	/// <summary>
	///  Filter for "arquivoFH" to search BO for tags
	/// </summary>
	protected ArquivoFH arquivoFH;
	/// <summary>
	///  Filter for "regiaoFH" to search BO for tags
	/// </summary>
	protected RegiaoFH regiaoFH;

	#endregion

	#region [ Page Events ]

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

	protected void btnExecute_Click(object sender, ImageClickEventArgs e)
	{
		this.Execute();
	}

	#endregion

	#region Properties and Form

	/// <summary>
	/// Define all services to all properties
	/// </summary>
	private void DefineProperties()
	{
		// Ini service to "conteudo"
		conteudo = new Conteudo();
		conteudo.Podcast = new Podcast();

		// Ini service to "podcast"
		entidadePodcast = new Podcast();
		entidadePodcast.Conteudo = new Conteudo();

		// Ini service to "podcastIdioma"
		entidadePodcastIdioma = new PodcastIdioma();
		entidadePodcastIdioma.Podcast = new Podcast();
		entidadePodcastIdioma.Podcast.Conteudo = new Conteudo();
		entidadePodcastIdioma.Idioma = new Idioma();

		// Ini service to "Arquivo"
		entidadeArquivo = new Arquivo();

		// Ini service to "tag"
		entidadeTag = new Tag();
		conteudoTagService = new ConteudoTagService();
		conteudoTagFH = new ConteudoTagFH();

		podcastService = new PodcastService();
		podcastIdiomaService = new PodcastIdiomaService();
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

		// Ini "podcast"
		entidadePodcast = new Podcast();
		entidadePodcast.Conteudo = new Conteudo();
		entidadePodcast.Conteudo.ConteudoId = conteudo.ConteudoId;

		// Ini and define "podcastIdioma"
		entidadePodcastIdioma = new PodcastIdioma();
		entidadePodcastIdioma.Podcast = new Podcast();
		entidadePodcastIdioma.Podcast.Conteudo = new Conteudo();
		entidadePodcastIdioma.Podcast.Conteudo.ConteudoId = conteudo.ConteudoId;
		entidadePodcastIdioma.Idioma = new Idioma();
		entidadePodcastIdioma.Idioma.IdiomaId = this.IdiomaId;

		conteudo.Tages = new List<Tag>();

		// Search all "ConteudoTag" by ID of "Conteudo"
		IList<ConteudoTag> conteudoTagList = new List<ConteudoTag>();
		conteudoTagFH.ConteudoId = Convert.ToString(conteudo.ConteudoId);
		conteudoTagList = new ConteudoTagService().RetornaTodos(0, 0, "palavra", "ASC", conteudoTagFH);

		foreach (ConteudoTag conteudoTag in conteudoTagList)
		{
			entidadeTag = new Tag();
			entidadeTag = new TagService().Carregar(conteudoTag.Tag.TagId);
			if (entidadeTag != null)
			{
				conteudo.Tages.Add(entidadeTag);
			}
		}

		#region Arquivo

		// Search all news by "podcastId"
		podcastIdiomaFH = new PodcastIdiomaFH();
		podcastIdiomaFH.PodcastId = Convert.ToString(conteudo.ConteudoId);
		IList<PodcastIdioma> entidadePodcasIdiomatList = new List<PodcastIdioma>();
		entidadePodcasIdiomatList = new PodcastIdiomaService().CarregarTodos(0, 0, "", "", podcastIdiomaFH);

		DataTable dt = new DataTable();
		dt.Columns.Add(new DataColumn("arquivoId", typeof(int)));
		dt.Columns.Add(new DataColumn("nomeArquivo", typeof(string)));
		for (int img = 0; img < entidadePodcasIdiomatList.Count; img++)
		{
			DataRow dr = dt.NewRow();
			Arquivo entidadeArquivo = new Arquivo();
			entidadeArquivo = new ArquivoService().Carregar(entidadePodcasIdiomatList[img].ArquivoPodcast);
			dr["arquivoId"] = entidadeArquivo.ArquivoId;
			dr["NomeArquivo"] = entidadeArquivo.NomeArquivo;

			dt.Rows.Add(dr);
		}

		sfArquivo.DataSource = dt;
		sfArquivo.DataBind();

		#endregion

		// Ini service to find "podcast"
		podcastService = new PodcastService();
		entidadePodcast = podcastService.Carregar(entidadePodcast);

		// Ini service to find "podcastIdioma"
		podcastIdiomaService = new PodcastIdiomaService();
		entidadePodcast.PodcastIdiomas = new List<PodcastIdioma>();

		// Add "podcastIdioma"
		entidadePodcast.PodcastIdiomas.Add(podcastIdiomaService.Carregar(entidadePodcastIdioma));

		// Add "podcast" to "conteudo"
		conteudo.Podcast = new Podcast();
		conteudo.Podcast = entidadePodcast;
		// Add "podcastIdioma" to "podcast"
		conteudo.Podcast = new PodcastService().Carregar(entidadePodcast);
		conteudo.Podcast.PodcastIdiomas = entidadePodcast.PodcastIdiomas;
	}

	/// <summary>
	/// 
	/// </summary>
	protected void ClearForm()
	{
		txtTitulo.Text = string.Empty;
		//uplArquivo.FileName = string.Empty;
		txtdtPublicacao.Text = string.Empty;
		txtTags.Text = string.Empty;
		txtTitulo.Text = string.Empty;
		txtDescricao.Text = string.Empty;
		txtAutor.Text = string.Empty;

		chbAtivo.Checked = false;
		chbDestaque.Checked = false;
		chbDestaqueFique.Checked = false;
	}

	/// <summary>
	/// 
	/// </summary>
	protected void LoadForm()
	{
		if (conteudo != null
			&& conteudo.Podcast != null
			&& conteudo.Podcast.PodcastIdiomas != null
			&& conteudo.Podcast.PodcastIdiomas.Count > 0)
		{
			if (entidadePodcast.PodcastIdiomas[0] != null)
			{
				txtTitulo.Text = entidadePodcast.PodcastIdiomas[0].TituloPodcast.ToString();
				txtDescricao.Text = entidadePodcast.PodcastIdiomas[0].DescricaoPodcast.ToString();
			}

			//Arquivo

			if (entidadePodcast.DataHoraPublicacao.ToString() != "")
			{
				txtdtPublicacao.Text = entidadePodcast.DataHoraPublicacao.ToString();
			}
			else
			{
				txtdtPublicacao.Text = DateTime.Now.ToString();
			}

			txtAutor.Text = entidadePodcast.Autor;

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

			if (entidadePodcast.DestaqueFiquePorDentro)
			{
				chbDestaqueFique.Checked = true;
			}
			else
			{
				chbDestaqueFique.Checked = false;
			}

			if (entidadePodcast.DestaquePodcasts)
			{
				chbDestaque.Checked = true;
			}
			else
			{
				chbDestaque.Checked = false;
			}

			if (entidadePodcast.DestaqueHome)
			{
				chbDestaqueHome.Checked = true;
			}
			else
			{
				chbDestaqueHome.Checked = false;
			}

			if (entidadePodcast.Ativo)
			{
				chbAtivo.Checked = true;
			}
			else
			{
				chbAtivo.Checked = false;
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
		conteudo.ConteudoTipo.ConteudoTipoId = 10;

		// Carrega "podcast"
		if (!String.IsNullOrEmpty(txtdtPublicacao.Text))
			entidadePodcast.DataHoraPublicacao = Convert.ToDateTime(txtdtPublicacao.Text);

		if (!String.IsNullOrEmpty(txtAutor.Text))
			entidadePodcast.Autor = txtAutor.Text;

		entidadePodcast.Ativo = chbAtivo.Checked;
		entidadePodcast.DestaqueFiquePorDentro = chbDestaqueFique.Checked;
		entidadePodcast.DestaquePodcasts = chbDestaque.Checked;
		entidadePodcast.DestaqueHome = chbDestaqueHome.Checked;

		if (!String.IsNullOrEmpty(txtDescricao.Text))
			entidadePodcastIdioma.DescricaoPodcast = txtDescricao.Text;

		if (!String.IsNullOrEmpty(txtTitulo.Text))
			entidadePodcastIdioma.TituloPodcast = txtTitulo.Text;

		entidadePodcastIdioma.Idioma.IdiomaId = this.IdiomaId;

		if (IdRegistro > 0)
		{
			conteudo.ConteudoId = Convert.ToInt32(IdRegistro);
			entidadePodcast.Conteudo.ConteudoId = conteudo.ConteudoId;
			entidadePodcastIdioma.Podcast.Conteudo.ConteudoId = conteudo.ConteudoId;
		}

		conteudo.Tages = new List<Tag>();

		if (!String.IsNullOrEmpty(Convert.ToString(txtTags.Text)))
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
	/// 
	/// </summary>
	protected void addListArquivo()
	{
		// arquivoIdPodcast
		List<Int32> lstArquivo = sfArquivo.BuscaPKs();
		foreach (int arquivoId in lstArquivo)
		{
			entidadePodcastIdioma.ArquivoPodcast = new Arquivo();
			entidadePodcastIdioma.ArquivoPodcast.ArquivoId = arquivoId;
		}
	}

	#endregion

	#region Execute, Save and Update
	/// <summary>
	/// 
	/// </summary>
	private void Execute()
	{
		int cont = 0;

		if (this.IdRegistro > 0)
		{
			podcastIdiomaFH = new PodcastIdiomaFH();
			podcastIdiomaFH.IdiomaId = this.IdiomaId.ToString();
			podcastIdiomaFH.PodcastId = this.IdRegistro.ToString();
			cont = new PodcastIdiomaService().TotalRegistros(podcastIdiomaFH);
		}
		
		try
		{
			if (!String.IsNullOrEmpty(this.txtdtPublicacao.Text) && Ag2.Manager.Helper.Util.IsDate(this.txtdtPublicacao.Text))
			{
				List<Int32> lstArquivo = sfArquivo.BuscaPKs();

				if (lstArquivo != null && lstArquivo.Count > 0)
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

					if (this.conteudo.Podcast != null && this.conteudo.ConteudoId > 0)
					{
						this.SaveWorkflow(); // Update "conteudo"
					}

					Util.ShowMessage("Registro salvo com sucesso!");
				}
				else
				{
					Util.ShowMessage("Deve ser relacionado pelo menos um arquivo!");
				}
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
	/// 
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
			entidadePodcast.Conteudo.ConteudoId = conteudo.ConteudoId;
			entidadePodcast.BancoAudio = true;
			entidadePodcastIdioma.Podcast.Conteudo.ConteudoId = conteudo.ConteudoId;

			try
			{
				if (this.IdRegistro == 0)
				{
					// Save "podcast"
					new PodcastService().Inserir(entidadePodcast);

					// Insert the Tag
					new TagService().Relacionar(conteudo);

					// Save "ConteudoRegiao"
					for (int i = 0; i < conteudo.ConteudoRegiao.Count; i++)
					{
						new ConteudoService().InserirRelacionado(conteudo, Convert.ToInt32(conteudo.ConteudoRegiao[i].RegiaoId));
					}
				}

				addListArquivo();

				// Save "podcastIdioma"
				new PodcastIdiomaService().Inserir(entidadePodcastIdioma);
			}
			catch
			{
				new ConteudoService().Excluir(conteudo);
			}
		}
	}

	/// <summary>
	/// 
	/// </summary>
	protected void Update()
	{
		addListArquivo();

		// Update "podcast"
		podcastService.Atualizar(entidadePodcast);

		// Update "podcastIdioma"
		podcastIdiomaService.Atualizar(entidadePodcastIdioma);

		// Insert the Tag
		new TagService().Relacionar(conteudo);

		//Exclui o relacionamento entre Conteudo e Regiao para inserir atualizado
		new ConteudoService().ExcluirRelacionado(conteudo);
		for (int i = 0; i < conteudo.ConteudoRegiao.Count; i++)
		{
			new ConteudoService().InserirRelacionado(conteudo, Convert.ToInt32(conteudo.ConteudoRegiao[i].RegiaoId));
		}
	}

	/// <summary>
	/// 
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
}