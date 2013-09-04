using UnityEngine;
using System.Collections;

public class Arc : MonoBehaviour {

//	var sections : float = 10.0; // should be float for division purposes
//private var lineRenderer : LineRenderer;
//	function Start(){    
//	lineRenderer = GetComponent(LineRenderer);
//	lineRenderer.SetVertexCount(sections);
//}
//
//function GetQuadraticCoordinates(t : float , p0 : Vector3 , c0 : Vector3 , p1 : Vector3 ) : Vector3 {
//	return Mathf.Pow(1-t,2)*p0 + 2*t*(1-t)*c0 + Mathf.Pow(t,2)*p1 ;;
//}
//
//function Plot( p0 : Vector3 , c0 : Vector3 , p1 : Vector3 ) {
//   var t : float ;    
//   for (var i : int = 0 ; i < sections ; i++ ){
//      t = i/(sections-1) ;
//      lineRenderer.SetPosition (i ,GetQuadraticCoordinates(t , p0 , c0 , p1 ));
//   }
//}
//	________________________________________________________________________________________________________
//	var start   : Transform ;
//var middle  : Transform ;
//var end 	: Transform ;
//var maxHeight : float = 200;
//
//private var bezier : Bezier ;
//
//function Start(){
//	bezier = GetComponent(Bezier);
//}
//
//function Update(){
//	var mousePos = Input.mousePosition; 
//	var yPosition : float ;
//	yPosition = Mathf.Min( Screen.height , Mathf.Max(mousePos.y,0) ); 
//	
//	middle.position.y =  ( yPosition / Screen.height ) * maxHeight ;
//	Debug.DrawLine(start.position,middle.position,Color.red);
//	Debug.DrawLine(middle.position,end.position,Color.red);
//	Debug.DrawLine(start.position,end.position,Color.red);
//	bezier.Plot(start.position , middle.position , end.position );
//}
//	
	
	void PlotPoints()
	{
//		float t;
//		for(int i=0; i < sections;i++)
//		{
//			
//			//t is used when getting quadratic coordinates
//			// this/(total number of sections -1) % of the way through the line?
//			//t = i/(sections-1);
//			//lineRenderer.SetPosition(i, GetCoords(t, start, middle, end));
//		}
	}
		
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		// read this from the inside out:
			//First, take whichever is larger mousepos.y or 0 (keeps the mouse height above zero)
			//Next, if mouse is above zero, take whichever is lower screen height or mousepos.y (keeps mouse height from being above screen)
		//	yPosition = Mathf.Min( Screen.height , Mathf.Max(mousePos.y,0) ); 
		
		// max height is the screen's height -> if y position is zero, so is the middleposition (relative to the parabola
		// if y position is equal to screen height, then the parabola's height is it max as well
		//	middle.position.y =  ( yPosition / Screen.height ) * maxHeight ;
		
		
	}
}
