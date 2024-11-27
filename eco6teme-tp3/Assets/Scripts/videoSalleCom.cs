using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class videoSalleCom : MonoBehaviour
{
    public GameObject ecran1;
    public GameObject ecran2;
    public GameObject ecran3;
    public GameObject ecranPanel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player enter communication room => open screens");

            ecran1.SetActive(true);
            ecran2.SetActive(true);
            ecran3.SetActive(true);
            ecranPanel.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exit communication room => close screens");

            ecran1.SetActive(false);
            ecran2.SetActive(false);
            ecran3.SetActive(false);
            ecranPanel.SetActive(false);
        }
    }
}
