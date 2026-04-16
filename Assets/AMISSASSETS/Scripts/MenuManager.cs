using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    GestorPaneles gestorPaneles;
  

    // EVENTOS ESTÁTICOS 
    public static UnityEvent OnAccion1 = new UnityEvent();
    public static UnityEvent OnAccion2 = new UnityEvent();

    

    // MÉTODOS PARA LANZAR LOS EVENTOS CON LOS BOTONES 
    public void ClickBoton1()
    { 
        OnAccion1.Invoke();
    }
    public void ClickBoton2() 
    { 
        OnAccion2.Invoke(); 
    }
   
    //En el awake el slider tiene q localizar al audiomanager para poder manipularlo
    public void Awake()
    {       
       gestorPaneles = GetComponent<GestorPaneles>();
    }


    // CAMBIO DE ESCENAS
    public void cargarEscena0()
    {
        SceneManager.LoadSceneAsync(0);
    }

   public void cargarEscena1()
    {
        SceneManager.LoadSceneAsync(1);    
        gestorPaneles.volverAlJuego();
        gestorPaneles.activarJoystick();
    }

    public void cargarEscena2()
    {
        SceneManager.LoadSceneAsync(2);
        gestorPaneles.volverAlJuego();
    }


    /// OPCIONES DE MENU Y  AJUSTES
    public void abrirAjustes()
    {
       gestorPaneles.abrirAjustes();
    }

    public void salirDelJuego()
    {
        Application.Quit();
    }
    
    public void ponerPausa()
    {
        Time.timeScale = 0f;
        gestorPaneles.abrirAjustes();
    }
    public void quitarPausa()
    {
        Time.timeScale = 1f;
    }

    public void volverAlJuego()
    {
        gestorPaneles.volverAlJuego();
        quitarPausa();
    }

    public void volverAlMenu()
    {
        ///Cerrar panel ajustes y habilitar joystick
        gestorPaneles.volverAlMenu();
        ponerPausa();
    }


    /// FIN GAME Y REINICIO
    public void playerMuerto()
    {
        gestorPaneles.abriFinalDerrota();
        ponerPausa();
    }

    public void playerGano()
    {
        cargarEscena2();
        gestorPaneles.abriFinalVictoria();
    }


}
