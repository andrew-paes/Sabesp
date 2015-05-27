using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using Ag2.Manager.BusinessObject;
using Ag2.Manager.Helper;


public partial class content_ag2menu : System.Web.UI.UserControl
{
    CurrentSessions cs = new CurrentSessions();

    protected void Page_Init(object sender, EventArgs e)
    {
        StringBuilder sbMenu = new StringBuilder();
        ManagerMenu managerMenu = new ManagerMenu();
        List<ManagerMenuItem> menuItem;

        //templates de HTML
        //tempalte principal         
        String templateMenu1 = "<div class=\"itemmenu\"><a href=\"javascript:mostrasub('{0}');\">{1}<img src=\"../img/blt_mais.gif\" width=\"25\" height=\"25\" border=\"0\" alt=\"\" class=\"botao\" id=\"bltmenu{0}\" /></a></div>";

        //consulta menus de primeiro nivel   
        menuItem = managerMenu.GetStructure(cs.Perfil.PerfilId);
        //      
        for (int i = 0; i < menuItem.Count; i++)
        //foreach (Ag2.Manager.Menu.ManagerMenuItem itemRoot in menuItem)
        {
            Ag2.Manager.BusinessObject.ManagerMenuItem itemRoot = menuItem[i];
            //monta menu de primeiro nivel
            sbMenu.AppendFormat(templateMenu1, itemRoot.ID, itemRoot.Name);

            //verifica se tem segundo nivel para ele
            if (itemRoot.HasChildItems)
            {
                sbMenu.AppendFormat("<div id=\"submenu_{0}\" style=\"display:none;\">", itemRoot.ID);
                sbMenu.Append("<ul class=\"primary-nav\">\n");

                //MENU DE SEGUNDO NIVEL
                foreach (Ag2.Manager.BusinessObject.ManagerMenuItem item2 in itemRoot.ChildItems)
                {

                    sbMenu.Append("<li class=\"menuparent\">\n");
                    sbMenu.AppendFormat("<a  href=\"{0}\">&#8226; {1}</a>", ResolveUrl(item2.DestinationUrl), item2.Name);

                    //MENU DE TERCEIRO NIVEL
                    if (item2.HasChildItems)
                    {
                        sbMenu.Append("<ul class=\"submenu\">\n");

                        foreach (Ag2.Manager.BusinessObject.ManagerMenuItem item3 in item2.ChildItems)
                        {
                            sbMenu.AppendFormat("<li><a href=\"{0}\">&#8226; {1}</a></li>\n", ResolveUrl(item3.DestinationUrl), item3.Name);
                        }

                        sbMenu.Append("</ul>\n");
                    }
                    //MENU DE TERCEIRO NIVEL

                    sbMenu.Append("</li>\n");
                }
                //MENU DE SEGUNDO NIVEL

                sbMenu.Append("</ul>\n");
                sbMenu.Append("</div>");
            }
        }

        //Response.Write(sbMenu.ToString());   
        menuItemContainer.Controls.Add(ParseControl(sbMenu.ToString()));
    }
}
