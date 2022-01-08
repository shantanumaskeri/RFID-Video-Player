using UnityEngine;
using UnityEngine.UI;

public class KeyboardDisplayManager : MonoBehaviour
{

	public GameObject keyboard;
	public GameObject canvas;
	public InputField last_focused_input_field;
	public Text dummy_text;
	
	// Update is called once per frame
	private void Update()
    {
    	PopulateTextInput();
	}

	public void OpenKeyboard()
	{
		keyboard.SetActive(true);
	}

	public void CloseKeyboard()
	{
		keyboard.SetActive(false);
	}

	private void PopulateTextInput()
	{
		foreach (InputField inputField in canvas.GetComponentsInChildren<InputField>())
	    {
		    if (inputField.isFocused == true)
            {
            	if (inputField != last_focused_input_field)
            	{
            		last_focused_input_field = inputField;
            		dummy_text.text = "";
            	}
		    }
	    }

	    if (last_focused_input_field)
        {
		    last_focused_input_field.text = dummy_text.text;
	    }
	}

}
