using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreadorQR
{
    public class DatabaseManager
    {
        public DatabaseManager() {
        }
        public static bool ObjectContainsKey(JObject OBJ, string id)
        {
            foreach (var item in OBJ)
            {
                if (item.Key == id) return true;
            }
            return false;
        }

        public bool StockUsesProduct(string categoria, string codigo, JObject database)
        {
            foreach (var ipu in database) {
                if (ipu.Value["type"].ToString() == categoria
                    && ipu.Value["product"].ToString() == codigo) {
                    return true;
                }
            }
            return false;
        }
    }
}
