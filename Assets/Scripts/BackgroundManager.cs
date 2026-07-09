using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public float speed = 2f;
    public int numberOfCopies = 3;

    public float minGap = 0f;
    public float maxGap = 2f;

    private List<Transform> tiles = new List<Transform>();
    private SpriteRenderer spriteRenderer;
    private float tileWidth;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        tileWidth = spriteRenderer.bounds.size.x;

        tiles.Add(transform);

        for (int i = 1; i < numberOfCopies; i++)
        {
            GameObject copy = Instantiate(gameObject, transform.parent);
            copy.name = gameObject.name + "_" + (i + 1);

            Destroy(copy.GetComponent<BackgroundManager>());

            float gap = Random.Range(minGap, maxGap);

            copy.transform.position = new Vector3(
                GetRightMostTile().GetComponent<SpriteRenderer>().bounds.max.x + tileWidth / 2f + gap,
                transform.position.y,
                transform.position.z
            );

            tiles.Add(copy.transform);
        }
    }

    void Update()
    {
        if (!GameManager.Instance.isSTARTED)
            return;

        MoveTiles();
        RecycleTiles();
    }

    void MoveTiles()
    {
        foreach (Transform tile in tiles)
        {
            tile.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }

    void RecycleTiles()
    {
        float leftCameraEdge = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;

        foreach (Transform tile in tiles)
        {
            SpriteRenderer sr = tile.GetComponent<SpriteRenderer>();

            if (sr.bounds.max.x < leftCameraEdge)
            {
                Transform rightMostTile = GetRightMostTile();
                float rightMostEdge = rightMostTile.GetComponent<SpriteRenderer>().bounds.max.x;
                float gap = Random.Range(minGap, maxGap);

                tile.position = new Vector3(
                    rightMostEdge + tileWidth / 2f + gap,
                    tile.position.y,
                    tile.position.z
                );
            }
        }
    }

    Transform GetRightMostTile()
    {
        Transform rightMost = tiles[0];

        foreach (Transform tile in tiles)
        {
            if (tile.position.x > rightMost.position.x)
            {
                rightMost = tile;
            }
        }

        return rightMost;
    }
}