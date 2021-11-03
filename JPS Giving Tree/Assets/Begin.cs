using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Begin : MonoBehaviour
{
    string[] Rows;
    public GameObject[] ornamentList;
    // Start is called before the first frame update
    void Start()
    {

        // A correct website page.
        StartCoroutine(GetRequest("https://raw.githubusercontent.com/abeachJPS/GivingTree/main/GivingTree.csv"));

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);


                    var dataLines = webRequest.downloadHandler.text.Split('\n'); // Split also works with simple arguments, no need to pass char[]

                    Rows = dataLines;

                    for (int p = 0; p < Rows.Length - 2; p++)
                    {
                        ornamentList[p].SetActive(true);
                        ornamentList[p].GetComponent<Ornament>().Title = Rows[p+1].Split(',')[0];
                        ornamentList[p].GetComponent<Ornament>().Link = Rows[p + 1].Split(',')[1];
                    }

                    for (int i = 0; i < dataLines.Length; i++)
                    {
                        var data = dataLines[i].Split(',');
                        for (int d = 0; d < data.Length; d++)
                        {
                            print(data[d]); // what you get is split sequential data that is column-first, then row
                        }
                    }
                        break;
            }
        }
    }
}
