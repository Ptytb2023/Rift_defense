using MushroomMadness.UI.LoadScene;
using System;
using UnityEngine;

public class UiAsistent : MonoBehaviour
{
    [SerializeField] private ScreenLoadGame _loadGame;
    [SerializeField] private ScreenDefeat _screenDefeat;
    [SerializeField] private ScreenVictory _screenVictory;

    public Action ButtonClickExit;

    private void OnEnable()
    {
    }

    private void OnDisable()
    {
        _screenDefeat.ButtonClickMenu += ExitMenu;
        _screenVictory.ButtonClickMenu += ExitMenu;
    }

    public void ShowScreenDefeat()
    {
        _screenDefeat.gameObject.SetActive(true);
        _screenDefeat.ButtonClickMenu += ExitMenu;
    }


    public void ShowScreenVictory()
    {
        _screenVictory.gameObject.SetActive(true);
        _screenVictory.ButtonClickMenu += ExitMenu;
    }


    private void ExitMenu()
    {
        ButtonClickExit?.Invoke();
    }

    public void ShwoLoadSreen()
    {
        _loadGame.gameObject.SetActive(true);
    }
}
