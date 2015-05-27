using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Ag2.Manager.BusinessObject;
using Ag2.Manager.Module;

namespace Ag2.Manager.Helper
{
    public class CurrentSessions
    {
        public CurrentSessions()
        {
            //
        }

        public Ag2.Manager.BusinessObject.Idioma CurrentIdioma
        {
            get
            {
                if (System.Web.HttpContext.Current.Session["CurrentIdioma"] == null)
                    System.Web.HttpContext.Current.Session["CurrentIdioma"] = new Ag2.Manager.BusinessObject.Idioma();
                return (Ag2.Manager.BusinessObject.Idioma)System.Web.HttpContext.Current.Session["CurrentIdioma"];
            }
            set
            {
                System.Web.HttpContext.Current.Session["CurrentIdioma"] = value;
            }
        }

        public Perfil Perfil
        {
            get
            {
                if (System.Web.HttpContext.Current.Session["Perfil"] == null)
                    System.Web.HttpContext.Current.Session["Perfil"] = new Perfil();
                return (Perfil)System.Web.HttpContext.Current.Session["Perfil"];
            }
            set
            {
                System.Web.HttpContext.Current.Session["Perfil"] = value;
            }
        }

        public List<Int32> RegisterNavigatorGet(string strId)
        {
            if (System.Web.HttpContext.Current.Session["RegisterNavigator" + strId] == null)
                System.Web.HttpContext.Current.Session["RegisterNavigator" + strId] = new List<Int32>();
            return (List<Int32>)System.Web.HttpContext.Current.Session["RegisterNavigator" + strId];
        }

        public void RegisterNavigatorSet(string strId, object value)
        {
            System.Web.HttpContext.Current.Session["RegisterNavigator" + strId] = value;
        }


        public Collection<ManagerModuleField> CurrentFilters
        {
            get
            {
                if (System.Web.HttpContext.Current.Session["Filters"] == null)
                    System.Web.HttpContext.Current.Session["Filters"] = new Collection<ManagerModuleField>();
                return (Collection<ManagerModuleField>)System.Web.HttpContext.Current.Session["Filters"];
            }
            set
            {
                System.Web.HttpContext.Current.Session["Filters"] = value;
            }
        }

        public ManagerModule ActiveManagerModule
        {
            get
            {
                if (System.Web.HttpContext.Current.Session["ManagerModule"] == null)
                    System.Web.HttpContext.Current.Session["ManagerModule"] = new ManagerModule();
                return (ManagerModule)System.Web.HttpContext.Current.Session["ManagerModule"];
            }
            set
            {
                System.Web.HttpContext.Current.Session["ManagerModule"] = value;
            }
        }

        public String UserId
        {
            get
            {
                return Convert.ToString(System.Web.HttpContext.Current.Session["UserId"]);
            }
            set
            {
                System.Web.HttpContext.Current.Session["UserId"] = value;
            }
        }

    }
}
