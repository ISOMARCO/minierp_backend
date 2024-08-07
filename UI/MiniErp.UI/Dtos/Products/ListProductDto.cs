namespace MiniErp.UI.Dtos.Products;

public class ListProductDto : IList
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Type { get; set; }
    public string? Note { get; set; }
}