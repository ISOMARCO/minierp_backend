namespace MiniErp.Application.Features.CQRS.Results.ApiEndpointResults;

public class GetApiEndpointQueryResult
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string Controller { get; set; }
    public string Method { get; set; } = "GET";
    public string? Action { get; set; }
    public string? QueryString { get; set; }
}