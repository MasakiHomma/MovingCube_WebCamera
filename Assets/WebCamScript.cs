using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;

public class WebCamScript : MonoBehaviour {
	public int Width = 1920;
	public int Height = 1080;
	public int FPS = 30;//1秒間に何回WebCameraの画像を取得するかの変数

	public WebCamTexture webcamTexture;
	public Color[] pixelsDate;

	CubeScript cubeScript;

	void Start () {
		cubeScript = gameObject.GetComponent <CubeScript> ();

		WebCamDevice[] devices = WebCamTexture.devices;
		webcamTexture = new WebCamTexture(devices[0].name, Width, Height, FPS );
		webcamTexture.Play();
	}

	void Update () {
		for (int i = 0;i <= Mathf.Sqrt(cubeScript.gameObjeList.Count); i++) {
			for (int j = 0; j <= Mathf.Sqrt (cubeScript.gameObjeList.Count); j++) {
				pixelsDate = webcamTexture.GetPixels (	(int)(webcamTexture.width/
														Mathf.Sqrt (cubeScript.gameObjeList.Count)*i),
														(int)(webcamTexture.height/
														Mathf.Sqrt (cubeScript.gameObjeList.Count)*j),
														(int)(webcamTexture.width/Mathf.Sqrt (cubeScript.gameObjeList.Count)/1.1f),
														(int)(webcamTexture.width/Mathf.Sqrt (cubeScript.gameObjeList.Count)/1.1f) );
				Texture2D texture = new Texture2D(	(int)( webcamTexture.width/Mathf.Sqrt (cubeScript.gameObjeList.Count)/1.1f ),
													(int)( webcamTexture.height/Mathf.Sqrt (cubeScript.gameObjeList.Count)/1.1f )  );

				texture.SetPixels(pixelsDate);
				texture.Apply();

				cubeScript.gameObjeList[(  i*(int)( Mathf.Sqrt (cubeScript.gameObjeList.Count) )  )
										+j].GetComponent<Renderer> ().material.mainTexture = texture;
			}
		}
	}
}
