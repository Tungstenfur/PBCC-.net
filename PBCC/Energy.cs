

namespace PBCC;

public class Energy
{
    float Cfans, Clasers, Creactor, Ccoolant, Cadditional, Ctotal, Mbalance, price, prod,Ebal;
    public string powerInfo()
    {
        return "Power production: " + prod + "\n" +
               "Power consumption: \n" +
               "\tFans: " + Cfans + "GW\n" +
               "\tLasers: " + Clasers + "GW\n" +
               "\tReactor: " + Creactor + "GW\n" +
               "\tCoolant: " + Ccoolant + "GW\n" +
               "\tAdditional: " + Cadditional + "GW\n" +
               "\tTotal: " + Ctotal + "GW\n" +
               "Energy balance: " + Ebal + "GW\n" +
               "Price per GWh: " + price + "$\n" +
               "Balance: " + Mbalance + "$\n";
    }

    public void update(bool[] lasers,bool[] fans, bool coolant, bool reactor)
    {
        Cfans = 0;
        Clasers = 0;
        Creactor = 0;
        Ccoolant = 0;
        Cadditional = 0;
        Ctotal = 0;
        price = 0;
        prod = 0;
        Ebal = 0;
        foreach (bool value in lasers)
        {
            if (value)
                Clasers += 12;
        }
    }
}