using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace finns_i_sjon_2
{
    public class Spelare
    {
        private List<string> Hand = new List<string>();
        private int Poäng = 0;
        private int VemÄrDu = 0;
        private string KortDuVillHa;
        private string FårDuKöraIgen = "Nej";

        public string fårduköraigen{
            set{FårDuKöraIgen = value;}
            get{return FårDuKöraIgen;}
        }


        public string kortduvillha{
            set{KortDuVillHa = value;}
            get{return KortDuVillHa;}
        }

        public int vemärdu{
            set{VemÄrDu = value;}
            get{return VemÄrDu;}
        }
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
        public string RemoveHand{
            set{Hand.Remove(value);}
        }
    }
}