namespace Domain;
public class GetCategoryWithToDo:BaseCategoryDto
{
    public List<ToDo> ToDos { get; set; } = new List<ToDo>();
}
