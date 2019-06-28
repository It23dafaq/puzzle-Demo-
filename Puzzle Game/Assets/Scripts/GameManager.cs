using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameManager : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler,IPointerExitHandler
{ Button btn;
    List<string> _userletters = new List<string>();
    List<string> _secretletter = new List<string>();
    public List<string> _nameButton = new List<string>();
    public string finalletter = "";
    [SerializeField]
    public GameObject _gameobjVertical;
    [SerializeField]
    public GameObject _gameobjHorrizontal;

   public int _counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        _secretletter.Add("ΑΝ");
        _secretletter.Add("Α Ν Ω");
        _secretletter.Add("ΠΩΝΑ");
       
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging"+ eventData.pointerCurrentRaycast.gameObject.name);
        Debug.Log(eventData.pointerCurrentRaycast.gameObject.GetComponentInChildren<Text>().text);
        eventData.pointerCurrentRaycast.gameObject.GetComponentInChildren<Text>();
        
       
       // Debug.Log("pointer enter"+eventData.pointerEnter.gameObject.GetComponentInChildren<RawImage>());
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
     //   finalletter = "Α Ν Ω";
        _userletters.Add(finalletter);
        Debug.Log(finalletter);
        if (_secretletter.Contains(finalletter))
        {
            Debug.Log("im here");
            SetObjectVertical();
        }
        Debug.Log("Drag Ended");
        finalletter = "";
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
      
    }
    public void SetObjectHorizontal()
    {
        

        foreach (Text txt in _gameobjHorrizontal.GetComponentsInChildren<Text>())
        {
            string trimWord = finalletter.Split(' ')[_counter];
            txt.text = trimWord;
           


        }
        _counter = 0;

    }
    public void SetObjectVertical()
    {


        foreach (Text txt in _gameobjVertical.GetComponentsInChildren<Text>())
        {
            string trimWord = finalletter.Split(' ')[_counter];
            txt.text = trimWord;



        }
        _counter = 0;

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        finalletter = finalletter + eventData.pointerCurrentRaycast.gameObject.GetComponentInChildren<Text>().text;
    }
}
