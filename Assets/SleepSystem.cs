using LifeIsLoop.Character;
using UnityEngine;

namespace LifeIsLoop.SleepSystem
{
    public class SleepSystem : MonoBehaviour
    {
        [SerializeField] private CharacterNeeds _characterNeeds;
        [SerializeField] private AudioSource _audioSource;

        public float Time => _characterNeeds.Sleep.Value/_characterNeeds.Sleep.MaxValue;

        public void Sleep()
        {
            _audioSource.Play();
            _characterNeeds.Sleep.RemoveValue(_characterNeeds.Sleep.Value);
        }
    }
}