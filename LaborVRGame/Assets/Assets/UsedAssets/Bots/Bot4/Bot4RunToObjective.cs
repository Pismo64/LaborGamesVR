using BehaviorDesigner.Runtime.Tasks.Movement;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;
using UnityEngine.AI;

public class Bot4RunToObjective : NavMeshMovement
{
    [SerializeField]
    NavMeshAgent bot4;

    [SerializeField]
    Transform basePivot;

    private GameObject[] fences;
    private GameObject closestFence;
    private float oldDistance = 1000;

    public override void OnStart()
    {
        fences = GameObject.FindGameObjectsWithTag("Fence");

        foreach (GameObject go in fences)
        {
            float dist = Vector3.Distance(bot4.transform.position, go.transform.position);
            if (dist < oldDistance)
            {
                closestFence = go;
                oldDistance = dist;
            }
        }
    }
    public override TaskStatus OnUpdate()
    {

        bot4.SetDestination(closestFence.transform.position);
        float distance = Vector3.Distance(bot4.transform.position, closestFence.transform.position);
        if (distance < 3.5)
        {
            basePivot = GameObject.FindGameObjectWithTag("BasePivot").transform;
            bot4.transform.LookAt(basePivot.position);
            return TaskStatus.Success;
        }

        return TaskStatus.Running;
    }
}