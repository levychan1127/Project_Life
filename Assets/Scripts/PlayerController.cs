using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private float stateChangeTimer = 0;
    private Animator animator;
    private FileReadTest fileRead;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        fileRead = GetComponent<FileReadTest>();
        fileRead.Read();
    }
	
	// Update is called once per frame
	void Update () {
        if (stateChangeTimer > 3.0f)
        {            
            stateChangeTimer = 0;
        }
        stateChangeTimer += Time.deltaTime;
	}

}
