using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class SingleMission : IMission
    {
        private FunctionsContainer.CalcDelegate function;
        private string name;
        private string type;

        public SingleMission(FunctionsContainer.CalcDelegate f, string n)
        {
            function = f;
            name = n;
        }

        public string Name => name;

        public string Type => "Single";

        public event EventHandler<double> OnCalculate;

        public double Calculate(double value)
        {
            double ans = function.Invoke(value);
            if (OnCalculate != null)
            {
                OnCalculate.Invoke(this, ans);
            }
            return ans;
        }
    }
}
