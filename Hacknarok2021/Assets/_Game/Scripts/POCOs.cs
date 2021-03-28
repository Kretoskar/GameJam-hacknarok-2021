// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 

using Boo.Lang;

public class EnvironmentClimateChange
{
    public List<string> climate_change { get; set; }
    public List<string> environment { get; set; }
}

public class HealthcarePandemic
{
    public List<object> healthcare { get; set; }
    public List<string> pandemic { get; set; }
}

public class PoliticsProtestsFinance
{
    public List<string> finance { get; set; }
    public List<string> politics { get; set; }
    public List<string> protests { get; set; }
}

public class Energy
{
    public string oil_barrels { get; set; }
}

public class Food
{
    public string died_of_hunger { get; set; }
    public string money_spent_on_obesity { get; set; }
    public string money_spent_on_weight_loss { get; set; }
}

public class GovernmentAndEconomics
{
    public string education { get; set; }
    public string healthcare { get; set; }
    public string military { get; set; }
}

public class Health
{
    public string abortions { get; set; }
    public string accidents { get; set; }
    public string cancer_deaths { get; set; }
    public string suicides { get; set; }
}

public class Worldometers
{
    public Energy energy { get; set; }
    public Food food { get; set; }
    public GovernmentAndEconomics government_and_economics { get; set; }
    public Health health { get; set; }
}

public class Root
{
    public EnvironmentClimateChange environment_climate_change { get; set; }
    public HealthcarePandemic healthcare_pandemic { get; set; }
    public List<string> image_urls { get; set; }
    public List<string> news_api { get; set; }
    public PoliticsProtestsFinance politics_protests_finance { get; set; }
    public Worldometers worldometers { get; set; }
}