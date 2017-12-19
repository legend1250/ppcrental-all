using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPCRental.AcceptanceTests.Support
{
    public static class ActionResultExtensions
    {
        public static TModel Model<TModel>(this result)
        {
            return result.Should().NotBeNull()
                         .And.Subject.Should().BeAssignableTo<ViewResult>()
                         .Which.ViewData.Model.Should().NotBeNull()
                         .And.Subject.Should().BeAssignableTo<TModel>()
                         .Subject;
        }
    }
}
