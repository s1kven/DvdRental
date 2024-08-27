using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NpgsqlTypes;

namespace Domain.Entities;

[Table("film")]
public class Film : IEntity
{   
    [Key]
    [Column("film_id")]
    public int Id { get; set; }
    
    [MaxLength(100)]
    [Column("title")]
    public string? Title { get; set; }
    
    [MaxLength(200)]
    [Column("description")]
    public string? Description { get; set; }
    
    [Column("release_year")]
    public int? ReleaseYear { get; set; }
    
    [Column("language_id")]
    public int? LanguageId { get; set; }
    
    [Column("rental_duration")]
    public int? RentalDuration { get; set; }
    
    [Column("rental_rate")]
    public double? RentalRate { get; set; }
    
    [Column("length")]
    public int? Length { get; set; } //minutes
    
    [Column("replacement_cost")]
    public double? ReplacementCost { get; set; }
    
    [Column("rating")]
    public string? Rating { get; set; }
    
    [Column("last_update")]
    public DateTime? LastUpdate { get; set; }
    
    [Column("special_features")]
    public List<string>? SpecialFeatures { get; set; }
    
    [Column("fulltext")]
    public NpgsqlTsVector? FullText { get; set; }
}