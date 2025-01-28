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
S1.vemärdu = 1;
S2.vemärdu = 2;
S3.vemärdu = 3;
S4.vemärdu = 4;

int tid = 50;


int Antalkort = 7;
for(int i = 0; i < Antalkort; i++){ // Lägger kort i händerna
    S1.Addhand = Randomhand(ref Kortlek);
    S2.Addhand = Randomhand(ref Kortlek);
    S3.Addhand = Randomhand(ref Kortlek);
    S4.Addhand = Randomhand(ref Kortlek);
}



// skriver ut dem kort du har i handen
SkrivKort(S1);
SkrivKort(S2); 
SkrivKort(S3);
SkrivKort(S4);

// Kollar om de har fyra.
HarDe4(S1,"");
HarDe4(S2,"");
HarDe4(S3,"");
HarDe4(S4,"");

// Ta kort från annan spelare.
do{
    string mes0 = "Du ska ta ett kort från en annan spelare. Vilket kort vill du ta?";
    string mes1 = "Och vilken Spelare vill du fråga? 2, 3 eller 4";
    sakta(mes0,tid);
    SkrivKort(S1);
    S1.kortduvillha = Rätta(Console.ReadLine(),S1);
    sakta(mes1,tid);
    int SpleareDuVillFråga = KollaNummerOckså();

    if(SpleareDuVillFråga == S2.vemärdu){
        Kortlek = Spelsekvens(Kortlek, S1, S2);
    }
    if(SpleareDuVillFråga == S3.vemärdu){
        Kortlek = Spelsekvens(Kortlek, S1, S3);
    }
    if(SpleareDuVillFråga == S4.vemärdu){
        Kortlek = Spelsekvens(Kortlek, S1, S4);
    }
}while(S1.fårduköraigen == "Ja");


static List<string> Spelsekvens(List<string> Kortlek, Spelare SS1, Spelare SS2){
    int AntalKort = 0;
    int tid = 50;
    
    string mes1 = "Spelare " + SS2.vemärdu + " hade inga " + SS1.kortduvillha;
    string mes2 = "Du får ta från sjön";
    if(SS2.DinaKort.Contains(SS1.kortduvillha)){
        while(SS2.DinaKort.Contains(SS1.kortduvillha)){
            SS1.Addhand = SS1.kortduvillha;
            SS2.RemoveHand = SS1.kortduvillha;
            AntalKort++;
        }
        SS1.fårduköraigen = "Ja";
        if(SS1.vemärdu == 1){
            // Jag har stringen här för annars registrerar den inte AntalKort.
            string mes0 = "Spelare " + SS2.vemärdu + " hade " + AntalKort + "st " + SS1.kortduvillha;
            sakta(mes0,tid);
        }
    }
    else{
        if(SS1.vemärdu == 1){
            sakta(mes1,tid);
            sakta(mes2,tid);
        }
        SS1.Addhand = TaFrånSjön(ref Kortlek, SS1); 
        SS1.fårduköraigen = "Nej";     
    }
    return Kortlek;
}
static string TaFrånSjön(ref List<string> Kortlek, Spelare SS){
    Random ran = new Random();
    string Kort;
    int Nummer = ran.Next(0,Kortlek.Count);
    Kort = Kortlek[Nummer];
    Kortlek.Remove(Kort);
    if(SS.vemärdu == 1){
        int tid = 50;
        string mes0 = "Och ifrån sjön drog du: " + Kort;
        sakta(mes0,tid);
    }
    return Kort;
}
static int KollaNummerOckså(){
    int tid = 50;
    string mes0 = "Det är inte 2, 3 eller 4.";
    string mes1 = "Ingen vem vill du fråga 2, 3 eller 4"; 
    try{
        return int.Parse(Console.ReadLine());
    }
    catch{
        sakta(mes0,tid);
        sakta(mes1,tid);
        return KollaNummerOckså();
    }
}
static string Rätta(string Kort, Spelare SS){
    List<string> KK = new List<string>{"2","3","4","5","6","7","8","9","10"};
    int tid = 50;
    string mes0 = "Du har inte det kortet!";
    string mes1 = "Välj igen";
    if(SS.DinaKort.Contains(Kort)){
        foreach(string kort in KK){
            if(kort == Kort){
                return Kort;
            }
        }
        if(Kort == "knäkt"){
            Kort = "Knäkt";
            return Kort;
        }
        if(Kort == "dam"){
            Kort = "Dam";
            return Kort;
        }
        if(Kort == "kung"){
            Kort = "Kung";
            return Kort;
        }
        if(Kort == "ess"){
            Kort = "Ess";
            return Kort;
        }
        return Kort;
    }
    else{
        sakta(mes0,tid);
        sakta(mes1,tid);
        return Rätta(Console.ReadLine(),SS);
    }
    
}
static string HarDe4(Spelare SS, string EttAvDinaKort){
    int tid = 60;
    Random r = new Random();
    string[] k13 = {"Ess","2","3","4","5","6","7","8","9","10","Knäkt","Dam","Kung"};
    foreach(string kortfucker in k13){
        
        int harde4 = SS.DinaKort.FindAll(kort => kort == kortfucker).Count;
        if(harde4 == 4){
            string mes1 = "Spelare " + SS.vemärdu + " hade 4 av " + kortfucker + " och får 1 poäng." ;
            sakta(mes1,tid);

            SS.DinaKort.RemoveAll(kort => kort == kortfucker);

            if(SS.DinaKort.Count != 0){
                EttAvDinaKort = SS.DinaKort[r.Next(0,SS.DinaKort.Count)];
            }
            else{
                EttAvDinaKort = "";
            }           
        }          
    }
    return EttAvDinaKort;
}
static void sakta(string mes, int tid){
    foreach (char c in mes){
        Console.Write(c);
        Thread.Sleep(tid);
    }
    Console.WriteLine();
}
static void SkrivKort(Spelare SS){
    foreach(string Kort in SS.DinaKort){
        Console.Write(Kort + " ");
        Thread.Sleep(50);
    }
    Console.WriteLine();
}
static string Randomhand(ref List<string> Kortlek){
    Random ran = new Random();
    string Kort;
    int Nummer = ran.Next(0,Kortlek.Count);
    Kort = Kortlek[Nummer];
    Kortlek.Remove(Kort);
    return Kort;
}
