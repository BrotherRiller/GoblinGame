using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILevel : MonoBehaviour
{

    [SerializeField] Image healthbar;
    [SerializeField] Gradient healtbarColors;
    [SerializeField] GameObject redscreen;

    // Start is called before the first frame update
    void Start()
    {
        SetHealthbar(1);
    }

 

    public void SetHealthbar( float health, bool showRedscreen = false )
    {
        
        if (showRedscreen)
        {
            redscreen.SetActive(true);
            Invoke("ClearRedscreen", 0.4f);
        }
                  
        healthbar.fillAmount = health;
        healthbar.color = healtbarColors.Evaluate(health);
    }

    void ClearRedscreen()
    {
         CancelInvoke();
         redscreen.SetActive(false);
    }
}
