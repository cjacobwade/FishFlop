using UnityEngine;
using System.Collections;

public class FishControl : MonoBehaviour {
	
	bool touchFish = false;
	Vector3 startPos, endPos, moveDirection;
	float dragDistance;
	public LayerMask playerLayer;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		TouchInput();
	}
	
	void TouchInput()
	{
		Vector3 currentTouch;
		if(Input.GetMouseButton(0))
		{
			if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),1000,playerLayer))
			{
				touchFish = true;
				startPos = transform.position;
			}
		}
		if(Input.GetMouseButtonUp(0))
		{
			if(touchFish)	
			{
				endPos = Input.mousePosition;
				dragDistance = Mathf.Clamp(Vector3.Distance(startPos,endPos),0,5);
				moveDirection = startPos - endPos;
				print (dragDistance);
				
				rigidbody.AddRelativeForce(-transform.right*5);
				startPos = Vector3.zero;
				touchFish = false;
			}
		}

		if(touchFish)
		{
			currentTouch = new Vector3(Camera.main.ScreenPointToRay(Input.mousePosition).origin.x,Camera.main.ScreenPointToRay(Input.mousePosition).origin.y,startPos.z);
			Debug.DrawLine(startPos,currentTouch);
		}
	}
}
