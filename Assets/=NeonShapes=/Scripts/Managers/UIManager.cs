using UnityEngine.UI;
using UnityEngine;
using TMPro;

namespace NeonShapes
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private Image gameName;
        
        [Header("Buttons")]
        [SerializeField] private CustomButton playButton;
        [SerializeField] private CustomButton restartButton;
        
        [Header("Texts")]
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI currentScoreText;
        [SerializeField] private TextMeshProUGUI bestScoreText;
        [SerializeField] private TextMeshProUGUI newScoreText;
        
        //==================================================
        public void Hide_UI_Elements()
        {
            gameName.gameObject.SetActive(false);
            playButton.gameObject.SetActive(false);
            restartButton.gameObject.SetActive(false);
            currentScoreText.gameObject.SetActive(false);
            bestScoreText.gameObject.SetActive(false);
            newScoreText.gameObject.SetActive(false);
        }
        //==================================================
        public void ShowRestartButton()
        {
            restartButton.gameObject.SetActive(true);
        }
        //==================================================
        public void DisplayScore(int score)
        {
            scoreText.SetText("Score = " + score);
        }
        //==================================================
        public void DisplayFinalResult(int newScore, int oldScore)
        {
            currentScoreText.gameObject.SetActive(true);
            currentScoreText.SetText("Current = " + newScore);
            
            if (oldScore > 0)
            {
                bestScoreText.gameObject.SetActive(true);
                bestScoreText.SetText("BEST = " + oldScore);
            }
            if (newScore > oldScore)
            {
                newScoreText.gameObject.SetActive(true);
                newScoreText.SetText("NEW = " + newScore);
            }
        }
        //==================================================
    }
}