using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class MoveAndFreeze : MonoBehaviour
{

    [SerializeField] public Rigidbody m_body;
    bool keypressCheckF;
    bool keypressCheckC;


    // Start is called before the first frame update
    void Start()
    {
        m_body = transform.GetComponentInParent<Rigidbody>();
        m_body.constraints = RigidbodyConstraints.None;
    }

    // Update is called once per frame
    void Update()
    {
        //keypressCheckF = Input.GetKeyDown(KeyCode.F);
        keypressCheckC = Input.GetKeyDown(KeyCode.C);
        if (Input.GetKeyDown(KeyCode.F)) 
        {

            m_body.constraints = RigidbodyConstraints.FreezeAll;
            return;
        }
    }
}
