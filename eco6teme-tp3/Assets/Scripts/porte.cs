using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPorte : MonoBehaviour
{
    public GameObject Porte;
    public Transform to;
    private Quaternion initialRotation;

    private void Start()
    {
        // Save the initial rotation of the door
        initialRotation = Porte.transform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player enter storage room, opening door");
            StartCoroutine(OpenDoorSmoothly());
        }
    }

 
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exit storage room, closing door");
            StartCoroutine(CloseDoorSmoothly());
        }
    }

    private IEnumerator CloseDoorSmoothly()
    {
        float closeTime = 0.5f; // Duration to close the door
        float elapsedTime = 0.0f;

        Quaternion startRotation = Porte.transform.rotation;

        while (elapsedTime < closeTime)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / closeTime;
            Porte.transform.rotation = Quaternion.Slerp(startRotation, initialRotation, t);
            yield return null;
        }
        // Ensure the door is fully closed
        Porte.transform.rotation = initialRotation;
    }

    private IEnumerator OpenDoorSmoothly()
    {
        float openTime = 0.5f; // Duration to open the door
        float elapsedTime = 0.0f;

        Quaternion startRotation = Porte.transform.rotation;

        while (elapsedTime < openTime)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / openTime;
            Porte.transform.rotation = Quaternion.Slerp(startRotation, to.rotation, t);
            yield return null;
        }
        // Ensure the door is fully opened
        Porte.transform.rotation = to.rotation;
    }
}