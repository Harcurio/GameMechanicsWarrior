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
    public int than;
    public int value;
    public bool randomGenerated = false;


    //public Condition con = new Condition();
    public Effect eff = new Effect();

    
    
    public List<Rules> getNeighbors(Rules generated)
    {
        //Debug.Log(this.variablePlace);
        //Debug.Log(varlist.Count);
        List<Rules> newListRules = new List<Rules>();
       
        int step = 1;
        if (this.randomGenerated)
        {
            for (int j = 0; j < 3; j++)  //setValues(string name, string comparator, string valueComparator, string effect, string valueEffect)
            {
                Rules newNeighbor = new Rules();
                newNeighbor.setValues(generated.name, xCondition(j).ToString(), generated.valueComparator, generated.effect, generated.valueEffect);
                //generated.setComparator(xCondition(j).ToString());
                for(int i = 0; i < 5; i++)
                {
                    float valueComparator = float.Parse(generated.valueComparator);
                    float valueEffect = float.Parse(generated.valueEffect);
                    float vcm = valueComparator - (float)step;  // value comparator minus
                    float vcp = valueComparator + (float)step; // value comparator plus
                    float vem = valueEffect - (float)step;
                    float vep = valueEffect + (float)step;

                    Rules newNeighbor1 = new Rules();
                    Rules newNeighbor2 = new Rules();
                    Rules newNeighbor3 = new Rules();
                    Rules newNeighbor4 = new Rules();
                    Rules newNeighbor5 = new Rules();
                    Rules newNeighbor6 = new Rules();
                    Rules newNeighbor7 = new Rules();
                    Rules newNeighbor8 = new Rules();
                    Rules newNeighbor9 = new Rules();


                    newNeighbor1.setValues(generated.name, xCondition(j).ToString(), generated.valueComparator, xEffect(i).ToString(), generated.valueEffect);
                    newNeighbor2.setValues(generated.name, xCondition(j).ToString(), generated.valueComparator, xEffect(i).ToString(), vem.ToString());
                    newNeighbor3.setValues(generated.name, xCondition(j).ToString(), generated.valueComparator, xEffect(i).ToString(), vep.ToString());
                    newNeighbor4.setValues(generated.name, xCondition(j).ToString(), vcm.ToString(), xEffect(i).ToString(), generated.valueEffect);
                    newNeighbor5.setValues(generated.name, xCondition(j).ToString(), vcm.ToString(), xEffect(i).ToString(), vem.ToString());
                    newNeighbor6.setValues(generated.name, xCondition(j).ToString(), vcm.ToString(), xEffect(i).ToString(), vep.ToString());
                    newNeighbor7.setValues(generated.name, xCondition(j).ToString(), vcp.ToString(), xEffect(i).ToString(), generated.valueEffect);
                    newNeighbor8.setValues(generated.name, xCondition(j).ToString(), vcp.ToString(), xEffect(i).ToString(), vem.ToString());
                    newNeighbor9.setValues(generated.name, xCondition(j).ToString(), vcp.ToString(), xEffect(i).ToString(), vep.ToString());


                    newListRules.Add(newNeighbor1);
                    newListRules.Add(newNeighbor2);
                    newListRules.Add(newNeighbor3);
                    newListRules.Add(newNeighbor4);
                    newListRules.Add(newNeighbor5);
                    newListRules.Add(newNeighbor6);
                    newListRules.Add(newNeighbor7);
                    newListRules.Add(newNeighbor8);
                    newListRules.Add(newNeighbor9);


                    //  NEED TO SEARCH AND DELETE THE ORIGINAL FUNCTION....

                    /*
                    Variable newVar1 = new Variable(toNeighbor.nameVariable, toNeighbor.valueFloat);
                    newVar1.valueInt = eff.applyEffect(newVar1.valueInt, xEffect(i), secondRange + step);
                    Variable newVar2 = new Variable(toNeighbor.nameVariable, toNeighbor.valueFloat);
                    newVar2.valueInt = eff.applyEffect(newVar2.valueInt, xEffect(i), secondRange - step);
                    newListVar.Add(newVar1);
                    newListVar.Add(newVar2);
                    */

                }
            }
        }


        Debug.Log("neighborsDone");
        printList(newListRules);
        return newListRules;
    }

    public void printList(List<Rules> varList)
    {
        for (int i = 0; i < varList.Count; i++)
        {
            Debug.Log(varList[i].name + varList[i].comparator + varList[i].valueComparator + varList[i].effect + varList[i].valueEffect);
        }
        Debug.Log("endGetNeigbors List");
    }


    public Rules getRandomRule(List<Variable> varList, int x1, int x2, int y1, int y2)
    {
        List<Variable> newVar = varList;
        Variable toModify;
        Rules generatedRule = new Rules();



        Conditions.conditions c = randomCondtion();
        Effect.effects e = randomEffect();

        Random rd = new Random();
        int location = Random.Range(0, varList.Count);
        this.variablePlace = location;

        
        toModify = newVar[location];


        if (toModify.isINT())
        {
            this.than = Random.Range(x1, x2);
            this.value = Random.Range(y1, y2);
            generatedRule.setValues(toModify.nameVariable, c.ToString(),this.than.ToString(),e.ToString(),this.value.ToString());
            this.randomGenerated = true;
        }

        if (toModify.isFLOAT())
        {
            this.than = Random.Range(x1, x2);
            this.value = Random.Range(y1, y2);
            generatedRule.setValues(toModify.nameVariable, c.ToString(), this.than.ToString(), e.ToString(), this.value.ToString());
            this.randomGenerated = true;
        }

        if (toModify.isBOOL())
        {
            //for bool if is true is gonna be false and if is false is gonna be true.
            Debug.Log("Variable modified was bool");
            //toModify.valueBool = !toModify.valueBool;
              
        }

        //con.applyCondition();
        //newVar[this.variablePlace] = toModify;
        //Debug.Log(this.key);
        return generatedRule;
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

    public Conditions.conditions xCondition(int e)
    {
        System.Array A = System.Enum.GetValues(typeof(Effect.effects));
        Conditions.conditions x = (Conditions.conditions)A.GetValue(e);
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








