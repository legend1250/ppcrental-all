using System.Collections.Generic;
using PPCRental.Models;
using FluentAssertions;

namespace PPCRental.AcceptanceTests.Support
{
    public class ReferenceProjectList: Dictionary<string, PROPERTY>
    {
        public PROPERTY GetById(string projectId)
        {
            return this[projectId.Trim()].Should().NotBeNull()
                                      .And.Subject.Should().BeOfType<PROPERTY>().Which;
        }
    }
}
