using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sabesp.Interfaces;
using Sabesp.BO;
using Sabesp.Data.Services;
using Sabesp.FilterHelper;
using System.Web.UI.HtmlControls;
using System.Configuration;

public partial class CtlTituloTextoArquivo : SmartUserControl, IDinamicControl
{
	#region Properties

	public int ControleId { get; set; }

	protected ControleIdioma controleIdiomaBO; // Ini Business Object to "controleIdioma"
	protected ControleIdiomaDado controleIdiomaDadoBO; // Ini Business Object to "controleIdiomaDado"

	protected ControleIdiomaService controleIdiomaService; // Ini Service to "controleIdioma"
	protected ControleIdiomaDadoService controleIdiomaDadoService; // Ini Service to "controleIdiomaDado"

	protected ControleIdiomaDadoFH controleIdiomaDadoFH; // Ini FilterHelper to "controleIdiomaDado"

	#endregion

	#region Constructors

	public CtlTituloTextoArquivo() { }

	public CtlTituloTextoArquivo(int controleId)
	{
		this.ControleId = controleId;
	}

	#endregion

	#region Events

	/// <summary>
	/// 
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void Page_Load(object sender, EventArgs e)
	{

	}

	/// <summary>
	/// 
	/// </summary>
	public override void DataBind()
	{
		base.DataBind();

		this.BindConteudo();
	}

	#endregion

	#region [ Properties ]

	/// <summary>
	/// Define all services to all properties
	/// </summary>
	private void DefineProperties()
	{
		this.controleIdiomaBO = new ControleIdioma(); // Instance Business Object to "controleIdioma"
		this.controleIdiomaService = new ControleIdiomaService(); // Instance Service to "controleIdioma"

		this.controleIdiomaDadoBO = new ControleIdiomaDado(); // Instance Business Object to "controleIdiomaDado"
		this.controleIdiomaDadoService = new ControleIdiomaDadoService(); // Instance Service to "controleIdiomaDado"
		this.controleIdiomaDadoFH = new ControleIdiomaDadoFH(); // Instance Filter Helper to "controleIdiomaDado"
	}

	/// <summary>
	/// Load all properties
	/// </summary>
	private void LoadProperties()
	{
		this.controleIdiomaBO = controleIdiomaService.CarregarToSite(this.ControleId, Util.CurrentIdiomaId);

		if (this.controleIdiomaBO != null)
		{
			// Instance FH to search and return a list of "controleIdiomaDado"
			this.controleIdiomaDadoFH = new ControleIdiomaDadoFH();
			this.controleIdiomaDadoFH.ControleIdiomaId = Convert.ToString(this.controleIdiomaBO.ControleIdiomaId);
			IList<ControleIdiomaDado> entidadeControleIdiomaDadoList = new List<ControleIdiomaDado>();
			this.controleIdiomaDadoService = new ControleIdiomaDadoService();
			entidadeControleIdiomaDadoList = this.controleIdiomaDadoService.RetornaTodos(0, 0, "", "", controleIdiomaDadoFH); // Search and instance a list of "controleIdiomaDado"

			// Verify if exist a list of "controleIdiomaDado"
			if (entidadeControleIdiomaDadoList != null && entidadeControleIdiomaDadoList.Count > 0)
			{
				this.controleIdiomaBO.ControleIdiomaDados = new List<ControleIdiomaDado>();

				foreach (ControleIdiomaDado entidadeControleIdiomaDadoTemp in entidadeControleIdiomaDadoList)
				{
					this.controleIdiomaBO.ControleIdiomaDados.Add(entidadeControleIdiomaDadoTemp);
				}
			}
		}
	}

	#endregion

	#region [ Repeat ]

	/// <summary>
	/// 
	/// </summary>
	protected void BindConteudo()
	{
		this.DefineProperties();
		this.LoadProperties();

		if (this.controleIdiomaBO != null)
		{
			ltlTitulo.Text = this.controleIdiomaBO.Titulo;

			if (this.controleIdiomaBO.ControleIdiomaDados != null)
			{
				this.RepeatDataBind();
			}
		}
		else
		{
			this.Visible = false;
		}
	}

	/// <summary>
	/// 
	/// </summary>
	public void RepeatDataBind()
	{
		rptBox.ItemDataBound += new RepeaterItemEventHandler(rptConcurso_ItemDataBound);
		rptBox.DataSource = this.controleIdiomaBO.ControleIdiomaDados;
		rptBox.DataBind();
	}

	void rptConcurso_ItemDataBound(object sender, RepeaterItemEventArgs e)
	{
		// Get Conteudo
		ControleIdiomaDado controleIdiomaDadoBOTemp = (ControleIdiomaDado)e.Item.DataItem;

		// Verify if has value
		if (controleIdiomaDadoBOTemp != null)
		{
			// Set controls
			Literal ltlTexto = (Literal)e.Item.FindControl("ltlTexto");
			LinkButton lnkArquivo = (LinkButton)e.Item.FindControl("lnkArquivo");

			if (!String.IsNullOrEmpty(controleIdiomaDadoBOTemp.TextoChamada))
			{
				ltlTexto.Text = String.Concat("<span>", controleIdiomaDadoBOTemp.TextoChamada, "</span>");
			}

			if (!String.IsNullOrEmpty(controleIdiomaDadoBOTemp.ArquivoNome))
			{
				lnkArquivo.Text = String.Format("Download | {0}", controleIdiomaDadoBOTemp.ArquivoExtensao.ToUpper());
				lnkArquivo.Attributes.Add("nomeArquivo", controleIdiomaDadoBOTemp.ArquivoNome);
				lnkArquivo.Click += new EventHandler(lnkArquivo_Click);
			}
		}
	}

	private void lnkArquivo_Click(object sender, EventArgs e)
	{
		if (((LinkButton)sender) != null && !String.IsNullOrEmpty(((LinkButton)sender).Attributes["nomeArquivo"]))
		{
			string filePath = ConfigurationManager.AppSettings["uploadPath"].ToString();
			filePath = string.Concat(Server.MapPath(filePath), "box\\" , ((LinkButton)sender).Attributes["nomeArquivo"]);
			Util.DownloadFile(filePath, ((LinkButton)sender).Attributes["nomeArquivo"], true);
		}
	}

	#endregion
}