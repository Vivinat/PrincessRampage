using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace DefaultNamespace
{
    public interface ISubj
    {
        void register(IObs obs);
        void unregister(IObs obs);
        void notify(Enemy_Controller enemy, EnemyState state);
    }
}