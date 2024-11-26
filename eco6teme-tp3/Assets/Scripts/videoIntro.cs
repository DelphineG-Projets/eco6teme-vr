using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class videoIntro : MonoBehaviour
{
    public VideoPlayer video1;
    public GameObject ecran1;
    public VideoPlayer video2;
    public bool ecranActive;

    public int count;

    // Start is called before the first frame update
    
    public void Play() {
        ecranActive = false;
        if(video1.isPlaying)
        {
            ecran1.SetActive(false);
            video2.Play();
        }

    }

    private IEnumerator Reussite()
    {
        yield return new WaitForSeconds(2f);
        video1.Stop();
        ecran1.SetActive(false);
        video2.Play();
        yield break;
    }
}
