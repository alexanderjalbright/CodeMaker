using System;
using System.Collections.Generic;
using System.Text;

namespace CodeMaker
{
    public class Class
    {
        public Class(string visibility, string output string name)
        {
            Visibility = visibility;
            Output = output;
            Name = name;
            Properties = new List<Property>();
            Methods = new List<Method>();
        }

        public string Visibility { get; protected set; }
        public string Output { get; protected set; }
        public string Name { get; protected set; }
        public List<Property> Properties { get; private set; }
        public List<Method> Methods { get; private set; }

        public void AddProperty(Property newProperty)
        {

            Properties.Add(newProperty);
        }

        public virtual string ConcatedString()
        {
            return Visibility + " class " + Name + "()";
        }
    }
}
