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
using Ag2.Manager.WebUI;

public partial class content_module_noticia_noticia : SmartUserControl
{
	#region [Properties]
	/// <summary>
	/// Business Object for "Conteudo" fields
	/// </summary>
	protected Conteudo conteudo;
	/// <summary>
	/// Business Object for "Noticia" fields
	/// </summary>
	protected Noticia entidadeNoticia;
	/// <summary>
	/// Business Object for "NoticiaIdioma" fields
	/// </summary>
	protected NoticiaIdioma entidadeNoticiaIdioma;
	/// <summary>
	/// Business Object for "Arquivo" fields
	/// </summary>
	protected Arquivo entidadeArquivo;
	/// <summary>
	/// Business Object for "Noticia Imagem" fields
	/// </summary>
	protected NoticiaImagem entidadeNoticiaImagem;
	/// <summary>
	/// Business Object for "Tag" fields
	/// </summary>
	protected Tag entidadeTag;
	/// <summary>
	/// Business Object for "Região" fields
	/// </summary>
	protected Regiao entidadeRegiao;
	/// <summary>
	///   Service for "NoticiaService" 
	/// </summary>
	protected NoticiaService noticiaService;
	/// <summary>
	///   Service for "NoticiaIdiomaService" 
	/// </summary>
	protected NoticiaIdiomaService noticiaIdiomaService;
	/// <summary>
	///   Service for "ArquivoService" 
	/// </summary>
	protected ArquivoService arquivoService;
	/// <summary>
	///   Service for "NoticiaImagemService" 
	/// </summary>
	protected NoticiaImagemService noticiaImagemService;
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
	///  Filter for "NoticiaImagemFH" to search BO for tags
	/// </summary>
	protected NoticiaImagemFH noticiaImagemFH;
	/// <summary>
	///  Filter for "NoticiaFH" to search BO for tags
	/// </summary>
	protected NoticiaFH noticiaFH;
	/// <summary>
	///  Filter for "NoticiaIdiomaFH" to search BO for tags
	/// </summary>
	protected NoticiaIdiomaFH noticiaIdiomaFH;
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

	protected void Page_Init(object sender, EventArgs e)
	{
		this.DefineProperties();
		sfArquivo.DataKeyValue = Convert.ToString(this.IdRegistro);
		this.BindSubformArquivo();
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
			LoadCheckBox();

		if (this.IdRegistro > 0)
		{
			sfArquivo.Visible = true;
			if (!IsPostBack || this.IdiomaHasChanged)
			{
				this.LoadProperties();
				this.LoadForm();

				pnlRelacionado.Visible = true;
			}
		}
		else
		{
			sfArquivo.Visible = false;
			pnlRelacionado.Visible = false;
		}
	}


	protected void btnExecute_Click(object sender, ImageClickEventArgs e)
	{
		if (Page.IsValid)
		{
			this.FormToLoad();

			int cont = 0;
			if (this.IdRegistro > 0)
			{
				noticiaIdiomaFH = new NoticiaIdiomaFH();
				noticiaIdiomaFH.IdiomaId = this.IdiomaId.ToString();
				noticiaIdiomaFH.NoticiaId = this.IdRegistro.ToString();
				cont = new NoticiaIdiomaService().TotalRegistros(noticiaIdiomaFH);
			}

			if (conteudo != null && conteudo.ConteudoId > 0 && cont > 0)
			{
				try
				{
					if (Convert.ToDateTime(txtdtInicio.Text) <= Convert.ToDateTime(txtdtFim.Text))
					{
						this.Update();
						Util.ShowMessage("Registro alterado com sucesso!");
					}
				}
				catch
				{
					Util.ShowMessage("Registro não atualizado. Por favor tente mais tarde");
				}
			}
			else
			{
				if (Convert.ToDateTime(txtdtInicio.Text) <= Convert.ToDateTime(txtdtFim.Text))
				{
					this.Save();
					Util.ShowMessage("Registro salvo com sucesso!");
				}
			}

			if (Convert.ToDateTime(txtdtInicio.Text) <= Convert.ToDateTime(txtdtFim.Text))
			{
				// Update/ Save "Conteudo"
				this.SaveWorkflow();
			}
		}
	}

	#endregion

	#region [ Methods ]

	/// <summary>
	/// Define all services to all properties
	/// </summary>
	private void DefineProperties()
	{
		// Ini service to "conteudo"
		conteudo = new Conteudo();
		conteudo.Noticia = new Noticia();

		// Ini service to "Noticia"
		entidadeNoticia = new Noticia();
		entidadeNoticia.Conteudo = new Conteudo();

		// Ini service to "NoticiaIdioma"
		entidadeNoticiaIdioma = new NoticiaIdioma();
		entidadeNoticiaIdioma.Noticia = new Noticia();
		entidadeNoticiaIdioma.Noticia.Conteudo = new Conteudo();
		entidadeNoticiaIdioma.Idioma = new Idioma();

		// Ini service to "NoticiaImagem"
		entidadeNoticiaImagem = new NoticiaImagem();
		entidadeNoticiaImagem.Noticia = new Noticia();
		entidadeNoticiaImagem.Noticia.Conteudo = new Conteudo();
		entidadeNoticiaImagem.Noticia.NoticiaIdiomas = new List<NoticiaIdioma>();
		noticiaImagemFH = new NoticiaImagemFH();

		// Ini service to "Arquivo"
		entidadeArquivo = new Arquivo();
		entidadeArquivo.NoticiaImagens = new List<NoticiaImagem>();
		entidadeArquivo.NoticiasThumbGrande = new List<Noticia>();
		entidadeArquivo.NoticiasThumbMedio = new List<Noticia>();
		entidadeNoticia.ArquivoThumbGrande = new Arquivo();

		// Ini service to "tag"
		entidadeTag = new Tag();
		conteudoTagService = new ConteudoTagService();
		conteudoTagFH = new ConteudoTagFH();

		noticiaService = new NoticiaService();
		noticiaIdiomaService = new NoticiaIdiomaService();
		conteudoService = new ConteudoService();

		conteudo.Noticia.Conteudo = new Conteudo();
		conteudo.Noticia = new Noticia();

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

		// Ini "Noticia"
		entidadeNoticia = new Noticia();
		entidadeNoticia.Conteudo = new Conteudo();
		entidadeNoticia.Conteudo.ConteudoId = conteudo.ConteudoId;

		// Ini and define "NoticiaIdioma"
		entidadeNoticiaIdioma = new NoticiaIdioma();
		entidadeNoticiaIdioma.Noticia = new Noticia();
		entidadeNoticiaIdioma.Noticia.Conteudo = new Conteudo();
		entidadeNoticiaIdioma.Noticia.Conteudo.ConteudoId = conteudo.ConteudoId;
		entidadeNoticiaIdioma.Idioma = new Idioma();
		entidadeNoticiaIdioma.Idioma.IdiomaId = this.IdiomaId;

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

		#region Arquivo ThumbMedio - ThumGrande

		// Search all news by "podcastId"
		noticiaFH = new NoticiaFH();
		noticiaFH.NoticiaId = Convert.ToString(conteudo.ConteudoId);
		IList<Noticia> entidadeNoticiaList = new List<Noticia>();
		entidadeNoticiaList = new NoticiaService().CarregarTodos(0, 0, new string[] { "noticiaId" }, new string[] { "ASC" }, noticiaFH);

		DataTable dtGrande = new DataTable();
		dtGrande.Columns.Add(new DataColumn("arquivoId", typeof(int)));
		dtGrande.Columns.Add(new DataColumn("nomeArquivo", typeof(string)));

		DataTable dtMedio = new DataTable();
		dtMedio.Columns.Add(new DataColumn("arquivoId", typeof(int)));
		dtMedio.Columns.Add(new DataColumn("nomeArquivo", typeof(string)));

		for (int img = 0; img < entidadeNoticiaList.Count; img++)
		{
			DataRow drGrande = dtGrande.NewRow();
			Arquivo entidadeArquivo = new Arquivo();
			if (entidadeNoticiaList[img].ArquivoThumbGrande != null)
			{
				entidadeArquivo = new ArquivoService().Carregar(entidadeNoticiaList[img].ArquivoThumbGrande);
				drGrande["arquivoId"] = entidadeArquivo.ArquivoId;
				drGrande["NomeArquivo"] = entidadeArquivo.NomeArquivo;

				dtGrande.Rows.Add(drGrande);
			}

			if (entidadeNoticiaList[img].ArquivoThumbMedio != null)
			{
				DataRow drMedio = dtMedio.NewRow();
				entidadeArquivo = new Arquivo();
				entidadeArquivo = new ArquivoService().Carregar(entidadeNoticiaList[img].ArquivoThumbMedio);
				drMedio["arquivoId"] = entidadeArquivo.ArquivoId;
				drMedio["NomeArquivo"] = entidadeArquivo.NomeArquivo;

				dtMedio.Rows.Add(drMedio);
			}
		}

		if (dtGrande.Rows.Count > 0)
		{
			sfGrande.DataKeyValue = Convert.ToString(this.IdRegistro);
			sfGrande.DataSource = dtGrande;
			sfGrande.DataBind();
		}

		if (dtMedio.Rows.Count > 0)
		{
			sfGrande.DataKeyValue = Convert.ToString(this.IdRegistro);
			sfMedio.DataSource = dtMedio;
			sfMedio.DataBind();
		}

		#endregion

		#region NoticiaImagem

		this.BindSubformArquivo();

		#endregion

		// Ini service to find "Noticia"
		noticiaService = new NoticiaService();
		entidadeNoticia = noticiaService.Carregar(entidadeNoticia);

		// Ini service to find "NoticiaIdioma"
		noticiaIdiomaService = new NoticiaIdiomaService();
		entidadeNoticia.NoticiaIdiomas = new List<NoticiaIdioma>();

		// Add "NoticiaIdioma"
		entidadeNoticia.NoticiaIdiomas.Add(noticiaIdiomaService.Carregar(entidadeNoticiaIdioma));

		// Add "Noticia" to "conteudo"
		conteudo.Noticia = new Noticia();
		conteudo.Noticia = entidadeNoticia;
		// Add "NoticiaIdioma" to "Noticia"
		conteudo.Noticia = new NoticiaService().Carregar(entidadeNoticia);
		conteudo.Noticia.NoticiaIdiomas = entidadeNoticia.NoticiaIdiomas;
	}

	/// <summary>
	/// 
	/// </summary>
	protected void LoadForm()
	{
		if (conteudo != null
			&& conteudo.Noticia != null
			&& conteudo.Noticia.NoticiaIdiomas != null
			&& conteudo.Noticia.NoticiaIdiomas.Count > 0)
		{
			if (conteudo.Noticia.NoticiaIdiomas.Count > 0)
			{
				if (conteudo.Noticia.NoticiaIdiomas[0] != null)
				{
					txtTitulo.Text = conteudo.Noticia.NoticiaIdiomas[0].TituloNoticia.ToString();
					txtConteudo.Text = conteudo.Noticia.NoticiaIdiomas[0].TextoNoticia.ToString();
					txtChamadaNoticia.Text = conteudo.Noticia.NoticiaIdiomas[0].ChamadaNoticia.ToString();
				}
			}

			txtdtPublicacao.Text = Convert.ToDateTime(conteudo.Noticia.DataHoraPublicacao).ToString("dd/MM/yyyy");

			if (conteudo.Noticia.DataExibicaoInicio != null)
			{
				txtdtInicio.Text = Convert.ToDateTime(conteudo.Noticia.DataExibicaoInicio).ToString("dd/MM/yyyy");
				txtHoraInicio.Text = Convert.ToDateTime(conteudo.Noticia.DataExibicaoInicio).ToString("HH:mm");
			}

			if (conteudo.Noticia.DataExibicaoFim != null)
			{
				txtdtFim.Text = Convert.ToDateTime(conteudo.Noticia.DataExibicaoFim).ToString("dd/MM/yyyy");
				txtHoraFim.Text = Convert.ToDateTime(conteudo.Noticia.DataExibicaoFim).ToString("HH:mm");
			}

			txtAutor.Text = (conteudo.Noticia != null && conteudo.Noticia.Autor != null) ? conteudo.Noticia.Autor.ToString() : string.Empty;
			txtFonte.Text = (conteudo.Noticia != null && conteudo.Noticia.Fonte != null) ? conteudo.Noticia.Fonte.ToString() : string.Empty;
			txtFonteURL.Text = (conteudo.Noticia != null && conteudo.Noticia.FonteUrl != null) ? conteudo.Noticia.FonteUrl.ToString() : string.Empty;

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

			if (conteudo.Noticia.DestaqueFiquePorDentro)
				chbDestaqueFique.Checked = true;
			else
				chbDestaqueFique.Checked = false;

			if (conteudo.Noticia.DestaqueHome)
				chbDestaqueHome.Checked = true;
			else
				chbDestaqueHome.Checked = false;

			if (conteudo.Noticia.DestaqueNoticias)
				chbDestaque.Checked = true;
			else
				chbDestaque.Checked = false;

			chbDestaqueUltimasNoticias.Checked = conteudo.Noticia.DestaqueUltimasNoticias;
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
		conteudo.ConteudoTipo.ConteudoTipoId = 1;

		// Carrega "Noticia"
		if (!String.IsNullOrEmpty(txtdtInicio.Text))
		{
			entidadeNoticia.DataExibicaoInicio = Convert.ToDateTime(String.Concat(txtdtInicio.Text, " ", txtHoraInicio.Text));
		}

		if (!String.IsNullOrEmpty(txtdtFim.Text))
		{
			entidadeNoticia.DataExibicaoFim = Convert.ToDateTime(String.Concat(txtdtFim.Text, " ", txtHoraFim.Text));
		}

		if (!String.IsNullOrEmpty(txtdtPublicacao.Text))
		{
			entidadeNoticia.DataHoraPublicacao = Convert.ToDateTime(txtdtPublicacao.Text);
		}

		if (!String.IsNullOrEmpty(txtAutor.Text))
		{
			entidadeNoticia.Autor = txtAutor.Text;
		}

		entidadeNoticia.Ativa = true;
		entidadeNoticia.DestaqueFiquePorDentro = chbDestaqueFique.Checked;
		entidadeNoticia.DestaqueHome = chbDestaqueHome.Checked;
		entidadeNoticia.DestaqueNoticias = chbDestaque.Checked;
		entidadeNoticia.DestaqueUltimasNoticias = chbDestaqueUltimasNoticias.Checked;

		if (!String.IsNullOrEmpty(txtFonte.Text))
		{
			entidadeNoticia.Fonte = txtFonte.Text;
		}

		if (!String.IsNullOrEmpty(txtFonteURL.Text))
		{
			entidadeNoticia.FonteUrl = txtFonteURL.Text;
		}

		// Carrega "NoticiaIdioma"
		if (!String.IsNullOrEmpty(txtTitulo.Text))
		{
			entidadeNoticiaIdioma.TituloNoticia = txtTitulo.Text;
		}

		if (!String.IsNullOrEmpty(txtConteudo.Text))
		{
			entidadeNoticiaIdioma.TextoNoticia = txtConteudo.Text;
		}

		if (!String.IsNullOrEmpty(txtChamadaNoticia.Text))
		{
			entidadeNoticiaIdioma.ChamadaNoticia = txtChamadaNoticia.Text;
		}

		entidadeNoticiaIdioma.Idioma.IdiomaId = this.IdiomaId;

		if (IdRegistro > 0)
		{
			conteudo.ConteudoId = Convert.ToInt32(IdRegistro);
			entidadeNoticia.Conteudo.ConteudoId = conteudo.ConteudoId;
			entidadeNoticiaIdioma.Noticia.Conteudo.ConteudoId = conteudo.ConteudoId;
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
			entidadeNoticia.Conteudo.ConteudoId = conteudo.ConteudoId;
			entidadeNoticiaIdioma.Noticia.Conteudo.ConteudoId = conteudo.ConteudoId;

			try
			{
				if (this.IdRegistro == 0)
				{
					addListArquivo();

					// Save "Noticia"
					new NoticiaService().Inserir(entidadeNoticia);

					// Insert the Tag
					new TagService().Relacionar(conteudo);

					// Save "ConteudoRegiao"
					for (int i = 0; i < conteudo.ConteudoRegiao.Count; i++)
					{
						new ConteudoService().InserirRelacionado(conteudo, Convert.ToInt32(conteudo.ConteudoRegiao[i].RegiaoId));
					}
				}

				// Save "NoticiaIdioma"
				new NoticiaIdiomaService().Inserir(entidadeNoticiaIdioma);

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
		// add "NoticiaImagem" and "Thumb Médio and Grande"
		addListArquivo();

		// Update "Noticia"
		noticiaService.Atualizar(entidadeNoticia);

		// Update "NoticiaIdioma"
		noticiaIdiomaService.Atualizar(entidadeNoticiaIdioma);

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
	protected void addListArquivo()
	{
		// arquivoThumMedio
		List<Int32> lstNoticiaMedio = sfMedio.BuscaPKs();
		foreach (int arquivoId in lstNoticiaMedio)
		{
			entidadeNoticia.ArquivoThumbMedio = new Arquivo();
			entidadeNoticia.ArquivoThumbMedio.ArquivoId = arquivoId;
		}

		// arquivoThumGrande
		List<Int32> lstNoticiaGrande = sfGrande.BuscaPKs();
		foreach (int arquivoId in lstNoticiaGrande)
		{
			entidadeNoticia.ArquivoThumbGrande = new Arquivo();
			entidadeNoticia.ArquivoThumbGrande.ArquivoId = arquivoId;
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

	/// <summary>
	/// Clear the form
	/// </summary>
	protected void ClearForm()
	{
		txtTitulo.Text = string.Empty;
		//uplThumbGrande.FileName = string.Empty;
		//uplThumbMédio.FileName = string.Empty;
		txtAutor.Text = string.Empty;
		txtChamadaNoticia.Text = string.Empty;
		txtConteudo.Text = string.Empty;
		txtdtFim.Text = string.Empty;
		txtdtInicio.Text = string.Empty;
		txtdtPublicacao.Text = string.Empty;
		txtFonte.Text = string.Empty;
		txtFonteURL.Text = string.Empty;
		txtTags.Text = string.Empty;
		txtTitulo.Text = string.Empty;
		txtHoraFim.Text = string.Empty;
		txtHoraInicio.Text = string.Empty;
		chbDestaque.Checked = false;
		chbDestaqueUltimasNoticias.Checked = false;
		chbDestaqueFique.Checked = false;
		chbDestaqueHome.Checked = false;
	}

	#endregion

	protected void BindSubformArquivo()
	{
		// Search all news by "noticiaId"
		noticiaImagemFH = new NoticiaImagemFH();
		noticiaImagemFH.NoticiaId = this.IdRegistro.ToString();
		IList<NoticiaImagem> entidadeNoticiaImagemList = new List<NoticiaImagem>();
		entidadeNoticiaImagemList = new NoticiaImagemService().RetornaTodos(0, 0, "", "", noticiaImagemFH);

		DataTable dt = new DataTable();
		dt.Columns.Add(new DataColumn("arquivoId", typeof(int)));
		dt.Columns.Add(new DataColumn("nomeArquivo", typeof(string)));
		for (int img = 0; img < entidadeNoticiaImagemList.Count; img++)
		{
			DataRow dr = dt.NewRow();
			Arquivo entidadeArquivo = new Arquivo();
			entidadeArquivo = new ArquivoService().Carregar(entidadeNoticiaImagemList[img].Arquivo);
			dr["arquivoId"] = entidadeNoticiaImagemList[img].NoticiaImagemId;
			dr["NomeArquivo"] = entidadeArquivo.NomeArquivo;

			dt.Rows.Add(dr);
		}


		sfArquivo.DataSource = dt;
		sfArquivo.DataBind();
		sfArquivo.DataKeyValue = this.IdRegistro.ToString();
	}

	protected void sfArquivo_Excluir(object sender, Ag2.Manager.WebUI.SubFormEventArgs e)
	{
		if (e.listIDs != null)
		{
			foreach (string sid in e.listIDs)
			{
				NoticiaImagemComentarioService noticiaImagemComentarioService = new NoticiaImagemComentarioService();
				List<NoticiaImagemComentario> noticiaImagensComentarios = (List<NoticiaImagemComentario>)noticiaImagemComentarioService.CarregarTodos(0, 0, null, null, new NoticiaImagemComentarioFH() { NoticiaImagemId = sid });
				if (noticiaImagensComentarios != null)
				{
					foreach (NoticiaImagemComentario nic in noticiaImagensComentarios)
					{
						noticiaImagemComentarioService.Excluir(nic);
					}
				}

				NoticiaImagemService noticiaImagemService = new NoticiaImagemService();
				NoticiaImagem ni = noticiaImagemService.Carregar(new NoticiaImagem() { NoticiaImagemId = Convert.ToInt32(sid) });
				if (ni != null)
				{
					noticiaImagemService.Excluir(ni);
				}
			}
		}

		this.BindSubformArquivo();
	}
}
