using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceBuilding : MonoBehaviour
{
    ResourceManager res;
    [SerializeField] string ResourceName;

    // Start is called before the first frame update
    void Start()
    {
        res = GameObject.Find("ResourceManager").GetComponent<ResourceManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (res == null)
        {
            GameObject.Find("ResourceManager").GetComponent<ResourceManager>();
        }  
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Interactable") && other.transform.name.Contains(ResourceName))
        {
            if (res != null)
            {
                res.AddResource(ResourceName.ToLower(), 1);
                Destroy(other.gameObject);
            }
        }
    }
}
