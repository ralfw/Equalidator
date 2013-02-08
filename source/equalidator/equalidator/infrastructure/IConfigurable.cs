using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace equalidator.infrastructure
{
    public interface IConfigurable
    {
        void Configure(params string[] args);
    }
}