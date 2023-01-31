using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimation : MonoBehaviour
{
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            anim.SetTrigger("Harvest");
        }
        if (Input.GetMouseButton(2))
        {
            anim.SetTrigger("Walk");
        }

    

        //Hausaufgabe:
        /*
        Trennen Sie Logik von Animation: Ein Skript soll Methoden enthalten, die auf einen gewissen
        Trigger setzen.

        Bauen Sie den Worker Platzhalter um. Der Orlag soll nun der Worker sein.
        Wenn der Orlag sich bewegt soll Walk getriggered werden. Wenn er abbaut, soll eine andere Animation getriggered werden. (Bonus: Sogar beim Abgeben von Materialien soll eine weitere Animation getriggered werden (Animationen werden vom Dozenten via E-Mail geschickt))


        */
    }
}
