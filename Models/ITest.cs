using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityInject.Models
{
    public interface ITest
    {        
        string getName();
    }
    public class Test : ITest
    {
        private Computer computer;
        public Test(Computer computer)
        {
            this.computer = computer;
        }
        public string getName()
        {
            //return "wxl";
            computer.Name = "computer";
            return computer.getName();
        }
    }
    public class Test2:ITest{
        private IComputer computer;
        public Test2(IComputer computer) {
            this.computer = computer;
        }
        public string getName()
        {
            //return "sx";
            computer.Name = "IComputer";
            return computer.getName();
        }
    }
    public interface IComputer {
        string Name { get; set; }
        string getName();
    }
    public class Computer : IComputer
    {
        public string Name { get; set; }
        public string getName()
        {
            return Name;
        }
    }

}
