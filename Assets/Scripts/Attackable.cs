using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Attackable : MonoBehaviour {
  public float hp;
  public bool wasAttacked = false;
  public bool enemy = false;

  void Update () {
    wasAttacked = false;
  }

  public void GetAttacked (float damage) {
    if (wasAttacked) return;
    wasAttacked = true;
    hp -= damage;
  }
}
