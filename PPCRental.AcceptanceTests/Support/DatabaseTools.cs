using TechTalk.SpecFlow;
using PPCRental.Models;

namespace PPCRental.AcceptanceTests.Support
{
    [Binding]
   public class DatabaseTools
    {
      [BeforeScenario]
        public void CleanDatabase()
        {//thực hiện clean database trc khi kt một senerio
            using (var db = new ppcrental3119Entities())
            {
                db.PROPERTY_FEATURE.RemoveRange(db.PROPERTY_FEATURE);
                db.PROPERTies.RemoveRange(db.PROPERTies);
                db.SaveChanges();
            }
        }
    }
}
