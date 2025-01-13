public class PaginationState
{
    public int CurrentPage { get; set; } = 0;
    public int ItemsPerPage { get; set; } = 5;
    public int TotalItems { get; set; }

    public int TotalPages => (int)Math.Ceiling(TotalItems / (double)ItemsPerPage);

    public void GoToNextPage()
    {
        if (CurrentPage < TotalPages - 1)
        {
            CurrentPage++;
        }
    }

    public void GoToPreviousPage()
    {
        if (CurrentPage > 0)
        {
            CurrentPage--;
        }
    }
}