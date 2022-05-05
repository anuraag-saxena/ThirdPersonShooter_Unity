using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public class PathFinder : MonoBehaviour
{
    [HideInInspector] public UnityEngine.AI.NavMeshAgent Agent;
    [SerializeField] float distanceReamainingThreshold;

    bool m_desdestinationReached;
    bool destinationReached {
        get { 
            return m_desdestinationReached; 
        }
        set { 
            m_desdestinationReached = value;
            if (m_desdestinationReached) {
                if (OnDestinationReached != null) { 
                    OnDestinationReached();
                }
            }
        }
    }

    public event System.Action OnDestinationReached;

    void Awake() {
        Agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    public void SetTarget(Vector3 target) {
        destinationReached = false;
        Agent.SetDestination(target);
    }

    void Update() {
        if (destinationReached || !Agent.hasPath)
            return;

        if (Agent.remainingDistance < distanceReamainingThreshold) { 
            destinationReached = true;
        }
    }

}
