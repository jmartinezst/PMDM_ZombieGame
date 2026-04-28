# PMDM Zombie Game 🧟‍♂️📱
**Demo técnica de acción 3D para dispositivos Android** desarrollada con **Unity 6 LTS**.

---

##  Características Técnicas
* **Arquitectura:** Implementación de patrones **Singleton** y escena de **Preload** para la gestión de sistemas persistentes (Audio, UI, Eventos) evitando duplicidad de objetos.
* **Optimización de Memoria:** Sistema de **Object Pooling** dinámico para proyectiles y respawn de enemigos, eliminando los picos de latencia del *Garbage Collector*.
* **IA & Navegación:** Enemigos basados en **Máquinas de Estados Finitos (FSM)** con detección mediante *SphereCast* optimizado y navegación segregada por capas en **NavMesh**.
* **Renderizado:** Uso de **Universal Render Pipeline (URP)** y estética *Low Poly* con texturas de 512px para garantizar **60 FPS** estables.
* **Controles:** Sistema de entrada táctil adaptado mediante **Joystick dinámico** (Starter Assets personalizados).

##  Stack Tecnológico
* **Motor:** Unity 6 (LTS)
* **Lenguaje:** C# (.NET Standard 2.1)
* **Pipeline:** Universal Render Pipeline (URP)
* **Control de Versiones:** Git
* **Build:** IL2CPP (Arquitectura ARM64 para Google Play) con compresión LZ4.

##  Análisis de Rendimiento (Unity Profiler)
* **Tasa de Frames:** Constante a **60 FPS** (tiempos de frame < 16.6ms).
* **Uso de Memoria:** Gráfica plana sin picos, validando la eficiencia del *Object Pooling*.
* **Audio:** Gestión eficiente mediante **AudioMixer** con canales segregados para SFX y Música.

##  Instalación y Despliegue

1. Descarga el archivo `.apk` de la última versión.
2. Habilita la instalación desde "Orígenes desconocidos" en los ajustes de tu terminal Android.
3. Instala el archivo y ejecuta la aplicación.


---
**Autor:** Javier Martínez Sodric  
**Proyecto:** Programación Multimedia y Dispositovs Móviles
