using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public struct GroupName
    {
        string[] allowableNames = { "БИСТ", "БИВТ", "БПИ" };
        public string name = null;
        string number;
        public GroupName(string name, int number)
        {
            if (allowableNames.Contains(name))
            {
                this.name = name;
            }
            this.number = Convert.ToString(number);
        }
        public string GetName()
        {
            if (name == null || number == null)
            {
                return "отсутствует";
            }
            return $"{name}-{number}";
        }
    }
}
