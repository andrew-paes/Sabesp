using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using Ag2.Manager.Helper;
using Sabesp.BO;
using Sabesp.Data;
using Sabesp.Data.Services;
using Sabesp.FilterHelper;

public partial class content_module_comunicado_comunicado : SmartUserControl
{
	#region [ Properties ]
	/// <summary>
	/// Business Object for "Conteudo" fields
	/// </summary>
	protected Conteudo conteudo;
	/// <summary>
	/// Business Object for "Regiao" fields
	/// </summary>
	protected Regiao entidadeRegiao;
	/// <summary>
	/// Business Object for "EntidadeComunicado" fields
	/// </summary>
	protected Comunicado entidadeComunicado;
	/// <summary>
	///  Business Object for "EntidadeComunicadoIdioma" fields
	/// </summary>
	protected ComunicadoIdioma entidadeComunicadoIdioma;
	/// <summary>
	///  Business Object for "EntidadeTag" fields
	/// </summary>
	protected Tag entidadeTag;
	/// <summary>
	///  Business Object for "EntidadeConteudoTag" fields
	/// </summary>
	protected ConteudoTag entidadeConteudoTag;
	/// <summary>
	///   Service for "Comunicado" 
	/// </summary>
	protected ComunicadoService comunicadoService;
	/// <summary>
	///   Service for "ComunicadoIdioma" 
	/// </summary>
	protected ComunicadoIdiomaService comunicadoIdiomaService;
	/// <summary>
	///   Service for "Regiao" 
	/// </summary>
	protected RegiaoService regiaoService;
	/// <summary>
	///   Service for "Tag" 
	/// </summary>
	protected TagService tagService;
	/// <summary>
	///  Service for "ConteudoTag" 
	/// </summary>
	protected ConteudoTagService conteudoTagService;
	/// <summary>
	///  Filter for "ConteudoTagFH" to search BO for tags
	/// </summary>
	protected ConteudoTagFH conteudoTagFH;
	/// <summary>
	///  Filter for "comunicadoIdiomaFH" to search BO for tags
	/// </summary>
	protected ComunicadoIdiomaFH comunicadoIdiomaFH;
	/// <summary>
	///  Filter for "regiaoFH" to search BO for tags
	/// </summary>
	protected RegiaoFH regiaoFH;

	#endregion

	#region [ Page Events ]

	protected void Page_Load(object sender, EventArgs e)
	{
		//Initialize properties n services
		this.DefineProperties();

		if (!Page.IsPostBack)
			LoadCheckBox();

		// check if new register
		if (this.IdRegistro > 0)
		{
			if (!IsPostBack || this.IdiomaHasChanged)
			{
				this.LoadProperties();
				this.LoadForm();

				this.pnlRelacionado.Visible = true;
			}
		}
		else // can't associate if new 
		{
			this.pnlRelacionado.Visible = false;
		}
	}

	#region [ btnExecute Events ]
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

	#endregion

	#region [ Methods ]

	/// <summary>
	/// To verify if a date interval is valid
	/// </summary>
	/// <returns></returns>
	private bool DateIntervalValidator()
	{
		bool isValid = false;

		if (String.IsNullOrEmpty(this.txtdtInicio.Text.Trim()) || String.IsNullOrEmpty(this.txtdtFim.Text.Trim()))
		{
			isValid = true;
		}
		else
		{
			if (Convert.ToDateTime(this.txtdtInicio.Text) <= Convert.ToDateTime(this.txtdtFim.Text))
			{
				isValid = true;
			}
		}

		return isValid;
	}

	#region [ DefineProperties And WorkForm ]

	/// <summary>
	/// Define all services to all properties
	/// </summary>
	private void DefineProperties()
	{
		// Define conteudo properties
		this.DefinePropertiesConteudo();
		// Define Tag
		this.DefinePropertiesEntidadeTag();
		// Define entidatecomunicado
		this.DefinePropertiesEntidadeComunicado();
		// Define ConteudoTag
		this.DefinePropertiesConteudoTag();
		// define services
		this.DefinePropertiesServices();

	}

	/// <summary>
	/// Define properties Conteudo
	/// </summary>
	private void DefinePropertiesConteudo()
	{
		// Ini service to "conteudo"
		this.conteudo = new Conteudo();
		this.conteudo.Comunicado = new Comunicado();
		this.conteudo.Comunicado.ComunicadoIdiomas = new List<ComunicadoIdioma>();
		this.conteudo.ConteudoTipo = new ConteudoTipo();
		this.conteudo.Tages = new List<Tag>();
		//conteudo.Comunicado.ComunicadoIdiomas[0].Idioma.IdiomaId = this.IdiomaId;
	}

	/// <summary>
	/// Define properties "tag"
	/// </summary>
	private void DefinePropertiesEntidadeTag()
	{
		// Ini service to "tag"
		this.entidadeTag = new Tag();
	}

	/// <summary>
	/// Define properties "EntidadeComunicado"
	/// </summary>
	private void DefinePropertiesEntidadeComunicado()
	{
		// Ini service to "comunicado"
		this.entidadeComunicado = new Comunicado();
		this.entidadeComunicado.Conteudo = new Conteudo();
		this.entidadeComunicado.ComunicadoIdiomas = new List<ComunicadoIdioma>();
		this.entidadeComunicadoIdioma = new ComunicadoIdioma();
		this.entidadeComunicadoIdioma.Comunicado = new Comunicado();
		this.entidadeComunicadoIdioma.Comunicado.Conteudo = new Conteudo();
		this.entidadeComunicadoIdioma.Idioma = new Idioma();
		this.entidadeComunicadoIdioma.Idioma.IdiomaId = this.IdiomaId;
	}

	/// <summary>
	/// Define properties "ConteudoTag"
	/// </summary>
	private void DefinePropertiesConteudoTag()
	{
		// Ini service to "ConteudoTag"
		this.entidadeConteudoTag = new ConteudoTag();

	}

	/// <summary>
	/// Define services
	/// </summary>
	private void DefinePropertiesServices()
	{
		this.comunicadoService = new ComunicadoService();
		this.comunicadoIdiomaService = new ComunicadoIdiomaService();
		this.conteudoTagService = new ConteudoTagService();
		this.conteudoTagFH = new ConteudoTagFH();
	}

	/// <summary>
	/// Load all properties
	/// </summary>
	private void LoadProperties()
	{
		// Find and add "conteudo"        
		this.conteudo.ConteudoId = Convert.ToInt32(IdRegistro);
		this.conteudo = new ConteudoService().Carregar(this.conteudo);

		// Load by "conteudo"
		this.entidadeComunicado.Conteudo.ConteudoId = conteudo.ConteudoId; // Ini "comunicado"
		this.entidadeComunicadoIdioma.Comunicado.Conteudo.ConteudoId = conteudo.ConteudoId; // Define "comunicadoIdioma"
		this.entidadeComunicado = comunicadoService.Carregar(this.entidadeComunicado); // Find "comunicado"

		// Load "Idioma" by "conteudo"
		this.entidadeComunicado.ComunicadoIdiomas = new List<ComunicadoIdioma>();
		this.entidadeComunicado.ComunicadoIdiomas.Add(this.comunicadoIdiomaService.Carregar(this.entidadeComunicadoIdioma)); // Add "comunicadoIdioma"

		// Load Comunicado.
		this.conteudo.Comunicado = entidadeComunicado; // Add "comunicado" to "conteudo"        
		this.conteudo.Comunicado = new ComunicadoService().Carregar(entidadeComunicado); // Add "comunicadoIdioma" to "comunicado"
		this.conteudo.Comunicado.ComunicadoIdiomas = entidadeComunicado.ComunicadoIdiomas;

		this.conteudo.Tages = new List<Tag>();

		// Search all "ConteudoTag" by ID of "Conteudo"
		IList<ConteudoTag> conteudoTagList = new List<ConteudoTag>();
		this.conteudoTagFH.ConteudoId = Convert.ToString(conteudo.ConteudoId);

		conteudoTagList = new ConteudoTagService().RetornaTodos(0, 0, "palavra", "ASC", conteudoTagFH);

		// add tag list from "Conteudo Tag"
		foreach (ConteudoTag conteudoTag in conteudoTagList)
		{
			this.entidadeTag = new Tag();
			this.entidadeTag = new TagService().Carregar(conteudoTag.Tag.TagId);
			if (entidadeTag != null)
			{
				this.conteudo.Tages.Add(this.entidadeTag);
			}
		}
	}

	/// <summary>
	/// Clear the form
	/// </summary>
	protected void ClearForm()
	{
		this.txtTitulo.Text = string.Empty;
		this.txtdtFim.Text = string.Empty;
		this.txtdtInicio.Text = string.Empty;
		this.txtdtPublicacao.Text = string.Empty;
		this.txtTags.Text = string.Empty;
		this.txtTitulo.Text = string.Empty;
		this.txtHoraFim.Text = string.Empty;
		this.txtHoraInicio.Text = string.Empty;

		//chbAtivo.SelectedValue = "0";
		//chbDestaqueFique.SelectedValue = "0";
		//chbDestaqueHome.SelectedValue = "0";
	}

	/// <summary>
	/// Load Page, controls and properties
	/// </summary>
	protected void LoadForm()
	{
		// first clear form controls
		this.ClearForm();

		// if has value
		if (this.conteudo != null
			&& this.conteudo.Comunicado != null
			&& this.conteudo.Comunicado.ComunicadoIdiomas != null
			&& this.conteudo.Comunicado.ComunicadoIdiomas.Count > 0)
		{
			if (conteudo.Comunicado.ComunicadoIdiomas[0] != null)
			{
				this.txtTitulo.Text = this.conteudo.Comunicado.ComunicadoIdiomas[0].TituloComunicado.ToString();
				this.txtComunicado.Text = this.conteudo.Comunicado.ComunicadoIdiomas[0].TextoComunicado.ToString();
			}
			this.txtdtPublicacao.Text = this.entidadeComunicado.DataHoraPublicacao.ToString("dd/MM/yyyy");

			//this.chbAtivo.Checked = this.entidadeComunicado.Ativo;
			this.chbDestaqueFique.Checked = this.entidadeComunicado.DestaqueFiquePorDentro;
			this.chbDestaqueHome.Checked = this.entidadeComunicado.DestaqueHome;

			if (this.entidadeComunicado.DataExibicaoInicio != null)
			{
				this.txtdtInicio.Text = Convert.ToDateTime(this.entidadeComunicado.DataExibicaoInicio).ToString("dd/MM/yyyy");
				this.txtHoraInicio.Text = Convert.ToDateTime(entidadeComunicado.DataExibicaoInicio).ToString("hh:mm");
			}

			if (this.entidadeComunicado.DataExibicaoFim != null)
			{
				this.txtdtFim.Text = Convert.ToDateTime(entidadeComunicado.DataExibicaoFim).ToString("dd/MM/yyyy");
				this.txtHoraFim.Text = Convert.ToDateTime(entidadeComunicado.DataExibicaoFim).ToString("hh:mm");
			}

			// load tags
			this.LoadTagsTextBox();
		}
	}

	/// <summary>
	/// Load tag textbox
	/// </summary>
	private void LoadTagsTextBox()
	{
		// Set "tag" textbox
		if (this.conteudo.Tages != null
			&& this.conteudo.Tages.Count > 0)
		{
			string strTag = string.Empty;

			string[] parts = new string[this.conteudo.Tages.Count];
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

			this.txtTags.Text = strTag;
		}
	}

	/// <summary>
	/// Pass all prop from the form to service properties
	/// </summary>
	private void FormToLoad()
	{

		this.entidadeComunicado.DataHoraPublicacao = Convert.ToDateTime(this.txtdtPublicacao.Text);

		// To define the correct format to initial date if exist
		if (string.IsNullOrEmpty(this.txtdtInicio.Text))
		{
			this.entidadeComunicado.DataExibicaoInicio = null;
		}
		else
		{
			if (Ag2.Manager.Helper.Util.IsDate(this.txtdtInicio.Text))
			{
				string dataHora = this.txtdtInicio.Text + " " + this.txtHoraInicio.Text;
				this.entidadeComunicado.DataExibicaoInicio = Convert.ToDateTime(dataHora);
			}
			else
			{
				this.entidadeComunicado.DataExibicaoInicio = null;
			}
		}

		// To define the correct format to final date if exist
		if (string.IsNullOrEmpty(this.txtdtFim.Text))
		{
			this.entidadeComunicado.DataExibicaoFim = null;
		}
		else
		{
			if (Ag2.Manager.Helper.Util.IsDate(this.txtdtFim.Text))
			{
				string dataHora = this.txtdtFim.Text + " " + this.txtHoraFim.Text;
				this.entidadeComunicado.DataExibicaoFim = Convert.ToDateTime(dataHora);
			}
			else
			{
				this.entidadeComunicado.DataExibicaoFim = null;
			}
		}

		this.entidadeComunicado.Ativo = true;
		this.entidadeComunicado.DestaqueFiquePorDentro = this.chbDestaqueFique.Checked;
		this.entidadeComunicado.DestaqueHome = this.chbDestaqueFique.Checked;

		if (this.IdRegistro > 0)
		{
			this.conteudo.ConteudoId = Convert.ToInt32(this.IdRegistro);
			this.entidadeComunicado.Conteudo.ConteudoId = this.conteudo.ConteudoId;
			this.entidadeComunicadoIdioma.Comunicado.Conteudo.ConteudoId = this.conteudo.ConteudoId;
		}

		this.entidadeComunicadoIdioma.TituloComunicado = this.txtTitulo.Text;
		this.entidadeComunicadoIdioma.TextoComunicado = this.txtComunicado.Text;

		this.entidadeComunicado.ComunicadoIdiomas.Add(this.entidadeComunicadoIdioma);

		this.conteudo.Comunicado = this.entidadeComunicado;

		this.AddTagsToLoad();

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
	/// Add tags to tag entity
	/// </summary>
	private void AddTagsToLoad()
	{
		if (!String.IsNullOrEmpty(Convert.ToString(this.txtTags)))
		{
			string[] tags = new string[] { };
			tags = this.txtTags.Text.Split(',');
			foreach (string tag in tags)
			{
				this.entidadeTag = new Tag();
				this.entidadeTag.Palavra = tag.Trim().Replace(".", "");
				this.entidadeTag.Idioma = new Idioma();
				this.entidadeTag.Idioma.IdiomaId = this.IdiomaId;

				this.conteudo.Tages.Add(entidadeTag);
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

	#endregion

	#region [ Save, Update N WorkFlow ]

	/// <summary>
	/// Button execute
	/// </summary>
	private void Execute()
	{
		int cont = 0;
		if (this.IdRegistro > 0)
		{
			comunicadoIdiomaFH = new ComunicadoIdiomaFH();
			comunicadoIdiomaFH.IdiomaId = this.IdiomaId.ToString();
			comunicadoIdiomaFH.ComunicadoId = this.IdRegistro.ToString();
			cont = new ComunicadoIdiomaService().TotalRegistros(comunicadoIdiomaFH);
		}

		try
		{
			if (!String.IsNullOrEmpty(this.txtdtPublicacao.Text) && Ag2.Manager.Helper.Util.IsDate(this.txtdtPublicacao.Text))
			{
				// set values to properties
				this.FormToLoad();

				// Compare final and initial date
				if (this.DateIntervalValidator())
				{
					// Check if update or delete command
					if (conteudo != null && conteudo.ConteudoId > 0 && cont > 0)
					{
						this.Update();
					}
					else
					{
						this.Save();
					}

					if (this.conteudo.Comunicado != null && this.conteudo.ConteudoId > 0)
					{
						this.SaveWorkflow(); // Update "conteudo"
					}

					Util.ShowMessage("Registro salvo com sucesso!");
				}
				else
				{
					Util.ShowMessage("A data inicio deve ser menor que data fim.!");
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
			this.conteudo.ConteudoTipo.ConteudoTipoId = 3;
			this.conteudo.DataHoraCadastro = DateTime.Now;
			new ConteudoService().Inserir(this.conteudo);
		}
		else
		{
			conteudo.ConteudoId = Convert.ToInt32(this.IdRegistro);
		}

		if (this.conteudo != null
			&& this.conteudo.ConteudoId > 0)
		{
			this.conteudo.Comunicado.Conteudo.ConteudoId = this.conteudo.ConteudoId;

			this.conteudo.Comunicado.ComunicadoIdiomas[0].Comunicado.Conteudo.ConteudoId = this.conteudo.ConteudoId;

			try
			{
				if (this.IdRegistro == 0)
				{
					new ComunicadoService().Inserir(this.conteudo.Comunicado);

					// Insert the Tag
					new TagService().Relacionar(this.conteudo);

					// Save "ConteudoRegiao"
					for (int i = 0; i < conteudo.ConteudoRegiao.Count; i++)
					{
						new ConteudoService().InserirRelacionado(conteudo, Convert.ToInt32(conteudo.ConteudoRegiao[i].RegiaoId));
					}
				}

				new ComunicadoIdiomaService().Inserir(this.conteudo.Comunicado.ComunicadoIdiomas[0]);
			}
			catch
			{
				new ConteudoService().Excluir(this.conteudo);
			}
		}
	}
	/// <summary>
	/// 
	/// </summary>
	protected void Update()
	{
		// Update "comunicado"
		this.comunicadoService.Atualizar(this.conteudo.Comunicado);

		// Update "comunicadoIdioma"
		this.comunicadoIdiomaService.Atualizar(this.conteudo.Comunicado.ComunicadoIdiomas[0]);

		// Insert the Tag
		new TagService().Relacionar(this.conteudo);

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
		if (this.conteudo != null
			&& this.conteudo.ConteudoId > 0)
		{
			int wId = WorkflowUtil.SaveWorkflow(this.IdWorkflow
												, StatusWorkflow1
												, this.conteudo.ConteudoId
												, this.txtTitulo.Text
												, this.ModuleName
												, "Conteudo");

			if (wId > 0)
			{
				if (this.IdRegistro > 0)
				{
					Util.ShowUpdateMessage();
					this.LoadProperties();
					this.LoadForm();
					this.StatusWorkflow1.DataBind();
				}
				else
				{
					Util.ShowInsertMessage();
					Response.Redirect(String.Concat("edit.aspx?md="
													, this.ModuleName
													, "&id="
													, conteudo.ConteudoId
													, "&wid="
													, wId), false);
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