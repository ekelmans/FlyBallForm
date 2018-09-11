using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Xml.Serialization;

namespace FlyBallForm.Controllers
{
    public class HeatController : ApiController
    {
        // GET api/<controller>
        public string Get()
        {
            string conStr = ConfigurationManager.ConnectionStrings["FlyFormConnectionString"].ConnectionString;

            SqlConnection con = new SqlConnection(conStr);

            SqlCommand com = new SqlCommand("SELECT * FROM FlyFormHeat ", con);

            SqlDataAdapter da = new SqlDataAdapter(com);

            DataSet ds = new DataSet();

            da.Fill(ds);

            string csv = "";
        

            foreach (DataRow rw in ds.Tables["Table"].Rows)
            {

                for (int i = 0; i < ds.Tables["Table"].Columns.Count; i++)
                {
                    csv += rw[i].ToString() + Convert.ToChar(9);
                }

                csv += Environment.NewLine;
                System.Diagnostics.Debug.WriteLine(csv);

            }



            return csv;

            //return JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.None);

            //return ToStringAsXml(ds);
        }

        // GET api/<controller>/117430
        public string Get(int id)
        {

            string conStr = ConfigurationManager.ConnectionStrings["FlyFormConnectionString"].ConnectionString;

            SqlConnection con = new SqlConnection(conStr);

            SqlCommand com = new SqlCommand("SELECT * FROM FlyFormHeat WHERE HeatID = @HeatID", con);


            com.Parameters.AddWithValue("@HeatID", id);

            SqlDataAdapter da = new SqlDataAdapter(com);

            DataSet ds = new DataSet();

            da.Fill(ds);

            return JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.None);

            //return ToStringAsXml(ds);

        }

        public static string ToStringAsXml(DataSet ds)
        {
            StringWriter sw = new StringWriter();
            ds.WriteXml(sw, XmlWriteMode.WriteSchema);
            string s = sw.ToString();
            return s;
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {


        }

        // PUT api/<controller>/117430
        public string Put(int id, [FromBody]string value)
        {
            int HeatID = id;
            int RaceID = 11736;
            int HeatNr = 1;
            int BaanKleurID = 1;
            int TeamID = 3434;
            decimal Tijd = 0;
            int ResultaatID = 3;
            int Punten = 1;
            int Hond1 = 1;
            int Hond2 = 1;
            int Hond3 = 1;
            int Hond4 = 1;
            int Hond5 = 1;
            int Hond6 = 1;

            string conStr = ConfigurationManager.ConnectionStrings["FlyFormConnectionString"].ConnectionString;

            SqlConnection con = new SqlConnection(conStr);

            SqlCommand com = new SqlCommand("update [FlyForm].[dbo].[FlyFormHeat] set RaceID = @RaceID,HeatNr = @HeatNr,BaanKleurID= @BaanKleurID,TeamID = @TeamID,Tijd = @Tijd,ResultaatID= @ResultaatID,Punten = @Punten,Hond1 = @Hond1,Hond2 = @Hond2,Hond3 = @Hond3,Hond4 = @Hond4,Hond5 = @Hond5,Hond6 = @Hond6 where HeatID = @HeatID", con);

            com.Parameters.AddWithValue("@HeatID", HeatID);
            com.Parameters.AddWithValue("@RaceID", RaceID);
            com.Parameters.AddWithValue("@HeatNr", HeatNr);
            com.Parameters.AddWithValue("@BaanKleurID", BaanKleurID);
            com.Parameters.AddWithValue("@TeamID", TeamID);
            com.Parameters.AddWithValue("@Tijd", Tijd);
            com.Parameters.AddWithValue("@ResultaatID", ResultaatID);
            com.Parameters.AddWithValue("@Punten", Punten);
            com.Parameters.AddWithValue("@Hond1", Hond1);
            com.Parameters.AddWithValue("@Hond2", Hond2);
            com.Parameters.AddWithValue("@Hond3", Hond3);
            com.Parameters.AddWithValue("@Hond4", Hond4);
            com.Parameters.AddWithValue("@Hond5", Hond5);
            com.Parameters.AddWithValue("@Hond6", Hond6);

            con.Open();

            com.ExecuteNonQuery();

            con.Close();

            return "OK";
        }

        // DELETE api/<controller>/117430   (wordt niet gebruikt)
        public void Delete(int id)
        {
        }

    }

}