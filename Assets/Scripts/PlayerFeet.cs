using UnityEngine;
using System.Collections;

public class PlayerFeet : MonoBehaviour {

    private Player m_Player;

    void Start()
    {
        m_Player = GetComponentInParent<Player>();
	}
	
	void OnTriggerEnter2D(Collider2D col)
    {
        m_Player.SetGrounded(true);
    }

    void OnTriggerStay2D(Collider2D col)
    {
        m_Player.SetGrounded(true);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        m_Player.SetGrounded(false);
    }

}
