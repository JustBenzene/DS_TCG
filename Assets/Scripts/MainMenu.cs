using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject mainMenuButtons;
    [SerializeField] GameObject deckEditorButtons;
    [SerializeField] GameObject chooseDeckButtons;

    [SerializeField] GameObject buttons;
    [SerializeField] GameObject title;

    [SerializeField] GameObject deck1;
    [SerializeField] GameObject deck2;
    [SerializeField] GameObject deck3;
    [SerializeField] GameObject editDeck;

    private void Start()
    {
        float temp = 875 + (0.75f - (float)GameManager.aspectRatio) * 1700f;
        title.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, temp);

        temp = 650 + (0.75f - (float)GameManager.aspectRatio) * 1400f;
        buttons.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, temp);
    }

    public void OnClickNewGame()
    {
        Debug.Log("Clicked on New Game");
    }

    public void OnClickLoadGame()
    {
        Debug.Log("Clicked on Load Game");
    }

    public void OnClickDecks()
    {
        Debug.Log("Clicked on Decks");

        mainMenuButtons.gameObject.SetActive(false);

        if ((PlayerPrefs.GetString("Deck1Empty") == "False") || (PlayerPrefs.GetString("Deck2Empty") == "False") || (PlayerPrefs.GetString("Deck3Empty") == "False"))
        {
            editDeck.GetComponent<Button>().interactable = true;
        }
        else
        {
            editDeck.GetComponent<Button>().interactable = false;
        }

        deckEditorButtons.gameObject.SetActive(true);
    }

    public void OnClickOptions()
    {
        Debug.Log("Clicked on Options");
    }

    public void OnClickNewDeck()
    {
        Debug.Log("Clicked on New Deck");

        GameManager.deckNumber = 0;
        SceneManager.LoadScene("DeckEditor", LoadSceneMode.Additive);
    }

    public void OnClickEditDeck()
    {
        Debug.Log("Clicked on Edit Deck");

        deckEditorButtons.gameObject.SetActive(false);

        if (PlayerPrefs.GetString("Deck1Empty") == "False")
        {
            deck1.GetComponent<Button>().interactable = true;
        }
        else
        {
            deck1.GetComponent<Button>().interactable = false;
        }
        if (PlayerPrefs.GetString("Deck2Empty") == "False")
        {
            deck2.GetComponent<Button>().interactable = true;
        }
        else
        {
            deck2.GetComponent<Button>().interactable = false;
        }
        if (PlayerPrefs.GetString("Deck3Empty") == "False")
        {
            deck3.GetComponent<Button>().interactable = true;
        }
        else
        {
            deck2.GetComponent<Button>().interactable = false;
        }

        chooseDeckButtons.gameObject.SetActive(true);
    }

    public void OnClickBack()
    {
        Debug.Log("Clicked on Back");

        deckEditorButtons.gameObject.SetActive(false);
        mainMenuButtons.gameObject.SetActive(true);
    }

    public void OnClickDeck1()
    {
        Debug.Log("Clicked on Deck 1");

        GameManager.deckNumber = 1;
        SceneManager.LoadScene("DeckEditor", LoadSceneMode.Additive);
    }

    public void OnClickDeck2()
    {
        Debug.Log("Clicked on Deck 2");

        GameManager.deckNumber = 2;
        SceneManager.LoadScene("DeckEditor", LoadSceneMode.Additive);
    }

    public void OnClickDeck3()
    {
        Debug.Log("Clicked on Deck 3");

        GameManager.deckNumber = 3;
        SceneManager.LoadScene("DeckEditor", LoadSceneMode.Additive);
    }

    public void OnClickBack2()
    {
        Debug.Log("Clicked on Back");

        chooseDeckButtons.gameObject.SetActive(false);

        if ((PlayerPrefs.GetString("Deck1Empty") == "False") || (PlayerPrefs.GetString("Deck2Empty") == "False") || (PlayerPrefs.GetString("Deck3Empty") == "False"))
        {
            editDeck.GetComponent<Button>().interactable = true;
        }
        else
        {
            editDeck.GetComponent<Button>().interactable = false;
        }

        deckEditorButtons.gameObject.SetActive(true);
    }
}
