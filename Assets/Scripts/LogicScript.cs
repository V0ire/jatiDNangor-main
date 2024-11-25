using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LogicScript : MonoBehaviour
{
public int playerCoin;
public Text waktuText;
public Text coinText;
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
}
public void gameOver_timelimit()
{
    gameOverScreen_timelimit.SetActive(true);
}public void missionSuccess()
{
    missionSuccessScreen.SetActive(true);
}
}
