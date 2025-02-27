using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject highScorePanel;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject optionsPanel;

    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private TextMeshProUGUI textHighScore;
    [SerializeField] private HighScoreData highScoreData;

    [SerializeField] private Player player;
    [SerializeField] private AlienSpawner alienSpawner;
    [SerializeField] private Button continueButton;
    [SerializeField] private Button startNewButton;
    [SerializeField] private Button startButton;

    [SerializeField] private TextMeshProUGUI[] texts;

    private void Start()
    {
        Time.timeScale = 0f;
    }

    private void Update()
    {
        if ((player.isDeath ||  alienSpawner.isAlienWinning) && !gameOverPanel.activeSelf)
        {
            OpenGameOver(false); 
        }

        if(alienSpawner.currentAliens <= 0 && !gameOverPanel.activeSelf)
        {
            OpenGameOver(true);
        }

        if(Input.GetKey(KeyCode.Escape) && !pausePanel.activeSelf)
        {
            Pause();
        }
    }

    public void OpenGameOver(bool isWin)
    {
        Time.timeScale = 0f;
        if (isWin)
        {
            text.text = "You win!";
        }
        else 
        {
            text.text = "You lose!";
        }

        textHighScore.text = highScoreData.currentScore.ToString();
        gameOverPanel.SetActive(true);
        highScoreData.NewScore();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartNew()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        continueButton.interactable = true;
        pausePanel.SetActive(false);
        startNewButton.gameObject.SetActive(true);
        startButton.gameObject.SetActive(false);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void Continue()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void HighScore(bool isOpen)
    {
        highScorePanel.SetActive(isOpen);
        pausePanel.SetActive(!isOpen);
        highScoreData.SortMaxScore();
        for (int i = 0; i < texts.Length; i++)
        {
            texts[i].text = highScoreData.maxScore[texts.Length - 1 -i].ToString();
        }
    }

    public void OptionsPanel(bool isOn)
    {
        optionsPanel.SetActive(isOn);
        pausePanel.SetActive(!isOn);
    }
}