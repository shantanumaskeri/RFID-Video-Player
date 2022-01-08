/***
 * Author: Yunhan Li 
 * Any issue please contact yunhn.lee@gmail.com
 ***/

using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace VRKeyboard.Utils 
{
    public class KeyboardManager : MonoBehaviour 
    {
        #region Public Variables
        
        [Header("User defined")]
        [Tooltip("If the character is uppercase at the initialization")]
        public bool isUppercase = false;
        public int maxInputLength;
 
        
        [Header("UI Elements")]
        public Text inputText;

        [Header("Essentials")]
        public Transform characters;

        #endregion

        #region Private Variables

        private string Input 
        {
            get { return inputText.text;  }
            set { inputText.text = value;  }
        }

        private Dictionary<GameObject, Text> keysDictionary = new Dictionary<GameObject, Text>();

        private bool capslockFlag = false;
        private bool shiftFlag = false;

        #endregion

        #region Monobehaviour Callbacks

        private void Awake() 
        {
            
            for (int i = 0; i < characters.childCount; i++) 
            {
                GameObject key = characters.GetChild(i).gameObject;
                Text _text = key.GetComponentInChildren<Text>();
                keysDictionary.Add(key, _text);

                key.GetComponent<Button>().onClick.AddListener(() => {
                    GenerateInput(_text.text);
                });
            }

            capslockFlag = isUppercase;
            CapsLock();

            shiftFlag = isUppercase;
            Shift();
        }

        #endregion

        #region Public Methods

        public void Backspace() 
        {
            if (Input.Length > 0) 
            {
                Input = Input.Remove(Input.Length - 1);
            } 
            else 
            {
                return;
            }
        }

        public void Clear() 
        {
            Input = "";
        }
       
        public void CapsLock() 
        {
            if (capslockFlag) 
            {
                foreach (var pair in keysDictionary) 
                {
                    pair.Value.text = ToUpperCase(pair.Value.text);
                }
            } 
            else 
            {
                foreach (var pair in keysDictionary) 
                {
                    pair.Value.text = ToLowerCase(pair.Value.text);
                }
            }

            capslockFlag = !capslockFlag;

        }
        
        public void Shift() 
        {
            if (shiftFlag)
            {
                 foreach (var pair in keysDictionary) 
                 {
                    pair.Value.text = ToUpperCase(pair.Value.text);
                    if(pair.Value.text == "1"){ pair.Value.text = "!";  }
                    if(pair.Value.text == "2"){ pair.Value.text = "@";  }
                    if(pair.Value.text == "3"){ pair.Value.text = "#";  }
                    if(pair.Value.text == "4"){ pair.Value.text = "$";  }
                    if(pair.Value.text == "5"){ pair.Value.text = "%";  }
                    if(pair.Value.text == "6"){ pair.Value.text = "^";  }
                    if(pair.Value.text == "7"){ pair.Value.text = "&";  }
                    if(pair.Value.text == "8"){ pair.Value.text = "*";  }
                    if(pair.Value.text == "9"){ pair.Value.text = "(";  }
                    if(pair.Value.text == "0"){ pair.Value.text = ")";  }
                    if(pair.Value.text == "-"){ pair.Value.text = "_";  }
                    if(pair.Value.text == "="){ pair.Value.text = "+";  }
                    if(pair.Value.text == "["){ pair.Value.text = "{";  }
                    if(pair.Value.text == "]"){ pair.Value.text = "}";  }
                    if(pair.Value.text == "\\"){ pair.Value.text = "|";  }
                    if(pair.Value.text == ";"){ pair.Value.text = ":";  }
                    if(pair.Value.text == "'"){ pair.Value.text = "\"";  }
                    if(pair.Value.text == ","){ pair.Value.text = "<";  }
                    if(pair.Value.text == "."){ pair.Value.text = ">";  }
                    if(pair.Value.text == "/"){ pair.Value.text = "?";  }
                 }
            }
            else
            {
                foreach (var pair in keysDictionary) 
                {
                    pair.Value.text = ToLowerCase(pair.Value.text);
                    if(pair.Value.text == "!"){ pair.Value.text = "1";  }
                    if(pair.Value.text == "@"){ pair.Value.text = "2";  }
                    if(pair.Value.text == "#"){ pair.Value.text = "3";  }
                    if(pair.Value.text == "$"){ pair.Value.text = "4";  }
                    if(pair.Value.text == "%"){ pair.Value.text = "5";  }
                    if(pair.Value.text == "^"){ pair.Value.text = "6";  }
                    if(pair.Value.text == "&"){ pair.Value.text = "7";  }
                    if(pair.Value.text == "*"){ pair.Value.text = "8";  }
                    if(pair.Value.text == "("){ pair.Value.text = "9";  }
                    if(pair.Value.text == ")"){ pair.Value.text = "0";  }
                    if(pair.Value.text == "_"){ pair.Value.text = "-";  }
                    if(pair.Value.text == "+"){ pair.Value.text = "=";  }
                    if(pair.Value.text == "{"){ pair.Value.text = "[";  }
                    if(pair.Value.text == "}"){ pair.Value.text = "]";  }
                    if(pair.Value.text == "|"){ pair.Value.text = "\\";  }
                    if(pair.Value.text == ":"){ pair.Value.text = ";";  }
                    if(pair.Value.text == "\""){ pair.Value.text = "'";  }
                    if(pair.Value.text == "<"){ pair.Value.text = ",";  }
                    if(pair.Value.text == ">"){ pair.Value.text = ".";  }
                    if(pair.Value.text == "?"){ pair.Value.text = "/";  }
                 }
            }

            shiftFlag = !shiftFlag;

        }

        #endregion

        #region Private Methods
        
        public void GenerateInput(string s) 
        {
            if (Input.Length > maxInputLength) { return; }
            Input += s;
        }

        private string ToLowerCase(string s) 
        {
            return s.ToLower();
        }

        private string ToUpperCase(string s) 
        {
            return s.ToUpper();
        }

        #endregion
    }
}