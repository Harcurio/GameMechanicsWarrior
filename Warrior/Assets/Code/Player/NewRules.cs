using System.Collections;
using System.Collections.Generic;
using UnityEngine;




//[RequireComponent(typeof(Conditions))]
[RequireComponent(typeof(Variable))]



public class NewRules
{


    //Conditions condition;
    Variable var;

    // LISTA DE VARIABLES
    public List<Variable> varList = new List<Variable>();
    public Conditions con = new Conditions();
    public int variablePlace;
    public string key;
    public bool randomGenerated = false;
     

    //public Condition con = new Condition();
    public Effect eff = new Effect();

    
    
    public List<Variable> getNeighbors(List<Variable> varlist,  string key)
    {
        Debug.Log(this.variablePlace);
        Debug.Log(varlist.Count);
        List<Variable> newListVar = new List<Variable>();
        int step = 1;
        if (this.randomGenerated)
        {
            Debug.Log("flag was savedsdfsdf");

            for (int j = 0; j < varlist.Count; j++)
            {
                Debug.Log(j);
           
                Debug.Log(j);
                Debug.Log("index value");
                Variable toNeighbor = varlist[j];


                //toModify.nameVariable + "-" + c +"-"+ ran +"-" + e + "-" + ran2 + "-";
                //Conditions.conditions cUsed = getConditionUsed(words[1]);
                //Effect.effects eUsed = getEffectUsed(words[3]);
                


                if (toNeighbor.isINT())
                {
                    string[] words = key.Split('-');
                    int firstRange = int.Parse(words[2]);
                    int secondRange = int.Parse(words[4]);
                    Debug.Log("is Int");

                    for (int i = 0; i < 5; i++)
                    {
                        Variable newVar1 = toNeighbor;
                        newVar1.valueInt = eff.applyEffect(newVar1.valueInt, xEffect(i), secondRange + step);
                        Variable newVar2 = toNeighbor;
                        newVar2.valueInt = eff.applyEffect(newVar2.valueInt, xEffect(i), secondRange - step);
                        newListVar.Add(newVar1);
                        newListVar.Add(newVar2);
                    }

                }

                if (toNeighbor.isFLOAT())
                {
                    string[] words = key.Split('-');
                    int firstRange = int.Parse(words[2]);
                    int secondRange = int.Parse(words[4]);
                    Debug.Log("is float");
                    for (int i = 0; i < 5; i++)
                    {
                        Variable newVar1 = toNeighbor;
                        newVar1.valueFloat = eff.applyEffect(newVar1.valueFloat, xEffect(i), secondRange + step);
                        Variable newVar2 = toNeighbor;
                        newVar2.valueFloat = eff.applyEffect(newVar2.valueFloat, xEffect(i), secondRange - step);
                        newListVar.Add(newVar1);
                        newListVar.Add(newVar2);
                    }
                }

            }



        }


        Debug.Log("final count");
        Debug.Log(newListVar.Count);
        return newListVar;
    }
        

    public List<Variable> getRandomRule(List<Variable> varList, int x1, int x2, int y1, int y2)
    {
        List<Variable> newVar = varList;
        Variable toModify;
        
        Conditions.conditions c = randomCondtion();
        Effect.effects e = randomEffect();

        Random rd = new Random();
        int location = Random.Range(0, varList.Count);
        this.variablePlace = location;
        this.key = "";
        this.randomGenerated = true;
        toModify = newVar[location];
        

        int ran, ran2;

        if (toModify.isINT())
        {
            ran = Random.Range(x1, x2);
            if (con.applyCondition(toModify.valueInt,c,ran))
            {
                Debug.Log("Variable modified was Int");
                ran2 = Random.Range(y1, y2);
                toModify.valueInt  = eff.applyEffect(toModify.valueInt,e,ran2);
                this.key = this.key + toModify.nameVariable + "-" + c +"-"+ ran +"-" + e + "-" + ran2 + "-";
                Debug.Log(this.key);

            }
        }

        if (toModify.isFLOAT())
        {
            ran = Random.Range(x1, x2);
            if (con.applyCondition(toModify.valueInt, c, ran))
            {
                ran2 = Random.Range(y1, y2);
                Debug.Log("Variable modified was Float");
                toModify.valueFloat = eff.applyEffect(toModify.valueInt, e, ran2);
                this.key = this.key + toModify.nameVariable + "-" + c + "-" + ran + "-" + e + "-" + ran2 + "-";
                Debug.Log(this.key);
            }
        }

        if (toModify.isBOOL())
        {
            //for bool if is true is gonna be false and if is false is gonna be true.
            Debug.Log("Variable modified was bool");
            toModify.valueBool = !toModify.valueBool;
              
        }

        //con.applyCondition();
        newVar[location] = toModify;
        return newVar;
    }
    

    public Conditions.conditions randomCondtion()
    {
        System.Array A = System.Enum.GetValues(typeof(Conditions.conditions));
        Conditions.conditions x = (Conditions.conditions)A.GetValue(Random.Range(0, 3));
        return x;
    }

    public Conditions.conditions randomCondtionBool()
    {
        System.Array A = System.Enum.GetValues(typeof(Conditions.conditions));
        Conditions.conditions x = (Conditions.conditions)A.GetValue(Random.Range(3, 5));
        return x;
    }

    public Effect.effects randomEffect()
    {
        System.Array A = System.Enum.GetValues(typeof(Effect.effects));
        Effect.effects x = (Effect.effects)A.GetValue(Random.Range(0, 5));
        return x;
    }

    public Effect.effects xEffect(int e)
    {
        System.Array A = System.Enum.GetValues(typeof(Effect.effects));
        Effect.effects x = (Effect.effects)A.GetValue(e);
        return x;
    }


    public Conditions.conditions getConditionUsed(string cond)
    {
        switch (cond)
        {
            case "biggerThan":
                return Conditions.conditions.lessThan;
            case "lessThan":
                return Conditions.conditions.biggerThan;
            case "equalThan":
                return Conditions.conditions.equalThan;
            default:
                return Conditions.conditions.COUNT;
        }

    }

    public Effect.effects getEffectUsed(string cond)
    {
        switch (cond)
        {
            case "add":
                return Effect.effects.add;
            case "subtract":
                return Effect.effects.subtract;
            case "multiply":
                return Effect.effects.multiply;
            case "divide":
                return Effect.effects.divide;
            case "residue":
                return Effect.effects.residue;
            default:
                return Effect.effects.change;
        }
    }





    /* we can do a function that updates all the variables inside the walk each time there is a change...*/










}








