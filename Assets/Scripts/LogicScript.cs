using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LogicScript : MonoBehaviour
{
/*input all gameObject and change the integer based on level design*/

//Achievement integer(coin, star)    
public int playerCoin;
public int threeStar;
public int twoStar;
public int oneStar;

//time and coin text
public Text waktuText;
public Text coinText;
//Screen
public GameObject zeroStarScreen;
public GameObject oneStarScreen;
public GameObject twoStarScreen;
public GameObject threeStarScreen;
public GameObject coinScreen;
public GameObject TimerScreen;
public GameObject gameOverScreen_crash;
public GameObject gameOverScreen_timelimit;
public GameObject missionSuccessScreen;
[ContextMenu("Increase Coin")]
public void addCoin()
{
    playerCoin += 1;
    coinText.text = playerCoin.ToString();
}

public void restartGame()
{
    SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
}
public void gameOver_crash()
{
    gameOverScreen_crash.SetActive(true);
    coinScreen.SetActive(false);
    TimerScreen.SetActive(false);
}
public void gameOver_timelimit()
{
    gameOverScreen_timelimit.SetActive(true);
    coinScreen.SetActive(false);
    TimerScreen.SetActive(false);
}
public void missionSuccess()
{
    missionSuccessScreen.SetActive(true);
    coinScreen.SetActive(false);
    TimerScreen.SetActive(false);

    int coinStar = playerCoin;
    
    if (coinStar == threeStar)
    {
        threeStarScreen.SetActive(true);
    }
    else if (twoStar < coinStar && coinStar < threeStar)
    {
        twoStarScreen.SetActive(true);
    }
    else if (oneStar < coinStar && coinStar < twoStar)
    {
        oneStarScreen.SetActive(true);
    }
    else
    {
        zeroStarScreen.SetActive(true);
    }
}

}
