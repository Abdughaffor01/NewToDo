using System.ComponentModel.DataAnnotations;

namespace Domain;
public class Category
{
    [Key]
    public int Id { get; set; }
    [MaxLength(30)]
    public string Name { get; set; }
    public List<ToDo> ToDos { get; set; }
}
