using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text;

[System.Serializable]
public class DialogueChoice
{
    public string choiceText;
    public int targetLineIndex;
}

[System.Serializable]
public class DialogueLine
{
    public string speakerName;
    [TextArea(3, 5)] public string text;
    public Sprite portraitSprite;

    [Header("Branching (Optional)")]
    public bool endDialogueAfterThisLine;
    public int nextLineOverride = -1;
    public List<DialogueChoice> choices;
}

public class Scene01Events : MonoBehaviour
{
    [Header("UI Components")]
    public CanvasGroup dialoguePanelGroup;
    public TextMeshProUGUI nameBox;
    public TextMeshProUGUI textBox;
    public Image portraitDisplay;

    [Header("Choice UI")]
    public Transform choiceButtonContainer;
    public GameObject choiceButtonPrefab;

    [Header("Settings")]
    public List<DialogueLine> dialogueLines;
    public float typingSpeed = 0.04f;

    private Coroutine dialogueCoroutine;
    private int currentLineIndex = 0;
    private bool isLineComplete = false;
    private bool skipRequested = false;
    private bool isWaitingForChoice = false;
    private bool isDialogueStarted = false;

    void Start()
    {
        SetUIVisibility(false);
        ClearUI();
    }

    void Update()
    {
        if (!isDialogueStarted)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartDialogue();
            }
            return;
        }

        if (isWaitingForChoice) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isLineComplete)
            {
                skipRequested = true;
            }
            else
            {
                AdvanceDialogue();
            }
        }
    }

    void StartDialogue()
    {
        if (dialogueLines != null && dialogueLines.Count > 0)
        {
            isDialogueStarted = true;
            currentLineIndex = 0;

            SetUIVisibility(true);

            dialogueCoroutine = StartCoroutine(PlayDialogueRoutine());
        }
    }

    IEnumerator PlayDialogueRoutine()
    {
        StringBuilder stringBuilder = new StringBuilder();
        DialogueLine currentLine = dialogueLines[currentLineIndex];

        if (nameBox != null)
        {
            nameBox.text = currentLine.speakerName;
        }

        if (portraitDisplay != null)
        {
            portraitDisplay.sprite = currentLine.portraitSprite;
            portraitDisplay.gameObject.SetActive(currentLine.portraitSprite != null);
        }

        textBox.text = "";
        stringBuilder.Clear();
        isLineComplete = false;
        skipRequested = false;

        for (int j = 0; j < currentLine.text.Length; j++)
        {
            if (skipRequested)
            {
                textBox.text = currentLine.text;
                break;
            }
            stringBuilder.Append(currentLine.text[j]);
            textBox.text = stringBuilder.ToString();
            yield return new WaitForSeconds(typingSpeed);
        }

        isLineComplete = true;

        if (currentLine.choices != null && currentLine.choices.Count > 0)
        {
            DisplayChoices(currentLine);
        }
    }

    void DisplayChoices(DialogueLine currentLine)
    {
        isWaitingForChoice = true;

        foreach (Transform child in choiceButtonContainer)
        {
            Destroy(child.gameObject);
        }

        foreach (DialogueChoice choice in currentLine.choices)
        {
            GameObject newButton = Instantiate(choiceButtonPrefab, choiceButtonContainer);
            TextMeshProUGUI buttonText = newButton.GetComponentInChildren<TextMeshProUGUI>();
            if (buttonText != null) buttonText.text = choice.choiceText;

            Button btnComponent = newButton.GetComponent<Button>();
            if (btnComponent != null)
            {
                btnComponent.onClick.AddListener(() => OnChoiceSelected(choice.targetLineIndex));
            }
        }
    }

    void OnChoiceSelected(int targetLineIndex)
    {
        isWaitingForChoice = false;

        foreach (Transform child in choiceButtonContainer)
        {
            Destroy(child.gameObject);
        }

        currentLineIndex = targetLineIndex;

        if (currentLineIndex >= 0 && currentLineIndex < dialogueLines.Count)
        {
            if (dialogueCoroutine != null) StopCoroutine(dialogueCoroutine);
            dialogueCoroutine = StartCoroutine(PlayDialogueRoutine());
        }
        else
        {
            EndDialogue();
        }
    }

    void AdvanceDialogue()
    {
        DialogueLine currentLine = dialogueLines[currentLineIndex];

        if (currentLine.endDialogueAfterThisLine)
        {
            EndDialogue();
            return;
        }

        if (currentLine.nextLineOverride != -1)
        {
            currentLineIndex = currentLine.nextLineOverride;
        }
        else
        {
            currentLineIndex++;
        }

        if (currentLineIndex < dialogueLines.Count)
        {
            if (dialogueCoroutine != null) StopCoroutine(dialogueCoroutine);
            dialogueCoroutine = StartCoroutine(PlayDialogueRoutine());
        }
        else
        {
            EndDialogue();
        }
    }

    void EndDialogue()
    {
        isDialogueStarted = false;

        ClearUI();
        SetUIVisibility(false);

        Debug.Log("Stopped Speaking");
    }

    void ClearUI()
    {
        if (textBox != null) textBox.text = "";
        if (nameBox != null) nameBox.text = "";
        if (portraitDisplay != null) portraitDisplay.gameObject.SetActive(false);
    }

    void SetUIVisibility(bool visible)
    {
        if (dialoguePanelGroup != null)
        {
            dialoguePanelGroup.alpha = visible ? 1f : 0f;
            dialoguePanelGroup.blocksRaycasts = visible;
            dialoguePanelGroup.interactable = visible;
        }
    }
}
