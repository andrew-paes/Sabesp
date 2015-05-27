using System;
using System.Collections.Generic;
using System.Text;
using Ag2.Manager.ADO.MSSql;
using System.Data;
using System.Web.Security;
using Ag2.Manager.Helper;
using Ag2.Manager.DAL;
using Ag2.Manager.Helper;

namespace Ag2.Manager.BusinessObject
{

    public enum UserStatus { Valid = 1, Invalid, Blocked }


    public class User
    {
        private string _name;
        private Util util = new Util();

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }


        //Variavel com status do usuario
        //public enum UserStatus 

        public DataTable GetById(int ID)
        {
            UserADO userDb = new UserADO();
            return userDb.GetById(ID);
        }

        /// <summary>Valida login do usuário</summary>
        /// <param name="login">Login do usuário</param>
        /// <param name="password">Senha não criptografada do usuário</param>
        public UserStatus Validate(string login, string password)
        {
            DataTable userData;
            IUserDAL userDb = (IUserDAL)Util.GetADO("UserADO", System.Reflection.Assembly.GetExecutingAssembly());
            UserStatus userStatus = UserStatus.Invalid;

            if (Membership.ValidateUser(login, password))
            {
                FormsAuthentication.RedirectFromLoginPage(login, true);
                userStatus = UserStatus.Valid;


                string userId = Membership.GetUser(login).ProviderUserKey.ToString();
                Ag2.Manager.Helper.CurrentSessions cs = new Ag2.Manager.Helper.CurrentSessions();
                cs.UserId = userId;
                userData = userDb.GetPerfilByUserId(userId);

                Ag2.Manager.Module.ManagerModule manager = new Ag2.Manager.Module.ManagerModule();

                if (ConfigurationManager.EnableMultiLanguage)
                    cs.CurrentIdioma = manager.GetIdiomaDefault();

                Perfil p = new Perfil();
                p.PerfilId = Convert.ToInt32(userData.Rows[0]["perfilId"].ToString());
                p.Name = userData.Rows[0]["perfilName"].ToString();
                cs.Perfil = p; //Insere na sessão os dados do perfil
            }
            else
            {
                userStatus = UserStatus.Invalid;
            }

            return userStatus;
        }

        /// <summary>
        /// Consulta usuário pelo login
        /// </summary>
        /// <param name="login">Login do usuário</param>
        /// <returns>DataTable com dados do usuário</returns>
        public DataTable GetByLogin(string login)
        {
            UserADO userDb = new UserADO();
            return userDb.GetByLogin(login);
        }
    }




}
