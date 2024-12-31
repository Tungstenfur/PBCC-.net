namespace PBCC;

public class Energy
{
    float Cfans, Clasers, Creactor, Ccoolant, Cadditional, Ctotal, Mbalance, price, prod,Ebal;
    string powerInfo()
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
}