using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace LifeIsLoop
{
    public class InteractableGameObject : MonoBehaviour
    {
        [SerializeField] private GameObject _interactionAbility;
        [SerializeField] private KeyCode _key;
        [Space]
        public UnityEvent OnInteract;

        private Coroutine _interactCoroutine;

        private void Awake()
        {
            HideInteractionAbility();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                ShowInteractionAbility();
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                HideInteractionAbility();
            }
        }

        private void ShowInteractionAbility()
        {
            _interactionAbility.SetActive(true);
            _interactCoroutine = StartCoroutine(InteractCoroutine());
        }

        private void HideInteractionAbility()
        {
            _interactionAbility.SetActive(false);
            if (_interactCoroutine != null)
            {
                StopCoroutine(_interactCoroutine);
                _interactCoroutine = null;
            }
        }

        IEnumerator InteractCoroutine()
        {
            while (true)
            {
                if (Input.GetKeyDown(_key))
                {
                    Debug.Log("Interact");
                    OnInteract?.Invoke();
                }
                yield return null;
            }
        }
    }
}
