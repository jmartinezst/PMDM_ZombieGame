using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GestorPaneles : MonoBehaviour
{

   public CanvasGroup grupoJoystick;
   public CanvasGroup grupoHUD;
   public CanvasGroup grupoMenu;
   public CanvasGroup grupoAjustes;
   public CanvasGroup grupoFinal;

   public GameObject grupoJoystickGO;
   public GameObject grupoHUDGO;
   public GameObject grupoMenuGO;
   public GameObject grupoAjustesGO;
   public GameObject grupoFinalGO;

   public GameObject scrollGO;
   public Button botonVolverMenu;

   void Awake()
   {
      grupoJoystick = grupoJoystickGO.GetComponent<CanvasGroup>();
      grupoHUD = grupoHUDGO.GetComponent<CanvasGroup>();
      grupoMenu = grupoMenuGO.GetComponent<CanvasGroup>();
      grupoAjustes = grupoAjustesGO.GetComponent<CanvasGroup>();
      grupoFinal = grupoFinalGO.GetComponent<CanvasGroup>();
   }

   public void abrirAjustes()
   {
      modificarPanel(grupoHUD,0,false, false);
      modificarPanel(grupoJoystick,0,false, false);
      modificarPanel(grupoAjustes,1,true, true);
      modificarPanel(grupoMenu,0,false, false);
   }

   public void abrirMenu()
   {
      modificarPanel(grupoHUD,0,false, false);
      modificarPanel(grupoJoystick, 0,false, false);
      modificarPanel(grupoAjustes,0,false, false);
      modificarPanel(grupoMenu,1,true, true);
      modificarPanel(grupoFinal,0, false, false);
   }

   public void abriFinalDerrota()
   {
      modificarPanel(grupoHUD,0,false, false);
      modificarPanel(grupoJoystick,0,false, false);
      modificarPanel(grupoAjustes,0,false, false);
      modificarPanel(grupoMenu,0,false, false);
      modificarPanel(grupoFinal,1,true, true);

      //desactivar titulos
      scrollGO.SetActive(false);

      TMP_Text textoFinal = GameObject.FindGameObjectWithTag("FinalText").GetComponent<TMP_Text>();
      textoFinal.SetText("Has muerto");
   }

   public void abriFinalVictoria()
   {
      modificarPanel(grupoHUD,0,false, false);
      modificarPanel(grupoJoystick,0,false, false);
      modificarPanel(grupoAjustes,0,false, false);
      modificarPanel(grupoMenu,0,false, false);
      modificarPanel(grupoFinal,1,true, true);

      TMP_Text textoFinal = GameObject.FindGameObjectWithTag("FinalText").GetComponent<TMP_Text>();
      textoFinal.SetText("Has conseguido escapar");

      //activar titulos
    
      scrollGO.SetActive(true);
   }

   

   public void abrirControles()
   {
      modificarPanel(grupoHUD,1,false, false);
      modificarPanel(grupoJoystick, 1, true, true);
      modificarPanel(grupoAjustes,0,false, false);
      modificarPanel(grupoMenu,0 ,false, false);
      modificarPanel(grupoFinal,0, false, false);

      activarJoystick();
      
   }


   public void modificarPanel(CanvasGroup grupo, int visibilidad, bool actuable, bool bloquea)
   {
      grupo.alpha =visibilidad;
      grupo.interactable =actuable;
      grupo.blocksRaycasts = bloquea;
   }
   public void activarJoystick()
   {
      grupoJoystickGO.SetActive(false); // se fuerza por si esta activo a volver a activarse
      grupoJoystickGO.SetActive(true);
   }

   public void ActivarBotonMenu()
   {
      botonVolverMenu.gameObject.SetActive(true);
   }
   public void DesactivarBotonMenu()
   {
      botonVolverMenu.gameObject.SetActive(false);
   }
   
   



   

}
