using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //CameraInit();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void CameraInit()
    {
        //float devHeight = 13.34f;
        float devWidth = 7.5f;
        float screenHeight = Screen.height;
        float orthographicSize = this.GetComponent<Camera>().orthographicSize;
        float aspectRatio = Screen.width * 1.0f / Screen.height;
        float cameraWidth = orthographicSize * 2 * aspectRatio;
        if (cameraWidth < devWidth)
        {
            orthographicSize = devWidth / (2 * aspectRatio);
            this.GetComponent<Camera>().orthographicSize = orthographicSize;
        }

    }
}
