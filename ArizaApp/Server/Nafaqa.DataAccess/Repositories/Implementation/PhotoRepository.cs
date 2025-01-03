using Nafaqa.Core.Entities;
using Nafaqa.DataAccess.Persistence;

namespace Nafaqa.DataAccess.Repositories.Implementation;

public class PhotoRepository : BaseRepository<Photo, int>, IPhotoRepository
{
    public PhotoRepository(DatabaseContext context) : base(context) { }
}