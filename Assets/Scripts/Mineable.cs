using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mineable : MonoBehaviour
{

    [Header("Wood Yield")]
    [Tooltip("How Many Hits the Tree can take")]
    [SerializeField] [Range(1, 10)] int hitPoints = 3;
    [SerializeField] GameObject rockPrefab;
    [SerializeField] AudioClip miningSound;
    private int rockYield;
    private float hitCounter = 0;

    public void Start()
    {
        rockYield = hitPoints;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player")) //Muss später prüfen ob es Spieler oder ein Arbeiter ist
        {
            if (Input.GetMouseButton(0))
            {
                hitCounter += 0.01f;

                if (hitCounter >= 1f)
                {

                    var audioSourceChopper = other.transform.GetComponent<AudioSource>();
                    audioSourceChopper.clip = miningSound;
                    audioSourceChopper.Play();

                    hitCounter = 0;

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
        for (int i = 0; i < rockYield; i++)
        {
            float x = Random.Range(0, 4);
            float y = Random.Range(0.5f, 1);
            float z = Random.Range(0, 4);

            Instantiate(rockPrefab, gameObject.transform.position + new Vector3(x, y, z), Quaternion.Euler(0, 7, -45));

        }

    }
}
