﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnmpMonitor
{
    interface ITrapListener
    {
        void ListenTrap(bool linkDown);
    }
}
