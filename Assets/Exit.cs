using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LifeIsLoop.Utilities
{
    public class Exit : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                Application.Quit();
        }
    }
}