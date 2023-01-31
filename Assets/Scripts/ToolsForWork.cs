using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Worker))]
public class ToolsForWork : MonoBehaviour
{
    [SerializeField] GameObject woodTool;
    [SerializeField] GameObject stoneTool;
    [SerializeField] GameObject foodTool;
    [SerializeField] GameObject defaultTool;
    [SerializeField] GameObject weaponSlot;

    Vector3 axeRotOffset = new Vector3(-90, 90f,0);
    Vector3 axePosOffset = new Vector3(0, 0, 0);
    
    public void Start()
    {
        
    
        GameObject tool;

        switch (GetComponent<Worker>().GetJob())
        {
            
            case Worker.Job.wood:
                tool = Instantiate(woodTool, weaponSlot.transform.position,Quaternion.identity);
                tool.transform.SetParent(weaponSlot.transform);
                tool.transform.localRotation = Quaternion.Euler(axeRotOffset);
                break;

            case Worker.Job.stone:
                tool = Instantiate(stoneTool, weaponSlot.transform.position + axePosOffset, Quaternion.identity);
                tool.transform.SetParent(weaponSlot.transform);
                tool.transform.localRotation = Quaternion.Euler(axeRotOffset);

                break;

            case Worker.Job.food:
                tool = Instantiate(foodTool, weaponSlot.transform.position + axePosOffset, Quaternion.identity);
                tool.transform.SetParent(weaponSlot.transform);
                tool.transform.localRotation = Quaternion.Euler(axeRotOffset);
                break;

            case Worker.Job.wealth:
                tool = Instantiate(defaultTool, weaponSlot.transform.position + axePosOffset,  Quaternion.Euler(axeRotOffset));
                tool.transform.SetParent(weaponSlot.transform);
                break;
        }

    }

}
