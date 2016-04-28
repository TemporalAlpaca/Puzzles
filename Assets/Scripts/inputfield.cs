using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class inputfield : MonoBehaviour {

        void Start()
        {
            var input = gameObject.GetComponent<InputField>();
            input.onEndEdit.AddListener(SubmitName);  
        }

        private void SubmitName(string arg0)
        {
            Debug.Log(arg0);
        }
}
