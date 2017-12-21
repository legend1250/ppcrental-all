using TechTalk.SpecFlow;
using PPCRental.Models;

namespace PPCRental.AcceptanceTests.Support
{
    [Binding]
   public class DatabaseTools
    {
      //  [BeforeScenario]
        public void CleanDatabase()
        {
            using (var db = new ppcrental3119Entities())
            {
                db.PROPERTies.RemoveRange(db.PROPERTies);
                db.SaveChanges();
            }
        }
    }
}
