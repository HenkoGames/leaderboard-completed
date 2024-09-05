using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class LeaderBoardPlayerPanel : MonoBehaviour
{
    public Player player;

    public TextMeshProUGUI nameField;
    public TextMeshProUGUI scoreField;
    public Image avatar;
    public Image background;
    [Space]
    public GameObject LoadingBar;
    [Space]
    public Color[] topColors;
    void Start()
    {
        nameField.text = player.name;
        scoreField.text = $"Score: {player.score}";

        if(player.avatar != null)avatar.sprite = player.avatar;

        SetBackground();
        StartCoroutine(LoadAvatar(player.avatarLink));
        

    }
    private void SetBackground()
    {
        if ((int)player.type < topColors.Length)
        {
            background.color = topColors[(int)player.type];
        }
            


    }

    IEnumerator LoadAvatar(string Link)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(player.avatarLink);
        yield return request.SendWebRequest();
        if(!(request.isNetworkError || request.isHttpError))
        {
            Texture2D downloadedAvatar = ((DownloadHandlerTexture)request.downloadHandler).texture;
            player.avatar = Sprite.Create(downloadedAvatar, new Rect(0, 0, downloadedAvatar.width, downloadedAvatar.height), new Vector2(0.5f, 0.5f));
            avatar.sprite = player.avatar;
        }
        Destroy(LoadingBar);
    }
}
