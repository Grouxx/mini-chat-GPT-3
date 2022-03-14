using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenAI_API;
using System.Threading.Tasks;
using UnityEngine.UI;
using TMPro;
using System;
using System.ComponentModel;

public class OpenAI_Test : MonoBehaviour
{
    private string m_apyKey = "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";
    public TextMeshProUGUI YourInput;
    //public TMP_InputField YourInputField;
    public Image Neutre;
    public Image Heureux;
    public Image Malheureux;
    private void Start()
    {
        //var task = StartAsync();
        Heureux.enabled = false;
        Malheureux.enabled = false;
    }
    public async Task StartAsync()
    {
        string iBriefing = new string("Is the sentence " + "\"" + YourInput.text + "\"" + " positive? Answer by YES or NO: ");

        var api = new OpenAIAPI(m_apyKey, new Engine ("text-davinci-001"));
        var result = await api.Completions.CreateCompletionAsync(iBriefing, max_tokens: 100, temperature: 0.1f, top_p: 0f); ;
        print("\"" + result + "\"");

        if (result.ToString().Contains("Yes"))
        {
            Neutre.enabled = false;
            Heureux.enabled = true;
            Malheureux.enabled = false;
            Debug.Log("cool");
        }
        else if (result.ToString().Contains("No"))
        {
            Neutre.enabled = false;
            Heureux.enabled = false;
            Malheureux.enabled = true;
            Debug.Log("pas cool");
        }
        else
        {
            Neutre.enabled = true;
            Heureux.enabled = false;
            Malheureux.enabled = false;
            Debug.Log("erreur");
        }
    }
    
    public void Reload(string text)
    {
        var task = StartAsync();
    }

}
