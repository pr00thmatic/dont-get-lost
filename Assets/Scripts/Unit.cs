using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class Unit : MonoBehaviour {
  public bool isSelected;
  public Animator selection;
  public Unit target;
  public NavMeshAgent agent;
  public float cooldown = 0.1f;

  void OnEnable () {
    agent.updateRotation = false;
    agent.speed = GetComponentInParent<Team>().speed * 1.1f;
    // agent.acceleration = agent.speed * 8;
  }

  void Update () {
    selection.SetBool("is selected", isSelected);
    cooldown -= Time.deltaTime;
    if (target && cooldown <= 0) {
      agent.SetDestination(target.transform.position);
      cooldown = Random.Range(0.01f, 0.1f);
    }
  }

  public void Follow (Unit target) {
    this.target = target;
  }
}
