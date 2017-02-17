using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UniRx;
using UniRx.Triggers;
using System.Linq;
using System.Collections.Generic;

public class CubeScript : MonoBehaviour {

	float x_Position = -11;
	float z_Position = -11;

	public List<GameObject> gameObjeList = new List <GameObject>();

	void Start () {

		while (x_Position <= 12.1f) {
			while (z_Position <= 12.1f) {
				var cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
				cube.transform.position = new Vector3 (x_Position, 0, z_Position);
				gameObjeList.Add (cube);

				z_Position += 1.1f;
			}
			x_Position += 1.1f;
			z_Position = -11;
		}

		Debug.Log (""+gameObjeList.Count);

//		this.UpdateAsObservable ()
//			.SkipUntil (__ => {
//				
//			})
//			.Subscribe (_ => {
//
//		});

//		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
//		RaycastHit hit = new RaycastHit ();
		    
	}
}
