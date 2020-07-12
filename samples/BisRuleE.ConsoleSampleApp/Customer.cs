using BisRuleE;

namespace IBREConsoleSampleApp
{
    public class Customer
            {
                [BREntityProperty(Display = "Klantnaam")]
                public string Name { get; set; }

                [BREntityProperty(Display = "Shoptegoed")]
                public decimal Balance { get; set; }
            }
        
    
}