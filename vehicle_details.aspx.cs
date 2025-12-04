using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace vehicle_registration
{
    public partial class vehicle_details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        [WebMethod]
        public static int Save(string number1, string type1, string year1,string model1)
        {
            {
                #region dbsave

                int retVal = 0;
                string connectionString = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    // Updated query to include gender

                    string ren = "INSERT INTO vehicle_details (number,type,year,model) output INSERTED.id VALUES('" + number1 + "', '" + type1 + "', '" + year1 + "','" + model1 + "')";

                    using (SqlCommand cmd = new SqlCommand(ren, con))
                    {
                        con.Open();
                        retVal = (int)cmd.ExecuteScalar();
                        con.Close();
                    }
                }
                #endregion
                return retVal;
            }
        }



    }
}