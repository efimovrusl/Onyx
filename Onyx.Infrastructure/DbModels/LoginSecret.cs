using System;
using System.Collections.Generic;

namespace Onyx.Infrastructure.DbModels;

public partial class LoginSecret
{
    public Guid UserId { get; set; }

    public string HashedPassword { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
