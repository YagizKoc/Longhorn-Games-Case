using UnityEngine;

public class MainMenuButton : MonoBehaviour
{
    public void OnClick()
    {
        UIEvents.OnOpenMainMenu?.Invoke();
    }
}
