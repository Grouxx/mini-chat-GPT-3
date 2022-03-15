using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using OpenAI_API;
using System.Text;
using TMPro;

public class OpenAI_Chat_Memory : MonoBehaviour
{
    private string m_apyKey = "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";
    public TextMeshProUGUI YourInput;
    private StringBuilder memory;
    //public TextMeshProUGUI ResumeTextbox;

    public async Task StartAsync()
    {

        var api = new OpenAIAPI(m_apyKey, new Engine("text-davinci-001"));
        var result = await api.Completions.CreateCompletionAsync(YourInput.text, max_tokens: 100, temperature: 0.1f, top_p: 0f);
        //await api.Completions.StreamCompletionAsync(new CompletionRequest("My name is Roger and I am a principal software engineer at Salesforce.  This is my resume:", 200, 0.5, presencePenalty: 0.1, frequencyPenalty: 0.1), res => ResumeTextbox.text += res.ToString());
        Debug.Log(result);
        memory.Append(result.ToString());
    }

    public void AddToMemory(string text)
    {
        var task = StartAsync();
        Debug.Log(memory);
    }
}
