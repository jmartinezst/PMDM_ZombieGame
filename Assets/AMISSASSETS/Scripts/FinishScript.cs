using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishScript : MonoBehaviour
{
  AudioSource source;
  public AudioClip sonidoError;
  MenuManager menuManager;
  TMP_Text avisos;

    void Awake()
    {
             menuManager = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<MenuManager>();
             avisos = GameObject.FindGameObjectWithTag("AvisosText").GetComponent<TMP_Text>();
             if(avisos == null) Debug.LogWarning("No hay panel avisos en finishscript");
             source = GetComponent<AudioSource>();
    }
  
    void OnTriggerEnter(Collider other)
    {
      
        if(other.gameObject.tag == "Player")
        {
            
            int herramientasPlayer = other.gameObject.GetComponent<PlayerInventario>().getHerramientasRecogidas();

            if(herramientasPlayer  >=3)
            {
                //HAS GANADO 
              menuManager.playerGano();
            }
            else
            {
               
                if(sonidoError !=null)
                {
                source.PlayOneShot(sonidoError);
                }
                avisos.SetText("te faltan llaves" + (3- herramientasPlayer));
                Invoke("borrarMensaje",2f);
            }


        }
    }

    public void borrarMensaje()
    {
       avisos.SetText(""); 
    }
}
