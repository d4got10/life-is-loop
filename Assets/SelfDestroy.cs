using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LifeIsLoop.Utilities
{
    public class SelfDestroy : MonoBehaviour
    {
        private bool _detonated = false;
        private void Update()
        {
            if((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)) && _detonated == false)
            {
                _detonated = true;
                Invoke(nameof(SelfDestruct), 3f);
            }
        }

        private void SelfDestruct()
        {
            Destroy(gameObject);
        }
    }
}