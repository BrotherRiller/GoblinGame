using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Combatant))]
public class Weapons : MonoBehaviour
{
    [SerializeField] GameObject bat;
    [SerializeField] GameObject weaponSlot;

    Vector3 axeRotOffset = new Vector3(0, 90f, 20);
    Vector3 axePosOffset = new Vector3(0, 0, 0);

    public void Start()
    {


        GameObject weapon;

       switch (GetComponent<Combatant>().GetJob())
        {
        
            case Combatant.Job.fightEnemies:
                weapon = Instantiate(bat, weaponSlot.transform.position + axePosOffset, Quaternion.Euler(axeRotOffset));
                    weapon.transform.SetParent(weaponSlot.transform);
                    break;

            case Combatant.Job.fightWarriors:
                weapon = Instantiate(bat, weaponSlot.transform.position + axePosOffset, Quaternion.identity);
                weapon.transform.SetParent(weaponSlot.transform);
                weapon.transform.localRotation = Quaternion.Euler(axeRotOffset);
                break;
        }
    }

}
