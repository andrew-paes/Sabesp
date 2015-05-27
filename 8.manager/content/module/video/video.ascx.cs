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

public partial class content_module_video_video : SmartUserControl
{
	#region [ Properties ]

	/// <summary>
	/// Business Object for "Conteudo" fields
	/// </summary>
	protected Conteudo conteudo;
	/// <summary>
	/// Business Object for "Video" fields
	/// </summary>
	protected Video entidadeVideo;
	/// <summary>
	/// Business Object for "Video Idioma" fields
	/// </summary>
	protected VideoIdioma entidadeVideoIdioma;
	/// <summary>
	/// Business Object for "Tag" fields
	/// </summary>
	protected Tag entidadeTag;
	/// <summary>
	/// Business Object for "Regiao" fields
	/// </summary>
	protected Regiao entidadeRegiao;
	/// <summary>
	///   Service for "VideoService" 
	/// </summary>
	protected VideoService videoService;
	/// <summary>
	///   Service for "VideoIdiomaService" 
	/// </summary>
	protected VideoIdiomaService videoIdiomaService;
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
	///  Filter for "VideoFH" to search BO for tags
	/// </summary>
	protected VideoFH videoFH;
	/// <summary>
	///  Filter for "VideoIdiomaFH" to search BO for tags
	/// </summary>
	protected VideoIdiomaFH videoIdiomaFH;
	/// <summary>
	///  Filter for "RegiaoFH" to search BO for tags
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

	#region [ Methods ]

	#region Properties And Form
	/// <summary>
	/// Define all services to all properties
	/// </summary>
	private void DefineProperties()
	{
		// Ini service to "conteudo"
		conteudo = new Conteudo();
		conteudo.Video = new Video();

		// Ini service to "video"
		entidadeVideo = new Video();
		entidadeVideo.Conteudo = new Conteudo();

		// Ini service to "videoIdioma"
		entidadeVideoIdioma = new VideoIdioma();
		entidadeVideoIdioma.Video = new Video();
		entidadeVideoIdioma.Video.Conteudo = new Conteudo();
		entidadeVideoIdioma.Idioma = new Idioma();

		// Ini service to "tag"
		entidadeTag = new Tag();
		conteudoTagService = new ConteudoTagService();
		conteudoTagFH = new ConteudoTagFH();

		videoService = new VideoService();
		videoIdiomaService = new VideoIdiomaService();
		conteudoService = new ConteudoService();
	}

	/// <summary>
	/// 
	/// </summary>
	protected void ClearForm()
	{
		txtTitulo.Text = string.Empty;
		txtYoutube.Text = string.Empty;
		txtdtPublicacao.Text = string.Empty;
		txtHoraPublicacao.Text = string.Empty;
		txtTags.Text = string.Empty;
		txtDescricao.Text = string.Empty;
		txtAutor.Text = string.Empty;

		chbAtivo.Checked = false;
		chbDestaque.Checked = false;
		chbDestaqueFique.Checked = false;
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

		// Ini "video"
		entidadeVideo = new Video();
		entidadeVideo.Conteudo = new Conteudo();
		entidadeVideo.Conteudo.ConteudoId = Convert.ToInt32(IdRegistro);

		// Ini and define "videoIdioma"
		entidadeVideoIdioma = new VideoIdioma();
		entidadeVideoIdioma.Video = new Video();
		entidadeVideoIdioma.Video.Conteudo = new Conteudo();
		entidadeVideoIdioma.Video.Conteudo.ConteudoId = Convert.ToInt32(IdRegistro);
		entidadeVideoIdioma.Idioma = new Idioma();
		entidadeVideoIdioma.Idioma.IdiomaId = this.IdiomaId;

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

		// Ini service to find "video"
		videoService = new VideoService();
		entidadeVideo = videoService.Carregar(entidadeVideo);

		// Ini service to find "videoIdioma"
		videoIdiomaService = new VideoIdiomaService();
		entidadeVideo.VideoIdiomas = new List<VideoIdioma>();

		// Add "videoIdioma"
		entidadeVideo.VideoIdiomas.Add(videoIdiomaService.Carregar(entidadeVideoIdioma));

		// Add "video" to "conteudo"
		conteudo.Video = new Video();
		conteudo.Video = entidadeVideo;
		// Add "videoIdioma" to "video"
		conteudo.Video = new VideoService().Carregar(entidadeVideo);
		conteudo.Video.VideoIdiomas = entidadeVideo.VideoIdiomas;
	}

	/// <summary>
	/// 
	/// </summary>
	protected void LoadForm()
	{
		if (conteudo != null
			&& conteudo.Video != null
			&& conteudo.Video.VideoIdiomas != null
			&& conteudo.Video.VideoIdiomas.Count > 0)
		{
			if (entidadeVideo.VideoIdiomas[0] != null)
			{
				txtTitulo.Text = entidadeVideo.VideoIdiomas[0].TituloVideo.ToString();
				txtDescricao.Text = entidadeVideo.VideoIdiomas[0].DescricaoVideo.ToString();
			}
			txtYoutube.Text = entidadeVideo.UrlYoutube.ToString();

			if (entidadeVideo.DataHoraPublicacao != null)
			{
				txtdtPublicacao.Text = entidadeVideo.DataHoraPublicacao.ToString("dd/MM/yyyy");
				txtHoraPublicacao.Text = Convert.ToDateTime(entidadeVideo.DataHoraPublicacao).ToString("HH:mm");
			}

			if (entidadeVideo.Autor != null)
			{
				txtAutor.Text = entidadeVideo.Autor.ToString();
			}

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

			if (conteudo.Video.DestaqueFiquePorDentro)
				chbDestaqueFique.Checked = true;
			else
				chbDestaqueFique.Checked = false;

			if (conteudo.Video.DestaqueVideos)
				chbDestaque.Checked = true;
			else
				chbDestaque.Checked = false;

			if (conteudo.Video.DestaqueHome)
				chbDestaqueHome.Checked = true;
			else
				chbDestaqueHome.Checked = false;

			if (conteudo.Video.Ativo)
				chbAtivo.Checked = true;
			else
				chbAtivo.Checked = false;
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
		conteudo.ConteudoTipo.ConteudoTipoId = 4;

		// Carrega "Video"
		if (!String.IsNullOrEmpty(txtdtPublicacao.Text))
		{
			if (!String.IsNullOrEmpty(txtHoraPublicacao.Text))
			{
				entidadeVideo.DataHoraPublicacao = Convert.ToDateTime(String.Concat(txtdtPublicacao.Text, " ", txtHoraPublicacao.Text));
			}
			else
			{
				entidadeVideo.DataHoraPublicacao = Convert.ToDateTime(txtdtPublicacao.Text);
			}
		}

		if (!String.IsNullOrEmpty(txtYoutube.Text))
			entidadeVideo.UrlYoutube = txtYoutube.Text;

		if (!String.IsNullOrEmpty(txtAutor.Text))
			entidadeVideo.Autor = txtAutor.Text;

		entidadeVideo.Ativo = chbAtivo.Checked;
		entidadeVideo.DestaqueFiquePorDentro = chbDestaqueFique.Checked;
		entidadeVideo.DestaqueVideos = chbDestaque.Checked;
		entidadeVideo.DestaqueHome = chbDestaqueHome.Checked;

		// Carrega "VideoIdioma"
		if (!String.IsNullOrEmpty(txtDescricao.Text))
			entidadeVideoIdioma.DescricaoVideo = txtDescricao.Text;

		if (!String.IsNullOrEmpty(txtTitulo.Text))
			entidadeVideoIdioma.TituloVideo = txtTitulo.Text;

		entidadeVideoIdioma.Idioma.IdiomaId = this.IdiomaId;

		if (IdRegistro > 0)
		{
			conteudo.ConteudoId = Convert.ToInt32(IdRegistro);
			entidadeVideo.Conteudo.ConteudoId = conteudo.ConteudoId;
			entidadeVideoIdioma.Video.Conteudo.ConteudoId = conteudo.ConteudoId;
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
			videoIdiomaFH = new VideoIdiomaFH();
			videoIdiomaFH.IdiomaId = this.IdiomaId.ToString();
			videoIdiomaFH.VideoId = this.IdRegistro.ToString();
			cont = new VideoIdiomaService().TotalRegistros(videoIdiomaFH);
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

				if (this.conteudo.Video != null && this.conteudo.ConteudoId > 0)
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
	/// save Video e VideoIdioma
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
			entidadeVideo.Conteudo.ConteudoId = conteudo.ConteudoId;
			entidadeVideoIdioma.Video.Conteudo.ConteudoId = conteudo.ConteudoId;

			try
			{
				if (this.IdRegistro == 0)
				{
					// Save "Video"
					new VideoService().Inserir(entidadeVideo);

					// Insert the Tag
					new TagService().Relacionar(conteudo);

					// Save "ConteudoRegiao"
					for (int i = 0; i < conteudo.ConteudoRegiao.Count; i++)
					{
						new ConteudoService().InserirRelacionado(conteudo, Convert.ToInt32(conteudo.ConteudoRegiao[i].RegiaoId));
					}
				}

				// Save "VideoIdioma"
				new VideoIdiomaService().Inserir(entidadeVideoIdioma);
			}
			catch
			{
				new ConteudoService().Excluir(conteudo);
			}
		}
	}

	/// <summary>
	/// update Video e VideoIdioma
	/// </summary>
	protected void Update()
	{
		try
		{
			// Update "Video"
			videoService.Atualizar(entidadeVideo);

			// Update "VideoIdioma"
			videoIdiomaService.Atualizar(entidadeVideoIdioma);

			// Insert the Tag
			new TagService().Relacionar(conteudo);

			//Exclui o relacionamento entre Conteudo e Regiao para inserir atualizado
			new ConteudoService().ExcluirRelacionado(conteudo);
			for (int i = 0; i < conteudo.ConteudoRegiao.Count; i++)
			{
				new ConteudoService().InserirRelacionado(conteudo, Convert.ToInt32(conteudo.ConteudoRegiao[i].RegiaoId));
			}
		}
		catch
		{
			Util.ShowMessage("Registro não atualizado. Por favor tente mais tarde");
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

	#endregion
}
