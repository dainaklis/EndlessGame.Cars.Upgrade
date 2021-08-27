using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseTextGO;
    [SerializeField] private GameObject pauseButtonHome;
    [SerializeField] private Image pauseButtonImage;

    [SerializeField] private Sprite pauseButtonSprite;
    [SerializeField] private Sprite playButtonSprite;


    private bool isGamePaused;
    private bool canPause = true;
    private float timeBeForPause;


    public void TogglePause()
    {
        if (!canPause)
        {
            return;
        }

        isGamePaused = !isGamePaused;

        if (isGamePaused)
        {
            pauseTextGO.SetActive(true);
            pauseButtonHome.SetActive(true);
            pauseButtonImage.sprite = playButtonSprite;

            timeBeForPause = Time.timeScale;
            Time.timeScale = 0;
        }
        else
        {
            pauseTextGO.SetActive(false);
            pauseButtonHome.SetActive(false);
            pauseButtonImage.sprite = pauseButtonSprite;
            
            Time.timeScale = timeBeForPause;
        }
    }

    public void ChangePauseTo(bool changeItTo)
    {
        canPause = changeItTo;
    }
}
