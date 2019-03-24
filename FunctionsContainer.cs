using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class FunctionsContainer
    {
        public delegate double CalcDelegate(double var);
        private Dictionary<string, CalcDelegate> functions = new Dictionary<string, CalcDelegate>();
        public CalcDelegate this[string key]
        {
            get
            {
                if (!functions.ContainsKey(key))
                {
                    functions[key] = val => val;
                }
                return functions[key];
            }
            set
            {
                functions[key] = value;
            }
        }

        internal List<string> getAllMissions()
        {
            var missions = new List<string>();
            foreach (var item in functions.Keys)
            {
                missions.Add(item);
            }
            return missions;
        }
    }
}
