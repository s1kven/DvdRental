using System.Text.Json.Serialization;
using Domain.Entities;

namespace Application.Dtos.Responses;

public record GetFilmsResponseData : IResponseData
{
    [JsonPropertyName("films")]
    public List<Film>? Films { get; init; }
}