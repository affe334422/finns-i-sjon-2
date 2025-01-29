using System.IO.Pipes;
using System.Runtime.Intrinsics.Arm;
using System.Runtime.Intrinsics.X86;
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

List<Spelare> FörVemSomVinner = new List<Spelare>(){S1,S2,S3,S4};

// För att ändra hastigheten på texten.
S1.tid = ÄndraHastighet(S1);
S2.tid = S1.tid;
S3.tid = S1.tid;
S4.tid = S1.tid;


/*  
    Den är här hör att Botarna du spelar mot ska kunna komma ihåg vad du frågar efter 
    och fråga den spelaren efter det kortet. 
    
    Det jag vill göra är att om någon annan frågade efter det kortet så uppdateras allas minnen
    borde kunna lägga det i klaserna och ha den här ute för att uppdatera dem i.

*/
string[] BotMinne = {null, null, null, null, null};
int SpleareDuVillFråga;


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


while(S1.DinaKort.Count > 0 || S2.DinaKort.Count > 0 || S3.DinaKort.Count > 0 || S4.DinaKort.Count > 0){
    
    // Kollar om de har fyra.
    HarDe4(S1);
    HarDe4(S2);
    HarDe4(S3);
    HarDe4(S4);

    // Ta kort från annan spelare.
    if(S1.DinaKort.Count != 0){
        VemsTur(S1);
        if(1==1){
            do{ 
                Kortlek = IngaKort(Kortlek, S1);
                string mes0 = "Du ska ta ett kort från en annan spelare. Vilket kort vill du ta?";
                string mes1 = "Och vilken Spelare vill du fråga? 2, 3 eller 4";
                sakta(mes0,S1.tid);
                SkrivKort(S1);
                S1.kortduvillha = Rätta(Console.ReadLine(),S1);
                BotMinne[S1.vemärdu] = S1.kortduvillha;
                sakta(mes1,S1.tid);
                SpleareDuVillFråga = KollapoängOckså();

                if(SpleareDuVillFråga == S2.vemärdu){
                    Kortlek = Spelsekvens(Kortlek, S1, S2, ref BotMinne);
                }
                if(SpleareDuVillFråga == S3.vemärdu){
                    Kortlek = Spelsekvens(Kortlek, S1, S3, ref BotMinne);
                }
                if(SpleareDuVillFråga == S4.vemärdu){
                    Kortlek = Spelsekvens(Kortlek, S1, S4, ref BotMinne);
                }
                HarDe4(S1);
            }while(S1.fårduköraigen == "Ja" && S1.DinaKort.Count > 0);
        }
        else{
            do{
                Kortlek = IngaKort(Kortlek, S1);
                SpleareDuVillFråga = Bot(BotMinne,S1);
                if(SpleareDuVillFråga == S2.vemärdu){
                    Kortlek = Spelsekvens(Kortlek, S1, S2, ref BotMinne);
                }
                if(SpleareDuVillFråga == S3.vemärdu){
                    Kortlek = Spelsekvens(Kortlek, S1, S3, ref BotMinne);
                }
                if(SpleareDuVillFråga == S4.vemärdu){
                    Kortlek = Spelsekvens(Kortlek, S1, S4, ref BotMinne);
                }
                HarDe4(S1);
            }while(S1.fårduköraigen == "Ja" && S1.DinaKort.Count > 0);
        }
        BotMinne[S1.vemärdu] = S1.kortduvillha;
    }

    if(S2.DinaKort.Count != 0){
        VemsTur(S2);
        do{
            Kortlek = IngaKort(Kortlek, S2);
            SpleareDuVillFråga = Bot(BotMinne,S2);
            if(SpleareDuVillFråga == S1.vemärdu){
                Kortlek = Spelsekvens(Kortlek, S2, S1, ref BotMinne);
            }
            if(SpleareDuVillFråga == S3.vemärdu){
                Kortlek = Spelsekvens(Kortlek, S2, S3, ref BotMinne);
            }
            if(SpleareDuVillFråga == S4.vemärdu){
                Kortlek = Spelsekvens(Kortlek, S2, S4, ref BotMinne);
            }
            HarDe4(S2);
        }while(S2.fårduköraigen == "Ja" && S2.DinaKort.Count > 0);
        BotMinne[S2.vemärdu] = S2.kortduvillha;
    }

    if(S3.DinaKort.Count != 0){
        VemsTur(S3);
        do{
            Kortlek = IngaKort(Kortlek,S3);
            SpleareDuVillFråga = Bot(BotMinne,S3);
            if(SpleareDuVillFråga == S1.vemärdu){
                Kortlek = Spelsekvens(Kortlek, S3, S1, ref BotMinne);
            }
            if(SpleareDuVillFråga == S2.vemärdu){
                Kortlek = Spelsekvens(Kortlek, S3, S2, ref BotMinne);
            }
            if(SpleareDuVillFråga == S4.vemärdu){
                Kortlek = Spelsekvens(Kortlek, S3, S4, ref BotMinne);
            }
            HarDe4(S3);
        }while(S3.fårduköraigen == "Ja" && S3.DinaKort.Count > 0);
        BotMinne[S3.vemärdu] = S3.kortduvillha;
    }

    if(S4.DinaKort.Count != 0){
        VemsTur(S4);
        do{ 
            Kortlek = IngaKort(Kortlek,S4);
            SpleareDuVillFråga = Bot(BotMinne,S4);
            if(SpleareDuVillFråga == S1.vemärdu){
                Kortlek = Spelsekvens(Kortlek, S4, S1, ref BotMinne);
            }
            if(SpleareDuVillFråga == S2.vemärdu){
                Kortlek = Spelsekvens(Kortlek, S4, S2, ref BotMinne);
            }
            if(SpleareDuVillFråga == S3.vemärdu){
                Kortlek = Spelsekvens(Kortlek, S4, S3, ref BotMinne);
            }
            HarDe4(S4);
        }while(S4.fårduköraigen == "Ja" && S4.DinaKort.Count > 0);
        BotMinne[S4.vemärdu] = S4.kortduvillha;
    }
}

VemVan(FörVemSomVinner);

static void VemVan(List<Spelare> SV){
    SV = MergeSort(SV);
    string mes0 = "Vinnaren är spelare " + SV[3].vemärdu + " med "+ SV[3].poäng + " poäng";
    string mes1 = "Tvåa kom spelare " + SV[2].vemärdu + " med "+ SV[2].poäng + " poäng";
    string mes2 = "Trea kom spelare " + SV[1].vemärdu + " med "+ SV[1].poäng + " poäng";
    string mes3 = "Sist kom spelare " + SV[0].vemärdu + " med "+ SV[0].poäng + " poäng";
    sakta(mes0,SV[0].tid);
    sakta(mes1,SV[0].tid);
    sakta(mes2,SV[0].tid);
    sakta(mes3,SV[0].tid);
}
static int Bot(string[] BotMinne, Spelare SS){
    for(int i = 1; i < BotMinne.Length; i++){
        if(SS.DinaKort.Contains(BotMinne[i]) && i != SS.vemärdu){
            SS.kortduvillha = BotMinne[i];
            return i;
        }
    }
    return BotHjärna(SS);
}
static List<string> IngaKort(List<string> Kortlek, Spelare SS){
    if(SS.DinaKort.Count < 1 && Kortlek.Count > 0){
        SS.Addhand = Randomhand(ref Kortlek);
    }
    return Kortlek;
}
static void VemsTur(Spelare SS){
    string mes0 = "Nu spelar spelare " + SS.vemärdu;
    sakta(mes0,SS.tid);
}
static List<string> Spelsekvens(List<string> Kortlek, Spelare SS1, Spelare SS2, ref string[] BotMinne){
    int AntalKort = 0;
    
    
    string mes1 = "Spelare " + SS2.vemärdu + " hade inga " + SS1.kortduvillha;
    string mes2 = "Du får ta från sjön";

    // Om det inte är spelare 1 så är det annan text.
    string en = " en " + SS1.kortduvillha;
    string ett = " ett " + SS1.kortduvillha;
    string mes3 = "Spelare " + SS1.vemärdu + " frågar spelare " + SS2.vemärdu + " efter";

    if(SS2.DinaKort.Contains(SS1.kortduvillha)){
        while(SS2.DinaKort.Contains(SS1.kortduvillha)){
            SS1.Addhand = SS1.kortduvillha;
            SS2.RemoveHand = SS1.kortduvillha;
            AntalKort++;
        }
        if(BotMinne[SS2.vemärdu] == SS1.kortduvillha){
            BotMinne[SS2.vemärdu] = "Losser";
        }
        SS1.fårduköraigen = "Ja";
        if(SS1.vemärdu == 1){
            // Jag har stringen här för annars registrerar den inte AntalKort.
            string mes0 = "Spelare " + SS2.vemärdu + " hade " + AntalKort + "st " + SS1.kortduvillha;
            sakta(mes0,SS1.tid);
        }
        else{
            if(SS1.kortduvillha == "Ess"){
                sakta(mes3 + ett,SS1.tid);
            }
            else{
                sakta(mes3 + en,SS1.tid);
            }
            // Samma här Antalkort måste vara under uträkningen.
            string mes4 = "Och de hade " + AntalKort + "st " + SS1.kortduvillha;
            sakta(mes4,SS1.tid);
        }
    }
    else{
        if(SS1.vemärdu == 1){
            sakta(mes1,SS1.tid);
            sakta(mes2,SS1.tid);
        }
        else{
            if(SS1.kortduvillha == "Ess"){
                sakta(mes3 + ett,SS1.tid);
            }
            else{
                sakta(mes3 + en,SS1.tid);
            }
            string mes5 = "Men de hade inga, så spelare " + SS1.vemärdu + " får ta från sjön";
            sakta(mes5,SS1.tid);
        }
        if(Kortlek.Count > 0){
            SS1.Addhand = TaFrånSjön(ref Kortlek, SS1);
        }
        else{
            string mes4 = "Sjön är tom, du kan inte ta något kort";
            sakta(mes4,SS1.tid);
        }
        SS1.fårduköraigen = "Nej";     
    }
    return Kortlek;
}
static string TaFrånSjön(ref List<string> Kortlek, Spelare SS){
    Random ran = new Random();
    string Kort;
    int poäng = ran.Next(0,Kortlek.Count);
    Kort = Kortlek[poäng];
    Kortlek.Remove(Kort);

    
    if(SS.vemärdu == 1){
        
        string mes0 = "Och ifrån sjön drog du: " + Kort;
        sakta(mes0,SS.tid);
    }
    else if(SS.vemärdu > 1){
            string mes1 = "Spelare " + SS.vemärdu + " har tagit från sjön";
            sakta(mes1,SS.tid);
    }
    return Kort;
}
static int KollapoängOckså(){
    Spelare SS = new Spelare();
    string mes0 = "Det är inte 2, 3 eller 4.";
    string mes1 = "Ingen vem vill du fråga 2, 3 eller 4"; 
    try{
        return int.Parse(Console.ReadLine());
    }
    catch{
        sakta(mes0,SS.tid);
        sakta(mes1,SS.tid);
        return KollapoängOckså();
    }
}
static string Rätta(string Kort, Spelare SS){
    List<string> KK = new List<string>{"2","3","4","5","6","7","8","9","10"};
    string mes0 = "Du har inte det kortet!";
    string mes1 = "Välj igen";
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
    if(SS.DinaKort.Contains(Kort)){
        foreach(string kort in KK){
            if(kort == Kort){
                return Kort;
            }
        }
        return Kort;
    }
    else{
        sakta(mes0,SS.tid);
        sakta(mes1,SS.tid);
        return Rätta(Console.ReadLine(),SS);
    }
    
}
static void HarDe4(Spelare SS){
    Random r = new Random();
    string[] k13 = {"Ess","2","3","4","5","6","7","8","9","10","Knäkt","Dam","Kung"};
    foreach(string kortfucker in k13){
        int harde4 = SS.DinaKort.FindAll(kort => kort == kortfucker).Count;
        if(harde4 == 4){
            string mes1 = "Spelare " + SS.vemärdu + " hade 4 av " + kortfucker + " och får 1 poäng." ;
            sakta(mes1,SS.tid);
            SS.DinaKort.RemoveAll(kort => kort == kortfucker);
            SS.poäng = 1;       
        }
    }
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
        Thread.Sleep(SS.tid);
    }
    Console.WriteLine();
}
static string Randomhand(ref List<string> Kortlek){
    Random ran = new Random();
    string Kort;
    int poäng = ran.Next(0,Kortlek.Count);
    Kort = Kortlek[poäng];
    Kortlek.Remove(Kort);
    return Kort;
}
static int ÄndraHastighet(Spelare SS){
    string mes0 = "Innan vi börjar så ska vi ställa in hastigheten av texten. Nu är den på "+ SS.tid;
    string mes1 = "Vill du ändra den? Ja eller Nej";
    string mes2 = "Vad vill du ändra det till?";
    string mes3 = "Om du skriver ett längre tall än " + SS.tid + " så går det snabare";
    string mes4 = "Det är ingen poäng, då frågar jag igen";
    string mes5 = "Är du säker? Ja eller Nej";
    string mes6 = "Är du nöjd?";
    sakta(mes0,SS.tid);
    sakta(mes1,SS.tid);
    string AA = Console.ReadLine();

    if(AA == "ja" || AA == "JA"){
        int tid = SS.tid;
        do{
            sakta(mes2,SS.tid);
            sakta(mes3,SS.tid);
            try{
                SS.tid = int.Parse(Console.ReadLine());
            }
            catch{
                sakta(mes4,SS.tid);
            }
        }while(tid == SS.tid);
        sakta(mes6,SS.tid);
        AA = Console.ReadLine();
        if(AA == "Nej" || AA == "nej"){
            return ÄndraHastighetNumer2(SS);
        }
    }
    else if(AA == "nej" || AA == "Nej"){
        sakta(mes5,SS.tid);
        AA = Console.ReadLine();
        if(AA == "ja" || AA == "JA"){
            return SS.tid;
        }
        else if(AA == "nej" || AA == "Nej"){
            return ÄndraHastighetNumer2(SS);
        }
    }
    return SS.tid;
}
static int ÄndraHastighetNumer2(Spelare SS){
    string mes1 = "Vill du ändra den? Ja eller Nej";
    string mes2 = "Vad vill du ändra det till?";
    string mes3 = "Om du skriver ett längre tall än " + SS.tid + " så går det snabare";
    string mes4 = "Det är ingen poäng, då frågar jag igen";
    string mes5 = "Är du säker? Ja eller Nej";
    string mes6 = "Är du nöjd?";
    sakta(mes1,SS.tid);
    string AA = Console.ReadLine();

    if(AA == "ja" || AA == "JA"){
        int tid = SS.tid;
        do{
            sakta(mes2,SS.tid);
            sakta(mes3,SS.tid);
            try{
                SS.tid = int.Parse(Console.ReadLine());
            }
            catch{
                sakta(mes4,SS.tid);
            }
        }while(tid == SS.tid);
        sakta(mes6,SS.tid);
        AA = Console.ReadLine();
        if(AA == "Nej" || AA == "nej"){
            return ÄndraHastighetNumer2(SS);
        }
    }
    else if(AA == "nej" || AA == "Nej"){
        sakta(mes5,SS.tid);
        AA = Console.ReadLine();
        if(AA == "ja" || AA == "JA"){
            return SS.tid;
        }
        else if(AA == "nej" || AA == "Nej"){
            return ÄndraHastighetNumer2(SS);
        }
    }
    return SS.tid;
}
static int BotHjärna(Spelare SS){
    Random r = new Random();
    SS.villfråga = r.Next(1,5);
    int plusminus;

    if(SS.villfråga == SS.vemärdu){
        plusminus = r.Next(1,3);
        if(plusminus == 1){
            if(SS.villfråga != 1){
                SS.villfråga--;
                if(SS.villfråga == SS.nyssfråga){
                    if(SS.villfråga != 1){
                        SS.villfråga--;
                    }
                    else{
                        SS.villfråga += 2;
                    }
                }
            }
            else{
                SS.villfråga++;
                if(SS.villfråga == SS.nyssfråga){
                    SS.villfråga++;
                }
            }
        }
        else{
            if(SS.villfråga != 4){
                SS.villfråga++;
                if(SS.villfråga == SS.nyssfråga){
                    if(SS.villfråga != 4){
                        SS.villfråga++;
                    }
                    else{
                        SS.villfråga -= 2;
                    }
                }
            }
            else{
                SS.villfråga--;
                if(SS.villfråga == SS.nyssfråga){
                    SS.villfråga--;
                }
            }
        }
    }
    else if(SS.villfråga == SS.nyssfråga){
        plusminus = r.Next(1,3);
        if(plusminus == 1){
            if(SS.villfråga != 1){
                SS.villfråga--;
                if(SS.villfråga == SS.vemärdu){
                    if(SS.villfråga != 1){
                        SS.villfråga--;
                    }
                    else{
                        SS.villfråga += 2;
                    }
                }
            }
            else{
                SS.villfråga++;
                if(SS.villfråga == SS.vemärdu){
                    SS.villfråga++;
                }
            }
        }
        else{
            if(SS.villfråga != 4){
                SS.villfråga++;
                if(SS.villfråga == SS.vemärdu){
                    if(SS.villfråga != 4){
                        SS.villfråga++;
                    }
                    else{
                        SS.villfråga -= 2;
                    }
                }
            }
            else{
                SS.villfråga--;
                if(SS.villfråga == SS.vemärdu){
                    SS.villfråga--;
                }
            }
        } 
    }
    SS.kortduvillha = SS.DinaKort[r.Next(0,SS.DinaKort.Count)];
    return SS.villfråga;
}
static List<Spelare> MergeSort(List<Spelare> PL){
    if (PL.Count <= 1)
        return PL;

    int Mitten = PL.Count / 2;
    // Dela listan i två halvor
    List<Spelare> AllaPåVSida = MergeSort(PL.GetRange(0, Mitten));
    List<Spelare> AllaPåHSida = MergeSort(PL.GetRange(Mitten, PL.Count - Mitten));
    // Slå ihop de sorterade halvorna
    return Merge(AllaPåVSida, AllaPåHSida);
}
// Merge-metoden
static List<Spelare> Merge(List<Spelare> AllaPåVSida, List<Spelare> AllaPåHSida){
    List<Spelare> result = new List<Spelare>();
    int i = 0;
    int j = 0;
    // Jämför och slå ihop
    while (i < AllaPåVSida.Count && j < AllaPåHSida.Count){
        if (AllaPåVSida[i].poäng <= AllaPåHSida[j].poäng){ // Sortera baserat på poäng
            result.Add(AllaPåVSida[i]);
            i++;
        }
        else{
            result.Add(AllaPåHSida[j]);
            j++;
        }
    }
    while (i < AllaPåVSida.Count){
        result.Add(AllaPåVSida[i]);
        i++;
    }
    while (j < AllaPåHSida.Count){
        result.Add(AllaPåHSida[j]);
        j++;
    }
    return result;
}