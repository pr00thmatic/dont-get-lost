using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TeamAttack : MonoBehaviour {
  float _power = 0;

  void Update () {
    if (Input.GetKeyDown(KeyCode.C) &&
        GetComponentInParent<Team>().isSelected) {
      Attack();
    }
  }

  public void Attack () {
    _power = 0;
    foreach (UnitAttack unit in GetComponentsInChildren<UnitAttack>()) {
      _power += unit.power;
      unit.Attack();
    }
  }

  public void RetroactiveAttack (Attackable attackable) {
    attackable.GetAttacked(_power);
  }
}
