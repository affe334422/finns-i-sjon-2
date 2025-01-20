using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace finns_i_sjon_2
{
    public class spelare_händer
    {
        private List<string> Hand = new List<string>();

        public void LäggTillIHand(string Kort){
            Hand.Add(Kort);
        }

        public void SkrivDinHand(){
            foreach(string Kort in Hand){
                Console.Write(Kort + " ");
            }
            Console.WriteLine();
            
        }






    }
}