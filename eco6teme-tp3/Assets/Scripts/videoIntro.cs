using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class videoIntro : MonoBehaviour
{
    public GameObject video1;
    public GameObject video2;

    // Start is called before the first frame update
    public void Detection()
    {
        video1.SetActive(true);

        if (video1.Stop)
        {
            video1.SetActive(false);
            video2.SetActive(true);
        }
    }
}
