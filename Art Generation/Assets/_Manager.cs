using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class _Manager : MonoBehaviour {

	List<float> red;
	List<float> green;
	List<float> blue;

	public static int IMG_WIDTH = 1024;
	public static int IMG_HEIGHT = 768;

	public GameObject thing;

	// Use this for initialization
	void Start () {

		//Initialize Lists
		red = new List<float> ();
		green = new List<float> ();
		blue = new List<float> ();

		//Generate Pixels
		art (5);

		//Create Texture
		Texture2D texture = new Texture2D (IMG_WIDTH, IMG_HEIGHT, TextureFormat.ARGB32, false);

		//Convert Pixels to Arrays
		float[] redArr = red.ToArray ();
		float[] greenArr = green.ToArray ();
		float[] blueArr = blue.ToArray ();

		//Set the Pixels of the Actual Texture
		for (int i = 0; i < IMG_WIDTH; i++) {
			for (int id = 0; id < IMG_HEIGHT; id++) {
				texture.SetPixel (i, id, new Color (redArr [i * IMG_HEIGHT + id], greenArr [i * IMG_HEIGHT + id], blueArr [i * IMG_HEIGHT + id]));
			}
		}

		//Apply the Pixels to the Texture
		texture.Apply ();

		//Apply the Texture to the Sprite on the Image
		thing.GetComponent<Image>().sprite = Sprite.Create(texture, new Rect(0, 0, IMG_WIDTH, IMG_HEIGHT), new Vector2(0.5f, 0.5f));
	}
	
	//Function for Generating the Pixels
	void art(int type) {

		switch (type) {
		//RANDOM PIXELS
		case(0):
		default:
			for (int i = 0; i < IMG_WIDTH; i++) {
				for (int id = 0; id < IMG_HEIGHT; id++) {
					red.Add (Random.Range (0.0f, 1.0f));
					green.Add (Random.Range (0.0f, 1.0f));
					blue.Add (Random.Range (0.0f, 1.0f));
				}
			}
			break;
		//ADDITION
		case(1):
			for (int i = 0; i < IMG_WIDTH; i++) {
				for (int id = 0; id < IMG_HEIGHT; id++) {
					red.Add ((float)((i * id + id) % 255) / 255);
					green.Add ((float)((i * id + i) % 255) / 255);
					blue.Add ((float)((i * id + id * id) % 255) / 255);
				}
			}
			break;
		//SUBTRACTION
		case(2):
			for (int i = 0; i < IMG_WIDTH; i++) {
				for (int id = 0; id < IMG_HEIGHT; id++) {
					red.Add ((float)((i * id - id) % 255) / 255);
					green.Add ((float)((i * id * i) % 255) / 255);
					blue.Add ((float)((i * id + id * id) % 255) / 255);
				}
			}
			break;
		//SINE
		case(3):
			for (int i = 0; i < IMG_WIDTH; i++) {
				for (int id = 0; id < IMG_HEIGHT; id++) {
					red.Add (Mathf.Sin(i) * (float)((i * id + id) % 255) / 255);
					green.Add (Mathf.Sin(id) * (float)((i * id + i) % 255) / 255);
					blue.Add (Mathf.Sin(i + id) * (float)((i * id + id * id) % 255) / 255);
				}
			}
			break;
		//TANGENT
		case(4):
			for (int i = 0; i < IMG_WIDTH; i++) {
				for (int id = 0; id < IMG_HEIGHT; id++) {
					red.Add (Mathf.Tan(i) * (float)((i * id + id) % 255) / 255);
					green.Add (Mathf.Tan(id) * (float)((i * id + i) % 255) / 255);
					blue.Add (Mathf.Tan(i + id) * (float)((i * id + id * id) % 255) / 255);
				}
			}
			break;
		//FOR ART
		case(5):
			for (int i = 0; i < IMG_WIDTH; i++) {
				for (int id = 0; id < IMG_HEIGHT; id++) {
					red.Add (Mathf.Tan(i * Mathf.Exp(id)) * (float)((i * id + id) % 255) / 255);
					green.Add (Mathf.Tan(id) * (float)((i * id + i * Mathf.Pow(id, i)) % 255) / 255);
					blue.Add (Mathf.Tan(i + id / Mathf.Log(i * id)) * (float)((i * id + id * id) % 255) / 255);
				}
			}
			break;
		}
	}
}
