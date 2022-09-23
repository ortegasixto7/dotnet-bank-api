﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetBank.Core.Validation
{
    public interface IRequestValidator<T>
    {
        void Validate(T request);
    }
}
