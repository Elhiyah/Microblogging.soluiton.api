﻿using System;
using System.Collections.Generic;

namespace Microblogging.Models;

public partial class Like
{
    public int Id { get; set; }

    public int TweetId { get; set; }

    public Guid UserId { get; set; }

    public virtual Tweet Tweet { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
