using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;
using System.Data.OracleClient;

namespace HospitalManagementSystem
{
    class connection
    {

            public OracleConnection thisConnection = new OracleConnection("Data Source=XE;User ID=MyHospital;Password=bandhan123;");

       
    }
}

