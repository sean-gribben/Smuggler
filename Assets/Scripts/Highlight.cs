using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour
{
	TextMesh text;
	void Start()
	{
		text = GetComponent<TextMesh>();
	}

    void OnMouseEnter()
    {
        text.color = Color.red;
    }

    void OnMouseExit()
    {
        text.color = Color.white;
    }
}
