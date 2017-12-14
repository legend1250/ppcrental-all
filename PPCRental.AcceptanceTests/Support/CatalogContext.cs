using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPCRental.AcceptanceTests.Support
{
    public class CatalogContext
    {
        public CatalogContext()
        {
            ReferenceBooks = new ReferenceProjectList();
        }
        public ReferenceProjectList ReferenceBooks { get; set; }
    }
    
}
