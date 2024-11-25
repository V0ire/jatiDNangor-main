using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public float sisaWaktu;
   public LogicScript logic;


    void Update()
    {
        sisaWaktu = sisaWaktu - Time.deltaTime;
        int menit = Mathf.FloorToInt(sisaWaktu / 60);
        int detik = Mathf.FloorToInt(sisaWaktu % 60);
        timerText.text = string.Format("{0:00}:{1:00}", menit, detik);
    if (sisaWaktu < 0.5F)
    {
        logic.gameOver_timelimit();
        sisaWaktu = 0.1F;
    }
    }
}
