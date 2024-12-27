namespace Nafaqa.Application.Models;

public class BaseResponseModel<TEntityId>
{
    public TEntityId Id { get; set; }
    public List<string> Errors { get; set; }
}
