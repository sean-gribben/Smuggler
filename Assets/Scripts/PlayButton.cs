using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
	void OnMouseUp()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene(1);
	}
}
