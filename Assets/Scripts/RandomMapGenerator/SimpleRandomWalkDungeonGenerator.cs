using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class SimpleRandomWalkDungeonGenerator : AbstrractDungeonGenerator
{
    [SerializeField]
    protected SimpleRandomWalkSO randomWalkParameters;

    protected HashSet<Vector2Int> RunRandomWalk(SimpleRandomWalkSO parameters, Vector2Int position)
    {
        var currentPosition = position;
        HashSet<Vector2Int> floorPosition = new HashSet<Vector2Int>();
        for(int i = 0; i < randomWalkParameters.iterations; i++)
        {
            var path = ProceduralGenerationAlgorithms.SimpleRandomWalk(currentPosition, randomWalkParameters.walkLength);
            floorPosition.UnionWith(path);
            if (randomWalkParameters.startRandomlyEachIteration)
                currentPosition = floorPosition.ElementAt(Random.Range(0, floorPosition.Count));
        }

        return floorPosition;
    }

    protected override void RunProceduralGeneration()
    {
        HashSet<Vector2Int> floorPostions = RunRandomWalk(randomWalkParameters,startPosition);
        tilemapVisualizer.Clear();
        tilemapVisualizer.PaintFloorTiles(floorPostions);
        WallGenerator.CreateWalls(floorPostions, tilemapVisualizer);
    }
}
