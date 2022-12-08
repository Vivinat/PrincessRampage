using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public interface IObs
    {
        public void updateObs(ISubj subject, EnemyState state);
    }
}

