using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PPCRental.Models;

namespace PPCRental.Models
{
    public class DBModel
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
        public List<PROPERTY_TYPE> propertyTypeService
        {
            get;
            set;
        }

        public List<security_questions> security_questionService
        {
            get;
            set;
        }
    }
}