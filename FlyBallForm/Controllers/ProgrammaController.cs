using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using FlyBallForm;

namespace FlyBallForm.Controllers
{
    public class ProgrammaController : ApiController
    {
        // GET api/<controller>
        public string Get()
        {
            string conStr = ConfigurationManager.ConnectionStrings["FlyFormConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand com = new SqlCommand("SELECT [RaceID], [WD], [Dagdeel], [RingNummer], [ProgrammaNr], [RTN], [DivisieNummer], [DivUBT], [RaceNr], [DT], [Gelopen], [Rood], [RUBT], [Blauw], [BUBT], [Finale], [Herkansing], [RH1], [RH1SH], [RH2], [RH2SH], [RH3], [RH3SH], [RH4], [RH4SH], [RH5], [RH5SH], [RH6], [RH6SH], [BH1], [BH1SH], [BH2], [BH2SH], [BH3], [BH3SH], [BH4], [BH4SH], [BH5], [BH5SH], [BH6], [BH6SH], [RText], [BText] FROM [FlyForm].[dbo].[FlyFormProgramma] ", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            string csv = "";
        

            foreach (DataRow rw in ds.Tables["Table"].Rows)
            {
                for (int i = 0; i < ds.Tables["Table"].Columns.Count; i++)
                {
                    csv += rw[i].ToString();

                    //add tab separator (maar niet bij de laatste kolom)
                    if (i < ds.Tables["Table"].Columns.Count -1) csv += Convert.ToChar(9);
                }

                csv += Environment.NewLine;

            }

            //System.Diagnostics.Debug.WriteLine(csv);

            return csv;
        }

        // GET api/<controller>/117430
        public string Get(int id)
        {

            string conStr = ConfigurationManager.ConnectionStrings["FlyFormConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand com = new SqlCommand("SELECT [RaceID], [WD], [Dagdeel], [RingNummer], [ProgrammaNr], [RTN], [DivisieNummer], [DivUBT], [RaceNr], [DT], [Gelopen], [Rood], [RUBT], [Blauw], [BUBT], [Finale], [Herkansing], [RH1], [RH1SH], [RH2], [RH2SH], [RH3], [RH3SH], [RH4], [RH4SH], [RH5], [RH5SH], [RH6], [RH6SH], [BH1], [BH1SH], [BH2], [BH2SH], [BH3], [BH3SH], [BH4], [BH4SH], [BH5], [BH5SH], [BH6], [BH6SH], [RText], [BText] FROM [FlyForm].[dbo].[FlyFormProgramma] WHERE [RaceID] = @RaceID", con);
            com.Parameters.AddWithValue("@RaceID", id);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            string csv = "";


            foreach (DataRow rw in ds.Tables["Table"].Rows)
            {
                for (int i = 0; i < ds.Tables["Table"].Columns.Count; i++)
                {
                    csv += rw[i].ToString();

                    //add tab separator (maar niet bij de laatste kolom)
                    if (i < ds.Tables["Table"].Columns.Count - 1) csv += Convert.ToChar(9);
                }

                csv += Environment.NewLine;

            }

            //System.Diagnostics.Debug.WriteLine(csv);

            return csv;
        }

        //Insert Access Programma in FlyFormProgramma via WEB API
        public string Post([FromBody]string value)
        {

            ClearFlyFormProgramma();

            string[] rws;
            string[] values;
            int i;
            
            rws = value.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);

            for (i = 0 ; i < rws.Length; i++)
            {

                DateTime Nu = DateTime.Now;

                rws[i] = rws[i].Replace("Waar", "True");
                rws[i] = rws[i].Replace("Onwaar", "False");

                values = rws[i].Split(Convert.ToChar(9));

                values[6] = values[6].Replace(".", ",");
                values[11] = values[11].Replace(".", ",");
                values[13] = values[13].Replace(".", ",");


                string WD = values[0];
                string Dagdeel = values[1];
                int RingNummer = int.Parse(values[2]);
                int ProgrammaNr = int.Parse(values[3]);
                string RTN = values[4];
                int DivisieNummer = int.Parse(values[5]);
                decimal DivUBT = decimal.Parse(values[6]);
                string RaceNr = values[7];
                string DT = values[8];
                string Gelopen = values[9];
                string Rood = values[10];
                decimal RUBT = (values[11]=="NULL")?decimal.Parse("0"): decimal.Parse(values[11]);
                string Blauw = values[12];
                decimal BUBT = (values[13] == "NULL") ? decimal.Parse("0") : decimal.Parse(values[13]);
                string Finale = values[14];
                string Herkansing = values[15];
                string RH1 = values[16];
                string RH2 = values[17];
                string RH3 = values[18];
                string RH4 = values[19];
                string RH5 = values[20];
                string RH6 = values[21];
                string BH1 = values[22];
                string BH2 = values[23];
                string BH3 = values[24];
                string BH4 = values[25];
                string BH5 = values[26];
                string BH6 = values[27];
                decimal RH1SH = decimal.Parse(values[28]);
                decimal RH2SH = decimal.Parse(values[29]);
                decimal RH3SH = decimal.Parse(values[30]);
                decimal RH4SH = decimal.Parse(values[31]);
                decimal RH5SH = decimal.Parse(values[32]);
                decimal RH6SH = decimal.Parse(values[33]);
                decimal BH1SH = decimal.Parse(values[34]);
                decimal BH2SH = decimal.Parse(values[35]);
                decimal BH3SH = decimal.Parse(values[36]);
                decimal BH4SH = decimal.Parse(values[37]);
                decimal BH5SH = decimal.Parse(values[38]);
                decimal BH6SH = decimal.Parse(values[39]);
                int RaceID = int.Parse(values[40]);


                string conStr = ConfigurationManager.ConnectionStrings["FlyFormConnectionString"].ConnectionString;

                SqlConnection con = new SqlConnection(conStr);

                SqlCommand com = new SqlCommand("INSERT INTO FlyFormProgramma (RaceID, WD, Dagdeel, RingNummer, ProgrammaNr, RTN, DivisieNummer, DivUBT, RaceNr, DT, Gelopen, Rood, RUBT, Blauw, BUBT, Finale, Herkansing, RH1, RH1SH, RH2, RH2SH, RH3, RH3SH, RH4, RH4SH, RH5, RH5SH, RH6, RH6SH, BH1, BH1SH, BH2, BH2SH, BH3, BH3SH, BH4, BH4SH, BH5, BH5SH, BH6, BH6SH, RText, BText) VALUES (@RaceID, @WD, @Dagdeel, @RingNummer, @ProgrammaNr, @RTN, @DivisieNummer, @DivUBT, @RaceNr, @DT, @Gelopen, @Rood, @RUBT, @Blauw, @BUBT, @Finale, @Herkansing, @RH1, @RH1SH, @RH2, @RH2SH, @RH3, @RH3SH, @RH4, @RH4SH, @RH5, @RH5SH, @RH6, @RH6SH, @BH1, @BH1SH, @BH2, @BH2SH, @BH3, @BH3SH, @BH4, @BH4SH, @BH5, @BH5SH, @BH6, @BH6SH, @RText, @BText)", con);

                com.Parameters.AddWithValue("@RaceID", RaceID);
                com.Parameters.AddWithValue("@WD", WD);
                com.Parameters.AddWithValue("@Dagdeel", Dagdeel);
                com.Parameters.AddWithValue("@RingNummer", RingNummer);
                com.Parameters.AddWithValue("@ProgrammaNr", ProgrammaNr);
                com.Parameters.AddWithValue("@RTN", RTN);
                com.Parameters.AddWithValue("@DivisieNummer", DivisieNummer);
                com.Parameters.AddWithValue("@DivUBT", DivUBT);
                com.Parameters.AddWithValue("@RaceNr", RaceNr);
                com.Parameters.AddWithValue("@DT", DT);
                com.Parameters.AddWithValue("@Gelopen", Gelopen);
                com.Parameters.AddWithValue("@Rood", Rood);
                com.Parameters.AddWithValue("@RUBT", RUBT);
                com.Parameters.AddWithValue("@Blauw", Blauw);
                com.Parameters.AddWithValue("@BUBT", BUBT);
                com.Parameters.AddWithValue("@Finale", Finale);
                com.Parameters.AddWithValue("@Herkansing", Herkansing);
                com.Parameters.AddWithValue("@RH1", RH1);
                com.Parameters.AddWithValue("@RH2", RH2);
                com.Parameters.AddWithValue("@RH3", RH3);
                com.Parameters.AddWithValue("@RH4", RH4);
                com.Parameters.AddWithValue("@RH5", RH5);
                com.Parameters.AddWithValue("@RH6", RH6);
                com.Parameters.AddWithValue("@BH1", BH1);
                com.Parameters.AddWithValue("@BH2", BH2);
                com.Parameters.AddWithValue("@BH3", BH3);
                com.Parameters.AddWithValue("@BH4", BH4);
                com.Parameters.AddWithValue("@BH5", BH5);
                com.Parameters.AddWithValue("@BH6", BH6);
                com.Parameters.AddWithValue("@RH1SH", RH1SH);
                com.Parameters.AddWithValue("@RH2SH", RH2SH);
                com.Parameters.AddWithValue("@RH3SH", RH3SH);
                com.Parameters.AddWithValue("@RH4SH", RH4SH);
                com.Parameters.AddWithValue("@RH5SH", RH5SH);
                com.Parameters.AddWithValue("@RH6SH", RH6SH);
                com.Parameters.AddWithValue("@BH1SH", BH1SH);
                com.Parameters.AddWithValue("@BH2SH", BH2SH);
                com.Parameters.AddWithValue("@BH3SH", BH3SH);
                com.Parameters.AddWithValue("@BH4SH", BH4SH);
                com.Parameters.AddWithValue("@BH5SH", BH5SH);
                com.Parameters.AddWithValue("@BH6SH", BH6SH);
                com.Parameters.AddWithValue("@RText", "");
                com.Parameters.AddWithValue("@BText", "");

                //if (TeamID == -1) com.Parameters.AddWithValue("@TeamID", DBNull.Value); else com.Parameters.AddWithValue("@TeamID", TeamID);
                //if (Tijd == -1) com.Parameters.AddWithValue("@Tijd", DBNull.Value); else com.Parameters.AddWithValue("@Tijd", Tijd);
                //com.Parameters.AddWithValue("@ResultaatID", ResultaatID);
                //if (Punten == -1) com.Parameters.AddWithValue("@Punten", DBNull.Value); else com.Parameters.AddWithValue("@Punten", Punten);

                con.Open();

                com.ExecuteNonQuery();

                con.Close();
            }

            return "OK, rows inserted: " + i.ToString() ;

        }

        //Update 1 row in FlyFormProgramma via WEB API
        public string Put(int id, [FromBody]string value)
        {

            string[] values;
            int i;

            DateTime Nu = DateTime.Now;

            value = value.Replace("Waar", "True");
            value = value.Replace("Onwaar", "False");

            values = value.Split(Convert.ToChar(9));

            values[6] = values[6].Replace(".", ",");
            values[11] = values[11].Replace(".", ",");
            values[13] = values[13].Replace(".", ",");


            string WD = values[0];
            string Dagdeel = values[1];
            int RingNummer = int.Parse(values[2]);
            int ProgrammaNr = int.Parse(values[3]);
            string RTN = values[4];
            int DivisieNummer = int.Parse(values[5]);
            decimal DivUBT = decimal.Parse(values[6]);
            string RaceNr = values[7];
            string DT = values[8];
            string Gelopen = values[9];
            string Rood = values[10];
            decimal RUBT = (values[11] == "NULL") ? decimal.Parse("0") : decimal.Parse(values[11]);
            string Blauw = values[12];
            decimal BUBT = (values[13] == "NULL") ? decimal.Parse("0") : decimal.Parse(values[13]);
            string Finale = values[14];
            string Herkansing = values[15];
            string RH1 = values[16];
            string RH2 = values[17];
            string RH3 = values[18];
            string RH4 = values[19];
            string RH5 = values[20];
            string RH6 = values[21];
            string BH1 = values[22];
            string BH2 = values[23];
            string BH3 = values[24];
            string BH4 = values[25];
            string BH5 = values[26];
            string BH6 = values[27];
            decimal RH1SH = decimal.Parse(values[28]);
            decimal RH2SH = decimal.Parse(values[29]);
            decimal RH3SH = decimal.Parse(values[30]);
            decimal RH4SH = decimal.Parse(values[31]);
            decimal RH5SH = decimal.Parse(values[32]);
            decimal RH6SH = decimal.Parse(values[33]);
            decimal BH1SH = decimal.Parse(values[34]);
            decimal BH2SH = decimal.Parse(values[35]);
            decimal BH3SH = decimal.Parse(values[36]);
            decimal BH4SH = decimal.Parse(values[37]);
            decimal BH5SH = decimal.Parse(values[38]);
            decimal BH6SH = decimal.Parse(values[39]);
            int RaceID = int.Parse(values[40]);


            string conStr = ConfigurationManager.ConnectionStrings["FlyFormConnectionString"].ConnectionString;

            SqlConnection con = new SqlConnection(conStr);

            SqlCommand com = new SqlCommand("UPDATE FlyFormProgramma SET WD=@WD,Dagdeel=@Dagdeel,RingNummer=@RingNummer,ProgrammaNr=@ProgrammaNr,RTN=@RTN,DivisieNummer=@DivisieNummer,DivUBT=@DivUBT,RaceNr=@RaceNr,DT=@DT,Gelopen=@Gelopen,Rood=@Rood,RUBT=@RUBT,Blauw=@Blauw,BUBT=@BUBT,Finale=@Finale,Herkansing=@Herkansing,RH1=@RH1,RH2=@RH2,RH3=@RH3,RH4=@RH4,RH5=@RH5,RH6=@RH6,BH1=@BH1,BH2=@BH2,BH3=@BH3,BH4=@BH4,BH5=@BH5,BH6=@BH6,RH1SH=@RH1SH,RH2SH=@RH2SH,RH3SH=@RH3SH,RH4SH=@RH4SH,RH5SH=@RH5SH,RH6SH=@RH6SH,BH1SH=@BH1SH,BH2SH=@BH2SH,BH3SH=@BH3SH,BH4SH=@BH4SH,BH5SH=@BH5SH,BH6SH=@BH6SH,RText=@RText,BText=@BText WHERE RaceID=@RaceID)", con);

            com.Parameters.AddWithValue("@RaceID", RaceID);
            com.Parameters.AddWithValue("@WD", WD);
            com.Parameters.AddWithValue("@Dagdeel", Dagdeel);
            com.Parameters.AddWithValue("@RingNummer", RingNummer);
            com.Parameters.AddWithValue("@ProgrammaNr", ProgrammaNr);
            com.Parameters.AddWithValue("@RTN", RTN);
            com.Parameters.AddWithValue("@DivisieNummer", DivisieNummer);
            com.Parameters.AddWithValue("@DivUBT", DivUBT);
            com.Parameters.AddWithValue("@RaceNr", RaceNr);
            com.Parameters.AddWithValue("@DT", DT);
            com.Parameters.AddWithValue("@Gelopen", Gelopen);
            com.Parameters.AddWithValue("@Rood", Rood);
            com.Parameters.AddWithValue("@RUBT", RUBT);
            com.Parameters.AddWithValue("@Blauw", Blauw);
            com.Parameters.AddWithValue("@BUBT", BUBT);
            com.Parameters.AddWithValue("@Finale", Finale);
            com.Parameters.AddWithValue("@Herkansing", Herkansing);
            com.Parameters.AddWithValue("@RH1", RH1);
            com.Parameters.AddWithValue("@RH2", RH2);
            com.Parameters.AddWithValue("@RH3", RH3);
            com.Parameters.AddWithValue("@RH4", RH4);
            com.Parameters.AddWithValue("@RH5", RH5);
            com.Parameters.AddWithValue("@RH6", RH6);
            com.Parameters.AddWithValue("@BH1", BH1);
            com.Parameters.AddWithValue("@BH2", BH2);
            com.Parameters.AddWithValue("@BH3", BH3);
            com.Parameters.AddWithValue("@BH4", BH4);
            com.Parameters.AddWithValue("@BH5", BH5);
            com.Parameters.AddWithValue("@BH6", BH6);
            com.Parameters.AddWithValue("@RH1SH", RH1SH);
            com.Parameters.AddWithValue("@RH2SH", RH2SH);
            com.Parameters.AddWithValue("@RH3SH", RH3SH);
            com.Parameters.AddWithValue("@RH4SH", RH4SH);
            com.Parameters.AddWithValue("@RH5SH", RH5SH);
            com.Parameters.AddWithValue("@RH6SH", RH6SH);
            com.Parameters.AddWithValue("@BH1SH", BH1SH);
            com.Parameters.AddWithValue("@BH2SH", BH2SH);
            com.Parameters.AddWithValue("@BH3SH", BH3SH);
            com.Parameters.AddWithValue("@BH4SH", BH4SH);
            com.Parameters.AddWithValue("@BH5SH", BH5SH);
            com.Parameters.AddWithValue("@BH6SH", BH6SH);
            com.Parameters.AddWithValue("@RText", "");
            com.Parameters.AddWithValue("@BText", "");

            //if (TeamID == -1) com.Parameters.AddWithValue("@TeamID", DBNull.Value); else com.Parameters.AddWithValue("@TeamID", TeamID);
            //if (Tijd == -1) com.Parameters.AddWithValue("@Tijd", DBNull.Value); else com.Parameters.AddWithValue("@Tijd", Tijd);
            //com.Parameters.AddWithValue("@ResultaatID", ResultaatID);
            //if (Punten == -1) com.Parameters.AddWithValue("@Punten", DBNull.Value); else com.Parameters.AddWithValue("@Punten", Punten);

            con.Open();

            com.ExecuteNonQuery();

            con.Close();

            return "OK, updated RaceID: " + RaceID.ToString();
        }

        // DELETE api/<controller>/117430   (wordt niet gebruikt)
        public string Delete(int id)
        {
            return "Delete is niet toegestaan via de WEB API";
        }

        // Maak de FlyFormProgramma table leeg via WEB API
        private void ClearFlyFormProgramma()
        {
            string conStr = ConfigurationManager.ConnectionStrings["FlyFormConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand com = new SqlCommand("delete from [dbo].[FlyFormProgramma]", con);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }

    }
}
