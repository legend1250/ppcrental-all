using PPCRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using FluentAssert;

namespace PPCRental.AcceptanceTests.Support
{
    public class ReferenceProjectList : Dictionary<string, DBModel>
    {
        //public DBModel GetById(string projectId)
        //{
        //    return this[projectId.Trim()].Should().NotBeNull()
        //                              .And.Subject.Should().BeOfType<DBModel>().Which;
        //}
    }
}
