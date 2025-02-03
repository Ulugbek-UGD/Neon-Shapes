using UnityEngine;

namespace NeonShapes
{
    public abstract class ShapeBase : MonoBehaviour
    {
        public enum Shape
        {
            None,
            Circle,
            Square,
            Star,
            Triangle
        }
        public Shape shape = Shape.None;
        
        [SerializeField] private Sprite[] shapeSprites;
        private SpriteRenderer spriteRenderer;
        
        //==================================================
        protected virtual void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
        //==================================================
        protected virtual void Update()
        {
            spriteRenderer.sprite = shape switch
            {
                Shape.Circle => shapeSprites[0],
                Shape.Square => shapeSprites[1],
                Shape.Star => shapeSprites[2],
                Shape.Triangle => shapeSprites[3],
                _ => spriteRenderer.sprite
            };
        }
        //==================================================
    }
}