using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class ComposedMission : IMission
    {
        private List<FunctionsContainer.CalcDelegate> functions;

        public ComposedMission(string desciption)
        {
            functions = new List<FunctionsContainer.CalcDelegate>();
            Name = desciption;
        }

        public string Name { get; set; }

        public string Type { get { return "Composed"; } }

        public event EventHandler<double> OnCalculate;

        public ComposedMission Add(FunctionsContainer.CalcDelegate func)
        {
            functions.Add(func);
            return this;
        }

        public double Calculate(double value)
        {
            // Giving each function the output from the function before.
            foreach (var function in functions) { value = function(value); }
            OnCalculate?.Invoke(this, value);
            return value;
        }
    }
}