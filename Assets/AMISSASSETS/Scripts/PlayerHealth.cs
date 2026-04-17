using UnityEngine.UI;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
  
    MenuManager menuManager;
    float vidaInicial =100;
    float puntosSalud;

    public GameObject healthBarGO;
    Image barraSalud;


    void Awake()
    {
       
        healthBarGO = GameObject.FindGameObjectWithTag("HealthBar");
        menuManager = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<MenuManager>();
        barraSalud = healthBarGO.GetComponent<Image>(); 
        if(barraSalud == null)
        {
            Debug.LogWarning("No detecto HealthBar");
        }
    }
    void Start()
    {
         restablecerVida();
    }

    public void restarVida(int cantidad)
    {
        puntosSalud -= cantidad;
        actualizarBarraVida();
        if(puntosSalud <=0)
        {
            Debug.Log("Has muerto");
            puntosSalud =0;
            menuManager.playerMuerto();
        }
    }

    public void sumarVida(int cantidad)
    {
        puntosSalud += cantidad;
        //asegurar a la vida maxima 
        if(puntosSalud > vidaInicial) puntosSalud = vidaInicial;
        actualizarBarraVida();
    }

    public void restablecerVida()
    {
        puntosSalud = vidaInicial;
    }

    public void actualizarBarraVida()
    {
        float porcentaje = puntosSalud/vidaInicial;
        barraSalud.fillAmount = porcentaje;
    }

   


}
