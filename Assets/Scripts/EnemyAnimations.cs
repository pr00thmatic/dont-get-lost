using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class EnemyAnimations : MonoBehaviour {
  public Animator animator;
  public NavMeshAgent agent;

  void Update () {
    animator.SetFloat("speed", agent.velocity.magnitude / agent.speed);
  }
}
