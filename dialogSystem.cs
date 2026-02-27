

using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class dialogSystem : MonoBehaviour
{
    public string[] lines;
    public float speedText;
    public static TMP_Text dialogText;

    public static int index;
    int stage;

    public AudioSource audioSource;
    public AudioClip[] voiceLines;

    private Coroutine typingCoroutine;

    void OnEnable()
    {
        if (audioSource != null)
            audioSource.Stop();
    }
    void Start()
    {
        dialogText.text = string.Empty;
        stage = GameManager.dialogStage;
        StartDialog();

    }

    void StartDialog()
    {
        PlayVoiceLine();
        typingCoroutine = StartCoroutine(TypeLine());

  
        CancelInvoke();


        float interval = 5f; 
        if (audioSource != null && audioSource.clip != null)
            interval = audioSource.clip.length;
    
        InvokeRepeating("scipText", interval, interval);
    }

    public void scipText()
    {
        if (dialogText.text == lines[index] || dialogText.text == "")
        {
            NextLines();
        }
        else
        {
            StopCoroutine(typingCoroutine);
            dialogText.text = lines[index];
            PlayVoiceLine();
        }
    }

    private void NextLines()
    {
        if (index < stage - 1)
        {
            index++;
            dialogText.text = string.Empty;

            PlayVoiceLine();
            typingCoroutine = StartCoroutine(TypeLine());

            CancelInvoke();
            float interval = 5f;
            if (audioSource != null && audioSource.clip != null)
                interval = audioSource.clip.length;

            InvokeRepeating("scipText", interval, interval);
        }
        else
        {
            CancelInvoke();
            Invoke("scipText", 0.1f);
            dialogText.text = "";
            gameObject.SetActive(false);
        }
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            dialogText.text += c;
            yield return new WaitForSeconds(speedText);
        }
    }

    void PlayVoiceLine()
    {
        if (voiceLines != null && index < voiceLines.Length && audioSource != null && voiceLines[index] != null)
        {
            audioSource.Stop();
            audioSource.clip = voiceLines[index];
            audioSource.Play();
        }
    }

    void Update()
    {
        stage = GameManager.dialogStage;
    }
}
