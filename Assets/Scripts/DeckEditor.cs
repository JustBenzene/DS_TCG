using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class DeckEditor : MonoBehaviour
{
    [SerializeField] GameObject number;
    [SerializeField] GameObject saveFile;

    private void Start()
    {
        number.GetComponent<TextMeshProUGUI>().SetText(GameManager.deckNumber.ToString());
    }

    public void OnClickBack()
    {
        SceneManager.UnloadSceneAsync("DeckEditor");
    }

    public void OnClickSave()
    {
        PlayerPrefs.SetString("Deck" + saveFile.GetComponent<Slider>().value.ToString() + "Empty", "False");
        PlayerPrefs.Save();
    }
}
