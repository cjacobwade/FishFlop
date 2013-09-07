using UnityEngine;
using System.Collections;

public class FishControl : MonoBehaviour {
	
	bool touchFish = false, grounded = false;
	Vector3 startPos, mousePos, currentTouch, moveDirection;
	public float sections, dropRate; //this is a float so I can divide
	float dragDistance;
	public LineRenderer aimArc;
	public LayerMask playerLayer;
	public GameObject box;
	// Use this for initialization
	void Start () 
	{
		print (Physics.gravity);
		Physics.gravity = new Vector3(0,-40,0);
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		Movement();//Also works on touch screens apparently
		DevControls();
	}
	
	void Movement()
	{
		box.transform.position = transform.position;
		box.transform.rotation = transform.rotation;
		if(grounded)
		{
			if(Input.GetMouseButtonDown(0))
			{
				if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),1000,playerLayer))
				{
					touchFish = true;
					startPos = transform.position;
				}
			}
		}
		if(Input.GetMouseButtonUp(0))
		{
			if(touchFish)	
			{
				moveDirection.x = Mathf.Clamp(moveDirection.x,-7,7);
				moveDirection.y = Mathf.Clamp(moveDirection.y,-9,9);
				rigidbody.AddForceAtPosition(moveDirection*200,mousePos);
				touchFish = false;
			}
		}
		if(touchFish)
		{
			mousePos = Input.mousePosition;
			mousePos.y = Mathf.Min( Screen.height , Mathf.Max(mousePos.y,0) );
			mousePos.x = Mathf.Min( Screen.width , Mathf.Max(mousePos.x,0) );
			currentTouch = new Vector3(Camera.main.ScreenPointToRay(mousePos).origin.x,Camera.main.ScreenPointToRay(mousePos).origin.y,startPos.z);
			Debug.DrawLine(transform.position,currentTouch,Color.green);
			moveDirection = transform.position - currentTouch; //moveDirection = startPos - currentTouch;
			moveDirection = Vector3.ClampMagnitude(moveDirection,15);
			DrawArc(moveDirection, currentTouch);
		}
		else aimArc.enabled = false;
	}
	
	void DevControls()
	{
		if(Input.GetKey(KeyCode.R)) Application.LoadLevel(Application.loadedLevel);
	}
	
	void DrawArc(Vector3 arcDirection, Vector3 touchPos)
	{	
		arcDirection.x = Mathf.Clamp(moveDirection.x,-23,23);
//		arcDirection.y = Mathf.Clamp(moveDirection.y,-7,20);
		Vector3 arcStart;
		float t;
		
		if(touchFish)
		{
			arcStart = transform.position;
			arcStart.z = 0.8f;
			aimArc.enabled = true;
			for(int i=0;i<sections;i++)
			{
				
				t = i/(sections-1);
				//variable = (condition) ? outcome1 : outcome2
				arcDirection.y = arcDirection.y > -4 ? arcDirection.y -= dropRate*(Mathf.Abs(arcStart.y - touchPos.y)/25)*i : arcDirection.y = -4;
				aimArc.SetPosition(i,arcStart + arcDirection*t);
			}
		}	
	}
	
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
