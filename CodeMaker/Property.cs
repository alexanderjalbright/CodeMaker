using System;
using System.Collections.Generic;
using System.Text;

namespace CodeMaker
{
    public class Property : Class
    {
        public Property(string visibility, string type, string name, string getsecurity, string get, string setsecurity, string set) : base(visibility, type, name)
        {
            if (get.Equals("yes"))
            {
                Get = "get;";
                GetSecurity = getsecurity;
            }
            else
                GetSecurity = "";
            if (set.Equals("yes"))
            {
                Set = "set;";
                SetSecurity = getsecurity;
            }
            else
                SetSecurity = "";
                        
        }
        
        public string Get { get; private set; }
        public string GetSecurity { get; private set; }
        public string Set { get; private set; }
        public string SetSecurity { get; private set; }

        public override string ConcatedString()
        {
            return Visibility + " " + Output + " " + Name + "{ " + GetSecurity + " " + Get + " " + SetSecurity + " " + Set + " }";
        }
    }
}
