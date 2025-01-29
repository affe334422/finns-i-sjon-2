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
        // Hastigheten på texten. När den är har inne så är det lättare att ändra den för hela spelet.
        private int Tid = 50;

        private int VemDuvillFråga;
        private int VemDuNyssFråga;

        public int villfråga{
            set{VemDuvillFråga = value;}
            get{return VemDuvillFråga;}
        }
        public int nyssfråga{
            set{VemDuNyssFråga = value;}
            get{return VemDuNyssFråga;}
        }

        public int tid{
            set{Tid = value;}
            get{return Tid;}
        }
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