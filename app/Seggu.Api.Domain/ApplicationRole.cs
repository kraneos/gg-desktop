using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace Seggu.Api.Domain
{
    public class ApplicationRole : IdentityRole<Guid, ApplicationUserRole>
    {
    }
}