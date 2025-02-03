using UnityEngine;

namespace NeonShapes
{
    public class Enemy : ShapeBase
    {
        [SerializeField, Range(2, 4)] private float fallSpeed = 3;
        
        //==================================================
        private void OnEnable()
        {
            GameManager.OnGameFinished += OnFinishGame;
        }
        //==================================================
        private void OnDisable()
        {
            GameManager.OnGameFinished -= OnFinishGame;
        }
        //==================================================
        private void OnFinishGame()
        {
            Destroy(gameObject);
        }
        //==================================================
        protected override void Update()
        {
            base.Update();
            transform.Translate(Vector3.down * (fallSpeed * Time.deltaTime));
        }
        //==================================================
    }
}