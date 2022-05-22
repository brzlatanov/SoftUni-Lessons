namespace BookShop.DataProcessor.ExportDto
{
    public class AuthorExportDto
    {
        public string AuthorName { get; set; }
        public BookExportDto[] Books { get; set; }
    }
}