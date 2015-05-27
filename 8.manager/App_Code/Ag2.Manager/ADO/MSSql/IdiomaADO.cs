using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;

namespace Ag2.Manager.ADO.MSSql
{
    /// <summary>
    /// Summary description for IdiomaADO
    /// </summary>
    public class IdiomaADO : BaseADO, Ag2.Manager.DAL.IIdiomaDAL
    {
        public IdiomaADO()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        /// <summary>
        /// Carrega idioma
        /// </summary>
        /// <param name="idioma"></param>
        /// <returns></returns>
        public Ag2.Manager.BusinessObject.Idioma LoadIdioma(Ag2.Manager.BusinessObject.Idioma idioma)
        {
            StringBuilder sbSQL = new StringBuilder();
            sbSQL.Append(" SELECT * FROM idioma WHERE idiomaId = @idiomaId ");

            DbCommand cmd = db.GetSqlStringCommand(sbSQL.ToString());
            db.AddInParameter(cmd, "@idiomaId", DbType.Int32, idioma.IdiomaId);

            IDataReader dr = db.ExecuteReader(cmd);

            try
            {
                if (dr.Read())
                {
                    idioma.IdiomaId = Convert.ToInt32(dr["IdiomaId"]);
                    idioma.Active = Convert.ToBoolean(dr["Active"]);
                    idioma.Default = Convert.ToBoolean(dr["Default"]);
                    idioma.Flag = dr["Flag"].ToString();
                    idioma.Name = dr["Name"].ToString();
                }
            }
            catch
            {
                //
            }
            finally
            {
                cmd.Connection.Close();
                dr.Close();
            }

            return idioma;
        }

        /// <summary>
        /// Retorna os idiomas ativos
        /// </summary>
        /// <returns></returns>
        public List<Ag2.Manager.BusinessObject.Idioma> GetActiveIdiomas()
        {            
            StringBuilder sbSQL = new StringBuilder();
            sbSQL.Append(" SELECT * FROM idioma WHERE [Active] = 1 ORDER BY name ");

            DbCommand cmd = db.GetSqlStringCommand(sbSQL.ToString());

            IDataReader dr = db.ExecuteReader(cmd);

            List<Ag2.Manager.BusinessObject.Idioma> idiomas = new List<Ag2.Manager.BusinessObject.Idioma>();
            Ag2.Manager.BusinessObject.Idioma idioma = null;

            try
            {
                while (dr.Read())
                {
                    idioma = new Ag2.Manager.BusinessObject.Idioma();
                    idioma.IdiomaId = Convert.ToInt32(dr["IdiomaId"]);
                    idioma.Active = Convert.ToBoolean(dr["Active"]);
                    idioma.Default = Convert.ToBoolean(dr["Default"]);
                    idioma.Flag = dr["Flag"].ToString();
                    idioma.Name = dr["Name"].ToString();

                    idiomas.Add(idioma);
                }
            }
            catch
            {
                //
            }
            finally
            {
                cmd.Connection.Close();
                dr.Close();
            }

            return idiomas;
        }

        /// <summary>
        /// Retorna idioma default do manager
        /// </summary>
        /// <returns></returns>
        public Ag2.Manager.BusinessObject.Idioma GetIdiomaDefault()
        {
            Ag2.Manager.BusinessObject.Idioma idioma = null;
            StringBuilder sbSQL = new StringBuilder();
            sbSQL.Append(" SELECT * FROM idioma WHERE [default] = 1 ");

            DbCommand cmd = db.GetSqlStringCommand(sbSQL.ToString());

            IDataReader dr = db.ExecuteReader(cmd);

            try
            {
                if (dr.Read())
                {
                    idioma = new Ag2.Manager.BusinessObject.Idioma();
                    idioma.IdiomaId = Convert.ToInt32(dr["IdiomaId"]);
                    idioma.Active = Convert.ToBoolean(dr["Active"]);
                    idioma.Default = Convert.ToBoolean(dr["Default"]);
                    idioma.Flag = dr["Flag"].ToString();
                    idioma.Name = dr["Name"].ToString();
                }
            }
            catch
            {
                //
            }
            finally
            {
                cmd.Connection.Close();
                dr.Close();
            }

            return idioma;
        }
    }
}
