using System;
using UnityEngine;

[Serializable]
public class GenericObstacle
{
    string obstacleName;
    float passiveDangerFactor;
    float instantDangerIncrement;

    public GenericObstacle(string obstacleName, float passiveDangerFactor, float instantDangerIncrement)
    {
        this.obstacleName = obstacleName;
        this.passiveDangerFactor = passiveDangerFactor;
        this.instantDangerIncrement = instantDangerIncrement;
    }
}
