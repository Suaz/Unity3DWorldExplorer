using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject winingPanel;
    [SerializeField] GameObject Live1;
    [SerializeField] GameObject Live2;
    [SerializeField] GameObject Live3;
    [SerializeField] TextMeshProUGUI starsCounter;
    void Start()
    {
        GameController.Instance.ResetStats();   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            pauseMenu.SetActive(true);
        }
        CheckLives();
        starsCounter.SetText(GameController.Instance.stars.ToString());

        Debug.Log(GameController.Instance.lives);
        Live1.SetActive(GameController.Instance.lives > 0);
        Live2.SetActive(GameController.Instance.lives > 1);
        Live3.SetActive(GameController.Instance.lives > 2);


        if (GameController.Instance.lives == 0)
        {
            gameOverPanel.SetActive(true);
        }
    }

    public void Continue()
    {
        Debug.Log("Continue");
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenu.SetActive(false);
    }

    public void GoMenu()
    {
        Debug.Log("Menu");
        SceneManager.LoadScene("Start", LoadSceneMode.Single);
    }

    public void CheckLives()
    {

    }
}
