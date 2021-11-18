using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
namespace RunGame.LevelControl
{

    public class LevelControl : MonoBehaviour
    {
        public static LevelControl current;

        [Header("Level Distance")]
        [SerializeField] private Transform _playerPos;
        public Transform PlayerPos
        {
            get { return _playerPos; }
            set { _playerPos = value; }
        }
        [SerializeField] private Transform _finishLine;
        public Transform FinishLine
        {
            get { return _finishLine; }
            set { _finishLine = value; }
        }
        [Header("Slider Value")]
        [SerializeField] private Slider _sliderValue;
        public Slider SliderValue
        {
            get { return _sliderValue; }
            set { _sliderValue = value; }
        }
        [SerializeField] private float _levelDistance;
        public float LevelDistance
        {
            get { return _levelDistance; }
            set { _levelDistance = value; }
        }
        [SerializeField] private float _maxDistance;
        public float MaxDistance
        {
            get { return _maxDistance; }
            set { _maxDistance = value; }
        }

        [Header("Level Control")]
        [SerializeField] private int _currentLevel;
        public int CurrentLevel
        {
            get { return _currentLevel; }
            set { _currentLevel = value; }
        }

        [SerializeField] private Text _currentLevelText;
        public Text CurrentLevelText
        {
            get { return _currentLevelText; }
            set { _currentLevelText = value; }
        }
        [SerializeField] private Text _nextLevelText;
        public Text NextLevelText
        {
            get { return _nextLevelText; }
            set { _nextLevelText = value; }
        }



        private void Awake()
        {
            PlayerPrefs.DeleteAll();

            current = this;

            CurrentLevel = PlayerPrefs.GetInt("currentLevel");
            
            if (SceneManager.GetActiveScene().name != "Level " + CurrentLevel)
            {
                SceneManager.LoadScene("Level " + CurrentLevel);
            }
            else
            {
                CurrentLevelText.text = (CurrentLevel + 1).ToString();
                NextLevelText.text = (CurrentLevel + 2).ToString();
            }
            
        }

        void Start()
        {
            MaxDistance = FinishLine.position.z - PlayerPos.position.z;
        }

        
        void Update()
        {
            LevelFinishControl();
            ResetLevel();
        }

        public void LevelFinishControl()
        {
            LevelDistance = Vector3.Distance(PlayerPos.position, FinishLine.position);

            SliderValue.value = 1 - (LevelDistance / MaxDistance);

            if (SliderValue.value >= 0.94f)
            {
                FinishLevel();
                LoadLevel();


            }

        }

        public void FinishLevel()
        {
            PlayerPrefs.SetInt("currentLevel", CurrentLevel + 1);
        }

        public void LoadLevel()
        {
            if (CurrentLevel == 2)
            {
                SceneManager.LoadScene("Finish");
                PlayerPrefs.DeleteAll();
            }
            else
            {
                SceneManager.LoadScene("Level " + (CurrentLevel + 1));
            }
        }

        public void ResetLevel()
        {
            if(PlayerPos.position.y <= -2)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

        }
    }
}