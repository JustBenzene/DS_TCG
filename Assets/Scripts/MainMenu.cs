using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject mainMenuButtons;
    [SerializeField] GameObject deckEditorButtons;
    [SerializeField] GameObject buttons;
    [SerializeField] GameObject title;
    [SerializeField] GameObject[] deleteButtons;
    [SerializeField] GameObject[] decknames;
    [SerializeField] GameObject areYouSure;

    private void Start()
    {
        float temp = 1f + (GameManager.aspectRatio - 1.334545f) * 0.2f * 1.004405f;
        buttons.GetComponent<RectTransform>().localScale = new Vector3(temp, temp, temp);

        temp = 300f - (GameManager.aspectRatio - 1.334545f) * 15f * 1.004405f;
        foreach (GameObject button in deleteButtons)
        {
            button.GetComponent<RectTransform>().localPosition = new Vector3(temp, button.GetComponent<RectTransform>().localPosition.y , 0);
        }

        temp = 650f + (GameManager.aspectRatio - 1.334545f) * 450f * 1.004405f;
        buttons.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, temp, 0);

        temp = 875f + (GameManager.aspectRatio - 1.334545f) * 625f * 1.004405f;
        title.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, temp, 0);

        if (GameManager.lastMenuPage == 1)
        {
            SetUpDeckEditor();
        }
    }

    public void OnClickNewGame()
    {
        
    }

    public void OnClickLoadGame()
    {
        
    }

    public void OnClickOptions()
    {
        
    }

    public void OnClickDeckEditor()
    {
        SetUpDeckEditor();
    }

    public void OnClickBack()
    {
        deckEditorButtons.SetActive(false);
        mainMenuButtons.SetActive(true);
    }

    public void OnClickDeck1()
    {
        OpenDeck(1);
    }

    public void OnClickDeck2()
    {
        OpenDeck(2);
    }

    public void OnClickDeck3()
    {
        OpenDeck(3);
    }

    public void OnClickDelete1()
    {
        DeleteDeck(1);
    }

    public void OnClickDelete2()
    {
        DeleteDeck(2);
    }

    public void OnClickDelete3()
    {
        DeleteDeck(3);
    }

    public void OnClickYes()
    {
        PlayerPrefs.SetString("Deck" + GameManager.deckNumber.ToString() + "Empty", "y");
        PlayerPrefs.SetString("Deck" + GameManager.deckNumber.ToString() + "Name", "");

        SetUpDeckEditor();

        areYouSure.SetActive(false);
        deckEditorButtons.SetActive(true);
    }

    public void OnClickNo()
    {
        areYouSure.SetActive(false);
        deckEditorButtons.SetActive(true);
    }

    void SetUpDeckEditor()
    {
        mainMenuButtons.SetActive(false);

        for (int temp = 0; temp <= 2; temp++)
        {
            if (PlayerPrefs.GetString("Deck" + (temp + 1).ToString() + "Empty") == "n")
            {
                deleteButtons[temp].GetComponent<Button>().interactable = true;
                decknames[temp].GetComponent<TextMeshProUGUI>().SetText(PlayerPrefs.GetString("Deck" + (temp + 1).ToString() + "Name"));
            }
            else
            {
                deleteButtons[temp].GetComponent<Button>().interactable = false;
                decknames[temp].GetComponent<TextMeshProUGUI>().SetText("New Deck");
            }
        }

        deckEditorButtons.SetActive(true);
    }

    void DeleteDeck(int number)
    {
        GameManager.deckNumber = number;

        deckEditorButtons.SetActive(false);
        areYouSure.SetActive(true);
    }

    void OpenDeck(int number)
    {
        GameManager.deckNumber = number;
        GameManager.lastMenuPage = 1;
        SceneManager.LoadScene("DeckEditor");
    }
}
