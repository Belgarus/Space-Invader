using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverPannel;
    [SerializeField] TextMeshProUGUI gameOverText;
    [SerializeField] Player player;
    [SerializeField] AlienContainer container;
    private void Update()
    {
        if (player.isDead || container.isAlienWinning)
        {
            OpenGameOver(false);
        }
        if (container.currentAlienAmount <= 0)
        {
            OpenGameOver(true);
        }
    }
    public void OpenGameOver(bool isWin)
    {
        Time.timeScale = 0f;
        if (isWin)
        {
            gameOverText.text = "You win!";
        }
        else
        {
            gameOverText.text = "You lost!";
        }
        gameOverPannel.SetActive(true);
    }
    public void StartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}

