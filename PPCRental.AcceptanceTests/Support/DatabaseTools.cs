using TechTalk.SpecFlow;
using PPCRental.Models;

namespace PPCRental.AcceptanceTests.Support
{
    [Binding]
   public class DatabaseTools
    {
        [BeforeScenario]
        public void CleanDatabase()
        {
            using (var db = new DatabaseContext())
            {
                db.OrderLines.RemoveRange(db.OrderLines);
                db.Orders.RemoveRange(db.Orders);
                db.Books.RemoveRange(db.Books);
                db.SaveChanges();
            }
        }
    }
}
