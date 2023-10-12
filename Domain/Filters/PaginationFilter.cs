namespace Domain;
public class PaginationFilter
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public PaginationFilter(int pageNumber, int pageSize)
    {
        if (pageNumber <= 0) PageNumber = 1;
        if (pageSize <= 0) PageNumber = 10;
    }
}
