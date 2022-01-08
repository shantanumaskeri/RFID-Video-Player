using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class RFIDCardReader : MonoBehaviour
{

	public GameObject sceneObject;

	private string this_card_id_temp;
	private string this_card_id;
	private readonly List<string> cardIds = new List<string>();
    private readonly List<string> videoNames = new List<string>();

	// Start is called before the first frame update
	private void Start()
    {
        ReadDataFromFile();
    }

    // Update is called once per frame
    private void Update()
    {
        ReadDataFromReader();
    }

	private void ReadDataFromFile()
	{
		string file1 = Application.dataPath + "/../Videos/DO_NOT_DELETE_ID.txt";

		if (!File.Exists(file1))
		{
			return;
		}
		else
		{
			StreamReader reader = new StreamReader(file1);

			while (!reader.EndOfStream)
			{
				string fileContents = reader.ReadLine();
				string[] lines = fileContents.Split(',');

				cardIds.Add(lines[0]);
				cardIds.Add(lines[1]);
				cardIds.Add(lines[2]);
			}

			reader.Close();
		}

		string file2 = Application.dataPath + "/../Videos/DO_NOT_DELETE_VIDEO.txt";

		if (!File.Exists(file2))
		{
			return;
		}
		else
		{
			StreamReader reader = new StreamReader(file2);

			while (!reader.EndOfStream)
			{
				string fileContents = reader.ReadLine();
				string[] lines = fileContents.Split(',');

				videoNames.Add(lines[0]);
				videoNames.Add(lines[1]);
				videoNames.Add(lines[2]);
			}

			reader.Close();
		}
	}

	private void ReadDataFromReader()
	{
		string inputstring = Input.inputString;

		inputstring = inputstring.Trim();

		if (inputstring.Length > 0)
		{
			this_card_id_temp += inputstring;
			this_card_id_temp = this_card_id_temp.Trim();
			
			if (this_card_id_temp.Length >= 10) 
			{
				this_card_id = this_card_id_temp;
				this_card_id_temp = "";

				CheckIdToLoadSceneVideo();
			}
		}
	}

    private void CheckIdToLoadSceneVideo()
    {
		string activeSceneName = SceneManager.GetActiveScene().name;

		if (this_card_id == cardIds[0])
		{
            if (activeSceneName != videoNames[0])
            {
				sceneObject.GetComponent<AutoSceneHandler>().nextScene = videoNames[0];
				sceneObject.GetComponent<AutoSceneHandler>().enabled = true;
			}
		}
		if (this_card_id == cardIds[1])
		{
			if (activeSceneName != videoNames[1])
			{
				sceneObject.GetComponent<AutoSceneHandler>().nextScene = videoNames[1];
				sceneObject.GetComponent<AutoSceneHandler>().enabled = true;
			}
		}
		if (this_card_id == cardIds[2])
		{
			if (activeSceneName != videoNames[2])
			{
				sceneObject.GetComponent<AutoSceneHandler>().nextScene = videoNames[2];
				sceneObject.GetComponent<AutoSceneHandler>().enabled = true;
			}
		}
    }

}
