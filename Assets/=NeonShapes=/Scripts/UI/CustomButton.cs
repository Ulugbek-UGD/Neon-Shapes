using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;

namespace NeonShapes
{
    public class CustomButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
    {
        [SerializeField] private AudioClip clickSound;
        
        [Header("Event")]
        [SerializeField] private UnityEvent onClick;
        
        private Image image;
        
        //==================================================
        private void Awake()
        {
            image = GetComponent<Image>();
        }
        //==================================================
        private void OnEnable()
        {
            SetAlpha(0.7f);
        }
        //==================================================
        public void OnPointerEnter(PointerEventData eventData)
        {
            SetAlpha(1f);
        }
        //==================================================
        public void OnPointerExit(PointerEventData eventData)
        {
            SetAlpha(0.7f);
        }
        //==================================================
        public void OnPointerDown(PointerEventData eventData)
        {
            SetScale(0.9f);
            AudioManager.Instance.PlaySound(clickSound);
        }
        //==================================================
        public void OnPointerUp(PointerEventData eventData)
        {
            SetScale(1f);
        }
        //==================================================
        public void OnPointerClick(PointerEventData eventData)
        {
            onClick?.Invoke();
        }
        //==================================================
        private void SetAlpha(float value)
        {
            var color = image.color;
            color.a = value;
            image.color = color;
        }
        //==================================================
        private void SetScale(float value)
        {
            transform.localScale = new Vector3(value, value, value);
        }
        //==================================================
    }
}