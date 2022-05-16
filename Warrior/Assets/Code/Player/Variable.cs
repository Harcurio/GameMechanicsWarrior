using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variable {


    bool isInt = false;
    bool isFloat = false;
    bool isBool = false;

    
    
    public int valueInt; //{ get; set; }
    public float valueFloat; //{ get; set; }
    public bool valueBool; //{ get; set; }

    public unsafe int* varInt;
    public unsafe float* varFloat;
    public unsafe bool* varBool;
    
    public string nameVariable{ get; set; }
    public string locationVariable { get; set; }

    public Variable(string nameVariable, int valueInt )
    {
        this.nameVariable = nameVariable;
        this.isInt = true;
        unsafe
        {
            this.varInt = &valueInt;
        }
        
        //this.valueInt = valueInt;
    }

    public Variable(string nameVariable, float valueFloat)
    {
        this.nameVariable = nameVariable;
        this.isFloat = true;
        unsafe
        {
            this.varFloat = &valueFloat;       
        }
        //this.valueFloat = valueFloat;
    }

    public Variable(string nameVariable, bool Valuebool)
    {
        this.nameVariable = nameVariable;
        this.isBool = true;
        unsafe
        {
            this.varBool = &Valuebool;
        }
        //this.valueBool = Valuebool;
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
