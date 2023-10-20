using System.Collections.Generic;
using UnityEngine;

public class Question : MonoBehaviour
{
   
    public string text = null;
    public List<Option> options = null;

    public void ShuffleOptions()
    {
        System.Random random = new System.Random();
        int n = options.Count;
        while (n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            Option value = options[k];
            options[k] = options[n];
            options[n] = value;
        }
    }
}
