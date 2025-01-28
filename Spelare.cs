using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace finns_i_sjon_2
{
    public class Spelare
    {
        private List<string> Hand = new List<string>();
        private int Poäng = 0;
        public int poäng{
            set{Poäng = Poäng + value;}
            get{return Poäng;}
        }

        public List<string> DinaKort{
            get{return Hand;}
        }

        public string Addhand{   
            set{Hand.Add(value);}
        }
    }
}