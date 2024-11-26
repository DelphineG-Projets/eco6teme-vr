using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Greenhouse : MonoBehaviour
{


    public bool watercanOn;
    public bool waterOn; //Pressed the btn

    public GameObject particleswater;
    public GameObject btnWater;


    /*  // Plant 1 stages
     *      // Sockets
    public GameObject balance_interactable;
    public GameObject waterpump_interactable;

    // Watercan
    public LayerMask watercan = LayerMask.GetMask("Wall");
    public GameObject particles;
     public GameObject plante_1_etape_0;
     public GameObject plante_1_etape_1;
     public GameObject plante_1_etape_2;
     public GameObject plante_1_etape_3;

     // Plant 2 stages
     public GameObject plante_2_etape_0;
     public GameObject plante_2_etape_1;
     public GameObject plante_2_etape_2;
     public GameObject plante_2_etape_3;

     // Plant 3 stages
     public GameObject plante_3_etape_0;
     public GameObject plante_3_etape_1;
     public GameObject plante_3_etape_2;
     public GameObject plante_3_etape_3;

     // Lumières puzzle progression
    public GameObject light_teller_green_1;
     public GameObject light_teller_green_2;
     public GameObject light_teller_green_3;
     public GameObject light_teller_red_1;
     public GameObject light_teller_red_2;
     public GameObject light_teller_red_3;*/

    public void waterTrue()
    {
        watercanOn = true;
    }

    public void waterFalse()
    {
        watercanOn = false;
    }

    public void btnwaterOn()
    {
        if (watercanOn)
        {
            waterOn = true;
        }
    }



}