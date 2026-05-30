namespace Shoppi.Api.Entities
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";

        // Add this line for tutorial compatibility
        public string IconCSS { get; set; } = "";
    }
}
