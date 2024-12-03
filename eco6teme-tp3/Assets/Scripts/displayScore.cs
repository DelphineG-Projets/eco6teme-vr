using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class displayScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI recordedTimeText;
    [SerializeField] TextMeshProUGUI bestTimeText;
    
    // Start is called before the first frame update
    void Start()
    {
        float bestTime = Timer.bestTime;

        if (Timer.recordedTime <= bestTime)
        {
        int minutes = Mathf.FloorToInt(Timer.recordedTime / 60);
        int seconds = Mathf.FloorToInt(Timer.recordedTime % 60);
        recordedTimeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }

        if (bestTime < float.MaxValue)
        {
            int bestMinutes = Mathf.FloorToInt(bestTime / 60);
            int bestSeconds = Mathf.FloorToInt(bestTime % 60);
            bestTimeText.text = string.Format("{0:00}:{1:00}", bestMinutes, bestSeconds);
        }
        else
        {
            bestTimeText.text = "00:00";
        }

    }
}
