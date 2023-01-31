using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(OrlagAnimationController))]
public class Worker : MonoBehaviour
{

    [SerializeField] Transform deliverResourceLocation;
    [SerializeField] Transform harvestResourceLocation;
    OrlagAnimationController anim;

    public enum Job
    {
        wood,
        stone,
        food,
        wealth
    }

    public enum WorkerState
    {
        getResource,
        deliverResource,
        moveToResource,
        moveToBuilding,
        harvesting
    }

    [SerializeField] WorkerState currentState;
    [SerializeField] Job jobToDo;

    private NavMeshAgent agent;

    public void Start()
    {
        anim = GetComponent<OrlagAnimationController>();
        agent = this.GetComponent<NavMeshAgent>();
        currentState = WorkerState.getResource;

        string tagToSearchFor;

        switch (jobToDo)
        {
            case Job.wood:
                tagToSearchFor = "SawmillBuilding";
                break;

            case Job.stone:
                tagToSearchFor = "MasonBuilding";
                break;

            case Job.food:
                tagToSearchFor = "FoodBuilding";
                break;

            case Job.wealth:
                tagToSearchFor = "WealthBuilding";
                break;

            default:
                tagToSearchFor = "SawmillBuilding";
                break;
        }

        deliverResourceLocation = GameObject.FindWithTag(tagToSearchFor).transform;
    }


    public void Update()
    {
        if (harvestResourceLocation == null)
        {
            currentState = WorkerState.getResource;
            
        }

        switch (currentState)
        {
            case WorkerState.getResource:
                harvestResourceLocation = GetNextResourceNode();
                agent.SetDestination(harvestResourceLocation.position);
                currentState = WorkerState.moveToResource;
               
                break;

            case WorkerState.moveToResource:
                anim.Walk();
                if (Vector3.Distance(this.transform.position, harvestResourceLocation.position) <= agent.stoppingDistance + harvestResourceLocation.GetComponent<SphereCollider>().radius)
                {
                    anim.Swing();
                    StartCoroutine(WaitForHarvestFinish(5f));
                    
                }
              
                break;

            case WorkerState.deliverResource:
                agent.SetDestination(deliverResourceLocation.position);
                currentState = WorkerState.moveToBuilding;                
                break;


            case WorkerState.harvesting:
                anim.Swing();
                break;

            case WorkerState.moveToBuilding:
                anim.Walk();
                if (Vector3.Distance(this.transform.position, deliverResourceLocation.position) <= agent.stoppingDistance )
                {
                    
                    ResourceManager manager = GameObject.Find("ResourceManager").GetComponent<ResourceManager>();
                   
                    
                    manager.AddResource(jobToDo.ToString(),5);

                    anim.Deliver();
                    currentState = WorkerState.getResource;
                }
                break;

            default:
                break;
        }
    }

    private IEnumerator WaitForHarvestFinish(float timeToWait)
    {
        currentState = WorkerState.harvesting;

        yield return new WaitForSecondsRealtime(timeToWait);

        currentState = WorkerState.deliverResource;
    }



    private Transform GetNextResourceNode()
    {
        string tagToSearchFor;
        
        switch (jobToDo)
        {
            case Job.wood:
                tagToSearchFor = "WoodResource";
                break;

            case Job.stone:
                tagToSearchFor = "StoneResource";
                break;

            case Job.food:
                tagToSearchFor = "FoodResource";
                break;

            case Job.wealth:
                tagToSearchFor = "WealthResource";
                break;

            default:
                tagToSearchFor = "WoodResource";
                break;
        }


        GameObject[] targetLocations = GameObject.FindGameObjectsWithTag( tagToSearchFor );
        GameObject finalDestination = targetLocations[0];

        for (int i = 0; i < targetLocations.Length; i++)
        {
            //Prüft ob die aktuelle Position des GOs im Array näher am Worker liegt, als die aktuell gespeicherte
            //Falls ja, wird die gespeicherte Position ausgetauscht
            if (Vector3.Distance(this.transform.position, targetLocations[i].transform.position) <
                Vector3.Distance(this.transform.position, finalDestination.transform.position))
            {
                finalDestination = targetLocations[i];
            }


        }
        return finalDestination.transform;

    }


    public Job GetJob()
    {
        return jobToDo;
    }

}
