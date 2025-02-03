using UnityEngine;

namespace NeonShapes
{
    public class GameOverTrigger : MonoBehaviour
    {
        //==================================================
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<Enemy>(out _))
            {
                GameManager.Instance.FinishGame();
            }
        }
        //==================================================
    }
}