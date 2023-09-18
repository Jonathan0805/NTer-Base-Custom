﻿using MySql.Data.MySqlClient;
using N_Ter.Common;
using N_Ter_Task_Data_Structures.DataSets;

namespace N_Ter.MySQL.Customizable
{
    public class Sample_Master_Table_FK : Base.Sample_Master_Table_FK
    {
        private string _strConnectionString;
        Common_Database_Actions objComDB;

        public Sample_Master_Table_FK(string strConnectionString)
        {
            _strConnectionString = strConnectionString;
            objComDB = new Common_Database_Actions(_strConnectionString);
        }

        public override DS_Master_Tables ReadAsMaster()
        {
            MySqlConnection con = new MySqlConnection(_strConnectionString);
            MySqlDataAdapter adp = new MySqlDataAdapter("SELECT Master_ID AS Data_ID, Master_Data AS Data FROM tblzm_sample_with_foreign_key", con);
            DS_Master_Tables ds = new DS_Master_Tables();
            adp.Fill(ds.tblData);
            objComDB.CloseAdapter(ref con, ref adp);
            return ds;
        }

        public override DS_Master_Tables ReadAsMaster(int Foreign_Key_ID)
        {
            MySqlConnection con = new MySqlConnection(_strConnectionString);
            MySqlDataAdapter adp = new MySqlDataAdapter("SELECT Master_ID AS Data_ID, Master_Data AS Data FROM tblzm_sample_with_foreign_key WHERE Foreign_Key_ID = " + Foreign_Key_ID, con);
            DS_Master_Tables ds = new DS_Master_Tables();
            adp.Fill(ds.tblData);
            objComDB.CloseAdapter(ref con, ref adp);
            return ds;
        }

        public override DS_Master_Tables ReadAsMaster(int Foreign_Key_ID, int Foreign_Key_2_ID)
        {
            MySqlConnection con = new MySqlConnection(_strConnectionString);
            MySqlDataAdapter adp = new MySqlDataAdapter("SELECT Master_ID AS Data_ID, Master_Data AS Data FROM tblzm_sample_with_foreign_key WHERE Foreign_Key_ID = " + Foreign_Key_ID + " AND Foreign_Key_2_ID = " + Foreign_Key_2_ID, con);
            DS_Master_Tables ds = new DS_Master_Tables();
            adp.Fill(ds.tblData);
            objComDB.CloseAdapter(ref con, ref adp);
            return ds;
        }
    }
}
