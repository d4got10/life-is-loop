using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LifeIsLoop.FoodSystem
{
    public class CampFire : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _foodRenderer;

        [SerializeField] private CharacterFoodSlot _characterFoodSlot;
        [SerializeField] private FoodSystem _foodSystem;

        [SerializeField] private AudioSource _audioSourceFailure;
        [SerializeField] private AudioSource _audioSourceSuccess;

        private Food _currentFood;

        public void Interact()
        {
            if (_currentFood == null)
            {
                var food = _characterFoodSlot.CurrentFood;
                if(food != null && food.NeedsBeCooked)
                {
                    SetFood(_characterFoodSlot.UseFood());
                    Debug.Log("Еда жарится");
                    _audioSourceSuccess.Play();
                }
                else
                {
                    _audioSourceFailure.Play();
                }
            }
            else
            {
                _foodSystem.Consume(_currentFood);
                SetFood(null);
                Debug.Log("Еда сьедена");
            }
        }

        private void SetFood(Food food)
        {
            _currentFood = food;
            UpdateView();
        }

        private void UpdateView()
        {
            if (_currentFood == null)
                _foodRenderer.sprite = null;
            else
                _foodRenderer.sprite = _currentFood.CookedSprite;
        }
    }
}