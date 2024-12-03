using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    float elapsedTime;
    public static float recordedTime;
    public static float bestTime = float.MaxValue;

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void RecordTime()
    {
        recordedTime = elapsedTime;
        Debug.Log("Recorded Time: " + recordedTime);

        // Update the score if the new time is better
        if (recordedTime < bestTime)
        {
            bestTime = recordedTime;
            Debug.Log("New Best Time: " + bestTime);
        }
    }
}
