using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Greenhouse : MonoBehaviour
{
    public XRSocketInteractor balanceSocket;

    public bool watercanOn;
    public bool waterOn; // Pressed the btn
    public bool stepZeroPlant;
    public bool stepOnePlant;
    public bool stepTwoPlant;
    public bool stepThreePlant;

    public GameObject particleswater;
    public GameObject btnWater;

    public bool plant1;
    public bool plant2;
    public bool plant3;
    public bool light;

    public GameObject light_red;
    public GameObject light_green;
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



    XRSocketInteractor socket;

    void Start()
    {
        socket = GetComponent<XRSocketInteractor>();
        stepZeroPlant = true;
        light = false;
        lightchange = false;
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

    public void OnSelectEntered(SelectEnterEventArgs args)
    {
        // Récupérer le GameObject de l'objet sélectionné
        GameObject selectedObject = args.interactableObject.transform.gameObject;

        // Afficher le tag de l'objet placé sur le socket
        Debug.Log("Objet placé sur le socket a le tag : " + selectedObject.tag);

        if (stepZeroPlant)
        {
            // Vérifier si l'objet a le tag "Arrosoir"
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
                light = true;
            }
        }


        if (stepOnePlant)
        {
            // Vérifier si l'objet a le tag "Arrosoir"
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
                light = true;
            }
        }
    }

    private IEnumerator Timerchangeplant()
    {
        // Wait for 3 seconds
        yield return new WaitForSeconds(3f);

        // After 3 seconds, change the objects as required
        plante_1_etape_3.SetActive(false);
        plante_2_etape_0.SetActive(true);
        Debug.Log("Plante 1 étape 3 est maintenant désactivée et Plante 2 étape 0 est activée");
        light_green.SetActive(false);
        lightchange = false;
    }

    private IEnumerator Timerchangelight()
    {
        // Wait for 3 seconds
        yield return new WaitForSeconds(3f);
        light_red.SetActive(false);
        light_green.SetActive(true);
        Debug.Log("Plante 1 étape 3 est maintenant désactivée et Plante 2 étape 0 est activée");
        lightchange = true;
    }

    public void Update()
    {

        if (stepZeroPlant && light)
        {
            if (lightchange)
            {
                light = false;
                plante_1_etape_2.SetActive(false);
                plante_1_etape_3.SetActive(true);
                light_teller_green_1.SetActive(true);
                light_teller_red_1.SetActive(false);
                Debug.Log("Light Réussit ! Plante 1 réussit");
                stepOnePlant = true;
                stepZeroPlant = false;
                StartCoroutine(Timerchangeplant());
            }

        }

    }
    public void Light()
    {
        if (stepZeroPlant && light)
        {
            light_red.SetActive(true);
            StartCoroutine(Timerchangelight());

        }

        if (stepOnePlant && light)
        {
            light = false;
            plante_2_etape_2.SetActive(false);
            plante_2_etape_3.SetActive(true);
            light_teller_green_2.SetActive(true);
            light_teller_red_2.SetActive(false);
            Debug.Log("Light Réussit ! Plante 2 réussit");
            stepTwoPlant = true;
            stepOnePlant = false;
        }
    }
}