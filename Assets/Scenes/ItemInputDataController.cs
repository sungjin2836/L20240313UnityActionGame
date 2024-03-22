using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInputDataController : MonoBehaviour
{

    public Text ResultText;
    public InputField inputData;
    public string Input = "";
   
    public void ItemDictionary()
    {
        Input = inputData.GetComponent<InputField>().text;
        Dictionary<string, string> item = new Dictionary<string, string>();
        Debug.Log(Input);

        item.Add("Name", Input.ToString());
        item.Add("Att", name);
        item.Add("Def", name);
        item.Add("Lev", name);
        item.Add("Ability", name);
        item.Add("Explan", name);

        ResultText.text = item["Name"];
        ResultText.text += item["Att"];
        ResultText.text += item["Def"];
        ResultText.text += item["Lev"];
        ResultText.text += item["Ability"];
        ResultText.text += item["Explan"];

        foreach (var Value in item.Values)
        {
            Debug.Log(Value);
        }
       

    }

    public void ItemData()
    {
        ResultText.text = "";
    }
}
