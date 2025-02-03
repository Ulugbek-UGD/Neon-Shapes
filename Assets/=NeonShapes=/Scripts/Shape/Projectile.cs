using UnityEngine;

namespace NeonShapes
{
    public class Projectile : ShapeBase
    {
        [SerializeField, Range(10, 20)] private float flySpeed = 15;
        
        [Header("Audio")]
        [SerializeField] private AudioClip collideSound;
        
        private Rigidbody2D body2D;
        
        //==================================================
        protected override void Awake()
        {
            base.Awake();
            body2D = GetComponent<Rigidbody2D>();
        }
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
        private void Start()
        {
            Destroy(gameObject, 3);
        }
        //==================================================
        protected void FixedUpdate()
        {
            body2D.velocity = new Vector2(body2D.velocity.x, flySpeed);
        }
        //==================================================
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<Enemy>(out var enemy))
            {
                if (shape == enemy.shape)
                {
                    GameManager.Instance.AddScore();
                    AudioManager.Instance.PlaySound(collideSound);
                }
                else
                {
                    GameManager.Instance.FinishGame();
                }
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }
        //==================================================
    }
}