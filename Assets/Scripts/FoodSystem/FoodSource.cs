using LifeIsLoop.FoodSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSource : MonoBehaviour
{
    [SerializeField] private Food _food;
    [SerializeField] private CharacterFoodSlot _characterFoodSlot;
    [SerializeField] private AudioSource _audioSourceSuccess;
    [SerializeField] private AudioSource _audioSourceFailure;
    [Space(20)]
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite _spriteWithoutFood;

    [SerializeField] private float _restoreTime = 50;

    private float _restoredTime;
    private bool HasFood => _restoredTime >= _restoreTime;

    private Sprite _spriteWithFood;

    private void Awake()
    {
        _spriteWithFood = _spriteRenderer.sprite;
        _restoredTime = _restoreTime;
    }

    public void Interact()
    {
        if (HasFood)
        {
            if (_characterFoodSlot.PickUpFood(_food))
            {
                _restoredTime = 0;
                _spriteRenderer.sprite = _spriteWithoutFood;
                _audioSourceSuccess.Play();
            }
            else
            {
                _audioSourceFailure.Play();
            }
        }
    }

    private void Update()
    {
        if (HasFood == false)
        {
            _restoredTime += Time.deltaTime;
            if (_restoredTime > _restoreTime)
            {
                _restoredTime = _restoreTime;
                _spriteRenderer.sprite = _spriteWithFood;
            }
            }
    }
}
