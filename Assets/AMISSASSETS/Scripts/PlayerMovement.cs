using UnityEngine;
using UnityEngine.AI;


public class PlayerMovement : MonoBehaviour
{


GameObject StickGO;
RectTransform StickRT;

float velocidad = 5f;
float rangoJoystick = 75f;

public Vector2 posicionOriginal;
Vector3 valorJoystick;

NavMeshAgent agente;



    void Awake()
    {
        agente = GetComponent<NavMeshAgent>();
        StickGO = GameObject.FindGameObjectWithTag("Stick");
        StickRT = StickGO.GetComponent<RectTransform>();

        posicionOriginal = StickRT.anchoredPosition;
    }

    void Update()
    {
        Vector2 stickPosition = posicionOriginal - StickRT.anchoredPosition;

        Vector2 vectorMovimiento = stickPosition /rangoJoystick;

        if(vectorMovimiento.magnitude > 1f)
        {
            vectorMovimiento = vectorMovimiento.normalized;
        }
        if(vectorMovimiento.magnitude > 0.1f)
        {
            valorJoystick = new Vector3( vectorMovimiento.x, 0 , vectorMovimiento.y);
            agente.Move(valorJoystick * velocidad * Time.deltaTime);

            Quaternion targetRotation = Quaternion.LookRotation(valorJoystick);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10f * Time.deltaTime);


        }
        else
        {
            valorJoystick = Vector3.zero;
            agente.Move(Vector3.zero);
        }
    }

    public Vector3 getDireccion()
    {
        
        return valorJoystick;
    }


}
