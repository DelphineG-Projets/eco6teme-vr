using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Greenhouse : MonoBehaviour
{
    // Lights indicating puzzle progress
    public GameObject light_teller_green_1;
    public GameObject light_teller_green_2;
    public GameObject light_teller_green_3;
    public GameObject light_teller_red_1;
    public GameObject light_teller_red_2;
    public GameObject light_teller_red_3;

    // Plant stages
    public GameObject plante_3_etape_1;
    public GameObject plante_3_etape_2;
    public GameObject plante_3_etape_3;

    void Update()
    {
        if (plante_3_etape_1.activeSelf)
        {
            light_teller_green_1.SetActive(true);
            light_teller_red_1.SetActive(false);
        }
        if (plante_3_etape_2.activeSelf)
        {
            light_teller_green_2.SetActive(true);
            light_teller_red_2.SetActive(false);
        }
        if (plante_3_etape_3.activeSelf)
        {
            light_teller_green_3.SetActive(true);
            light_teller_red_3.SetActive(false);
        }
    }
}