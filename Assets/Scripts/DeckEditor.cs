using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class DeckEditor : MonoBehaviour
{
    [SerializeField] GameObject numberOnScreen;
    [SerializeField] int number;

    private void Start()
    {
        number = GameManager.deckNumber;
        numberOnScreen.GetComponent<TextMeshProUGUI>().SetText(number.ToString());
    }

    public void OnClickDontSafe()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnClickSave()
    {
        PlayerPrefs.SetString("Deck" + number.ToString() + "Empty", "False");
        PlayerPrefs.Save();
        SceneManager.LoadScene("MainMenu");
    }
}
