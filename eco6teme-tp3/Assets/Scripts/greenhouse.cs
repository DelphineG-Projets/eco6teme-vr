using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Greenhouse : MonoBehaviour
{
    public XRSocketInteractor balanceSocket;
    public bool watercanOn;
    public bool waterOn;
    public bool stepZeroPlant;
    public bool stepOnePlant;
    public bool stepTwoPlant;
    public bool stepThreePlant;
    public GameObject particleswater;
    public GameObject btnWater;

    public bool plant1;
    public bool plant2;
    public bool plant3;

    public GameObject light_red;
    public GameObject light_green;


    public bool light_square;
    public bool lightchange;
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

    public GameObject plante_2_etape_0;
    public GameObject plante_2_etape_1;
    public GameObject plante_2_etape_2;
    public GameObject plante_2_etape_3;

    public GameObject plante_3_etape_0;
    public GameObject plante_3_etape_1;
    public GameObject plante_3_etape_2;
    public GameObject plante_3_etape_3;

    XRSocketInteractor socket;

    void Start()
    {
        socket = GetComponent<XRSocketInteractor>();
        stepZeroPlant = true;
        light_square = false;
        lightchange = false;
    }

    public void socketCheck()
    {
        IXRSelectInteractable objName = socket.GetOldestInteractableSelected();
        Debug.Log(objName.transform.name + " in socket of " + transform.name);
    }

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

    public void OnSelectEntered(SelectEnterEventArgs args)
    {
        GameObject selectedObject = args.interactableObject.transform.gameObject;
        Debug.Log("Objet placé sur le socket a le tag : " + selectedObject.tag);

        if (stepZeroPlant)
        {
            if (selectedObject.CompareTag("arrosoir_1") && waterOn)
            {
                Debug.Log("Arrosoir Réussit");
                plante_1_etape_0.SetActive(false);
                plante_1_etape_1.SetActive(true);
                waterOn = false;
            }
            if (selectedObject.CompareTag("engrais_1") && plante_1_etape_1)
            {
                Debug.Log("Engrais Russit Réussit");
                plante_1_etape_1.SetActive(false);
                plante_1_etape_2.SetActive(true);
                light_square = true;
            }
        }

        if (stepOnePlant)
        {
            if (selectedObject.CompareTag("arrosoir_1") && waterOn)
            {
                Debug.Log("Arrosoir Réussit");
                plante_2_etape_0.SetActive(false);
                plante_2_etape_1.SetActive(true);
                waterOn = false;
            }
            if (selectedObject.CompareTag("engrais_2") && plante_2_etape_1)
            {
                Debug.Log("Engrais Russit Réussit");
                plante_2_etape_1.SetActive(false);
                plante_2_etape_2.SetActive(true);
                light_square = true;
            }
        }

        if (stepTwoPlant)
        {
            if (selectedObject.CompareTag("arrosoir_1") && waterOn)
            {
                Debug.Log("Arrosoir Réussit");
                plante_3_etape_0.SetActive(false);
                plante_3_etape_1.SetActive(true);
                waterOn = false;
            }
            if (selectedObject.CompareTag("engrais_3") && plante_3_etape_1)
            {
                Debug.Log("Engrais Russit Réussit");
                plante_3_etape_1.SetActive(false);
                plante_3_etape_2.SetActive(true);
                light_square = true;
            }
        }
    }

    private IEnumerator Timerchangeplant()
    {
        yield return new WaitForSeconds(3f);

        light_square = false;
        lightchange = false;
        light_green.SetActive(false);

        if (stepOnePlant)
        {
            plante_1_etape_3.SetActive(false);
            plante_2_etape_0.SetActive(true);
            Debug.Log("Plante 1 étape 3 est maintenant désactivée et Plante 2 étape 0 est activée");
        }

        if (stepTwoPlant)
        {
            plante_2_etape_3.SetActive(false);
            plante_3_etape_0.SetActive(true);
            Debug.Log("Plante 1 étape 3 est maintenant désactivée et Plante 2 étape 0 est activée");
        }

    }


    private IEnumerator Timerchangelight()
    {
        yield return new WaitForSeconds(3f);
        light_square = true;
        Debug.Log("Plante 1 étape 3 est maintenant désactivée et Plante 2 étape 0 est activée");
        lightchange = true;



        light_red.SetActive(false);
        light_green.SetActive(true);
}

    public void Update()
    {
        if (stepZeroPlant && light_square)
        {
            if (lightchange)
            {
                light_square = false;
                plante_1_etape_2.SetActive(false);
                plante_1_etape_3.SetActive(true);
                Debug.Log("Light Réussit ! Plante 1 réussit");
                light_teller_green_1.SetActive(true);
                light_teller_red_1.SetActive(false);
                stepOnePlant = true;
                stepZeroPlant = false;
                StartCoroutine(Timerchangeplant());
            }
        }

        if (stepOnePlant && light_square)
        {
            if (lightchange)
            {
                light_square = false;
                plante_2_etape_2.SetActive(false);
                plante_2_etape_3.SetActive(true);
                light_teller_green_2.SetActive(true);
                light_teller_red_2.SetActive(false);
                Debug.Log("Light Réussit ! Plante 2 réussit");
                stepTwoPlant = true;
                stepOnePlant = false;
                StartCoroutine(Timerchangeplant());
            }
        }

        if (stepTwoPlant && light_square)
        {
            if (lightchange)
            {
                light_square = false;
                plante_3_etape_2.SetActive(false);
                plante_3_etape_3.SetActive(true);
                light_teller_green_3.SetActive(true);
                light_teller_red_3.SetActive(false);
                Debug.Log("Light Réussit ! Plante 2 réussit");
                stepThreePlant = true;
                stepTwoPlant = false;
            
            }
        }
    
        if(stepThreePlant)
        {
            Debug.Log("JEU FINI");
        }
    }

    public void Light()
    {

        if (stepZeroPlant && light_square)
        {

            light_square = false;
            StartCoroutine(Timerchangelight());
            light_red.SetActive(true);

        }

        if (stepOnePlant && light_square)
        {
            light_square = false;
            light_red.SetActive(true);
            StartCoroutine(Timerchangelight());
        }

        if (stepTwoPlant && light_square)
        {
            light_square = false;
            light_red.SetActive(true);
            StartCoroutine(Timerchangelight());
        }
    }
}
