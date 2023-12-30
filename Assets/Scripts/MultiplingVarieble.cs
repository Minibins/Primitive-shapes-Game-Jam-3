using System;
using System.Collections.Generic;
public struct MultiplingVarieble<TypeOfVariable>
{
    readonly public TypeOfVariable _variable;
    public List<float> Multiplers;
    public List<float> Additions;
    public MultiplingVarieble(TypeOfVariable variable) : this()
    {
        this._variable = variable;
        Multiplers = new List<float>();
        Additions = new List<float>();
    }

    public float Variable
    {
        get
        {
            float Multiplers = 1f;
            foreach(var value in this.Multiplers)
            {
                Multiplers *= value;
            }
            float Additions = 0f;
            foreach(var value in this.Additions)
            {
                Additions += value;
            }
            return (Convert.ToSingle(_variable) * Multiplers)+Additions;
        }
    }
}
