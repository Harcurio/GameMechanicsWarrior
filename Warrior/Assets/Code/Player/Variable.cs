using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variable : MonoBehaviour {


    bool isInt = false;
    bool isFloat = false;
    bool isBool = false;

<<<<<<< HEAD
<<<<<<< HEAD
    
    
    //public int valueInt; //{ get; set; }
    //public float valueFloat; //{ get; set; }
    //public bool valueBool; //{ get; set; }

    public unsafe int* varInt;
    public unsafe float* varFloat;
    public unsafe bool* varBool;
    
=======
    public int valueInt { get; set; }
    public float valueFloat { get; set; }
    public bool valueBool { get; set; }
>>>>>>> parent of af71274 (changes with pointers in variable class)
=======
    public int valueInt { get; set; }
    public float valueFloat { get; set; }
    public bool valueBool { get; set; }
>>>>>>> parent of af71274 (changes with pointers in variable class)
    public string nameVariable{ get; set; }

    public Variable(string nameVariable, int valueInt )
    {
        this.nameVariable = nameVariable;
        this.isInt = true;
<<<<<<< HEAD
<<<<<<< HEAD
        unsafe
        {
            this.varInt = &valueInt;
        }
        
        //this.valueInt = valueInt;
=======
        this.valueInt = valueInt;
>>>>>>> parent of af71274 (changes with pointers in variable class)
=======
        this.valueInt = valueInt;
>>>>>>> parent of af71274 (changes with pointers in variable class)
    }

    public Variable(string nameVariable, float valueFloat)
    {
        this.nameVariable = nameVariable;
        this.isFloat = true;
<<<<<<< HEAD
<<<<<<< HEAD
        unsafe
        {
            this.varFloat = &valueFloat;

            
            Debug.Log("value inside the class val: ");
            Debug.Log(*this.varFloat);
        }
        
        //this.valueFloat = valueFloat;
=======
        this.valueFloat = valueFloat;
>>>>>>> parent of af71274 (changes with pointers in variable class)
=======
        this.valueFloat = valueFloat;
>>>>>>> parent of af71274 (changes with pointers in variable class)
    }

    public Variable(string nameVariable, bool Valuebool)
    {
        this.nameVariable = nameVariable;
        this.isBool = true;
<<<<<<< HEAD
<<<<<<< HEAD
        unsafe
        {
            this.varBool = &Valuebool;
        }
        //this.valueBool = Valuebool;
=======
        this.valueBool = Valuebool;
>>>>>>> parent of af71274 (changes with pointers in variable class)
=======
        this.valueBool = Valuebool;
>>>>>>> parent of af71274 (changes with pointers in variable class)
    }


    public bool isINT(){
        if (isInt)
        {
            return true;
        }
        return false;
    }

    public bool isFLOAT()
    {
        if (isFloat)
        {
            return true;
        }
        return false;
    }

    public bool isBOOL()
    {
        if (isBool)
        {
            return true;
        }
        return false;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
