using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIButtonEventTrigger : MonoBehaviour
{
    public enum ButtonEventType
    {
        StartButton,
        MainMenu,
        NextLevelButton,
        Settings,
        Credits,
        Pause,
        Resume,
        GoToMainMenu,
        Quit
    }

    public ButtonEventType eventType;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(TriggerEvent);
    }

    private void TriggerEvent()
    {
        switch (eventType)
        {
            case ButtonEventType.StartButton:
                GameManager.Instance.StartGame();
                break;
            case ButtonEventType.MainMenu:
                UIEvents.RaiseMainMenu();
                break;
            case ButtonEventType.NextLevelButton:
                SceneManager.LoadScene("Area 2");
                break;
            case ButtonEventType.Settings:
                UIEvents.RaiseSettings();
                break;
            case ButtonEventType.Credits:
                UIEvents.RaiseCredits();
                break;
            case ButtonEventType.Pause:
                UIEvents.RaisePause();
                break;
            case ButtonEventType.Resume:
                UIEvents.RaiseResume();
                break;
            case ButtonEventType.GoToMainMenu:
                GameManager.Instance.GoToMainMenu();
                break;
            case ButtonEventType.Quit:
                UIEvents.RaiseQuit();
                break;
        }
    }
}
