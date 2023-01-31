using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choppable : MonoBehaviour
{
    [Header("Wood Yield")]
    [Tooltip("How Many Hits the Tree can take")]
    [SerializeField] [Range(1, 10)] int hitPoints = 3;
    [SerializeField] GameObject woodPrefab;
    [SerializeField] AudioClip chopSound;
    private int woodYield;
    private float chopCounter = 0;

    public void Start()
    {
        woodYield = hitPoints;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player")) //Muss später prüfen ob es Spieler oder ein Arbeiter ist
        {
            if (Input.GetMouseButton(0))
            {
                chopCounter += 0.01f;

                if (chopCounter >= 1f)
                {

                    var audioSourceChopper = other.transform.GetComponent<AudioSource>();
                    audioSourceChopper.clip = chopSound;
                    audioSourceChopper.Play();

                    chopCounter = 0;

                    ReduceAndCheckHP();
                }

            }


        }
    }

    private void ReduceAndCheckHP()
    {
        hitPoints--;
        if (hitPoints <= 0)
        {
            SpawnWood();

            Destroy(gameObject);
        }

    }


    private void SpawnWood()
    {
        for (int i =0; i < woodYield; i++)
        {
            float x = Random.Range(0, 4);
            float y = Random.Range(0.5f, 1);
            float z = Random.Range(0, 4);

            Instantiate(woodPrefab, gameObject.transform.position + new Vector3(x, y, z), Quaternion.Euler(0, 7, -45));

        }
        
    }
}
