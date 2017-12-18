using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using PPCRental.Models;

namespace PPCRental.AcceptanceTests.Common
{
    public class ProjectAssertions
    {
        public static void FoundProjectShouldMatchTitles(IEnumerable<DBModel> foundProjects, IEnumerable<string> expectedTitles)
        {
            foundProjects.Select(b => b.Title).Should().BeEquivalentTo(expectedTitles);
        }

        //public static void FoundProjectShouldMatchTitlesInOrder(IEnumerable<DBModel> foundProjects, IEnumerable<string> expectedTitles)
        //{
        //    foundProjects.Select(b => b.Title).Should().Equal(expectedTitles);
        //}

        public static void HomeScreenShouldShow(IEnumerable<Book> shownBooks, string expectedTitle)
        {
            shownBooks.Select(b => b.Title).Should().Contain(expectedTitle);
        }

        public static void HomeScreenShouldShow(IEnumerable<Book> shownBooks, IEnumerable<string> expectedTitles)
        {
            shownBooks.Select(b => b.Title).Should().BeEquivalentTo(expectedTitles);
        }

        //public static void HomeScreenShouldShowInOrder(IEnumerable<Book> shownBooks, IEnumerable<string> expectedTitles)
        //{
        //    shownBooks.Select(b => b.Title).Should().Equal(expectedTitles);
        //}
    }
}
