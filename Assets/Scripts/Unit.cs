using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Unit : MonoBehaviour {
  public bool isSelected;
  public Animator selection;

  void Update () {
    selection.SetBool("is selected", isSelected);
  }
}
