using System.ComponentModel.DataAnnotations;

namespace Domain;
public class ToDo
{
    [Key]
    public int Id { get; set; }
    [MaxLength(30)]
    public string Title { get; set; }
    [MaxLength(500)]
    public string Description { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}