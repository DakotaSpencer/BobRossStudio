using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class MoveAndFreeze : XRGrabInteractable
{

    [SerializeField] private Rigidbody m_body;
    [SerializeField] private GameObject objectHeld;
    bool keypressCheckF;
    bool keypressCheckC;


    // Start is called before the first frame update
    void Start()
    {
        //m_body = GameObject.Find(m_body.name).GetComponent<Rigidbody>();
        m_body.constraints = RigidbodyConstraints.None;
    }

    // Update is called once per frame
    void Update()
    {
        //keypressCheckF = Input.GetKeyDown(KeyCode.F);
        keypressCheckC = Input.GetKeyDown(KeyCode.C);

        if (Input.GetButtonDown("VR_PrimaryButton_LeftHand") && transform.GetComponent<XRGrabInteractable>())
        {
            m_body.constraints = RigidbodyConstraints.FreezeAll;
        }
    }
}
