using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapPieceInstance : MonoBehaviour {
  public bool visible = false;
  public float probability = 0.3f;
  bool _last = false;

  void Update () {
    if (_last != visible && visible == false) {
      if (Random.Range(0,1f) < probability) {
        GetComponentInParent<MapPiece>().Shuffle();
      }
    }

    _last = visible;
  }

  void OnTriggerStay (Collider c) {
    if (c.GetComponent<Defoger>()) {
      visible = true;
    }
  }

  void OnTriggerExit(Collider c) {
    if (c.GetComponent<Defoger>()) {
      visible = false;
    }
  }

}
