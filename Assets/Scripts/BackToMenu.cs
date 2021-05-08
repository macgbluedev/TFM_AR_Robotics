using System.Collections;
using System.Collections.Generic;
using Unity.Robotics.ROSTCPConnector;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
	public ROSConnection ros;
	public void BackMenu()
	{
		//ros.CloceTcpListener();
		SceneManager.LoadScene("MainMenu");
	}
}
