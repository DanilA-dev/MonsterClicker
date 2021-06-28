using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions 
{
   public static Vector3 GetRandomPos(float minX, float maxX, float minZ, float maxZ)
   {
        float randomX = Random.Range(minX, maxX);
        float randomZ = Random.Range(minZ, maxZ);

        var newPos = new Vector3(randomX, 0f, randomZ);
        return newPos;
   }

    public static Vector3 GetRandomPos(float minX, float maxX, float minY, float maxY, float minZ, float maxZ)
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        float randomZ = Random.Range(minZ, maxZ);

        var newPos = new Vector3(randomX, randomY, randomZ);
        return newPos;
    }


}
