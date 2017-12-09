using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PPCRental.Models;
namespace PPCRental.Driver
{
    public class ViewModels
    {
        public List<PROPERTY> zProperties { get; set; }
        public List<WARD> zWards { get; set; }
        public List<DISTRICT> zDistricts { get; set; }
        public List<STREET> zStreets { get; set; }
    }
}