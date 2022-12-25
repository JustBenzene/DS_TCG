using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DeckEditor : MonoBehaviour
{
    [SerializeField] GameObject numberOnScreen;
    [SerializeField] GameObject nameField;
    [SerializeField] int number;

    private void Start()
    {
        number = GameManager.deckNumber;
        numberOnScreen.GetComponent<TextMeshProUGUI>().SetText(number.ToString());
        nameField.GetComponent<TMP_InputField>().text = PlayerPrefs.GetString("Deck" + number.ToString() + "Name");
    }

    public void OnClickDontSafe()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnClickSave()
    {
        PlayerPrefs.SetString("Deck" + number.ToString() + "Empty", "n");
        PlayerPrefs.SetString("Deck" + number.ToString() + "Name", nameField.GetComponent<TMP_InputField>().text);
        PlayerPrefs.Save();
        SceneManager.LoadScene("MainMenu");
    }
}
