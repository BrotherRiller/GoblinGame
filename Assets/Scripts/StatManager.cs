using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    public int HP { get; private set; } = 0;

    [SerializeField] int hp;

    private void Start()
    {
        HP = hp;
    }

    private void Update()
    {
        if(HP <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void ReduceHP(int attack)
    {
        HP -= attack;
        Debug.Log(HP);
    }
}
