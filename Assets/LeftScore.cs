using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftScore : MonoBehaviour
{
    // Start is called before the first frame update
    int score;
    void Start()
    {
        score = 0;
        gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = score.ToString();
    }

    public void inc()
    {
        score += 1;
    }
}
