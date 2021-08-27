using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class SaveLoadKmToTxt : MonoBehaviour
{
    public Text inputFieldTxt;

    // Start is called before the first frame update
    void Start()
    {
        Directory.CreateDirectory(Application.streamingAssetsPath + "/Km Test/");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateTxt()
    {
        if (inputFieldTxt.text == "")
        {
            return;
        }

        //Path of the file
        string txtDocumentionName = Application.streamingAssetsPath + "/Km Test/" + "Kilo" + ".txt";
        //Create File if it doesn't exist
        if (!File.Exists(txtDocumentionName)) 
        {
            File.WriteAllText(txtDocumentionName, "Testas \n\n");
        }
        //Content of the file
        string content = inputFieldTxt.text;
        
        //Add some to text to it
        File.AppendAllText(txtDocumentionName, content + "\n");
    }


}
