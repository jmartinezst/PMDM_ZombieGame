

using UnityEngine;
using UnityEngine.SceneManagement;



public class CargaMenu : MonoBehaviour
{
    
    public GameObject canvas;

    void Start()
    {
        Debug.Log("Escena 0, continuas");
        Invoke("cargarSiguiente",1f);
    }


    public void cargarSiguiente()
    {   
        canvas.GetComponent<GestorPaneles>().abrirMenu();
        SceneManager.LoadScene(1);
    }


}