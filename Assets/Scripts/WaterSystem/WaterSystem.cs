using LifeIsLoop.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LifeIsLoop.WaterSystem
{
    public class WaterSystem : MonoBehaviour
    {
        [SerializeField] private CharacterNeeds _characterNeeds;
        [SerializeField] private AudioSource _audioSource;
        public void Drink(float amount)
        {
            _audioSource.Play();
            _characterNeeds.Thirst.RemoveValue(amount);
        }
    }
}