using UnityEngine;

public class MyPID: MonoBehaviour
{
    
    public  float pFactor, iFactor, dFactor;

    public float integral;
    public float lastError;
    public void SetFactors(Vector3 factors)
    {
        pFactor = factors.x;
        iFactor = factors.y;
        dFactor = factors.z;
    }
    public void init(float pFactor, float iFactor, float dFactor)
    {
        this.pFactor = pFactor;
        this.iFactor = iFactor;
        this.dFactor = dFactor;

    }

    public float update(float currentError, float timeFrame)
    {
        integral += currentError * timeFrame;
        var deriv = (currentError - lastError) / timeFrame;
        lastError = currentError;
        return currentError * pFactor + integral * iFactor + deriv * dFactor;
    }
}
