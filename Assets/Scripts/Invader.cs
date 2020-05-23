using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class Invader : MonoBehaviour {
  /** un timer que al agotarse, el bicho
      decida si va a invadir de acuerdo a su probabiliadd de
      invación.
      Independientemente de si invade o no, su probabilidad
      debería crecer. Multiplicarse por 1.6666666666~.
      Si decide invadir, su timer se detiene.
      una variable: "sigue dispuesto a invadir?"
      Cuando decide invadir, su agente debería ir al castillo
      mediante agent.SetDestination(Vector3.zero);
  **/

  [Range(0,1)]
  public float probabilityOfInvation;
  public NavMeshAgent agent;
}
