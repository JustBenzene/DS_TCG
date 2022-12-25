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

    [SerializeField] GameObject middle;

    private void Start()
    {
        float temp = 718f + (GameManager.aspectRatio - 1.334545f) * 797f * 1.004405f;
        middle.GetComponent<RectTransform>().sizeDelta = new Vector2(800, temp);

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
