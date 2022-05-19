using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class MoveAndFreeze : MonoBehaviour
{
    [SerializeField] private Rigidbody m_body;
    [SerializeField] private GameObject objectHeld;
    bool frozen = false;


    // Start is called before the first frame update
    void Start()
    {
        //interactor = GetComponent<XRDirectInteractor>();
        //m_body = GameObject.Find(m_body.name).GetComponent<Rigidbody>();
        m_body.constraints = RigidbodyConstraints.None;
    }

    // Update is called once per frame
    public void Freeze()
    {
        m_body.constraints = RigidbodyConstraints.FreezeAll;
        frozen = true;
    }

    public void Unfreeze()
    {
        m_body.constraints = RigidbodyConstraints.None;
        frozen = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            m_body.constraints = RigidbodyConstraints.None;
            frozen = false;
        }
    }
}
