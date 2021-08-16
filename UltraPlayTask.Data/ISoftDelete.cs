using System;
using System.Collections.Generic;
using System.Text;

namespace UltraPlayTask.Data
{
    public interface ISoftDelete
    {
        bool IsDeleted { get; set; }
        DateTimeOffset? DeletionDateTime { get; set; }
    }
}
