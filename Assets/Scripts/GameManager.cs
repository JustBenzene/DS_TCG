using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static float aspectRatio = (float)Screen.width / (float)Screen.height;

    public static int deckNumber = 0;

    public static int lastMenuPage = 0;

    private void Start()
    {
        DontDestroyOnLoad(this);
    }
}
