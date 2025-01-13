

namespace PBCC;

public class Energy
{
    double Cfans, Clasers, Creactor, Ccoolant, Cadditional, Ctotal, Mbalance, price, prod,Ebal,AbsMbalance;
    private string MbalanceString;
    Random rng = new Random();
    public string powerInfo()
    {
        return "Power production: " + prod + "MW"+"\n" +
               "Power consumption: \n" +
               "\tFans: " + Cfans + "MW\n" +
               "\tLasers: " + Clasers + "MW\n" +
               "\tReactor: " + Creactor + "MW\n" +
               "\tCoolant: " + Ccoolant + "MW\n" +
               "\tAdditional: " + Cadditional + "MW\n" +
               "\tTotal: " + Ctotal + "MW\n" +
               "Energy balance: " + Ebal + "MW\n" +
               "Price per MWh: " + price + "$\n" +
               "Balance: " + MbalanceString + "$\n";
    }

    public void update(bool[] lasers,int[] fans, bool coolant, int reactor, int temperature)
    {
        Cfans = 0;
        Clasers = 0;
        Creactor = 0;
        Ccoolant = 0;
        Cadditional = 0;
        Ctotal = 0;
        price = 50;
        prod = 0;
        Ebal = 0;
        foreach (bool value in lasers)
        {
            if (value)
                Clasers += Math.Round((10+rng.NextDouble()*4),1);
        }

        foreach (int value in fans)
        {
            if (value!=0)
                Cfans += Math.Round((10+rng.NextDouble()*4),1);
        }
        if(coolant)
            Ccoolant = Math.Round((100+rng.NextDouble()*50),1);
        Creactor = Math.Round((100+rng.NextDouble()*Math.Pow(reactor*2,3)),1);
        Cadditional = rng.Next(101, 200);
        Clasers= Math.Round(Clasers,1);//Without this it breaks for some reason
        Cfans= Math.Round(Creactor,1);
        Ctotal = Cfans + Clasers + Creactor + Ccoolant + Cadditional;
        Ctotal = Math.Round(Ctotal,1);
        prod = Math.Round(Math.Pow(4000 + temperature, 1.1)/20);
        Ebal = Math.Round( prod - Ctotal);;
        Mbalance+=Ebal*price;
        AbsMbalance=Math.Abs(Mbalance);
        if (AbsMbalance > 1000 && AbsMbalance < 1000000)
            MbalanceString = Math.Round(Mbalance / 1000) + "k";
        else if(AbsMbalance>1000000 && AbsMbalance < 1000000000)
            MbalanceString = Math.Round(Mbalance / 1000000,1) + "M";
        else if (AbsMbalance > 1000000000)
            MbalanceString = Math.Round(Mbalance / 1000000000,1) + "B";
        else
            MbalanceString = Mbalance.ToString();   
    }
}