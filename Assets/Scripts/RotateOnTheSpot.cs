using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOnTheSpot : MonoBehaviour
{

    [SerializeField] float turnSpeed;
    [SerializeField] float fleeSpeed;
    float baseTurnSpeed;
    float distanceToPlayer;
    bool isTurning = true;
    // Start is called before the first frame update
    void Start()
    {
        baseTurnSpeed = turnSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        #region Turn on the spot
        if (isTurning)
        {
            transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime, Space.World);

            distanceToPlayer = Vector3.Distance(GameObject.Find("Player").transform.position, gameObject.transform.position);

            if (distanceToPlayer <= 8f)
            {
                turnSpeed = baseTurnSpeed * (8 - distanceToPlayer);
            }
            else
            {
                turnSpeed = baseTurnSpeed;
            }
        }
        #endregion

       

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTurning = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTurning = true;
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 direction = gameObject.transform.position - other.transform.position; //Richtung -> Weg vom Spieler
            direction.y = 0; //soll schlieﬂlich nicht in den Boden sinken

            transform.Translate (direction * fleeSpeed * Time.deltaTime, Space.World);
        }
    }

}
