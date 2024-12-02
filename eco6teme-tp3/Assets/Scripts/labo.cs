using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Labo : MonoBehaviour
{
    public XRSocketInteractor balanceSocket;
    public bool watercanOn;
    public bool waterOn;

    public bool fioleOn;

    public bool stepZeroLab;
    public bool stepOneLab;
    public bool stepTwoLab;
    public bool stepThreeLab;
    public GameObject particleswater;
    public GameObject btnWater;

    public GameObject video1;
    public GameObject video2;
    public GameObject video3;
    public GameObject video4;

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

    public GameObject fiole_1_etape_0;
    public GameObject fiole_1_etape_1;
    public GameObject fiole_1_etape_2;

    public GameObject fiole_2_etape_0;
    public GameObject fiole_2_etape_1;
    public GameObject fiole_2_etape_2;

    public GameObject fiole_3_etape_0;
    public GameObject fiole_3_etape_1;
    public GameObject fiole_3_etape_2;



    XRSocketInteractor socket;

    void Start()
    {
        socket = GetComponent<XRSocketInteractor>();
        stepZeroLab = true;
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

        if (stepZeroLab)
        {
            if (selectedObject.CompareTag("fiole_1"))
            {
                Debug.Log("Arrosoir Réussit");
                fiole_1_etape_0.SetActive(true);
                fioleOn = true;
            }
            if (selectedObject.CompareTag("arrosoir_1") && waterOn && fioleOn)
            {
                Debug.Log("Engrais Russit Réussit");
                fiole_1_etape_0.SetActive(false);
                fiole_1_etape_1.SetActive(true);
                light_square = true;
                waterOn = false;
                fioleOn = false;
            }
        }

        if (stepOneLab)
        {
            if (selectedObject.CompareTag("fiole_2"))
            {
                Debug.Log("Arrosoir Réussit");
                fiole_2_etape_0.SetActive(true);
                fioleOn = true;

}
            if (selectedObject.CompareTag("arrosoir_1") && waterOn && fioleOn)
            {
                Debug.Log("Engrais Russit Réussit");
                fiole_2_etape_0.SetActive(false);
                fiole_2_etape_1.SetActive(true);
                light_square = true;
                waterOn = false;
                fioleOn = false;
            }
        }

        if (stepTwoLab)
        {
            if (selectedObject.CompareTag("fiole_3"))
            {
                Debug.Log("Arrosoir Réussit");
                fiole_3_etape_0.SetActive(true);
                fioleOn = true;
            }
            if (selectedObject.CompareTag("arrosoir_1") && waterOn && fioleOn)
            {
                Debug.Log("Engrais Russit Réussit");
                fiole_3_etape_0.SetActive(false);
                fiole_3_etape_1.SetActive(true);
                light_square = true;
                waterOn = false;
                fioleOn = false;
            }
        }
    }

    private IEnumerator Timerchangefiole()
    {
        yield return new WaitForSeconds(3f);

        light_square = false;
        lightchange = false;
        light_green.SetActive(false);

        if (stepOneLab)
        {
            fiole_1_etape_2.SetActive(false);
            video1.SetActive(false);
            video2.SetActive(true);
            Debug.Log("Plante 1 étape 3 est maintenant désactivée et Plante 2 étape 0 est activée");
        }

        if (stepTwoLab)
        {
            fiole_2_etape_2.SetActive(false);
            video2.SetActive(false);
            video3.SetActive(true);
            Debug.Log("Plante 1 étape 3 est maintenant désactivée et Plante 2 étape 0 est activée");
        }

        if (stepThreeLab)
        {
            video3.SetActive(false);
            video4.SetActive(true);
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
        if (stepZeroLab && light_square)
        {
            if (lightchange)
            {
                light_square = false;
                fiole_1_etape_1.SetActive(false);
                fiole_1_etape_2.SetActive(true);
                Debug.Log("Light Réussit ! Plante 1 réussit");
                light_teller_green_1.SetActive(true);
                light_teller_red_1.SetActive(false);
                stepOneLab = true;
                stepZeroLab = false;
                StartCoroutine(Timerchangefiole());
            }
        }

        if (stepOneLab && light_square)
        {
            if (lightchange)
            {
                light_square = false;
                fiole_2_etape_1.SetActive(false);
                fiole_2_etape_2.SetActive(true);
                light_teller_green_2.SetActive(true);
                light_teller_red_2.SetActive(false);
                Debug.Log("Light Réussit ! Plante 2 réussit");
                stepTwoLab = true;
                stepOneLab = false;
                StartCoroutine(Timerchangefiole());
            }
        }

        if (stepTwoLab && light_square)
        {
            if (lightchange)
            {
                light_square = false;
                fiole_3_etape_1.SetActive(false);
                fiole_3_etape_2.SetActive(true);
                light_teller_green_3.SetActive(true);
                light_teller_red_3.SetActive(false);
                Debug.Log("Light Réussit ! Plante 2 réussit");
                stepThreeLab = true;
                stepTwoLab = false;

            }
        }

        if (stepThreeLab)
        {
            Debug.Log("JEU FINI");
        }
    }

    public void Light()
    {

        if (stepZeroLab && light_square)
        {

            light_square = false;
            StartCoroutine(Timerchangelight());
            light_red.SetActive(true);

        }

        if (stepOneLab && light_square)
        {
            light_square = false;
            light_red.SetActive(true);
            StartCoroutine(Timerchangelight());
        }

        if (stepTwoLab && light_square)
        {
            light_square = false;
            light_red.SetActive(true);
            StartCoroutine(Timerchangelight());
        }
    }
}