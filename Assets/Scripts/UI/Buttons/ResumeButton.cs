using UnityEngine;

public class ResumeButton : MonoBehaviour
{
    public void OnClick()
    {
        UIEvents.OnResume?.Invoke();
    }
}
