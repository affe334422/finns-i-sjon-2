using System.Runtime.Intrinsics.Arm;
using finns_i_sjon_2;


List<string> Kortlek = new List<string>{
    "Ess", "Ess", "Ess", "Ess", "2", "2", "2", "2", "3", "3", "3", "3",
    "4", "4", "4", "4", "5", "5", "5", "5", "6", "6", "6", "6",
    "7", "7", "7", "7", "8", "8", "8", "8", "9", "9", "9", "9",
    "10", "10", "10", "10", "Knäkt", "Knäkt", "Knäkt", "Knäkt",
    "Dam", "Dam", "Dam", "Dam", "Kung", "Kung", "Kung", "Kung"
};
Random ran = new Random();
Spelare S1 = new Spelare();
Spelare S2 = new Spelare();
Spelare S3 = new Spelare();
Spelare S4 = new Spelare();



for(int i = 0; i < 7; i++){ // Lägger kort i händerna
    S1.Addhand = Randomhand(ref Kortlek, ran);
    S2.Addhand = Randomhand(ref Kortlek, ran);
    S3.Addhand = Randomhand(ref Kortlek, ran);
    S4.Addhand = Randomhand(ref Kortlek, ran);
}


// skriver ut dem kort du har i handen
SkrivKort(S1);
SkrivKort(S2);
SkrivKort(S3);
SkrivKort(S4);


static void SkrivKort(Spelare SS){
    foreach(string Kort in SS.DinaKort){
        Console.Write(Kort + " ");
    }
}

static string Randomhand(ref List<string> Kortlek, Random ran){
    string Kort;
    int Nummer = ran.Next(1,Kortlek.Count);
    Kort = Kortlek[Nummer];
    Kortlek.Remove(Kort);
    return Kort;
}
