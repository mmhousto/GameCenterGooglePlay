using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance { get { return instance; } set { instance = value; } }

    public TextMeshProUGUI userNameLabel, userIDLabel, randomNumberLabel;
    public SignInManager signInManager;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void ShowLeaderboard()
    {
        signInManager.ShowLeaderboards();
    }

    public void ShowAchievement()
    {
        signInManager.ShowAchievements();
    }

    public void GetRandomNumber()
    {
        int random = Random.Range(0, 1001);
        randomNumberLabel.text = random.ToString();

        signInManager.CheckHighScore(random);

        if (random > 900) signInManager.CheckOver900();
    }

    public void SetLabels()
    {
        if (signInManager.signedIn)
        {
            userNameLabel.text = signInManager.userName;
            userIDLabel.text = signInManager.userID;
        }
    }
}
