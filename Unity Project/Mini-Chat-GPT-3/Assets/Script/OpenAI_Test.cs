using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenAI_API;
using System.Threading.Tasks;
using System;

public class OpenAI_Test : MonoBehaviour
{
    string apiKeys = "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";
    public async
    void start()
    {
        var api = new OpenAI_API.OpenAIAPI(engine: Engine.Davinci);

        var result = await api.Completions.CreateCompletionAsync("One Two Three One Two", temperature: 0.1);
        Console.WriteLine(result.ToString());
        Debug.Log(result.ToString());
    }

    // Update is called once per frame
    void Update()
    {

    }
}
