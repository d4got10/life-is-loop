using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LifeIsLoop.Character
{
    public class CharacterDeath : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private CharacterNeeds _characterNeeds;

        private bool _isDead = false;

        private void Awake()
        {
            _characterNeeds.OnDeath += Death;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Death();
            }
        }

        public void Death()
        {
            if (_isDead == false)
            {
                _isDead = true;
                _animator.SetTrigger("Death");
                Invoke(nameof(LoadEndScene), 2f);
            }
        }

        private void LoadEndScene() => SceneManager.LoadScene(1);
    }
}
