using JetBrains.Annotations;
using SimplePopupManager;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Newtonsoft.Json;
using System;
using System.Linq;

public class LeaderBoard : MonoBehaviour,IPopupInitialization
{
    private List<Player> playersToShow;
    public TextAsset playersJSON;
    [Space]
    public GameObject playerPanelPrefab;
    public RectTransform contentWindow;
    public Transform panelsHolder;
    public float padding;
    [Space]
    public GameObject loadingBar;
    public Task Init(object param)
    {
        playersToShow = Player.ParsePlayers(playersJSON.text);
        DrawPanel();
        return Task.CompletedTask;
    }

    public void DrawPanel()
    {

        if (playersToShow == null) return;

        playersToShow = playersToShow.OrderByDescending(playersToShow => playersToShow.score).ToList();

        SetupContentWindow();
        DrawPlayerPanels();


    }
    private void SetupContentWindow()
    {
        contentWindow.sizeDelta = new Vector2(
            contentWindow.rect.size.x, 
            playersToShow.Count * (playerPanelPrefab.GetComponent<RectTransform>().rect.height + padding) 
            );

    }

    private void DrawPlayerPanels()
    {
        for (int i = 0; i < playersToShow.Count; i++)
        {
            RectTransform panel = Instantiate(playerPanelPrefab, Vector3.zero, Quaternion.identity, panelsHolder).GetComponent<RectTransform>();
            playersToShow[i].type = (Player.PlayerType)i;
            panel.localPosition = Vector3.down * (i * panel.rect.height + padding * i);
            panel.GetComponent<LeaderBoardPlayerPanel>().player = playersToShow[i];

        }
        Destroy(loadingBar);
    }


}

public class LeaderboardParams
{
    //Empty, but open to extension
}