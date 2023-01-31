using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    [SerializeField] int AttackDamage;
    [SerializeField] GameObject target;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(target.tag);
        if (other.transform.CompareTag(target.tag))
        {
            other.gameObject.GetComponent<StatManager>().ReduceHP(AttackDamage);
        }
    }
}
