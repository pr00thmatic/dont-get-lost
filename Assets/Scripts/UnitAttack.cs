using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitAttack : MonoBehaviour {
  public float power;
  public Collider c;

  public void Attack () {
    StartCoroutine(_Attack());
  }

  void OnTriggerEnter (Collider c) {
    Attackable attackable = c.GetComponentInParent<Attackable>();
    if (attackable) {
      GetComponentInParent<TeamAttack>().RetroactiveAttack(attackable);
    }
  }

  IEnumerator _Attack () {
    yield return null;
    c.enabled = true;
    yield return null;
    c.enabled = false;
  }
}
