using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject LevelEndMenu;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject creditsMenu;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private Image item1DisplayImage;
    [SerializeField] private Image item2DisplayImage;
    [SerializeField] private Image item3DisplayImage;
    [SerializeField] private TextMeshProUGUI scoreText;

    private Dictionary<MenuType, GameObject> menuMap;

    private void Awake()
    {
        Debug.Log("works");
        item1DisplayImage = GameObject.Find("Item 1")?.GetComponent<Image>();
        item2DisplayImage = GameObject.Find("Item 2")?.GetComponent<Image>();
        item3DisplayImage = GameObject.Find("Item 3")?.GetComponent<Image>();
        ScoreTextUpdate();
        HideItemIcon();
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        //DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;

        

        menuMap = new Dictionary<MenuType, GameObject>
        {
            { MenuType.Main, mainMenu },
            { MenuType.LevelEnd, LevelEndMenu },
            { MenuType.Settings, settingsMenu },
            { MenuType.Credits, creditsMenu },
            { MenuType.Pause, pauseMenu }
        };
    }

    private void OnEnable()
    {
        UIEvents.OnOpenMainMenu += OpenMainMenu;
        UIEvents.OnOpenLevelEndMenu += OpenLevelEndMenu;
        UIEvents.OnOpenSettings += OpenSettingsMenu;
        UIEvents.OnOpenCredits += OpenCreditsMenu;
        UIEvents.OnPause += OpenPauseMenu;
        UIEvents.OnResume += ClosePauseMenu;
        UIEvents.OnQuit += HandleQuit;
    }

    private void OnDisable()
    {
        UIEvents.OnOpenMainMenu -= OpenMainMenu;
        UIEvents.OnOpenSettings -= OpenSettingsMenu;
        UIEvents.OnOpenCredits -= OpenCreditsMenu;
        UIEvents.OnPause -= OpenPauseMenu;
        UIEvents.OnResume -= ClosePauseMenu;
        UIEvents.OnQuit -= HandleQuit;
    }

    private void Start()
    {
        if (GameEvents.current != null)
            GameEvents.current.objectsMatched += ScoreTextUpdate;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;

        if (GameEvents.current != null)
            GameEvents.current.objectsMatched -= ScoreTextUpdate;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Level1")
        {
            
        }

        pauseMenu = GameObject.Find("Pause Menu");
        if (pauseMenu != null)
            pauseMenu.SetActive(false);
    }

    public void OpenMenu(MenuType menuToOpen)
    {
        foreach (var pair in menuMap)
        {
            if (pair.Value == null)
                continue;

            pair.Value.SetActive(pair.Key == menuToOpen);
        }
    }

    public void OpenMainMenu() => OpenMenu(MenuType.Main);
    public void OpenPauseMenu() => OpenMenu(MenuType.Pause);
    public void OpenLevelEndMenu() => OpenMenu(MenuType.LevelEnd);
    public void OpenSettingsMenu() => OpenMenu(MenuType.Settings);
    public void OpenCreditsMenu() => OpenMenu(MenuType.Credits);

    /*public void OpenPauseMenu()
    {
        if (pauseMenu != null)
            pauseMenu.SetActive(true);
    }*/

    public void ClosePauseMenu()
    {
        if (pauseMenu != null)
            pauseMenu.SetActive(false);

        if (GameManager.Instance != null)
            GameManager.Instance.isPaused = false;
    }

    private void HandleQuit()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.QuitGame();
    }

    public void ShowItemIcon(Sprite icon)
    {
        if (MatchManager.Instance.selectedItems.Count == 1)
        {
            item1DisplayImage.sprite = icon;
            item1DisplayImage.enabled = true;
        }
        else if (MatchManager.Instance.selectedItems.Count == 2)
        {
            item2DisplayImage.sprite = icon;
            item2DisplayImage.enabled = true;
        }
        else if (MatchManager.Instance.selectedItems.Count == 3)
        {
            item3DisplayImage.sprite = icon;
            item3DisplayImage.enabled = true;
        }
    }
    public void HideItemIcon()
    {
        if (item1DisplayImage != null) {

            item1DisplayImage.sprite = null;
            item2DisplayImage.sprite = null;
            item3DisplayImage.sprite = null;

            item1DisplayImage.enabled = false;
            item2DisplayImage.enabled = false;
            item3DisplayImage.enabled = false;
        }
        
    }


    public void ScoreTextUpdate()
    {
        if (scoreText != null && GameManager.Instance != null)
            scoreText.text = "Score: " + GameManager.Instance.score.ToString();
    }
}
