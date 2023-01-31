using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceOff : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 dir = collision.gameObject.transform.position - this.gameObject.transform.position;
            dir.Normalize();

            var charContrl = collision.transform.GetComponent<CharacterController>();

            charContrl.enabled = false;
            collision.transform.position = collision.transform.position + dir / 2;
            charContrl.enabled = true;

        }
    }

}
