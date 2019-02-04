using System;
using System.Collections.Generic;
using System.Text;

namespace CodeMaker
{
    public class Method : Class
    {
        public Method(string visibility, string output, string name, string inputtype, string inputname) : base(visibility, name)
        {
            InputType = inputtype;
            InputName = inputname;
        }

        public string InputType { get; private set; }
        public string InputName { get; private set; }

        public override void PrintItself()
        {
            Console.WriteLine(Visibility + " " + Output + " " + Name + "(" + InputType + " " + InputName + ")");
        }
    }
}
