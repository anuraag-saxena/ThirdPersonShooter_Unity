using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PathFinder))]
[RequireComponent(typeof(EnemyPlayer))]
public class EnemyAnimation : MonoBehaviour
{
    [SerializeField] Animator animator;

    Vector3 lastposition;
    PathFinder pathFinder;
    EnemyPlayer enemyPlayer;

    void Awake() {
        pathFinder = GetComponent<PathFinder>();
        enemyPlayer = GetComponent<EnemyPlayer>();
    }

    void Update() {
        float velocity = ((transform.position - lastposition).magnitude) / Time.deltaTime;
        lastposition = transform.position;
        animator.SetBool("IsWalking", enemyPlayer.EnemyState.CurrentMode == EnemyState.EMode.AWARE);
        animator.SetFloat("Vertical", velocity/pathFinder.Agent.speed);
    }
}
