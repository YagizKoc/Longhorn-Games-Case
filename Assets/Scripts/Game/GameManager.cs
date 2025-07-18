using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    public int levelCount = 2;
    public int levelMatchCount;
    public bool isGameActive = false;
    public int score;
    public static GameManager Instance { get; private set; }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isGameActive) {

            TogglePause();
        }
    }
    private void Awake()
    {
        //Singleton check
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        

    }

    //UI related functions
    public void StartGame()
    {
        SceneManager.LoadScene("Area 1");
        levelMatchCount = 4;
        isGameActive = true;
        AudioManager.Instance.StopMusic(AudioManager.Instance.backgroundMusic);
        isPaused = false;
        MatchManager.Instance.selectedItems.Clear();
        UIManager.Instance.HideItemIcon();
    }

    public void GoToMainMenu()
    {
        Debug.Log("GoToMainMenu called");
        score = 0;
        SceneManager.LoadScene("Main Menu");
        isGameActive = false;
        Time.timeScale = 1.0f;
        AudioManager.Instance.PlayMusic(AudioManager.Instance.backgroundMusic);
    }


    public void QuitGame()
    {
        Application.Quit();
    }

    //Pausing
    public bool isPaused = false;
    
    public void PauseGame()
    {
        Time.timeScale = 0f;
        isPaused = true;

        UIManager.Instance.OpenPauseMenu();
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        isPaused = false;

        UIManager.Instance.ClosePauseMenu();
    }

    public void TogglePause()
    {
        if (isPaused)
            ResumeGame();
        else
            PauseGame();
    }

    public void scoreUpdate() {

        score = score + MatchManager.Instance.selectedItems[0].GetScore() + MatchManager.Instance.selectedItems[1].GetScore() + MatchManager.Instance.selectedItems[2].GetScore();
    }

    public void LevelCompleted() { 
    
        //UIManager.Instance.LevelEndMenu();
    }
}

