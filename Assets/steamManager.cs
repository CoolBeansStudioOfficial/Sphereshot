using UnityEngine;
using Steamworks;

public class steamManager : MonoBehaviour
{
    public steamManager Instance;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        try
        {
            SteamClient.Init(480, true);
            print("success: " + SteamClient.Name);
        }
        catch (System.Exception e)
        {
            print(e);
            // Something went wrong - it's one of these:
            //
            //     Steam is closed?
            //     Can't find steam_api dll?
            //     Don't have permission to play app?
            //
        }

    }
}
