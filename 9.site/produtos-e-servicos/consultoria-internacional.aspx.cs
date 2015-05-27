using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class produtos_e_servicos_consultoria_internacional : System.Web.UI.Page
{
	#region [ Properties ]


	#endregion

	#region [ Events ]

	protected void Page_Load(object sender, EventArgs e)
	{
		this.LoadPage();
	}

	#endregion 

	#region [ Methods ]

	private void LoadPage()
	{
		listaProdutos.DataBind();
		segundaColunaDinamica1.DataBind();
	}

	#endregion

}
