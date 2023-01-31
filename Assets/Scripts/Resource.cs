using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Rigidbody))]
public class Resource : MonoBehaviour
{

    [SerializeField] float turnSpeed;
    [SerializeField] AudioClip dropSound;
    AudioSource source;


    private void Awake()
    {
        source = GetComponent<AudioSource>();
        SpawSound();

        this.GetComponent<Rigidbody>().isKinematic = true;
    }
  

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime, Space.World);
    }

    public void SpawSound()
    {
        source.clip = dropSound;
        source.Play();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Terrain"))
        {

           
                this.transform.GetComponent<Rigidbody>().isKinematic = true;
            
            
        }
    }
}
