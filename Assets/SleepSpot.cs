using LifeIsLoop.SleepSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LifeIsLoop.SleepSystem
{
    public class SleepSpot : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private SleepSystem _sleepSystem;

        private bool _interactable = true;

        public void Interact()
        {
            if (_interactable)
            {
                _interactable = false;
                _animator.SetTrigger("Sleep");
                Invoke(nameof(Sleep), 1f);
            }
        }

        private void Sleep()
        {
            _interactable = true;
            _sleepSystem.Sleep();
        }
    }
}
