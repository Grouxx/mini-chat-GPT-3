using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenAI;


public class TestOpenAI : MonoBehaviour
{
    string m_Apikey = "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";

    // Start is called before the first frame update
    void Start()
    {
       var api = new OpenAIClient(m_Apikey);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
