using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    internal class DanhMuc_DAO
    {

        public static DataTable DanhSachDanhMuc()
        {
            DataProvider dp = new DataProvider();

            SqlCommand cmd = new SqlCommand( @"Select * From DanhMuc");

            DataTable table = new DataTable();

            return table;
        }

        
    }
}
