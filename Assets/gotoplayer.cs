
using UnityEngine;

public class gotoplayer : MonoBehaviour {

    public Transform player;
    public Vector3 offset;
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(player.position.x, 0, 0)+offset;
    }
}
