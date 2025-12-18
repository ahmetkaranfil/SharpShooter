using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text enemiesLeftText;
    [SerializeField] GameObject winPanel;

    int enemiesLeft = 0;

    const string ENEMIES_LEFT_STRING = "Kalan Düşman: ";

    public void UpdateEnemiesLeft(int amount = 0)
    {
        enemiesLeft += amount;
        enemiesLeftText.text = ENEMIES_LEFT_STRING + enemiesLeft.ToString();

        if (enemiesLeft <= 0)
        {
            winPanel.SetActive(true);
        }
    }


    public void RestartButton()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentLevel);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
