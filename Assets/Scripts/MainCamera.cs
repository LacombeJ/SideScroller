using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {

    public Player m_Player;

	// Use this for initialization
	void Start()
    {
	    
	}
	
	// Update is called once per frame
	void Update()
    {
        transform.position = new Vector3(m_Player.transform.position.x,
            m_Player.transform.position.y, transform.position.z);
	}
}
