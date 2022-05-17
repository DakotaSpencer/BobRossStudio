using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CreateRotation : MonoBehaviour
{
    private XRDirectInteractor interactor = null;
    public bool IsGrabbing;
    // Start is called before the first frame update
    void Start()
    {
        interactor = GetComponent<XRDirectInteractor>();
        IsGrabbing = false;

    }


    private void OnEnable()
    {

        interactor.onSelectEntered.AddListener(TakeInput);
        interactor.onSelectExited.AddListener(StopInput);

    }

    private void OnDisable()
    {

        interactor.onSelectEntered.RemoveListener(TakeInput);
        interactor.onSelectExited.RemoveListener(StopInput);

    }

    private void TakeInput(XRBaseInteractable interactable)
    {

        IsGrabbing = true;
        Debug.Log("is grabbing");

    }

    private void StopInput(XRBaseInteractable interactable)
    {

        IsGrabbing = false;
        Debug.Log("is releasing");

    }
}
