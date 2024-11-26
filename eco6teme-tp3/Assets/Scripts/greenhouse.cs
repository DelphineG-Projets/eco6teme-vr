using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Greenhouse : MonoBehaviour
{

    public XRSocketInteractor balanceSocket;

    public bool watercanOn;
    public bool waterOn; //Pressed the btn
    public bool stepOne; 
    public bool stepTwo; 

    public GameObject particleswater;
    public GameObject btnWater;

    public bool plant1;
    public bool plant2;
    public bool plant3;

    public GameObject light_teller_green_1;
    public GameObject light_teller_red_1;
    public GameObject light_teller_green_2;
    public GameObject light_teller_red_2;
    public GameObject light_teller_green_3;
    public GameObject light_teller_red_3;


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
    public GameObject light_teller_green_1
     public GameObject light_teller_green_2;
     public GameObject light_teller_green_3;
     public GameObject light_teller_red_1
     public GameObject light_teller_red_2;
     public GameObject light_teller_red_3;*/


    //WATER STEP 1
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


    public void balance()
    {
        if ((balanceSocket.interactionLayers & InteractionLayerMask.GetMask("Arrosoir")) != 0 & waterOn)
        {
            stepOne = true;
            light_teller_green_1.SetActive(true);
            light_teller_red_1.SetActive(false);
            waterOn = false;
        }

        if ((balanceSocket.interactionLayers & InteractionLayerMask.GetMask("engrais_vert")) != 0 & stepOne)
        {
            stepTwo = true;
            light_teller_green_2.SetActive(true);
            light_teller_red_2.SetActive(false);
        }

    }

    public void Light()
    {
        if (stepTwo)
        {
            light_teller_green_3.SetActive(true);
            light_teller_red_3.SetActive(false);
        }
    }
    

}