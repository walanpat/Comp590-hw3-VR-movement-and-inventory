using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelectionScript : MonoBehaviour
{
    //code was received from tutorial  https://www.youtube.com/watch?v=_yf5vzZ2sYE
    [SerializeField] private Material highlight;
    [SerializeField] private string selectableTag = "Selectable";
    [SerializeField] private Material defaultMaterial;

        public float score=0;
        //gamersRiseUp is our text mesh for inventory
        public TextMeshPro gamersRiseUp;
        //My name is displayed here
        public TextMeshPro name;
        // tells you how many points you have (1 for each collected object, possible total of 20);
        public TextMeshPro scoreCard;

    public List<string> inventory = new List<string>();

    private Transform _selection;
    // Start is called before the first frame update
    void Start()
    {
        scoreCard.text = "score: " + score;
        gamersRiseUp.text = "Inventory:  ";
    }

    // Update is called once per frame
    void Update()
    {
        if(_selection!=null){
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;
            _selection = null;
        }
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit)){
            var selection = hit.transform;
            if(selection.CompareTag(selectableTag)){

                 var selectionRenderer = selection.GetComponent<Renderer>();
                
                    if(selectionRenderer != null){
                
                        selectionRenderer.material = highlight;
                    }
                        _selection = selection;
                        if(Input.GetKeyDown("space")){
                            //find a way to properly delete without major issues, for some reason
                            //our current destroy is fucking whack.
                            //Write code to delete this object and add it to your inventory.
                           
                           
                            inventory.Add(hit.collider.gameObject.name);
                            gamersRiseUp.text += " " + hit.collider.gameObject.name +  " ";
                            score += 1 ;
                            scoreCard.text = "score: " + score;
                            Destroy(hit.collider.gameObject);

                            Debug.Log("Inventory: ");

                            for(int  i = 0 ; i < inventory.Count; i++){
                                Debug.Log(inventory[i]);
                            }


                            
                            
                        }
                        
            }
        }
    }
}
