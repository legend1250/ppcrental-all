namespace PPCRental.AcceptanceTests.Support
{
    public class CatalogContext
    {
        public CatalogContext()
        {
            ReferenceProjects = new ReferenceProjectList();
        }

        public ReferenceProjectList ReferenceProjects { get; set; }
    }
}
