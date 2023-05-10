using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

  public GameObject mainMenu;
  public GameObject winMenu;
  public GameObject lossMenu;
  public GameObject coinCounter;
  public static bool restartGame = false;
  public int coinCount = 0;
  public TMP_Text coinCountText;

  void Start()
  {

    Time.timeScale = 1;

    if (restartGame)
    {
      StartGame();
    }

  }

  void Update()
  {
    coinCountText.text = ("Coins: " + coinCount.ToString());
    if (mainMenu.activeInHierarchy == false && lossMenu.activeInHierarchy == false && winMenu.activeInHierarchy == false)
    {
      coinCounter.SetActive(true);
    }
  }

  public void StartGame()
  {
    mainMenu.SetActive(false);
  }

  public void RestartGame()
  {
    restartGame = true;
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }

  public void NextLevel()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
  }

  public void MainMenu()
  {
    restartGame = false;
    if (SceneManager.GetActiveScene().name != "Level1")
    {
      SceneManager.LoadScene("Level1");
    }
    else
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
  }



}
