using UnityEngine;
using System.Collections;

public class Ground : MonoBehaviour {

    public float m_Depth = 1;

	// Use this for initialization
	void Start () {
        transform.position = new Vector3(transform.position.x,transform.position.y,m_Depth);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
