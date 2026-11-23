using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PrototypeEvents : MonoBehaviour
{

    public GameObject fadeScreenIn;
    public GameObject Player;
    public GameObject LoveInterest1;
    public GameObject textBox;
    [SerializeField] GameObject charName;

    [SerializeField] string textToSpeak;
    [SerializeField] int currentTextLength;
    [SerializeField] int textLength;
    [SerializeField] GameObject mainTextObject;

    [SerializeField] GameObject nextButton;
    [SerializeField] GameObject option1;
    [SerializeField] GameObject option2;
    [SerializeField] GameObject option1text;
    [SerializeField] GameObject option2text;
    [SerializeField] int eventPos = 0;

    [SerializeField] GameObject option3;
    [SerializeField] GameObject option4;
    [SerializeField] GameObject option3text;
    [SerializeField] GameObject option4text;

    public Slider loveMetre;
    


    void Update()
    {
        textLength = TextCreator.charCount;
    }

    void Start()
    {
        loveMetre.value = 0f;
        StartCoroutine(EventStarter());
    }

    IEnumerator EventStarter()
    {
        //event 0
        //variables need to be set to false for delay to work
        Player.SetActive(false);
        LoveInterest1.SetActive(false);
        textBox.SetActive(false);
        mainTextObject.SetActive(false);
        nextButton.SetActive(false);
        option1.SetActive(false);
        option2.SetActive(false);
        option1text.SetActive(false);
        option2text.SetActive(false);

        option3.SetActive(false);
        option4.SetActive(false);
        option3text.SetActive(false);
        option4text.SetActive(false);
        //loveMetre.SetActive(false);


        //setting delays for player to appear
        yield return new WaitForSeconds(2);
        fadeScreenIn.SetActive(false);
        Player.SetActive(true);
        yield return new WaitForSeconds(2);

        //player text 
        mainTextObject.SetActive(true);
        textBox.SetActive(true);
        textToSpeak = "text goes here";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);

        nextButton.SetActive(true);
        eventPos = 1;

    }

    IEnumerator EventOne()
    {
        //event 1
        nextButton.SetActive(false);
        option1.SetActive(false);
        option2.SetActive(false);
        option1text.SetActive(false);
        option2text.SetActive(false);
        //loveMetre.SetActive(false);

        textBox.SetActive(true);
        LoveInterest1.SetActive(true);
        //loveMetre.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Love Interest";

        textToSpeak = "love interest text goes here";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);

        option1.SetActive(true);
        option2.SetActive(true);
        option1text.SetActive(true);
        option2text.SetActive(true);
        option1text.GetComponent<TMPro.TMP_Text>().text = "heyy";
        option2text.GetComponent<TMPro.TMP_Text>().text = "go away";

        eventPos = 2;

    }

    IEnumerator Option1Seq()
    {
        option1.SetActive(false);
        option2.SetActive(false);
        option1text.SetActive(false);
        option2text.SetActive(false);

        loveMetre.value = 0f;

        textBox.SetActive(true);
        LoveInterest1.SetActive(true);
        //loveMetre.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Love Interest";

        textToSpeak = "idk what to write here";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);



    }

    IEnumerator Option2Seq()
    {
        option1.SetActive(false);
        option2.SetActive(false);
        option1text.SetActive(false);
        option2text.SetActive(false);

        loveMetre.value = 2f;

        textBox.SetActive(true);
        LoveInterest1.SetActive(true);
        //loveMetre.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Love Interest";

        textToSpeak = "well that was mean";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);

        nextButton.SetActive(true);
        eventPos = 3;

    }

    IEnumerator EventThree()
    {
        nextButton.SetActive(false);
        option3.SetActive(false);
        option4.SetActive(false);
        option3text.SetActive(false);
        option4text.SetActive(false);

        loveMetre.value = 2f;

        textBox.SetActive(true);
        LoveInterest1.SetActive(true);
        //loveMetre.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Love Interest";

        textToSpeak = "why'd you have to say it like that";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);

        option3.SetActive(true);
        option4.SetActive(true);
        option3text.SetActive(true);
        option4text.SetActive(true);
        option3text.GetComponent<TMPro.TMP_Text>().text = "sorry just in a bad mood";
        option4text.GetComponent<TMPro.TMP_Text>().text = "im serious just leave me alone";

    }

    IEnumerator Option3Seq()
    {
        option1.SetActive(false);
        option2.SetActive(false);
        option1text.SetActive(false);
        option2text.SetActive(false);

        loveMetre.value = 1f;

        textBox.SetActive(true);
        LoveInterest1.SetActive(true);
        //loveMetre.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Love Interest";

        textToSpeak = "Awwwe, that's okay";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);

    }

IEnumerator Option4Seq()
    {
        eventPos = 4;

        option3.SetActive(false);
        option4.SetActive(false);
        option3text.SetActive(false);
        option4text.SetActive(false);
        nextButton.SetActive(true);

        loveMetre.value = 5f;

        textBox.SetActive(true);
        LoveInterest1.SetActive(true);
        //loveMetre.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Love Interest";

        textToSpeak = "FINE";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
    }    
    
    IEnumerator EventFour()
    {
        nextButton.SetActive(false);
        option3.SetActive(false);
        option4.SetActive(false);
        option3text.SetActive(false);
        option4text.SetActive(false);

        loveMetre.value = 5f;

        textBox.SetActive(true);
        LoveInterest1.SetActive(true);
        //loveMetre.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Love Interest";

        textToSpeak = "I'm leaving then";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
    }



     void NextButton()
    {
        if (eventPos == 1)
        {
            StartCoroutine(EventOne());
        }

        if (eventPos == 3)
        {
            StartCoroutine(EventThree());
        }

        if (eventPos == 4)
        {
            StartCoroutine(EventFour());
        }

    }

    public void Option1()
    {
        StartCoroutine(Option1Seq());
    }

    public void Option2()
    {
        StartCoroutine(Option2Seq());
    }

    public void Option3()
    {
        StartCoroutine(Option3Seq());
    }

    public void Option4()
    {
        StartCoroutine(Option4Seq());
    }

}
