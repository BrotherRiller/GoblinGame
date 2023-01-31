using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    UILevel UI;
    [SerializeField] float updateHealthTime;
    [SerializeField] float decreaseHealth;
    float health = 1f;

    // Start is called before the first frame update
    void Start()
    {
        UI = FindObjectOfType<UILevel>();
        InvokeRepeating("SetHealth", updateHealthTime, updateHealthTime);

    }

  
    void SetHealth()
    {
        health -= decreaseHealth;
        UI.SetHealthbar(health);
    }

    public void Hurt( float hurtDegree)
    {
        health -= hurtDegree;
        health = Mathf.Clamp(health, 0, 1);
        UI.SetHealthbar(health, true);
    }

    public void Heal( float healDegree)
    {
        health += healDegree;
        health = Mathf.Clamp(health, 0, 1);
        UI.SetHealthbar(health);
    }




}
