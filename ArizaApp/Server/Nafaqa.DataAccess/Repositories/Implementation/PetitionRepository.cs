using Nafaqa.Core.Entities;
using Nafaqa.DataAccess.Persistence;
namespace Nafaqa.DataAccess.Repositories.Implementation;

public class PetitionRepository : BaseRepository<Petition, int>, IPetitionRepository
{
    public PetitionRepository(DatabaseContext context) : base(context) { }
}