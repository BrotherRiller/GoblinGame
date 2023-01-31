using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] float offset;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.SphereCast(transform.position, 0.25f, transform.forward, out hit))
        {

            if (hit.transform.CompareTag("Interactable"))
            {
                //HalteLogik
                if (Input.GetKey(KeyCode.F))
                {
                    hit.transform.position = transform.position + (transform.forward * offset);
                }
                else
                {
                    hit.transform.GetComponent<Rigidbody>().isKinematic = false;
                }

            }

        }


    }
}
