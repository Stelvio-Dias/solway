using Solway.Models;

namespace Solway.DAC.Specification;

public class AppUserWithContentSpecification : BaseSpecification<AppUser>
{
    public AppUserWithContentSpecification(string id) : base(x => x.Id == id)
    {
        AddInclude(x => x.Contents);
    }

    public AppUserWithContentSpecification()
    {
        AddInclude(x => x.Contents);
    }
}