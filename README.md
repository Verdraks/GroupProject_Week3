# Florian_GroupProject
- Le Player bouge case par case (playerMovement) et le visuel change en fonction de la direction (ChangePlayerVisual)
- Les PickUpObject on un visuel et un script pour les ramasser(PickUpObject)
- Il y a un GameManager qui vérifie le nombre d'objet à ramasser restant pour activer la zone de sortie
- L'Exit est un box collider pour finir le niveau
- La Grid de la Tilemap à deux layer Ground et Wall. Le TileManager le gère et RSE_GetTileType renvoie le type de cellule sur la position donnée
- RSE_RevelingTile, révèle une tile depuis le tileManager, sur la tilemap Fog
- Rso_movementPoits stocke le nombre de points de mouvement, le playercontroller enlève 1 et s'il est égal à 0 tue le joueur
- MaimMenu -> Play, Quit button
