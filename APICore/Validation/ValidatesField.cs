using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace APICore.Validation
{
    public class ValidatesField
    {
        public static bool Email(string email)
        {
            try
            {
                bool r = false;

                string emailRegex = string.Format("[\\w\\.-]+(\\+[\\w-]*)?@([\\w-]+\\.)+[\\w-]+");
                r = Regex.IsMatch(email, emailRegex);
                return r;
            }
            catch (Exception errEmail)
            {
                throw new Exception($"Error: {errEmail.Message}");
            }
        }

        public static bool Salary(string salary)
        {
            return true;
        }

        public static bool Fields(string[] fiels)
        {
            return true;
        }
    }
}
