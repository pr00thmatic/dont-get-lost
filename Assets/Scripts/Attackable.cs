using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Attackable : MonoBehaviour {
  public float hp;

  public void GetAttacked (float damage) {
    hp -= damage;
  }
}
