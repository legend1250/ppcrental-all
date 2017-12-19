using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using PPCRental.Models;// references toi project ppc

namespace PPCRental.AcceptanceTests.Common
{
    public class ProjectAssertions
    {
        public static void FoundProjectShouldMatchTitles(IEnumerable<PROPERTY> foundProjects, IEnumerable<string> expectedTitles)
        {                                             //ss object 
            foundProjects.Select(b => b.PropertyName).Should().BeEquivalentTo(expectedTitles);
        }

        //public static void FoundProjectShouldMatchTitlesInOrder(IEnumerable<DBModel> foundProjects, IEnumerable<string> expectedTitles)
        //{
        //    foundProjects.Select(b => b.Title).Should().Equal(expectedTitles);
        //}

        public static void HomeScreenShouldShow(IEnumerable<PROPERTY> shownBooks, string expectedTitle)
        {
            shownBooks.Select(b => b.PropertyName).Should().Contain(expectedTitle);
        }

        public static void HomeScreenShouldShow(IEnumerable<PROPERTY> shownBooks, IEnumerable<string> expectedTitles)
        {
            shownBooks.Select(b => b.PropertyName).Should().BeEquivalentTo(expectedTitles);
        }

        //public static void HomeScreenShouldShowInOrder(IEnumerable<Book> shownBooks, IEnumerable<string> expectedTitles)
        //{
        //    shownBooks.Select(b => b.Title).Should().Equal(expectedTitles);
        //}
    }
}
