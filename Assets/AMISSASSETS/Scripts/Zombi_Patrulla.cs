using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class Zombi_Patrulla : MonoBehaviour
{
    public Transform[] points;
        private int destPoint = 0;
        private NavMeshAgent agent;
        public float baseSpeed =3.5f;


        void Start () 
        {
            agent = GetComponent<NavMeshAgent>();
            agent.speed= baseSpeed;
            agent.autoBraking = false;
            GotoNextPoint();
        }


        void GotoNextPoint() 
        {
            if (points.Length == 0) return;

            agent.destination = points[destPoint].position;
            destPoint = (destPoint + 1) % points.Length;
        }


        void Update () 
        {
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
                GotoNextPoint();
        }

        public void detenerAgente()
        {
            agent.speed =0;
        }
         public void reanudarAgente()
        {
            agent.speed =baseSpeed;
        }
    }