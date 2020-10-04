using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LifeIsLoop.SleepSystem
{

    public class SkyViewer : MonoBehaviour
    {
        [SerializeField] private SleepSystem _sleepSystem;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Gradient _skyGradient;

        [SerializeField] private SpriteRenderer _shadowRenderer;

        private void Update()
        {
            _spriteRenderer.color = _skyGradient.Evaluate(_sleepSystem.Time);
            _shadowRenderer.color = new Color(0,0,0,2*_sleepSystem.Time - 1f);
        }
    }
}