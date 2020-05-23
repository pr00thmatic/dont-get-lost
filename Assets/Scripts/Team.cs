using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Team : MonoBehaviour {
  public bool isSelected;
  public Unit head;
  public float speed = 10;

  void Update () {
    if (isSelected) {
      head.transform.position += (Vector3.right * Input.GetAxis("Horizontal") +
                                  Vector3.up * Input.GetAxis("Vertical")) *
        speed * Time.deltaTime;
    }
  }
}
