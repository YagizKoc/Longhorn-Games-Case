using UnityEngine;

public class SettingsButton : MonoBehaviour
{
    public void OnClick()
    {
        UIEvents.OnOpenSettings?.Invoke();
    }
}
