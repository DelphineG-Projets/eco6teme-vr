using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Greenhouse : MonoBehaviour
{
    public XRSocketInteractor balanceSocket;

    public bool watercanOn;
    public bool waterOn; // Pressed the btn
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

    public GameObject plante_1_etape_0;
    public GameObject plante_1_etape_1;
    public GameObject plante_1_etape_2;
    public GameObject plante_1_etape_3;


    XRSocketInteractor socket;

    void Start()
    {
        socket = GetComponent<XRSocketInteractor>();
    }

    public void socketCheck()
    {

        IXRSelectInteractable objName = socket.GetOldestInteractableSelected();

        Debug.Log(objName.transform.name + " in socket of " + transform.name);
    }

    // Water STEP 1
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
        if (((balanceSocket.interactionLayers & InteractionLayerMask.GetMask("Arrosoir")) != 0) && waterOn)
        {
            stepOne = true;
            plante_1_etape_0.SetActive(false);
            plante_1_etape_1.SetActive(true);
            waterOn = false;
        }

        if (((balanceSocket.interactionLayers & InteractionLayerMask.GetMask("engrais_vert")) != 0) && stepOne)
        {
            stepTwo = true;
            plante_1_etape_1.SetActive(false);
            plante_1_etape_2.SetActive(true);
        }
    }

    public void Light()
    {
        if (stepTwo)
        {
            plante_1_etape_2.SetActive(false);
            plante_1_etape_3.SetActive(true);
            light_teller_green_1.SetActive(true);
            light_teller_red_1.SetActive(false);
        }
    }
}
