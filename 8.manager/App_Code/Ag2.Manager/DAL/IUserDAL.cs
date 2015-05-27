using System;
namespace Ag2.Manager.DAL
{
    interface IUserDAL
    {
        System.Data.DataTable GetById(int ID);
        System.Data.DataTable GetByLogin(string login);
        System.Data.DataTable GetPerfilByUserId(string userId);
    }
}
