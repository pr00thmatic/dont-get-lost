using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Team : MonoBehaviour {
  public static event System.Action<Team> onSelected;

  public bool isSelected;
  public Unit head;
  public float speed = 10;

  void OnEnable () {
    onSelected += Unselect;
  }

  void Update () {
    if (isSelected) {
      head.transform.position += (Vector3.right * Input.GetAxis("Horizontal") +
                                  Vector3.up * Input.GetAxis("Vertical")) *
        speed * Time.deltaTime;
    }
  }

  void OnMouseDown () {
    Select();
  }

  public void Select () {
    isSelected = true;
    foreach (Unit u in GetComponentsInChildren<Unit>()) {
      u.isSelected = true;
    }

    if (onSelected != null) onSelected(this);
  }

  public void Unselect (Team nuSelection) { if (nuSelection != this) Unselect(); }

  public void Unselect () {
    isSelected = false;
    foreach (Unit u in GetComponentsInChildren<Unit>()) {
      u.isSelected = false;
    }
  }
}
