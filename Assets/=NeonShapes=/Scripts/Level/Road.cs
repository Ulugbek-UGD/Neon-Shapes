using UnityEngine.EventSystems;
using UnityEngine;
using System;

namespace NeonShapes
{
    public class Road : MonoBehaviour, IPointerEnterHandler
    {
        public static event Action<float> OnPointerAboveRoad;
        
        private SpriteRenderer spriteRenderer;
        private BoxCollider2D boxCollider2D;
        
        //==================================================
        private void OnEnable()
        {
            GameManager.OnGameStarted += OnGameStarted;
            GameManager.OnGameFinished += OnGameFinished;
        }
        //==================================================
        private void OnDisable()
        {
            GameManager.OnGameStarted -= OnGameStarted;
            GameManager.OnGameFinished -= OnGameFinished;
        }
        //==================================================
        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            boxCollider2D = GetComponent<BoxCollider2D>();
        }
        //==================================================
        private void OnGameStarted()
        {
            spriteRenderer.enabled = true;
            boxCollider2D.enabled = true;
        }
        //==================================================
        private void OnGameFinished()
        {
            spriteRenderer.enabled = false;
            boxCollider2D.enabled = false;
        }
        //==================================================
        public void OnPointerEnter(PointerEventData eventData)
        {
            OnPointerAboveRoad?.Invoke(transform.position.x);
        }
        //==================================================
    }
}