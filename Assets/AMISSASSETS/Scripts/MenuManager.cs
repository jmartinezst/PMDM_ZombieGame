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

    

    // MÉTODOS PARA LANZAR LOS EVENTOS CON LOS BOTONES:
    // Se necesitan publicos para que el player pueda localizarlos y vincular sus acciones a estos eventos, 
    // ya que estan en escenas diferentes.
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
    public void cargarEscenaMenu()
    {
        SceneManager.LoadScene(1);
        gestorPaneles.abrirMenu();
    }

   public void cargarEscenaJuego()
    {
        SceneManager.LoadScene(2);    
        gestorPaneles.abrirControles();
    }

    public void cargarEscenaFinal()
    {
        SceneManager.LoadScene(3);
        gestorPaneles.abrirControles();
    }


    /// OPCIONES DE MENU Y  AJUSTES
    public void abrirAjustes()
    {
        int x = SceneManager.GetActiveScene().buildIndex;
        if(x ==2)
        {
        Debug.Log("Ajustes de escena 2");
        gestorPaneles.abrirAjustes();
        ponerPausa();
        }
        else
        {
        Debug.Log("Ajustes de escena" + x);
        gestorPaneles.abrirAjustes();   
        }
    }

    public void salirDelJuego()
    {
        Application.Quit();
    }


    
    void ponerPausa()
    {
        Time.timeScale = 0f;       
    }

    void quitarPausa()
    {
        Time.timeScale = 1f;
    }



public void volver()
   {

      int x = SceneManager.GetActiveScene().buildIndex;
      if(x ==2)
      {
          volverAlJuego();
          quitarPausa();
      }
      else
      {
         volverAlMenu();
      }
   }
    public void volverAlJuego()
    {
        gestorPaneles.abrirControles();
    
    }

    public void volverAlMenu()
    {
        ///Cerrar panel ajustes y habilitar joystick
        gestorPaneles.abrirMenu();
       
    }


    /// FIN GAME Y REINICIO
    public void playerMuerto()
    {
        gestorPaneles.abriFinalDerrota();
      
    }

    public void playerGano()
    {
        cargarEscenaFinal();
        gestorPaneles.abriFinalVictoria();
    }


}
