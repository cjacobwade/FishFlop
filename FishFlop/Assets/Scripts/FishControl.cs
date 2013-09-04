using UnityEngine;
using System.Collections;

public class FishControl : MonoBehaviour {
	
	bool touchFish = false, grounded = false;
	Vector3 startPos, endPos, currentTouch, moveDirection;
	float dragDistance;
	public LayerMask playerLayer;
	public ParticleSystem bubbles;
	// Use this for initialization
	void Start () 
	{
		print (Physics.gravity);
		Physics.gravity = new Vector3(0,-40,0);
	}
	
	// Update is called once per frame
	void Update () 
	{
		MouseInput();//Also works on touch screens apparently
		DevControls();
	}
	
	void MouseInput()
	{
		if(grounded)
		{
			if(Input.GetMouseButton(0))
			{
				if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),1000,playerLayer))
				{
					touchFish = true;
					startPos = transform.position;
					print (startPos);
				}
			}
		}
		if(Input.GetMouseButtonUp(0))
		{
			if(touchFish)	
			{
				//endPos = Input.mousePosition;
				moveDirection = transform.position - currentTouch; //moveDirection = startPos - currentTouch;
				moveDirection.x = Mathf.Clamp(moveDirection.x,-7,7);
				moveDirection.y = Mathf.Clamp(moveDirection.y,-9,9);
				rigidbody.AddForceAtPosition(moveDirection*200,endPos);
				//rigidbody.AddForceAtPosition(moveDirection *100,currentTouch);
				startPos = Vector3.zero;
				touchFish = false;
				print (moveDirection);
			}
		}
	
		if(touchFish)
		{
			endPos = Input.mousePosition;
			endPos = new Vector3(endPos.x,endPos.y,startPos.z);
			print (endPos);
			currentTouch = new Vector3(Camera.main.ScreenPointToRay(Input.mousePosition).origin.x,Camera.main.ScreenPointToRay(Input.mousePosition).origin.y,startPos.z);
			Debug.DrawLine(transform.position,currentTouch,Color.green);
//			currentTouch = new Vector3(startPos.x - currentTouch.x,startPos.y - currentTouch.y,startPos.z);
//			Debug.DrawLine(transform.position, currentTouch,Color.blue);
			Debug.DrawLine(startPos,endPos,Color.red);
		}
	}
	
	void DevControls()
	{
		if(Input.GetKey(KeyCode.R))
			Application.LoadLevel(Application.loadedLevel);
	}
	
	void DrawArc()
	{
		
	}
	
	//Line position
	//For each section of a line:
		//Point = Start pos + direction*section/(totalnumberofsections -1)
		//Point.y = Point.y - gravity
		//SetPosition of point
	
	void OnCollisionStay()
	{
		grounded = true;
		//print("WallHit");	
	}
	
	void OnCollisionExit()
	{
		grounded = false;
	}
}
