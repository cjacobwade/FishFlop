using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	public GameObject player;
	Vector3 position, playerPosition, difference;
	public Vector2 maxDist;

	// Update is called once per frame
	void Update () 
	{
		//Used these to figure out camera controls
		CameraBounds();
		
	}
	
	void CameraBounds()
	{
		position = transform.position;
		playerPosition = player.transform.position;
		playerPosition.z = position.z;
		float xDist = position.x - playerPosition.x;
		float yDist = position.y - playerPosition.y;
		if(Mathf.Abs(xDist) > maxDist.x || Mathf.Abs(yDist) > maxDist.y) transform.position = Vector3.Lerp(position, playerPosition,Time.deltaTime*3);

	}
}