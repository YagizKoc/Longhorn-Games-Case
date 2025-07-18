using System;

public static class UIEvents
{
    public static Action StartGame;
    public static Action OnOpenLevelEndMenu;
    public static Action OnOpenMainMenu;
    public static Action OnOpenSettings;
    public static Action OnOpenCredits;
    public static Action OnPause;
    public static Action OnResume;
    public static Action OnQuit;

    
    public static void RaiseMainMenu() => OnOpenMainMenu?.Invoke();
    public static void RaiseLevelEndMenu() => OnOpenLevelEndMenu?.Invoke();
    public static void RaiseSettings() => OnOpenSettings?.Invoke();
    public static void RaiseCredits() => OnOpenCredits?.Invoke();
    public static void RaisePause() => OnPause?.Invoke();
    public static void RaiseResume() => OnResume?.Invoke();
    public static void RaiseQuit() => OnQuit?.Invoke();
}
