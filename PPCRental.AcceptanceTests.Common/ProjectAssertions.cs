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

        public static void FoundProjectShouldMatchTitlesInOrder(IEnumerable<PROPERTY> foundProjects, IEnumerable<string> expectedTitles)
        {
            foundProjects.Select(b => b.PropertyName).Should().Equal(expectedTitles);
        }

        public static void HomeScreenShouldShow(IEnumerable<PROPERTY> shownProjects, string expectedTitle)
        {
            shownProjects.Select(b => b.PropertyName).Should().Contain(expectedTitle);
        }

        public static void HomeScreenShouldShow(IEnumerable<PROPERTY> shownProjects, IEnumerable<string> expectedTitles)
        {
            shownProjects.Select(b => b.PropertyName).Should().BeEquivalentTo(expectedTitles);
        }

        public static void HomeScreenShouldShowInOrder(IEnumerable<PROPERTY> shownProjects, IEnumerable<string> expectedTitles)
        {
            shownProjects.Select(b => b.PropertyName).Should().Equal(expectedTitles);
        }
    }
}
