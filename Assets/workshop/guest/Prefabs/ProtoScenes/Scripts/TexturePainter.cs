using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TexturePainter : MonoBehaviour {

	[Range(1,128)]
	public int textureWidth = 16;
	[Range(1,128)]
	public int textureHeight = 16;

	//public Color foregroundColor = Color.green;
	public Color backgroundColor = Color.yellow;

	Texture2D texture;
	public bool trs = false;
	public int finish;

	public int cleanPix;
	public int cleanPix2;
	public int dirtyPix;

	// Use this for initialization
	void Start () {
		CreateTexture ();
		Fill (backgroundColor);


		//foregroundColor = Color.clear;
		//backgroundColor = Color.clear;
	}

	void Update () {
		//if (Input.GetKey (KeyCode.Mouse0))
			//OnMouseDown ();
		//IsTransparent ();

		//if (IsTransparent (true)) {
		//Debug.Log ("final");
		//}

		//if (trs == true) {
			//Color[] pixels = texture.GetPixels ();
			//for (int i = 0; i < pixels.Length; i++)
				//if (pixels[i] == Color.clear) {
					//Debug.Log ("finish2");	
					//Debug.Log ("finish");
				//}

	
		if (cleanPix > dirtyPix) {
			Debug.Log ("finish");
			Destroy (this.gameObject);
		}
	}

	void IsTransparent(){
		//cleanPix2 = cleanPix;
		for (int x = 0; x < texture.width; x++)
			for (int y = 0; y < texture.height; y++)
				if (texture.GetPixel (x, y) == Color.clear) {
					cleanPix = 1 + cleanPix;
					cleanPix2 = cleanPix - cleanPix2;
					//cleanPix = dirtyPix / cleanPix;
					//Debug.Log (cleanPix);
				} else {
					dirtyPix++;
					//dirtyPix = dirtyPix / cleanPix;
					//dirtyPix =  dirtyPix/dirtyPix;
					//Debug.Log (dirtyPix);
				}
		
	}

	//void IsTransparent ()
		//{
		//bool allsTransparent = true;
		//for (int x = 0;x <texture.width; x++){
		//	for(int y = 0; y < texture.height; y++)
				//if(texture.GetPixel(x,y) != Color.clear)
				//{
					// bool allsTransparent = false;

				//}
			
		//}

	//}


		//Color[] pixels = texture.GetPixels ();
		//for (int y = 0; y< 
		//for (int x = 0; x < texture.width; x++)
			//for (int y = 0; y < texture.height; y++)
				//if (pixels.Length = Color.clear) {
					//Debug.Log ("finish2");
				//}

				//if (texture.GetPixel (x, y) == Color.clear) {
					//trs = true;
				//} else {
					//trs = false;
				//}
	//}
		



	void CreateTexture(){
		texture = new Texture2D (textureWidth, textureHeight);
		texture.filterMode = FilterMode.Trilinear;
		GetComponent<MeshRenderer> ().material.SetTexture ("_MainTex", texture);
	}

	void Fill(Color color){
		Color[] pixels = texture.GetPixels ();
		for (int i = 0; i < pixels.Length; i++) {
			pixels [i] = color;
			//trs = true;

			//if (pixels [i] == Color.clear) {
				//Debug.Log ("test");
				//trs = true;
			//}
		}

		texture.SetPixels (pixels);
		texture.Apply ();
	}

	void OnMouseDown()
	{
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hitInfo;
		if (Physics.Raycast (ray, out hitInfo)) {
			var pixelCoords = uv2PixelCoords (hitInfo.textureCoord);
			//Stroke (pixelCoords, foregroundColor);
			Stroke (pixelCoords, Color.clear);

			//bool IsTransparent;

			IsTransparent ();
		}
	}

	void Stroke(Vector2Int pixelCoords, Color color)
	{
		texture.SetPixel (pixelCoords.x, pixelCoords.y, color);

		texture.Apply ();
	}

	Vector2Int uv2PixelCoords(Vector2 uv)
	{
		int x = Mathf.FloorToInt(uv.x * textureWidth);
		int y = Mathf.FloorToInt(uv.y * textureHeight);
		return new Vector2Int (x, y);
	}

	// Update is called once per frame

}
