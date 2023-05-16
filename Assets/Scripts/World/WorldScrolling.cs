using UnityEngine;

public class WorldScrolling : MonoBehaviour {
     [SerializeField] private Transform playerTransform;
     private Vector2Int _currentTilePosition = new Vector2Int(0, 0);
     private Vector2Int _playerTilePosition;
     [SerializeField] private float tileSize = 20f;
     private GameObject[,] _terrainTiles;

     [SerializeField] private int fovHeight = 3;
     [SerializeField] private int fovWidth = 3;

     private Vector2Int _onTileGridPlayerPosition;

     [SerializeField] private int terrainTileHorizontalCount;
     [SerializeField] private int terrainTileVerticalCount;
     
     private void Awake() {
          _terrainTiles = new GameObject[terrainTileHorizontalCount, terrainTileVerticalCount];
     }

     private void Start() {
          UpdateTilesOnScreen();
          playerTransform = GameManager.Instance.playerTransform;
     }

     private void Update() {
          _playerTilePosition.x = (int)(playerTransform.position.x / tileSize);
          _playerTilePosition.y = (int)(playerTransform.position.y / tileSize);

          _playerTilePosition.x -= playerTransform.position.x < 0 ? 1 : 0;
          _playerTilePosition.y -= playerTransform.position.y < 0 ? 1 : 0;
          
          if (_currentTilePosition != _playerTilePosition) {
               _onTileGridPlayerPosition.x = CalculatePositionOnAxis(_onTileGridPlayerPosition.x, true);
               _onTileGridPlayerPosition.y = CalculatePositionOnAxis(_onTileGridPlayerPosition.y, false);
               
               UpdateTilesOnScreen();
          }
     }

     public void Add(GameObject tileGameObject, Vector2Int tilePosition) {
          _terrainTiles[tilePosition.x, tilePosition.y] = tileGameObject;

          _onTileGridPlayerPosition.x = CalculatePositionOnAxis(_onTileGridPlayerPosition.x, true);
          _onTileGridPlayerPosition.y = CalculatePositionOnAxis(_onTileGridPlayerPosition.y, false);
     }

     // Updates tiles on screen ((Super important comment to make sure people understand what the function "Update on tiles on screen" does as its not entirely clear what it does just by reading the name XD))
     private void UpdateTilesOnScreen() {
          for (int povX = -(fovWidth/2); povX <= fovWidth/2; povX++) {
               for (int povY = -(fovHeight/2); povY <= fovHeight/2; povY++) {
                    int tileToUpdateX = CalculatePositionOnAxis(_playerTilePosition.x + povX, true);
                    int tileToUpdateY = CalculatePositionOnAxis(_playerTilePosition.y + povY, false);
                    
                    GameObject tile = _terrainTiles[tileToUpdateX, tileToUpdateY];
                    Vector3 newPosition = CalculateTilePosition(_playerTilePosition.x + povX, _playerTilePosition.y + povY);
                    if (newPosition != tile.transform.position) { 
                         tile.transform.position = newPosition;
                         _terrainTiles[tileToUpdateX, tileToUpdateY].GetComponent<terrainTile>().Spawn();    
                    }
               }
          }
     }

     private Vector3 CalculateTilePosition(int x, int y) {
          return new Vector3(x * tileSize, y * tileSize, 0f);
     }
     
     // Generalized calculation of one axis value on grid with wrap
     private int CalculatePositionOnAxis(float currentValue, bool horizontal) {
          if (horizontal) {
               if (currentValue >= 0) {
                    currentValue = currentValue % terrainTileHorizontalCount;
               }
               else {
                    currentValue += 1;
                    currentValue = terrainTileHorizontalCount - 1 + currentValue % terrainTileHorizontalCount;
               }
          }
          else {
               if (currentValue >= 0) {
                    currentValue = currentValue % terrainTileVerticalCount;
               }
               else {
                    currentValue += 1;
                    currentValue = terrainTileVerticalCount - 1 + currentValue % terrainTileVerticalCount;
               }
          }
          return (int)currentValue;
     }
}

