using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sabesp.Interfaces;
using Sabesp.BO;
using Sabesp.FilterHelper;
using Sabesp.Data.Services;

public partial class CtlTituloTextoBloco : SmartUserControl, IDinamicControl
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

	public CtlTituloTextoBloco() { }

	public CtlTituloTextoBloco(int controleId)
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
			ltrTitulo.Text = this.controleIdiomaBO.Titulo;

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
		rptUltimas.DataSource = this.controleIdiomaBO.ControleIdiomaDados;
		rptUltimas.DataBind();
	}

	protected void rptUltimas_ItemDataBound(object sender, RepeaterItemEventArgs e)
	{
		// Get Conteudo
		ControleIdiomaDado controleIdiomaDadoBOTemp = (ControleIdiomaDado)e.Item.DataItem;

		// Verify if has value
		if (controleIdiomaDadoBOTemp != null)
		{
			// Set controls
			Literal lblDescricao = (Literal)e.Item.FindControl("lblDescricao");
			HyperLink hlDescricao = (HyperLink)e.Item.FindControl("hlDescricao");

			if (!String.IsNullOrEmpty(controleIdiomaDadoBOTemp.Link))
			{
				lblDescricao.Text = controleIdiomaDadoBOTemp.TextoChamada.ReplaceHtml();
				hlDescricao.NavigateUrl = controleIdiomaDadoBOTemp.Link;
				hlDescricao.Target = controleIdiomaDadoBOTemp.Target;
			}
			else
			{
				lblDescricao.Text = String.Concat("<span>", controleIdiomaDadoBOTemp.TextoChamada, "</span>");
			}
		}
	}

	#endregion
}