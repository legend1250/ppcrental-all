using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PPCRental.Models;

namespace PPCRental.Models
{
    public class AddressModel
    {
        
        public List<PROPERTY> projectService
        {
            get;
            set;
        }
        public List<DISTRICT> districtService
        {
            get;
            set;
        }
        public List<STREET> streetService
        {
            get;
            set;
        }
        public List<WARD> wardService
        {
            get;
            set;
        }
    }
}