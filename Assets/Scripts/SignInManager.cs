using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class SignInManager : MonoBehaviour
{
    public bool signedIn;
    public string userName;
    public string userID;

    // Start is called before the first frame update
    void Start()
    {
        SignIn();
    }

    void SignIn()
    {
        Social.localUser.Authenticate(success => {
            if (success)
            {
                Debug.Log("Authentication successful");
                string userInfo = "Username: " + Social.localUser.userName +
                    "\nUser ID: " + Social.localUser.id +
                    "\nIsUnderage: " + Social.localUser.underage;
                Debug.Log(userInfo);

                userName = Social.localUser.userName;
                userID = Social.localUser.id;

                signedIn = true;
                GameManager.Instance.SetLabels();
            }
            else
            {
                Debug.Log("Authentication failed");
                signedIn = false;
            }
                
        });
    }

    public void ShowLeaderboards()
    {
        Social.ShowLeaderboardUI(); // Shows Leaderboard UI
    }

    public void ShowAchievements()
    {
        Social.ShowAchievementsUI(); // Shows Achievement UI
    }

    public void CheckHighScore(int score)
    {
        if(signedIn)
        {
            // Reports Leaderboards - ReportScore()
#if UNITY_IOS
            Social.ReportScore(score, "random_highscore", success => {
                Debug.Log(success ? "Reported score successfully" : "Failed to report score");
            });
#elif UNITY_ANDROID
            Social.ReportScore(score, "CggIxqreykgQAhAB", success => {
                Debug.Log(success ? "Reported score successfully" : "Failed to report score");
            });
#endif
        }

    }

    public void CheckOver900()
    {
        if (signedIn)
        {
            // Reports Achievements - ReportProgress()
#if UNITY_IOS
            Social.ReportProgress("over_900", 100.0, success => {
                Debug.Log(success ? "Reported score successfully" : "Failed to report score");
            });
#elif UNITY_ANDROID
            Social.ReportProgress("CggIxqreykgQAhAC", 100.0, success => {
                Debug.Log(success ? "Reported score successfully" : "Failed to report score");
            });
#endif
        }

    }

}
