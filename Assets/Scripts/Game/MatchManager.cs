using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UIButtonEventTrigger;
using static UnityEditor.Searcher.Searcher.AnalyticsEvent;

public class MatchManager : MonoBehaviour
{
    public static MatchManager Instance;
    private int score;

    public List<MatchItem> selectedItems = new List<MatchItem>();

   
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); 
    }

    //Adds the clicked object to the list
    public void SelectItem(MatchItem item)
    {
        if (selectedItems.Contains(item)) return;//Do nothing if item is selected

        selectedItems.Add(item);
        if (selectedItems.Count < 3)
        {
        AudioManager.Instance.PlaySelectSound(); //Plays click sound only when unclicked object is clicked other thand third time.

        }
        if (selectedItems.Count == 3)
        {
            CheckMatch();
        }
    }

    //Be careful that 3 match destroys parent component
    private void CheckMatch()
    {
        ColorType color = selectedItems[0].GetColorType();

        bool allMatch = selectedItems.TrueForAll(i => i.GetColorType() == color);

        if (allMatch)
        {
            UIManager.Instance.HideItemIcon();
            GameManager.Instance.scoreUpdate();
            UIManager.Instance.ScoreTextUpdate();
            GameEvents.current.ObjectsMatched();
            AudioManager.Instance.PlayEffect(AudioManager.Instance.matchSound);
            GameManager.Instance.levelMatchCount -= 1;
            foreach (var item in selectedItems)
            {
                var particles = item.GetComponentInChildren<ParticleSystem>();
                if (particles != null) { 
                
                    particles.transform.parent = null;
                }
                particles.Play();
                Destroy(particles.gameObject, particles.main.duration);
                if (item.transform.parent != null)
                    Destroy(item.transform.parent.gameObject);
                else
                    Destroy(item.gameObject);
            }
            if (GameManager.Instance.levelMatchCount == 0) {

                UIEvents.RaiseLevelEndMenu();
            }
        }

        selectedItems.Clear();
        UIManager.Instance.HideItemIcon();
    }

    
}
