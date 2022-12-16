using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	
	public static GameController Instance;
	
	[SerializeField] public string Character = "RED";
    public const string CHARACTER_RED = "RED";
    public const string CHARACTER_BLUE = "BLUE";
    public  int lives = 3;
    public  int stars = 0;

    private void Awake()
	{
        DontDestroyOnLoad(this);

        if (Instance !=null && Instance != this )
		{
			Destroy(this);
		}
		else{
			Instance=this;
		}
    }
    public void SetCharacter(string character)
    {
        this.Character = character;
    }

    public void ResetStats()
    {
        lives = 3;
        stars = 0;
    }

    public void ApplyDamage()
    {
        lives = lives - 1;
    }

    public void AddStar()
    {
        stars = stars + 1;
    }
}
