using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalDetector : MonoBehaviour
{

    AudioSource audioData;
    List<GameObject> alreadyUnder = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        audioData = gameObject.GetComponent<AudioSource>();
        audioData.volume = 0.03f;
    }
    
    // Update is called once per frame
    void Update()
    {
        foreach(GameObject go in GameObject.FindGameObjectsWithTag("Character"))
        {
            if(!alreadyUnder.Contains(go) && (go.transform.position - transform.position).sqrMagnitude < 0.3f)
            {
                audioData.Play(0);
                alreadyUnder.Add(go);
            }else if ((go.transform.position - transform.position).sqrMagnitude > 0.3f && alreadyUnder.Contains(go))
            {
                alreadyUnder.Remove(go);
            }
        }
}
}
