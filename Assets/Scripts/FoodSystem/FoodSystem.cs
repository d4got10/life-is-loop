using LifeIsLoop.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LifeIsLoop.FoodSystem
{
    public class FoodSystem : MonoBehaviour
    {
        [SerializeField] private CharacterNeeds _characterNeeds;

        [SerializeField] private AudioSource _audioSource;

        public void Consume(Food food)
        {
            _audioSource.Play();
            _characterNeeds.Hunger.RemoveValue(food.Nutrition);
        }
    }
}
