using System.Text.Json.Serialization;

namespace SalesforceIngestor.SalesforceAuthentication;

public class SalesforceTokenResponse
{
    [JsonPropertyName("access_token")] public string? AccessToken { get; set; }

    [JsonPropertyName("scope")] public string? Scope { get; set; }

    [JsonPropertyName("instance_url")] public string? InstanceUrl { get; set; }

    [JsonPropertyName("id")] public string? Id { get; set; }

    [JsonPropertyName("token_type")] public string? TokenType { get; set; }

    public string? TenantId
    {
        get
        {
            return Id != null && Uri.TryCreate(Id, UriKind.Absolute, out var uri) 
                ? uri.Segments[2].TrimEnd('/') 
                : null;            
        }
    }
}