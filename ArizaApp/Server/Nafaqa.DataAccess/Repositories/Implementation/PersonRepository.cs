using Nafaqa.Core.Entities;
using Nafaqa.DataAccess.Persistence;

namespace Nafaqa.DataAccess.Repositories.Implementation;

public class PersonRepository : BaseRepository<Person, int>,IPersonRepository
{
    public PersonRepository(DatabaseContext context) : base(context)
    {
    }
}