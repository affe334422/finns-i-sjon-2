using System.Runtime.Intrinsics.Arm;
using finns_i_sjon_2;

List<string> Kortlek = new List<string>{
    "Ess", "Ess", "Ess", "Ess", "2", "2", "2", "2", "3", "3", "3", "3",
    "4", "4", "4", "4", "5", "5", "5", "5", "6", "6", "6", "6",
    "7", "7", "7", "7", "8", "8", "8", "8", "9", "9", "9", "9",
    "10", "10", "10", "10", "Knäkt", "Knäkt", "Knäkt", "Knäkt",
    "Dam", "Dam", "Dam", "Dam", "Kung", "Kung", "Kung", "Kung"
};

spelare_händer s1 = new spelare_händer();
spelare_händer s2 = new spelare_händer();
spelare_händer s3 = new spelare_händer();
spelare_händer s4 = new spelare_händer();

for(int i = 0; i != 7; i++){
    s1.LäggTillIHand(DraRandomKort(ref Kortlek));
    s2.LäggTillIHand(DraRandomKort(ref Kortlek));
    s3.LäggTillIHand(DraRandomKort(ref Kortlek));
    s4.LäggTillIHand(DraRandomKort(ref Kortlek));
}


s1.SkrivDinHand();
s2.SkrivDinHand();
s3.SkrivDinHand();
s4.SkrivDinHand();




static string DraRandomKort(ref List<string> Kortlek){
    Random r = new Random();
    if(Kortlek.Count == 0){
        return null;
    }
    int rr = Kortlek.Count();

    string Kort = Kortlek[r.Next(0,rr-1)];
    Kortlek.Remove(Kort);

    return Kort;
}