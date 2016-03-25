using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
using System.Collections;
using GoogleMobileAds.Api;

public class StartManager : MonoBehaviour
{
    //Ads
    BannerView bannerView;
    // Use this for initialization
    void Awake()
    {
        bannerView = new BannerView("ca-app-pub-5325622833123971/2069584440", AdSize.SmartBanner, AdPosition.Bottom);
        AdRequest.Builder builder = new AdRequest.Builder();
        //AdRequest request = builder.AddTestDevice(AdRequest.TestDeviceSimulator).AddTestDevice(SystemInfo.deviceUniqueIdentifier).Build();
        AdRequest request = builder.Build();// 실제 빌드

        bannerView.LoadAd(request); //배너 광고 요청
        bannerView.Show();  // 배너 광고 출력
    }

    void Start()
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
        .Build();

        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
        Social.localUser.Authenticate((bool success) =>
        {
            //Debug.Log(success);
        });
    }
    public void OnClick_Rank()
    {
        PlayGamesPlatform.Instance.ShowLeaderboardUI("CgkIyOj9mbIBEAIQAA");
    }

    public void OnClick_Start() 
    { 
    }

    public void OnClick_Info()
    {

    }
}
