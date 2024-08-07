using MiniErp.Domain.Entities.Common;
using MiniErp.Domain.Entities.Parameters;

namespace MiniErp.Domain.Entities;

public class ApiEndpoints : BaseEntity
{
    public string Name { get; set; }
    public string Code { get; set; }
    public string Controller { get; set; }
    public string Method { get; set; } = "GET";
    public string? Action { get; set; }
    public string? QueryString { get; set; }
    public Objects? Objects { get; set; }
}