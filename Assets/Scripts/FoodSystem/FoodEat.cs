using LifeIsLoop.FoodSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LifeIsLoop.FoodSystem
{
    public class FoodEat : MonoBehaviour
    {
        [SerializeField] private FoodSystem _foodSystem;
        [SerializeField] private CharacterFoodSlot _characterFoodSlot;
        [Space]
        [SerializeField] private GameObject _foodUseButton;

        private void Awake()
        {
            HideButton();
            _characterFoodSlot.OnFoodPickUp += OnNewFoodInSlot;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                if (_characterFoodSlot.CurrentFood != null && _characterFoodSlot.CurrentFood.NeedsBeCooked == false)
                    _foodSystem.Consume(_characterFoodSlot.UseFood());
            }
        }

        private void OnNewFoodInSlot(Food food)
        {
            if (food == null || food.NeedsBeCooked)
            {
                HideButton();
            }
            else
            {
                ShowButton();
            }
        }

        private void ShowButton()
        {
            _foodUseButton.SetActive(true);
        }

        private void HideButton()
        {
            _foodUseButton.SetActive(false);
        }
    }
}
