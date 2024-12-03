using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class startGame : MonoBehaviour
{
	private bool hasBeenSelected = false;
    private XRBaseInteractable interactable;

    public void ChangeScene()
	{
		SceneManager.LoadScene("Main");
	}

	public void EndToMenu()
	{
        if (hasBeenSelected)
        {
            Debug.Log("Second select action performed!");
            FindObjectOfType<Timer>().RecordTime(); // Record the time before transitioning
			SceneManager.LoadScene("menuprincipal");
        }
	}


    void Awake()
    {
        interactable = GetComponent<XRBaseInteractable>();

        if (interactable != null)
        {
            // Add a listener to the SelectEntered event
            interactable.selectEntered.AddListener(OnFirstSelect);
        }
    }

    private void OnFirstSelect(SelectEnterEventArgs args)
    {
        if (!hasBeenSelected)
        {
            hasBeenSelected = true;
            
            // Run your script logic here
            Debug.Log("First select action performed!");
        }
    }
}
