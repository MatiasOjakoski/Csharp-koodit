﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teht2ECsharp
{
    class JobChangedEventArgs : EventArgs
    {
        public Job Job { get; set; }
    }
}
