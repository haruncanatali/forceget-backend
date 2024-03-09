using System.Runtime.Serialization;
using Microsoft.AspNetCore.Identity;

namespace FORCEGET.Domain.Identity;

public class User : IdentityUser<long>
{
    public string FirstName { get; set; }
    public string Surname { get; set; }

    [IgnoreDataMember]
    public string FullName
    {
        get { return $"{FirstName} {Surname}"; }
    }
}