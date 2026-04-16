using Unity.VisualScripting;
using UnityEngine;

public class BalaScript : MonoBehaviour
{
   
    public float speed = 20f;
    public float lifeTime = 2f;

    void OnEnable()
    {
        Invoke("Desactivar", lifeTime);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void Desactivar()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Zombi"))
        {
            other.GetComponent<ZombiBrain>().morir();

        }
        Desactivar();
    }
}

