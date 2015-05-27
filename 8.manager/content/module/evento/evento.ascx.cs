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

public partial class content_module_evento_evento : SmartUserControl
{
	#region [ Properties ]

	/// <summary>
	/// Business Object for "Conteudo" fields
	/// </summary>
	protected Conteudo conteudo;
	/// <summary>
	/// Business Object for "Evento" fields
	/// </summary>
	protected Evento entidadeEvento;
	/// <summary>
	/// Business Object for "EventoIdioma" fields
	/// </summary>
	protected EventoIdioma entidadeEventoIdioma;
	/// <summary>
	/// Business Object for "Arquivo" fields
	/// </summary>
	protected Arquivo entidadeArquivo;
	/// <summary>
	/// Business Object for "EventoFoto" fields
	/// </summary>
	protected EventoFoto entidadeEventoFoto;
	/// <summary>
	/// Business Object for "Tag" fields
	/// </summary>
	protected Tag entidadeTag;
	/// <summary>
	/// Business Object for "Regiao" fields
	/// </summary>
	protected Regiao entidadeRegiao;
	/// <summary>
	///   Service for "Evento" 
	/// </summary>
	protected EventoService eventoService;
	/// <summary>
	///   Service for "EventoIdioma" 
	/// </summary>
	protected EventoIdiomaService eventoIdiomaService;
	/// <summary>
	///   Service for "Arquivo" 
	/// </summary>
	protected ArquivoService arquivoService;
	/// <summary>
	///   Service for "EventoFoto" 
	/// </summary>
	protected EventoFotoService eventoFotoService;
	/// <summary>
	///   Service for "Conteudo" 
	/// </summary>
	protected ConteudoService conteudoService;
	/// <summary>
	///   Service for "Tag" 
	/// </summary>
	protected TagService tagService;
	/// <summary>
	///   Service for "ConteudoTag" 
	/// </summary>
	protected ConteudoTagService conteudoTagService;
	/// <summary>
	///   Service for "Regiao" 
	/// </summary>
	protected RegiaoService regiaoService;
	/// <summary>
	///  Filter for "conteudoTagFH" to search BO for tags
	/// </summary>
	protected ConteudoTagFH conteudoTagFH;
	/// <summary>
	///  Filter for "eventoFotoFH" to search BO for tags
	/// </summary>
	protected EventoFotoFH eventoFotoFH;
	/// <summary>
	///  Filter for "eventoFH" to search BO for tags
	/// </summary>
	protected EventoFH eventoFH;
	/// <summary>
	///  Filter for "eventoIdiomaFH" to search BO for tags
	/// </summary>
	protected EventoIdiomaFH eventoIdiomaFH;
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

	protected void Page_Init(object sender, EventArgs e)
	{
		this.DefineProperties();
		sfArquivo.DataKeyValue = Convert.ToString(this.IdRegistro);
		this.BindSubformArquivo();
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			LoadCheckBox();
			LoadRegiaoCheckBox();
		}

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
			this.Execute();
		}
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
		conteudo.Evento = new Evento();

		// Ini service to "Evento"
		entidadeEvento = new Evento();
		entidadeEvento.Conteudo = new Conteudo();

		// Ini service to "EventoIdioma"
		entidadeEventoIdioma = new EventoIdioma();
		entidadeEventoIdioma.Evento = new Evento();
		entidadeEventoIdioma.Evento.Conteudo = new Conteudo();
		entidadeEventoIdioma.Idioma = new Idioma();

		// Ini service to "EventoFoto"
		entidadeEventoFoto = new EventoFoto();
		entidadeEventoFoto.Evento = new Evento();
		entidadeEventoFoto.Evento.Conteudo = new Conteudo();
		entidadeEventoFoto.Evento.EventoIdiomas = new List<EventoIdioma>();
		eventoFotoFH = new EventoFotoFH();

		// Ini service to "Arquivo"
		entidadeArquivo = new Arquivo();
		entidadeArquivo.EventoFotos = new List<EventoFoto>();
		entidadeArquivo.EventosThumbGrande = new List<Evento>();
		entidadeArquivo.EventosThumbMedio = new List<Evento>();
		entidadeEvento.ArquivoThumbGrande = new Arquivo();

		// Ini service to "tag"
		entidadeTag = new Tag();
		conteudoTagService = new ConteudoTagService();
		conteudoTagFH = new ConteudoTagFH();

		eventoService = new EventoService();
		eventoIdiomaService = new EventoIdiomaService();
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

		// Ini "Evento"
		entidadeEvento = new Evento();
		entidadeEvento.Conteudo = new Conteudo();
		entidadeEvento.Conteudo.ConteudoId = conteudo.ConteudoId;

		// Ini and define "EventoIdioma"
		entidadeEventoIdioma = new EventoIdioma();
		entidadeEventoIdioma.Evento = new Evento();
		entidadeEventoIdioma.Evento.Conteudo = new Conteudo();
		entidadeEventoIdioma.Evento.Conteudo.ConteudoId = conteudo.ConteudoId;
		entidadeEventoIdioma.Idioma = new Idioma();
		entidadeEventoIdioma.Idioma.IdiomaId = this.IdiomaId;

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

		#region Arquivo ThumbMedio - ThumGrande

		// Search all news by "podcastId"
		eventoFH = new EventoFH();
		eventoFH.EventoId = Convert.ToString(conteudo.ConteudoId);
		IList<Evento> entidadeEventoList = new List<Evento>();
		entidadeEventoList = new EventoService().RetornaTodosSite(0, new string[] { "eventoId" }, new string[] { "ASC" }, eventoFH);

		DataTable dtGrande = new DataTable();
		dtGrande.Columns.Add(new DataColumn("arquivoId", typeof(int)));
		dtGrande.Columns.Add(new DataColumn("nomeArquivo", typeof(string)));

		DataTable dtMedio = new DataTable();
		dtMedio.Columns.Add(new DataColumn("arquivoId", typeof(int)));
		dtMedio.Columns.Add(new DataColumn("nomeArquivo", typeof(string)));

		for (int img = 0; img < entidadeEventoList.Count; img++)
		{
			DataRow drGrande = dtGrande.NewRow();
			Arquivo entidadeArquivo = new Arquivo();
			if (entidadeEventoList[img].ArquivoThumbGrande != null)
			{
				entidadeArquivo = new ArquivoService().Carregar(entidadeEventoList[img].ArquivoThumbGrande);
				drGrande["arquivoId"] = entidadeArquivo.ArquivoId;
				drGrande["NomeArquivo"] = entidadeArquivo.NomeArquivo;

				dtGrande.Rows.Add(drGrande);
			}

			if (entidadeEventoList[img].ArquivoThumbGrande != null)
			{
				DataRow drMedio = dtMedio.NewRow();
				entidadeArquivo = new Arquivo();
				entidadeArquivo = new ArquivoService().Carregar(entidadeEventoList[img].ArquivoThumbMedio);
				drMedio["arquivoId"] = entidadeArquivo.ArquivoId;
				drMedio["NomeArquivo"] = entidadeArquivo.NomeArquivo;

				dtMedio.Rows.Add(drMedio);
			}
		}

		sfGrande.DataSource = dtGrande;
		sfGrande.DataBind();

		sfMedio.DataSource = dtMedio;
		sfMedio.DataBind();

		#endregion

		#region EventoFoto

		this.BindSubformArquivo();

		#endregion

		// Ini service to find "Evento"
		eventoService = new EventoService();
		entidadeEvento = eventoService.Carregar(entidadeEvento);

		// Ini service to find "EventoIdioma"
		eventoIdiomaService = new EventoIdiomaService();
		entidadeEvento.EventoIdiomas = new List<EventoIdioma>();

		// Add "EventoIdioma"
		entidadeEvento.EventoIdiomas.Add(eventoIdiomaService.Carregar(entidadeEventoIdioma));

		// Add "Evento" to "conteudo"
		conteudo.Evento = new Evento();
		conteudo.Evento = entidadeEvento;
		// Add "EventoIdioma" to "Evento"
		conteudo.Evento = new EventoService().Carregar(entidadeEvento);
		conteudo.Evento.EventoIdiomas = entidadeEvento.EventoIdiomas;
	}

	/// <summary>
	/// 
	/// </summary>
	protected void ClearForm()
	{
		txtTitulo.Text = string.Empty;
		//uplThumbGrande.FileName = string.Empty;
		//uplThumbMédio.FileName = string.Empty;
		txtResumo.Text = string.Empty;
		txtConteudo.Text = string.Empty;
		txtdtFim.Text = string.Empty;
		txtdtInicio.Text = string.Empty;
		txtdtPublicacao.Text = string.Empty;
		txtHoraPublicacao.Text = string.Empty;
		txtTags.Text = string.Empty;
		txtTitulo.Text = string.Empty;
		txtLocal.Text = string.Empty;
		chbDestaque.Checked = false;
		chbDestaqueFique.Checked = false;
	}

	/// <summary>
	/// 
	/// </summary>
	protected void LoadForm()
	{
		if (conteudo != null
			&& conteudo.Evento != null
			&& conteudo.Evento.EventoIdiomas != null
			&& conteudo.Evento.EventoIdiomas.Count > 0)
		{

			if (conteudo.Evento.EventoIdiomas[0] != null)
			{
				txtTitulo.Text = conteudo.Evento.EventoIdiomas[0].NomeEvento.ToString();
				txtConteudo.Text = conteudo.Evento.EventoIdiomas[0].DescricaoEvento.ToString();
				txtResumo.Text = conteudo.Evento.EventoIdiomas[0].ChamadaEvento.ToString();
			}

			if (conteudo.Evento.DataHoraEventoInicio != null)
			{
				txtdtInicio.Text = Convert.ToDateTime(conteudo.Evento.DataHoraEventoInicio).ToString("dd/MM/yyyy");
				txtHoraInicio.Text = Convert.ToDateTime(conteudo.Evento.DataHoraEventoInicio).ToString("HH:mm");
			}

			if (conteudo.Evento.DataHoraEventoFim != null)
			{
				txtdtFim.Text = Convert.ToDateTime(conteudo.Evento.DataHoraEventoFim).ToString("dd/MM/yyyy");
				txtHoraFim.Text = Convert.ToDateTime(conteudo.Evento.DataHoraEventoFim).ToString("HH:mm");
			}

			if (conteudo.Evento.DataHoraPublicacao.ToString() != "")
			{
				txtdtPublicacao.Text = Convert.ToDateTime(conteudo.Evento.DataHoraPublicacao).ToString("dd/MM/yyyy");
				txtHoraPublicacao.Text = Convert.ToDateTime(conteudo.Evento.DataHoraPublicacao).ToString("HH:mm");
			}
			else
			{
				txtdtPublicacao.Text = DateTime.Now.ToString("dd/MM/yyyy");
				txtHoraPublicacao.Text = DateTime.Now.ToString("HH:mm");
			}

			txtLocal.Text = (conteudo.Evento != null && conteudo.Evento.Local != null) ? conteudo.Evento.Local.ToString() : string.Empty;

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

			chbDestaqueFique.Checked = (conteudo.Evento.DestaqueFiquePorDentro);

			chbDestaque.Checked = (conteudo.Evento.DestaqueEventos);

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
		conteudo.ConteudoTipo.ConteudoTipoId = 2;

		// Carrega "Evento"
		if (!String.IsNullOrEmpty(txtdtInicio.Text))
		{
			entidadeEvento.DataHoraEventoInicio = Convert.ToDateTime(String.Concat(txtdtInicio.Text, " ", txtHoraInicio.Text));
		}

		if (!String.IsNullOrEmpty(txtdtFim.Text))
		{
			entidadeEvento.DataHoraEventoFim = Convert.ToDateTime(String.Concat(txtdtFim.Text, " ", txtHoraFim.Text));
		}

		if (!String.IsNullOrEmpty(txtdtPublicacao.Text))
		{
			if (!String.IsNullOrEmpty(txtHoraPublicacao.Text))
			{
				entidadeEvento.DataHoraPublicacao = Convert.ToDateTime(String.Concat(txtdtPublicacao.Text, " ", txtHoraPublicacao.Text));
			}
			else
			{
				entidadeEvento.DataHoraPublicacao = Convert.ToDateTime(txtdtPublicacao.Text);
			}
		}

		//entidadeEvento.ArquivoThumbGrande = 0;

		//entidadeEvento.ArquivoThumbMedio = 0;

		if (!String.IsNullOrEmpty(txtLocal.Text))
			entidadeEvento.Local = txtLocal.Text;

		entidadeEvento.Ativo = true;
		entidadeEvento.DestaqueFiquePorDentro = chbDestaqueFique.Checked;
		entidadeEvento.DestaqueEventos = chbDestaque.Checked;

		// Carrega "EventoIdioma"
		if (!String.IsNullOrEmpty(txtConteudo.Text))
			entidadeEventoIdioma.DescricaoEvento = txtConteudo.Text;

		if (!String.IsNullOrEmpty(txtResumo.Text))
			entidadeEventoIdioma.ChamadaEvento = txtResumo.Text;

		if (!String.IsNullOrEmpty(txtTitulo.Text))
			entidadeEventoIdioma.NomeEvento = txtTitulo.Text;

		entidadeEventoIdioma.Idioma.IdiomaId = this.IdiomaId;

		if (IdRegistro > 0)
		{
			conteudo.ConteudoId = Convert.ToInt32(IdRegistro);
			entidadeEvento.Conteudo.ConteudoId = conteudo.ConteudoId;
			entidadeEventoIdioma.Evento.Conteudo.ConteudoId = conteudo.ConteudoId;
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
		//Carrega a lista de Categoria de Eventos
		entidadeEvento.EventoCategorias = new List<EventoCategoria>();
		EventoCategoria entidadeEventoCategoria = new EventoCategoria();
		for (int i = 0; i < chbCategoria.Items.Count; i++)
		{
			entidadeEventoCategoria = new EventoCategoria();
			if (chbCategoria.Items[i].Selected)
			{
				entidadeEventoCategoria.EventoCategoriaId = Convert.ToInt32(chbCategoria.Items[i].Value);
				entidadeEvento.EventoCategorias.Add(entidadeEventoCategoria);
			}
		}
		// Carrega a lista de regiões vinculadas ao conteudo
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
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void chbCategoria_DataBound(object sender, EventArgs e)
	{

	}

	/// <summary>
	/// 
	/// </summary>
	protected void LoadCheckBox()
	{
		EventoCategoriaIdioma entidadeEventoCategoriaIdioma = new EventoCategoriaIdioma();

		EventoCategoriaIdiomaService eventoCategoriaIdiomaService = new EventoCategoriaIdiomaService();

		EventoCategoriaIdiomaFH eventoCategoriaIdiomaFH = new EventoCategoriaIdiomaFH();
		eventoCategoriaIdiomaFH.IdiomaId = this.IdiomaId.ToString();

		IList<EventoCategoriaIdioma> entidadeEventoCategoriaIdiomaList = new List<EventoCategoriaIdioma>();
		entidadeEventoCategoriaIdiomaList = eventoCategoriaIdiomaService.RetornaTodos(0, 0, "", "", eventoCategoriaIdiomaFH);

		chbCategoria.DataSource = entidadeEventoCategoriaIdiomaList;
		chbCategoria.DataTextField = "categoriaEvento";
		chbCategoria.DataValueField = "eventoCategoriaId";
		chbCategoria.DataBind();

		if (this.IdRegistro != 0 || this.IdRegistro != null)
		{
			for (int i = 0; i < chbCategoria.Items.Count; i++)
			{
				int cont = new EventoService().TotalRegistrosRelacionado(Convert.ToInt32(this.IdRegistro), Convert.ToInt32(chbCategoria.Items[i].Value));

				if (cont > 0)
					chbCategoria.Items[i].Selected = true;
				else
					chbCategoria.Items[i].Selected = false;
			}
		}

	}

	/// <summary>
	/// 
	/// </summary>
	protected void LoadRegiaoCheckBox()
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
		// arquivoThumMedio
		List<Int32> lstEventoMedio = sfMedio.BuscaPKs();
		foreach (int arquivoId in lstEventoMedio)
		{
			entidadeEvento.ArquivoThumbMedio = new Arquivo();
			entidadeEvento.ArquivoThumbMedio.ArquivoId = arquivoId;
		}

		// arquivoThumGrande
		List<Int32> lstEventoGrande = sfGrande.BuscaPKs();
		foreach (int arquivoId in lstEventoGrande)
		{
			entidadeEvento.ArquivoThumbGrande = new Arquivo();
			entidadeEvento.ArquivoThumbGrande.ArquivoId = arquivoId;
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
			eventoIdiomaFH = new EventoIdiomaFH();
			eventoIdiomaFH.IdiomaId = this.IdiomaId.ToString();
			eventoIdiomaFH.EventoId = this.IdRegistro.ToString();
			cont = new EventoIdiomaService().TotalRegistros(eventoIdiomaFH);
		}

		if (conteudo != null && conteudo.ConteudoId > 0 && cont > 0)
		{
			try
			{
				if (entidadeEventoIdioma.ChamadaEvento != null || entidadeEventoIdioma.DescricaoEvento != null
					|| entidadeEvento.DataHoraEventoFim != null || entidadeEvento.DataHoraEventoInicio != null)
				{
					if (Convert.ToDateTime(txtdtInicio.Text) <= Convert.ToDateTime(txtdtFim.Text))
					{
						this.Update();
						Util.ShowMessage("Registro alterado com sucesso!");
					}
					else
					{
						Util.ShowMessage("Registro não pode ser salvo verifique os campos data, data inicio menos que data fim!");
					}
				}
			}
			catch
			{
				Util.ShowMessage("Registro não atualizado. Por favor tente mais tarde");
			}
		}
		else
		{
			try
			{
				if (entidadeEventoIdioma.ChamadaEvento != null || entidadeEventoIdioma.DescricaoEvento != null
					|| entidadeEvento.DataHoraEventoFim != null || entidadeEvento.DataHoraEventoInicio != null)
				{
					if (Convert.ToDateTime(txtdtInicio.Text) <= Convert.ToDateTime(txtdtFim.Text))
					{
						this.Save();
						Util.ShowMessage("Registro salvo com sucesso!");
					}
					else
					{
						Util.ShowMessage("Registro não pode ser salvo verifique os campos data, data inicio menos que data fim!");
					}
				}
			}
			catch
			{
				Util.ShowMessage("Registro não atualizado. Por favor tente mais tarde");
			}
		}

		if (entidadeEventoIdioma.ChamadaEvento != null || entidadeEventoIdioma.DescricaoEvento != null
			|| entidadeEvento.DataHoraEventoFim != null || entidadeEvento.DataHoraEventoInicio != null)
		{
			// Update/ Save "Conteudo"
			this.SaveWorkflow();
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
			entidadeEvento.Conteudo.ConteudoId = conteudo.ConteudoId;
			entidadeEventoIdioma.Evento.Conteudo.ConteudoId = conteudo.ConteudoId;

			try
			{
				if (this.IdRegistro == 0)
				{
					addListArquivo();

					// Save "Evento"
					new EventoService().Inserir(entidadeEvento);

					// Insert the Tag
					new TagService().Relacionar(conteudo);

					// Save "Categorias"
					int id = conteudo.ConteudoId;
					for (int i = 0; i < entidadeEvento.EventoCategorias.Count; i++)
					{
						new EventoService().InserirRelacionado(entidadeEvento.EventoCategorias[i], id, this.IdiomaId);
					}

					// Save "ConteudoRegiao"
					for (int i = 0; i < conteudo.ConteudoRegiao.Count; i++)
					{
						new ConteudoService().InserirRelacionado(conteudo, Convert.ToInt32(conteudo.ConteudoRegiao[i].RegiaoId));
					}

				}

				// Save "EventoIdioma"
				new EventoIdiomaService().Inserir(entidadeEventoIdioma);

			}
			catch
			{
				new ConteudoService().Excluir(conteudo);

				eventoService.ExcluirRelacionado(conteudo.ConteudoId, this.IdiomaId);
			}
		}
	}

	/// <summary>
	/// 
	/// </summary>
	protected void Update()
	{
		addListArquivo();

		// Update "Evento"
		eventoService.Atualizar(entidadeEvento);

		// Update "EventoIdioma"
		eventoIdiomaService.Atualizar(entidadeEventoIdioma);

		try
		{
			//Exclui o relacionamento entre Evento e EventoCategoria para inserir atualizado
			eventoService.ExcluirRelacionado(conteudo.ConteudoId, this.IdiomaId);
			int id = conteudo.ConteudoId;
			for (int i = 0; i < entidadeEvento.EventoCategorias.Count; i++)
			{
				new EventoService().InserirRelacionado(entidadeEvento.EventoCategorias[i], id, this.IdiomaId);
			}

			//Exclui o relacionamento entre Conteudo e Regiao para inserir atualizado
			new ConteudoService().ExcluirRelacionado(conteudo);
			for (int i = 0; i < conteudo.ConteudoRegiao.Count; i++)
			{
				new ConteudoService().InserirRelacionado(conteudo, Convert.ToInt32(conteudo.ConteudoRegiao[i].RegiaoId));
			}

			if (entidadeEvento.EventoFotos.Count > 0)
			{
				// delete "EventoFoto"
				new EventoFotoService().Excluir(entidadeEvento.EventoFotos[0]);
				// save "EventoFoto"
				for (int img = 0; img < entidadeEvento.EventoFotos.Count; img++)
				{
					new EventoFotoService().Inserir(entidadeEvento.EventoFotos[img]);
				}
			}
			else
			{
				// delete "EventoFoto"
				entidadeEventoFoto = new EventoFoto();
				entidadeEventoFoto.Evento = new Evento();
				entidadeEventoFoto.Evento.Conteudo = new Conteudo();
				entidadeEventoFoto.Evento.Conteudo.ConteudoId = conteudo.ConteudoId;
				new EventoFotoService().Excluir(entidadeEventoFoto);
			}
		}
		catch
		{
			eventoService.ExcluirRelacionado(conteudo.ConteudoId, this.IdiomaId);
		}

		// Insert the Tag
		new TagService().Relacionar(conteudo);
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

	protected void BindSubformArquivo()
	{
		// Search all news by "eventoId"
		eventoFotoFH = new EventoFotoFH();
		eventoFotoFH.EventoId = this.IdRegistro.ToString();
		IList<EventoFoto> entidadeEventoFotoList = new List<EventoFoto>();
		entidadeEventoFotoList = new EventoFotoService().RetornaTodos(0, 0, null, null, eventoFotoFH);

		DataTable dt = new DataTable();
		dt.Columns.Add(new DataColumn("arquivoId", typeof(int)));
		dt.Columns.Add(new DataColumn("nomeArquivo", typeof(string)));
		for (int img = 0; img < entidadeEventoFotoList.Count; img++)
		{
			DataRow dr = dt.NewRow();
			Arquivo entidadeArquivo = new Arquivo();
			entidadeArquivo = new ArquivoService().Carregar(entidadeEventoFotoList[img].Arquivo);
			dr["arquivoId"] = entidadeEventoFotoList[img].EventoFotoId;
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
				EventoFotoComentarioService eventoFotoComentarioService = new EventoFotoComentarioService();
				List<EventoFotoComentario> eventoImagensComentarios = (List<EventoFotoComentario>)eventoFotoComentarioService.CarregarTodos(0, 0, null, null, new EventoFotoComentarioFH() { EventoFotoId = sid });
				if (eventoImagensComentarios != null)
				{
					foreach (EventoFotoComentario nic in eventoImagensComentarios)
					{
						eventoFotoComentarioService.Excluir(nic);
					}
				}

				EventoFotoService eventoFotoService = new EventoFotoService();
				EventoFoto ni = eventoFotoService.Carregar(new EventoFoto() { EventoFotoId = Convert.ToInt32(sid) });
				if (ni != null)
				{
					eventoFotoService.Excluir(ni);
				}
			}
		}

		this.BindSubformArquivo();
	}
}
