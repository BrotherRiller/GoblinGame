using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(OrlagAnimationController))]
public class Combatant : MonoBehaviour
{

    [SerializeField] Transform deliverResourceLocation;
    [SerializeField] Transform harvestResourceLocation;
    OrlagAnimationController anim;

    public enum Job
    {
        fightWarriors,
        fightEnemies
    }

    public enum CombatantState
    {
        idle,
        searchOpponent,
        moving,
        fighting
    }

    [SerializeField] CombatantState currentState;
    [SerializeField] Job jobToDo;

    private NavMeshAgent agent;
    private StatManager enemyHP;

    public void Start()
    {
        anim = GetComponent<OrlagAnimationController>();
        agent = this.GetComponent<NavMeshAgent>();
        currentState = CombatantState.searchOpponent;
        enemyHP = GetComponent<StatManager>();

        string tagToSearchFor;

        switch (jobToDo)
        {
            case Job.fightWarriors:
                tagToSearchFor = "WarriorOrlag";
                break;

            case Job.fightEnemies:
                tagToSearchFor = "EnemyOrlag";
                break;

            default:
                tagToSearchFor = "WarriorOrlag";
                break;
        }

        deliverResourceLocation = GameObject.FindWithTag(tagToSearchFor).transform;
    }


    public void Update()
    {
        if (harvestResourceLocation == null)
        {
            currentState = CombatantState.searchOpponent;

        }

        switch (currentState)
        {
            case CombatantState.idle:
                anim.Deliver();
                break;

            case CombatantState.searchOpponent:
                harvestResourceLocation = GetNextResourceNode();
                agent.SetDestination(harvestResourceLocation.position);
                currentState = CombatantState.moving;
                break;

            case CombatantState.moving:
                if (Vector3.Distance(this.transform.position, deliverResourceLocation.position) <= agent.stoppingDistance)
                {
                    anim.Walk();
                }
                else
                {
                    currentState = CombatantState.idle;
                }
                //if (Vector3.Distance(this.transform.position, deliverResourceLocation.position) <= agent.stoppingDistance)
                //{
                //    agent = fi
                //    this.gameObject.transform.LookAt(harvestResourceLocation.transform);
                //    
                //    this.gameObject.transform.Translate(Vector3.forward * Time.deltaTime);
                //}

                if (Vector3.Distance(this.transform.position, harvestResourceLocation.position) <= agent.stoppingDistance + harvestResourceLocation.GetComponent<SphereCollider>().radius)
                {
                    anim.Swing();
                    StartCoroutine(WaitForHarvestFinish(5f));

                }
                currentState = CombatantState.fighting;
                break;

            case CombatantState.fighting:
                anim.Swing();
                this.gameObject.transform.LookAt(harvestResourceLocation.transform);

                this.gameObject.transform.Translate(Vector3.forward * Time.deltaTime);
                break;
            //case WorkerState.getResource:
            //    harvestResourceLocation = GetNextResourceNode();
            //    agent.SetDestination(harvestResourceLocation.position);
            //    currentState = WorkerState.moveToResource;
            //
            //    break;
            //
            //case WorkerState.moveToResource:
            //    anim.Walk();
            //    if (Vector3.Distance(this.transform.position, harvestResourceLocation.position) <= agent.stoppingDistance + harvestResourceLocation.GetComponent<SphereCollider>().radius)
            //    {
            //        anim.Harvest();
            //        StartCoroutine(WaitForHarvestFinish(5f));
            //
            //    }
            //
            //    break;
            //
            //case WorkerState.deliverResource:
            //    agent.SetDestination(deliverResourceLocation.position);
            //    currentState = WorkerState.moveToBuilding;
            //    break;
            //
            //case WorkerState.harvesting:
            //    anim.Harvest();
            //    break;
            //
            //case WorkerState.moveToBuilding:
            //    anim.Walk();
            //    if (Vector3.Distance(this.transform.position, deliverResourceLocation.position) <= agent.stoppingDistance)
            //    {
            //
            //        ResourceManager manager = GameObject.Find("ResourceManager").GetComponent<ResourceManager>();
            //
            //
            //        manager.AddResource(jobToDo.ToString(), 5);
            //
            //        anim.Deliver();
            //        currentState = WorkerState.getResource;
            //    }
            //    break;
            //
            default:
                anim.Deliver();
                break;
        }
    }

    private IEnumerator WaitForHarvestFinish(float timeToWait)
    {
        currentState = CombatantState.fighting;

        yield return new WaitForSecondsRealtime(timeToWait);

        //currentState = CombatantState.deliverResource;
    }



    private Transform GetNextResourceNode()
    {
        string tagToSearchFor;

        switch (jobToDo)
        {
            case Job.fightWarriors:
                tagToSearchFor = "WarriorOrlag";
                break;

            case Job.fightEnemies:
                tagToSearchFor = "EnemyOrlag";
                break;

            default:
                tagToSearchFor = "WarriorOrlag";
                break;
        }


        GameObject[] targetLocations = GameObject.FindGameObjectsWithTag(tagToSearchFor);
        GameObject finalDestination;
        if (targetLocations.Length <= 0)
        {
            finalDestination = null;
            return finalDestination.transform;
        }
        else
        {
            finalDestination = targetLocations[0];
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

        

    }


    public Job GetJob()
    {
        return jobToDo;
    }

}
