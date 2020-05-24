using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyAttack : MonoBehaviour {
  public Collider c;
  public float power;
  public float time = 0.5f;
  public float cooldown = 0.5f;
  public EnemyAnimations anims;

  void Update () {
    if (cooldown < 0) {
      Attack();
      cooldown = time;
    }

    cooldown -= Time.deltaTime;
  }

  public void Attack () {
    StartCoroutine(_Attack());
  }

  void OnTriggerEnter (Collider c) {
    Attackable attackable = c.GetComponentInParent<Attackable>();
    if (attackable && !attackable.enemy) {
      attackable.GetAttacked(power);
      anims.animator.SetTrigger("attack");
    }
  }

  IEnumerator _Attack () {
    yield return null;
    c.enabled = true;
    yield return null;
    c.enabled = false;
  }
}
