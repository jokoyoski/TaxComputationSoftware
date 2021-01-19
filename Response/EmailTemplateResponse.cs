namespace TaxComputationSoftware.Respoonse
{
    public class EmailTemplateResponse
    {
        public string Subject { get; set; }
        public string PlainTextContent { get; set; }
        public string HtmlContent { get; set; }
    }
}