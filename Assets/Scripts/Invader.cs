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
        numeros magicos castillo (-24,1,25)
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

    [SerializeField]
    float intervalTime;
    float startTime;
    [SerializeField]
    float currentTime;
    int cmins;
    float csecs;

    [SerializeField]
    int rNum;
    [SerializeField]
    int compare;

    //bools
    bool goInvade;
    public bool isAlive;

    [SerializeField]
    Vector2 posLast;
    [SerializeField]
    Vector2 posCurrent;

    //coordenadas castillo
    const float xPosCastle = -24;
    const float yPosCastle = 21;

    System.Random rnd;

    private void Start()
    {
        rnd = new System.Random(seed);
        startTime = Time.time;
        intervalTime = decideTime + startTime;
        //currentTime = Time.time - startTime;
        isAlive = true;
        Timer();
        posLast = new Vector2(posCurrent.x, posCurrent.y);
        posCurrent = new Vector2(transform.position.x, transform.position.z);
        //Face to the right
        //this.transform.rotation = Quaternion.Euler(90, 180, 0);
    }

    private void Update()
    {
        Timer();
        DoInvade();
        RotationOverwrite();


        //debug
        //Face to the right
        //this.transform.rotation = Quaternion.Euler(270, 180, 0);
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
            rNum = rnd.Next(0, 101);
            compare = (int)(probabilityOfInvation * 100f);
            //si las ganas de atacar (10% de prob ataque)son mayores o iguales al random (9) se da el ataque
            // si tengo 10 porciento de ataque y el numero random cae en ese 10% ataque
            //(if ((int)(probabilityOfInvation * 100) >= rnd.Next(0, 101))
            //mejor a prueba de fallos
            if (compare >= rNum && !goInvade)
            {
                //Attack!!!
                goInvade = true;
                GoingToCastle();
            }

            else if (compare <= rNum)
            {
                float tmp = probabilityOfInvation * angerMultiplier;
                probabilityOfInvation += tmp;
                intervalTime = currentTime + decideTime;
                goInvade = false;
            }
        }
    }

    void GoingToCastle()
    {
        // agent.SetDestination(Vector3.zero);

        agent.SetDestination(new Vector3(xPosCastle, 1, yPosCastle));
        goInvade = true;
    }

    void RotationOverwrite()
    {
        posLast.x = posCurrent.x;
        posLast.y = posCurrent.y;
        //posCurrent.x = transform.position.x;
        // posCurrent.y = transform.position.z;
        posCurrent = new Vector2(transform.position.x, transform.position.z);

        if (posCurrent.x < xPosCastle)
        {
            this.transform.rotation = Quaternion.Euler(90, 0, 0);  // reverse to 
        }
        else if (posCurrent.x > xPosCastle)
        {
            this.transform.rotation = Quaternion.Euler(270, 180, 0);
        }
        //necesita que los float sean solo con un decimal para no blinquear mucho
        //if (posCurrent.x > posLast.x)
        //{
        //    this.transform.rotation = Quaternion.Euler(0, 0, 0);
        //}
        //else if (posCurrent.x < posLast.x)
        //{
        //    this.transform.rotation = Quaternion.Euler(0, 180, 0);
        //}
        //else if (posCurrent.y > posLast.y)
        //{
        //   this.transform.rotation = Quaternion.Euler(0, 0, 90);
        //}
        //else if (posCurrent.y < posLast.y)
        //{
        //    this.transform.rotation = Quaternion.Euler(0, 0, 180);
        //}
    }
}
