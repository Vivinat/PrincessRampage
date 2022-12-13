using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ReSharper disable All

namespace DefaultNamespace
{
    public interface IObs
    {
        public void updateObs(ISubj subject, Eventos evento);
    }
}

