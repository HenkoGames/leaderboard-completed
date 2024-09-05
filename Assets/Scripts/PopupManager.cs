using JetBrains.Annotations;
using SimplePopupManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Contains tools to work with popups in this Unity project, uses Singleton & peculiar Facade pattern
/// </summary>
public class PopupManager : MonoBehaviour
{
    [SerializeField]
    private RectTransform canvas;
    
    private static IPopupManagerService instance ;

    public void OpenPopup(string name)
    {
       GetInstance().OpenPopup(name, null, canvas);
    }
    public static void OpenPopup(string name, object param)
    {
        GetInstance().OpenPopup(name, param);
    }
    public static void ClosePopup(string name)
    {
        GetInstance().ClosePopup(name);
    }
    private static IPopupManagerService GetInstance()
    {
        if(instance == null)
        {
            instance = new PopupManagerServiceService();
        } 
        return instance;
    }
}
public class PopupParams
{

}