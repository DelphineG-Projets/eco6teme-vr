using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class videoSwitch : MonoBehaviour
{
    public VideoPlayer ecranPanel;
    public VideoClip clip2;
    public Animator btnPanel;

    public void onContact()
    {
        btnPanel.Play("introStart");
    }


    public void afterContact()
    {
            btnPanel.Play("introEnd");
    }

    public void clipSwitch(VideoClip clip)
    {
     clip2 = clip;
     ecranPanel.clip = clip2; 
    }

}
