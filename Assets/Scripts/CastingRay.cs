using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastingRay : MonoBehaviour
{
    [SerializeField] float power;
    [SerializeField] float radius;
    [SerializeField] float upMod;

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;

        if ( Physics.Raycast(transform.position, transform.forward, out hit) )
        {
            
            Debug.Log(hit.transform.name);

            //Hier Ihr Code

            if (hit.rigidbody != null)
            {
                //hit.transform.GetComponent<Rigidbody>().AddForce(transform.forward * 10, ForceMode.Impulse);
                hit.transform.GetComponent<Rigidbody>().AddExplosionForce(power, hit.transform.position, radius, upMod);

                Collider[] colliders = Physics.OverlapSphere(hit.transform.position, radius);
                foreach (Collider inRangeObjects in colliders)
                {
                    Rigidbody rb = inRangeObjects.GetComponent<Rigidbody>();

                    if (rb != null)
                        rb.AddExplosionForce(power, hit.transform.position, radius, 3.0F);
                }
            }

        }

        Debug.DrawRay(transform.position, transform.forward * 100, Color.cyan);

        
    }

    //Wenn der Raycast ein Objekt trifft, dass einen Rigidbody hat, soll dieses Weggestoﬂen werden
    //hit.GetComponent<Rigidbody>().AddForce(new Vector3(Richtung * Kraft die Sie w‰hlen), ForceMode.Impulse);
}
