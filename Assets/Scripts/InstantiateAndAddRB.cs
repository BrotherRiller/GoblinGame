using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateAndAddRB : MonoBehaviour
{
    [SerializeField] GameObject rock;
    [SerializeField] AudioClip sound;

    public void OnTriggerStay(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            var spawnedObject = Instantiate(rock, transform.position + Vector3.up * 10, Quaternion.identity);

            spawnedObject.AddComponent<Rigidbody>();
            spawnedObject.AddComponent<AudioSource>();

            spawnedObject.GetComponent<AudioSource>().clip = sound;
            spawnedObject.GetComponent<AudioSource>().Play();
        }
    }

}
