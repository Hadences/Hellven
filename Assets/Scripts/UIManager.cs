using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameover_screen;
    private SoundManager soundManager;
    private void Start()
    {
        soundManager = GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>();
    }

    public void homeScreen()
    {
        SceneManager.LoadScene("HomeScreen");
    }

    public void playScreen()
    {
        soundManager.playSound(SoundManager.Sounds.UI_CLICK);
        SceneManager.LoadScene("GameScene");
    }

    public void showGameOverScreen()
    {
        gameover_screen.SetActive(true);
    }

    public void unshowGameOverScreen()
    {
        gameover_screen.SetActive(false);
    }
}
