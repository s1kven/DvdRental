using System.Text.Json.Serialization;
using Domain.Entities;

namespace Application.Dtos.Responses;

public record GetFilmsResponseData : IResponseData
{
    [JsonPropertyName("films")]
    public IEnumerable<Film>? Films { get; init; }
}