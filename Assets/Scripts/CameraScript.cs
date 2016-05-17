using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class CameraScript : MonoBehaviour {

    WebCamTexture webcamTexture;
    public RawImage rawimage;
    void Start()
    {
        webcamTexture = new WebCamTexture();
        rawimage.texture = webcamTexture;
        rawimage.material.mainTexture = webcamTexture;
        webcamTexture.Play();

    }

    public void TakePhoto()
    {

        //yield return new WaitForSeconds(1);

        Texture2D photo = new Texture2D(webcamTexture.width, webcamTexture.height);
        photo.SetPixels(webcamTexture.GetPixels());
        photo.Apply();

        //Encode to a PNG
        byte[] bytes = photo.EncodeToPNG();
        //Write out the PNG. Of course you have to substitute your_path for something sensible
        File.WriteAllBytes(@"C:\Users\Caleb\Documents\Puzzles\Pictures\" + "photo.png", bytes);

        
    }

    public void OnDrawClick()
    {

    }
}
