using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPorte : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the other object has the "Player" tag
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered trigger zone, opening door.");
            // Rotate the door to open
            Vector3 openRotation = new Vector3(0, 90, 0); // Customize rotation as needed
            transform.eulerAngles = openRotation;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the other object has the "Player" tag
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited trigger zone, closing door.");
            // Rotate the door to close
            Vector3 closeRotation = new Vector3(0, 0, 0); // Customize rotation as needed
            transform.eulerAngles = closeRotation;
        }
    }
}