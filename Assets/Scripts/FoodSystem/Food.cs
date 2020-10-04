using UnityEngine;

namespace LifeIsLoop.FoodSystem
{
    [CreateAssetMenu(fileName = "New Food", menuName = "Life Is Loop/Food System/Create new Food")]
    public class Food : ScriptableObject
    {
        [SerializeField] private float _nutrition;
        [SerializeField] private bool _needsToBeCooked;
        [Space]
        [SerializeField] private Sprite _rawSprite;
        [SerializeField] private Sprite _cookedSprite;

        public float Nutrition => _nutrition;
        public bool NeedsBeCooked => _needsToBeCooked;

        public Sprite RawSprite => _rawSprite;
        public Sprite CookedSprite => _cookedSprite;
    }
}
