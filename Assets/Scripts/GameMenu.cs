using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameMenu : MonoBehaviour
{
    [SerializeField] GameObject MainMenu;
    [SerializeField] GameObject CharacterSelector;

    private void Start()
    {
        //MainMenu.transform.position = new Vector3(0, 0, 0);
        //CharacterSelector..position = new Vector3(0, 0, 0);

        MainMenu.SetActive(true);
        CharacterSelector.SetActive(false);
    }

    public void DisplayMainMenu()
    {
        MainMenu.SetActive(true);
        CharacterSelector.SetActive(false);
    }

    public void DisplayCharacterSelector()
    {
        MainMenu.SetActive(false);
        CharacterSelector.SetActive(true);
    }

    public void SelectRed()
    {
        GameController.Instance.Character = GameController.CHARACTER_RED;
    }
    public void SelectBlue()
    {
        GameController.Instance.Character = GameController.CHARACTER_BLUE;
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Jungle", LoadSceneMode.Single);
    }
}
