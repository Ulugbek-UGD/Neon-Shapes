using UnityEngine;
using System;

namespace NeonShapes
{
    public class Player : ShapeBase
    {
        [SerializeField, Range(10, 20)] private float moveSpeed = 20;
        [SerializeField] private Projectile projectile;
        
        [Header("Audio")]
        [SerializeField] private AudioClip shootSound;
        [SerializeField] private AudioClip collideSound;
        
        private float roadPositionX;
        
        private int shapeIndex = 1;
        
        //==================================================
        private void OnEnable()
        {
            Road.OnPointerAboveRoad += CacheRoadPositionX;
        }
        //==================================================
        private void OnDisable()
        {
            Road.OnPointerAboveRoad -= CacheRoadPositionX;
        }
        //==================================================
        private void CacheRoadPositionX(float value)
        {
            roadPositionX = value;
        }
        //==================================================
        protected override void Update()
        {
            base.Update();
            var position = transform.position;
            var desiredX = Mathf.Lerp(position.x, roadPositionX, moveSpeed * Time.deltaTime);
            var smoothPosition = new Vector3(desiredX, position.y, position.z);
            transform.position = smoothPosition;
            
            if (Input.GetButtonDown("Fire2"))
            {
                if (shapeIndex < Enum.GetValues(typeof(Shape)).Length - 1)
                {
                    shapeIndex++;
                }
                else
                {
                    shapeIndex = 1;
                }
                shape = (Shape)shapeIndex;
            }
            if (Input.GetButtonDown("Fire1") && Mathf.Abs(transform.position.x - roadPositionX) <= 0.2f && !Input.mousePosition.PointedOnUiObject())
            {
                Instantiate(projectile, transform.position, Quaternion.identity).shape = shape;
                AudioManager.Instance.PlaySound(shootSound);
            }
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
            }
        }
        //==================================================
    }   
}