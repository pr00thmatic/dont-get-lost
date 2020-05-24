using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class Invader : MonoBehaviour
{
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
    //cada vez que el enemigo decide no atacar su rabia crece x 1.666 veces.
    const float angerMultiplier = 1.6666f;

    public NavMeshAgent agent;
    [Range(0, 1)]
    public float probabilityOfInvation;

    //timer
    [Range(1, 120)]
    public float decideTime;

    public int seed;

    float intervalTime;
    float startTime;
    float currentTime;
    int cmins;
    float csecs;

    //bools
    bool goInvade;
    public bool isAlive;

    System.Random rnd;

    private void Start()
    {
        rnd = new System.Random(seed);
        startTime = Time.time;
        intervalTime = decideTime + startTime;
        //currentTime = Time.time - startTime;
        Timer();
    }

    private void Update()
    {
        Timer();
    }

    private void DisplayTime()
    {
        string m = cmins.ToString();
        string s = csecs.ToString();
    }

    private void Timer()
    {

        currentTime = Time.time - startTime;
        cmins = (int)currentTime / 60;
        csecs = currentTime % 60;

    }

    void DoInvade()
    {
        //si el tiempo es > al intervalo dado
        if (currentTime >= intervalTime)
        {

            //tengo ganas de atacar?
            // numero del 1 al 100
            int rNum = rnd.Next(0, 101);
            int compare = (int)(probabilityOfInvation * 100f);
            //si las ganas de atacar (10% de prob ataque)son mayores o iguales al random (9) se da el ataque
            // si tengo 10 porciento de ataque y el numero random cae en ese 10% ataque
            //(if ((int)(probabilityOfInvation * 100) >= rnd.Next(0, 101))
            //mejor a prueba de fallos
            if (compare >= rNum)
            {
                //Attack!!!
                goInvade = true;
                GoingToCastle();
            }

            else
            {
                probabilityOfInvation *= angerMultiplier;
                goInvade = false;
            }
        }
    }

    void GoingToCastle()
    {
        agent.SetDestination(Vector3.zero);
    }
}
