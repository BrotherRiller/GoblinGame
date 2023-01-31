using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignBuy : MonoBehaviour
{
    [SerializeField] GameObject sawmill;
    [SerializeField] GameObject mason;
    [SerializeField] GameObject farmhouse;

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
            if (Input.GetKey(KeyCode.Alpha1))
            {
                if (res.Wood >= 20 && res.Stone >= 5)
                {
                    Instantiate(sawmill, transform.position, Quaternion.Euler(-90, 0, 90));
                    res.SubResource("wood", 20);
                    res.SubResource("stone", 5);
                    Destroy(this.gameObject);
                }
                else
                {
                    Debug.Log("Nicht genug Ressourcen!");
                }
            }
            if (Input.GetKey(KeyCode.Alpha2))
            {
                if (res.Wood >= 10 && res.Stone >= 20)
                {
                    Instantiate(mason, transform.position, Quaternion.identity);
                    res.SubResource("wood", 10);
                    res.SubResource("stone", 20);
                    Destroy(this.gameObject);
                }
                else
                {
                    Debug.Log("Nicht genug Ressourcen!");
                }
            }
            if (Input.GetKey(KeyCode.Alpha3))
            {
                if (res.Wood >= 10 && res.Stone >= 10)
                {
                    Instantiate(farmhouse, transform.position, Quaternion.identity);
                    res.SubResource("wood", 10);
                    res.SubResource("stone", 10);
                    Destroy(this.gameObject);
                }
                else
                {
                    Debug.Log("Nicht genug Ressourcen!");
                }
            }
        }
    }
}
