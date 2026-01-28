using System;
using System.Collections.Generic;

namespace Onyx.Infrastructure.DbModels;

public partial class GroupsUser
{
    public Guid? UserId { get; set; }

    public Guid? GroupId { get; set; }

    public virtual Group? Group { get; set; }

    public virtual User? User { get; set; }
}
