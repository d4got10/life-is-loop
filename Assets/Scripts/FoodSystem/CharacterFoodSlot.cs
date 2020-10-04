using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LifeIsLoop.FoodSystem
{
    public class CharacterFoodSlot : MonoBehaviour
    {
        [SerializeField] private Image _foodSlotImage;

        public Action<Food> OnFoodPickUp;

        public Food CurrentFood { get; private set; }

        public bool PickUpFood(Food food)
        {
            if(CurrentFood == null)
            {
                CurrentFood = food;
                OnFoodPickUp?.Invoke(CurrentFood);
                UpdateView();
                return true;
            }
            return false;
        }

        public Food UseFood()
        {
            Food food = CurrentFood;
            CurrentFood = null;
            OnFoodPickUp?.Invoke(CurrentFood);
            UpdateView();
            return food;
        }

        private void UpdateView()
        {
            if (CurrentFood == null)
            {
                _foodSlotImage.sprite = null;
                _foodSlotImage.color = new Color(0, 0, 0, 0);
            }
            else
            {
                _foodSlotImage.sprite = CurrentFood.RawSprite;
                _foodSlotImage.color = new Color(1, 1, 1, 1);
            }
        }
    }
}
