using Unity.VisualScripting;
using UnityEngine;
using Vuforia;

public class WelcomeScreenManager : MonoBehaviour
{
    [Tooltip("El GameObject que representa la pantalla de bienvenida.")]
    [SerializeField]
    private GameObject m_GreetingPrompt;

    [Tooltip("El botón de continuar para cerrar la pantalla.")]
    [SerializeField]
    private GameObject m_ContinueButton;

    /// <summary>
    /// El GameObject que representa la pantalla de bienvenida.
    /// </summary>
    public GameObject GreetingPrompt
    {
        get => m_GreetingPrompt;
        set => m_GreetingPrompt = value;
    }

    private void Start()
    {
        ShowWelcomeScreen();

        // Obtener todos los Image Targets en la escena usando el método actualizado
        /*var imageTargets = Object.FindObjectsByType<ObserverBehaviour>(FindObjectsSortMode.None);
        foreach (var target in imageTargets)
        {
            target.OnTargetStatusChanged += OnTargetStatusChanged;
        }*/
    }

    /// <summary>
    /// Activa la pantalla de bienvenida.
    /// </summary>
    public void ShowWelcomeScreen()
    {
        if (m_GreetingPrompt != null)
        {
            m_GreetingPrompt.SetActive(true);
            if (m_ContinueButton != null)
            {
                m_ContinueButton.SetActive(true);
            }
        }
        else
        {
            Debug.LogWarning("No se ha asignado un GreetingPrompt.");
        }
    }

    /// <summary>
    /// Cierra la pantalla de bienvenida.
    /// </summary>
    public void CloseWelcomeScreen()
    {
        if (m_GreetingPrompt != null)
        {
            m_GreetingPrompt.SetActive(false);
        }
        else
        {
            Debug.LogWarning("No se ha asignado un GreetingPrompt.");
        }
    }

    /// <summary>
    /// Método llamado al presionar el botón de continuar.
    /// </summary>
    public void OnContinueButtonPressed()
    {
        CloseWelcomeScreen();
    }

    /// <summary>
    /// Maneja el evento cuando se detecta un Image Target.
    /// </summary>
    /// <param name="observer">El observador del Image Target.</param>
    /// <param name="targetStatus">El estado actual del Target.</param>
    public void OnTargetStatusChanged(ObserverBehaviour observer, TargetStatus targetStatus)
    {
        if (targetStatus.Status == Status.TRACKED || targetStatus.Status == Status.EXTENDED_TRACKED)
        {
            CloseWelcomeScreen();
        }
    }

    private void OnDestroy()
    {
        // Desregistrar el evento para evitar errores al destruir el objeto
        var imageTargets = Object.FindObjectsByType<ObserverBehaviour>(FindObjectsSortMode.None);
        foreach (var target in imageTargets)
        {
            target.OnTargetStatusChanged -= OnTargetStatusChanged;
        }
    }
}
