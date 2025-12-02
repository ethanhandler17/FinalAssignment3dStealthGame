using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameEnding : MonoBehaviour
{
    // Set the fade duration.
    public float fadeDuration = 1f;
    // Set the display image duration.
    public float displayImageDuration = 1f;
    // Get the player game object.
    public GameObject player;
    // Get the UI document.
    public UIDocument uiDocument;
    // Get the exit audio.
    public AudioSource exitAudio;
    // Get the caught audio.
    public AudioSource caughtAudio;

    // Set if the player is at the exit.
    bool m_IsPlayerAtExit;
    // Set if the player is caught.
    bool m_IsPlayerCaught;
    // Set the timer.
    float m_Timer;
    bool m_HasAudioPlayed;

    // Get the end screen.
    private VisualElement m_EndScreen;
    // Get the caught screen.
    private VisualElement m_CaughtScreen;

    // Start is called before the first frame update.
    void Start()
    {
        // Get the end screen.
        m_EndScreen = uiDocument.rootVisualElement.Q<VisualElement>("EndScreen");
        // Get the caught screen.
        m_CaughtScreen = uiDocument.rootVisualElement.Q<VisualElement>("CaughtScreen");
    }
    
    // On trigger enter, set the player at the exit to true.
    void OnTriggerEnter (Collider other)
    {
        // Check if the other object is the player.
        if (other.gameObject == player)
        {
            m_IsPlayerAtExit = true;
        }
    }

    // Call the caught player method.
    public void CaughtPlayer ()
    {
        // Set the player caught to true.
        m_IsPlayerCaught = true;
    }

    // Update is called once per frame.
    void Update ()
    // Check if the player is at the exit.
    {
        // Check if the player is at the exit.
        if (m_IsPlayerAtExit)
        {
            // Call the end level method.
            EndLevel (m_EndScreen, false, exitAudio);
        }
        // Check if the player is caught.
        else if (m_IsPlayerCaught)
        {
            // Call the end level method.
            EndLevel (m_CaughtScreen, true, caughtAudio);
        }
    }

    // End level method.
    void EndLevel (VisualElement element, bool doRestart, AudioSource audioSource)
    // Check if the audio has played.
    {
        if (!m_HasAudioPlayed)
        {
            // Play the audio.
            audioSource.Play();
            m_HasAudioPlayed = true;
        }
            
        // Increment the timer.
        m_Timer += Time.deltaTime;
        // Set the opacity of the element.
        element.style.opacity = m_Timer / fadeDuration;

        // Check if the timer is greater than the fade duration plus the display image duration.
        if (m_Timer > fadeDuration + displayImageDuration)
        // Check if the do restart is true.
        {
            if (doRestart)
            {
                // Reload the scene.
                SceneManager.LoadScene (0);
            }
            else
            {
                // Quit the application.
                Application.Quit();
                // Set the time scale to 0.
                Time.timeScale = 0;
               
            }
        }
    }
}