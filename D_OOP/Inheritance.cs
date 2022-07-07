using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_OOP
{
    public class BankTerminal
    {
        protected string id;

        public BankTerminal(string id)
        {
            this.id = id;
        }

        public virtual void Connect()
        {
            Console.WriteLine("General connecting protocol...");
        }
    }

    public class ModelXTerminal : BankTerminal
    {
        public ModelXTerminal(string id) : base(id)
        {

        }
        public override void Connect()
        {
            base.Connect();
            Console.WriteLine("Additional actions for Model X");
        }

    }

    public class ModelYTerminal : BankTerminal
    {
        public ModelYTerminal(string id) : base(id)
        {

        }
        public override void Connect()
        {
            Console.WriteLine("No base operations");
            Console.WriteLine("Actions for Model Y");
        }

    }
}
