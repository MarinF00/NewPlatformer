using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager1 : MonoBehaviour
{

   public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        PlayerPrefs.GetInt("Coins", CoinCounter.coinAmount);
    }
    public void QuitGame()
    {
        Debug.Log("WE QUIT THE GAME!");
        Application.Quit();
    }

    public void ChooseStage()
    {
        SceneManager.LoadScene("ChooseStage");
    }
    public void Stage1()
    {
        SceneManager.LoadScene("FirstStageLevels");
    }
    public void Stage2()
    {
        SceneManager.LoadScene("Stage2");
    }
    public void Stage3()
    {
        SceneManager.LoadScene("Stage3");
    }



}

