namespace XUnitText
{
    public class CatalogContextFactory
    {
        public readonly IProcessPixels ProcessPixels;

        public CatalogContextFactory()
        {
            ProcessPixels = new ProcessPixels();
        }
    }
}