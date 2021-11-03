using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Ornament : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public GameObject panel;
    public string Title, Link;
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void OnPointerEnter(PointerEventData eventData)
    {

        gameObject.transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
        panel.SetActive(true);
        panel.GetComponent<PanelText>().Title.text = Title;
        


    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.transform.localScale = new Vector3(1, 1, 1);
        panel.SetActive(false);
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Application.OpenURL(Link);
    }
}
