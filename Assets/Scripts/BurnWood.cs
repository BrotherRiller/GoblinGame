using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class BurnWood : MonoBehaviour
{
    private void Awake()
    {
        transform.GetComponent<SphereCollider>().radius = 1.5f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactable") && other.name.Contains("WoodResource"))
        {

            Destroy(other.gameObject);
            transform.GetComponent<SphereCollider>().radius += 0.1f;

            var player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<Player>().Heal(0.01f * 60f);
        }
    }


}
