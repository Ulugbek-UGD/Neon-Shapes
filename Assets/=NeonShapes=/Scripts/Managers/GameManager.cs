using UnityEngine;
using System;

namespace NeonShapes
{
    [DefaultExecutionOrder(-2)]
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private Player player;
        
        [Header("Managers")]
        [SerializeField] private SpawnManager spawnManager;
        [SerializeField] private UIManager uiManager;
        
        [Header("Audio")]
        [SerializeField] private AudioClip winSound;
        [SerializeField] private AudioClip loseSound;
        
        public static GameManager Instance { get; private set; }
        public static event Action OnGameStarted;
        public static event Action OnGameFinished;
        
        private int score;
        
        //==================================================
        private void Awake()
        {
            if (Instance == null || Instance == this)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        //==================================================
        public void StartGame()
        {
            score = 0;
            spawnManager.StartSpawn();
            uiManager.DisplayScore(score);
            uiManager.Hide_UI_Elements();
            player.gameObject.SetActive(true);
            OnGameStarted?.Invoke();
        }
        //==================================================
        public void AddScore()
        {
            score++;
            spawnManager.SpeedUpSpawn();
            uiManager.DisplayScore(score);
        }
        //==================================================
        public void FinishGame()
        {
            spawnManager.StopSpawn();
            
            var oldScore = PlayerPrefs.GetInt("PlayerScore");
            if (score > oldScore)
            {
                PlayerPrefs.SetInt("PlayerScore", score);
                PlayerPrefs.Save();
                AudioManager.Instance.PlaySound(winSound);
            }
            else
            {
                AudioManager.Instance.PlaySound(loseSound);
            }
            uiManager.DisplayFinalResult(score, oldScore);
            uiManager.ShowRestartButton();
            player.gameObject.SetActive(false);
            OnGameFinished?.Invoke();
        }
        //==================================================
        public void ExitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.ExitPlaymode();
#endif
            Application.Quit();
        }
        //==================================================
    }
}