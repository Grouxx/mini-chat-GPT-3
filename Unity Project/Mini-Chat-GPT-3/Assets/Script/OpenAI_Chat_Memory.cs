using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using OpenAI_API;

public class OpenAI_Chat_Memory : MonoBehaviour
{
    private string m_apyKey = "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";
    public async Task StartAsync()
    {
        //string iBriefing = new string("Is the sentence " + "\"" + YourInput.text + "\"" + " positive? Answer by YES or NO: ");

        var api = new OpenAIAPI(m_apyKey, new Engine("text-davinci-001"));
        var result = await api.Completions.CreateCompletionAsync("Yes", max_tokens: 100, temperature: 0.1f, top_p: 0f);
    }

        // Update is called once per frame
        void Update()
    {
        
    }
}
