using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerBuy : MonoBehaviour
{
    [SerializeField] GameObject worker;

    ResourceManager res;

    // Start is called before the first frame update
    void Start()
    {
        res = GameObject.Find("ResourceManager").GetComponent<ResourceManager>();
    }

    void FixedUpdate()
    {
        if (res == null)
        {
            GameObject.Find("ResourceManager").GetComponent<ResourceManager>();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetMouseButton(0))
            {
                StartCoroutine(WaitForMouseClick(1));
                
            }
        }
    }

    private IEnumerator WaitForMouseClick(float timeToWait)
    {
        if (res.Wood >= 5)
        {
            Instantiate(worker, transform.position, Quaternion.identity);
            res.SubResource("wood", 5);
        }
        else
        {
            Debug.Log("Nicht genug Ressourcen!");
        }

        yield return new WaitForSecondsRealtime(timeToWait);  
    }
}
