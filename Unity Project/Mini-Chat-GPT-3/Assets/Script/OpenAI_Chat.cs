using UnityEngine;
using OpenAI_API;
using System.Threading.Tasks;
using UnityEngine.UI;
using TMPro;

public class OpenAI_Chat : MonoBehaviour
{
    private string m_apyKey = "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"; //authentification key
    public TextMeshProUGUI YourInput;
    public Image Neutral;
    public Image Happy;
    public Image Angry;

    private void Start()
    {
        //we set the neutral image.
        Happy.enabled = false;
        Angry.enabled = false;
    }
    public async Task StartAsync()
    {
        string iBriefing = new string("Is the sentence " + "\"" + YourInput.text + "\"" + " positive? Answer by YES or NO: "); //we use as prompt this string, in wich we put the user's input

        var api = new OpenAIAPI(m_apyKey, new Engine("text-davinci-001"));
        var result = await api.Completions.CreateCompletionAsync(iBriefing, max_tokens: 100, temperature: 0.1f, top_p: 0f); //create the request to GPT-3 and get the completion.

        //we set the image corresponding to the answer of GPT-3
        if (result.ToString().Contains("Yes"))
        {
            Neutral.enabled = false;
            Happy.enabled = true;
            Angry.enabled = false;
        }
        else if (result.ToString().Contains("No"))
        {
            Neutral.enabled = false;
            Happy.enabled = false;
            Angry.enabled = true;
        }
        else
        {
            Neutral.enabled = true;
            Happy.enabled = false;
            Angry.enabled = false;
        }
    }

    //we reload a new request every time the user change his input.
    public void Reload(string text)
    {
        var task = StartAsync();
    }

}
