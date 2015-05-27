using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class produtos_e_servicos_Empresas : System.Web.UI.Page
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
