using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF03.Data
{
    internal static class connections
    {
        public const string sqlConStr = """
               server = ABD_EL_MONIEM; 
               user id = EF;
               database = EF01_DB_Test;
               password = 12345678;
               trustservercertificate = true;
            """;
    }
}
