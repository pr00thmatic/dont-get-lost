using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class Unit : MonoBehaviour {
  public bool isSelected;
  public Animator selection;
  public Unit target;
  public NavMeshAgent agent;

  void OnEnable () {
    agent.updateRotation = false;
    agent.speed = GetComponentInParent<Team>().speed;
    agent.acceleration = agent.speed * 6;
  }

  void Update () {
    selection.SetBool("is selected", isSelected);
    if (target) {
      agent.SetDestination(target.transform.position);
    }
  }

  public void Follow (Unit target) {
    this.target = target;
  }
}
