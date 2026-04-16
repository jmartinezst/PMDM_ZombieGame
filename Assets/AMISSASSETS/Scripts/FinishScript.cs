using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishScript : MonoBehaviour
{


  MenuManager menuManager;
  TMP_Text avisos;

    void Awake()
    {
             menuManager = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<MenuManager>();
             avisos = GameObject.FindGameObjectWithTag("AvisosText").GetComponent<TMP_Text>();
             if(avisos == null) Debug.LogWarning("No hay panel avisos en finishscript");
    }
  
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Algo entro");
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Es el player");
            int herramientasPlayer = other.gameObject.GetComponent<PlayerInventario>().getHerramientasRecogidas();

            if(herramientasPlayer  >=3)
            {
                //HAS GANADO 
              menuManager.playerGano();
            }
            else
            {
                Debug.Log("te faltan herramientas" + (3- herramientasPlayer));
               
                avisos.SetText("te faltan herramientas" + (3- herramientasPlayer));
            }


        }
    }
}
