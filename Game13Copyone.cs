
//using Microsoft.Xna.Framework;
//using System;
//using System.Diagnostics;
//using ThanaNita.MonoGameTnt;

//namespace Game13
//{
//    public class Game13Tile : Game2D
//    {
//        public Game13Tile()
//            : base(virtualScreenSize: new Vector2(960, 640),
//                    preferredWindowSize: new Vector2(960, 640))
//        {
//            BackgroundColor = Color.LightGray;
            
//        }
//        CameraMan cameraMan;

//        private TileMap floor2_floor;
//        private TileMap floor2_colision;
//        private TileMap floor1_floor;
//        private TileMap floor1_colision;
//        private Guy guy;
//        private Actor visual;

        
//        protected override void LoadContent()
//        {
//            BackgroundColor = Color.LightGray;

//            var builder = new TileMapBuilder();
//            // floor2
//            //var tileMap1 = builder.CreateSimple("TileSet.png", new Vector2(32,32),14,25,"TileMap1.csv");
//            //var floor2_floor = builder.CreateSimple("Content/resource/tileset/Room_Builder_32x32.png", new Vector2(32, 32), 76, 109, "Content/resource/tilemap/level_2_floor.csv");
//            //var floor2_colision = builder.CreateSimple("Content/resource/tileset/colision.png", new Vector2(32, 32), 6, 1, "Content/resource/tilemap/level_2_colision.csv");

//            //var floor2_wall = builder.CreateSimple("Content/resource/tileset/Room_Builder_32x32.png", new Vector2(32, 32), 76, 109, "Content/resource/tilemap/level_2_wall.csv");
//            //var floor2_hospital = builder.CreateSimple("Content/resource/tileset/19_Hospital_32x32.png", new Vector2(32, 32), 16, 110, "Content/resource/tilemap/level_2_hospital.csv");
//            //var floor2_generic = builder.CreateSimple("Content/resource/tileset/1_Generic_32x32.png", new Vector2(32, 32), 16, 78, "Content/resource/tilemap/level_2_generic.csv");
//            //var floor2_kitchen = builder.CreateSimple("Content/resource/tileset/12_Kitchen_32x32.png", new Vector2(32, 32), 16, 49, "Content/resource/tilemap/level_2_kitchen.csv");




//            //// 3. guy
//            //var guy = new Guy(floor2_colision);
//            ////int[] prohibitTiles = [104, 105, 118, 119];
//            //int[] prohibitTiles = [0];
//            //guy.ProhibitTiles = prohibitTiles;
//            //guy.Position = floor2_floor.TileCenter(5, 5);


//            ////check
//            //guy.OnTileCollision += CheckMapTransition;



//            //// 5. cameraMan
//            //cameraMan = new CameraMan(Camera, ScreenSize);
//            //cameraMan.FrameLimit = new RectF(ScreenSize).CreateExpand(new Vector2(-480, -320));
//            //guy.Add(cameraMan);

//            //var visual = new Actor() { Position = new Vector2(100, 100) };
//            //visual.Scale = new Vector2(1, 1);
//            //visual.Add(floor2_floor);
//            //visual.Add(floor2_wall);
//            //visual.Add(floor2_hospital);
//            //visual.Add(floor2_generic);
//            //visual.Add(floor2_kitchen);
//            //visual.Add(floor2_colision);

//            //var sorter = new TileMapSorter();
//            //sorter.Add(guy); // girl
//            ////sorter.Add(tree);
//            //visual.Add(sorter);

//            //All.Add(visual);
//            // Add to game
//            //All.Add(visual);
//            //All.Add(guy);


//            //new
//            // 1. Create tile maps and STORE REFERENCES
//            floor2_floor = builder.CreateSimple("Content/resource/tileset/Room_Builder_32x32.png", new Vector2(32, 32), 76, 109, "Content/resource/tilemap/level_2_floor.csv");
//            floor2_colision = builder.CreateSimple("Content/resource/tileset/colision.png", new Vector2(32, 32), 6, 1, "Content/resource/tilemap/level_2_colision.csv");

//            // Uncomment and add floor 1 maps
//            floor1_floor = builder.CreateSimple("Content/resource/tileset/Room_Builder_32x32.png", new Vector2(32, 32), 76, 109, "Content/resource/tilemap/level_1_floor.csv");
//            floor1_colision = builder.CreateSimple("Content/resource/tileset/colision.png", new Vector2(32, 32), 6, 1, "Content/resource/tilemap/level_1_colision.csv");

//            // 2. Create guy BEFORE adding to All
//            guy = new Guy(floor2_colision);
//            int[] prohibitTiles = [0, 2]; // Prohibit tiles 0 and 2
//            guy.ProhibitTiles = prohibitTiles;
//            guy.Position = floor2_floor.TileCenter(6, 6);

//            // 3. Add map transition detection
//            guy.OnTileCollision += CheckMapTransition;

//            // 4. Create visual actor
//            visual = new Actor();
//            visual.Add(floor2_floor);
//            visual.Add(floor2_colision);
//            // Add other necessary layers...

//            // 5. Add to All EXPLICITLY
//            All.Add(visual);
//            All.Add(guy);
           

//            // 6. Camera setup (if needed)
//            cameraMan = new CameraMan(Camera, ScreenSize);
//            cameraMan.FrameLimit = new RectF(ScreenSize).CreateExpand(new Vector2(-480, -320));
//            guy.Add(cameraMan);



//        }
//        protected override void AfterUpdateAndCollision()
//        {
//            if (cameraMan != null)
//                cameraMan.AdjustCamera();
//        }

//        bool floor = true;
//        private void CheckMapTransition(int tileX, int tileY, TileMap currentCollisionMap)
//        {
//            try
//            {
//                //System.Diagnostics.Debug.WriteLine($"Tile Collision Detected:");
//                System.Diagnostics.Debug.WriteLine($"Tile X: {tileX}, Tile Y: {tileY}");
//                //System.Diagnostics.Debug.WriteLine($"Current Collision Map: {currentCollisionMap}");

//                int currentTileCode = currentCollisionMap.GetTileCode(new Vector2i(tileX, tileY));
              
//                //System.Diagnostics.Debug.WriteLine($"Current Tile Code: {currentTileCode}");
                
//                // Check if the current tile is a transition tile (2)
//                if (currentTileCode == 2)
//                {
//                    System.Diagnostics.Debug.WriteLine(floor);
//                    //System.Diagnostics.Debug.WriteLine("Transition tile detected!");

//                    if (floor == true)
//                    {
//                        ChangeMap(floor1_floor, floor1_colision);
//                        floor = false;
//                        Debug.WriteLine(floor);
//                    }
//                    else if (floor == false) {
//                        Debug.WriteLine(floor);
//                        ChangeMap(floor2_floor, floor2_colision);
//                        floor = true;

//                    }

//                    //// Compare file paths or other unique identifiers instead of object references
//                    //if (IsMapSame(currentCollisionMap, floor2_colision))
//                    //{
//                    //    System.Diagnostics.Debug.WriteLine("Transitioning to Floor 1");
//                    //    ChangeMap(floor1_floor, floor1_colision,6,6);

//                    //}
//                    //else if (IsMapSame(currentCollisionMap , floor2_colision))
//                    //{
//                    //    System.Diagnostics.Debug.WriteLine("Transitioning to Floor 2");
//                    //    ChangeMap(floor2_floor, floor2_colision, 5, 5);
//                    //}
//                    //else
//                    //{
//                    //    System.Diagnostics.Debug.WriteLine("No matching collision map found!");
//                    //}
//                }
//                else
//                {
//                    //System.Diagnostics.Debug.WriteLine($"Not a transition tile. Current tile code is {currentTileCode}");
//                }
//            }
//            catch (Exception ex)
//            {
//                //System.Diagnostics.Debug.WriteLine($"Error in CheckMapTransition: {ex}");
//            }
//        }
//        private bool IsMapSame(TileMap map1, TileMap map2)
//        {
//            // Compare map properties that uniquely identify the map
//            // This might need adjustment based on your TileMap class implementation
//            return map1.ToString() == map2.ToString();
//        }

       

//        private void ChangeMap(TileMap newFloor, TileMap newCollision)
//        {
//            try
//            {
//                // Ensure guy is not null
//                if (guy == null)
//                {
//                    System.Diagnostics.Debug.WriteLine("Error: guy is null in ChangeMap");
//                    return;
//                }

//                // Update guy's collision map
//                guy.SetCollisionMap(newCollision);

//                // Reposition player - use TileCenter to ensure proper positioning
//                if (floor == false)
//                {
//                    //guy.Position = newFloor.TileCenter(4, 5);
//                    guy.Position = floor2_floor.TileCenter(4,1);
//                }
//                else {

//                    guy.Position = newFloor.TileCenter(4, 1);
//                }
                

//                // Recreate the visual actor
//                var newVisual = new Actor();
//                newVisual.Add(newFloor);
//                newVisual.Add(newCollision);

//                // Add other necessary layers (walls, decorations, etc.)
//                // Make sure to add the same layers you had in the previous map
//                // For example:
//                // newVisual.Add(newWallLayer);
//                // newVisual.Add(newHospitalLayer);

//                // Remove old visual and add new one
//                All.Remove(visual);
//                All.Add(newVisual);

//                // Re-add the guy to ensure it's on top
//                All.Remove(guy);
//                All.Add(guy);

//                // Update the visual reference
//                visual = newVisual;

//                System.Diagnostics.Debug.WriteLine("Map changed successfully");
//            }
//            catch (Exception ex)
//            {
//                System.Diagnostics.Debug.WriteLine($"Error in ChangeMap: {ex}");
//            }
//        }
//        private void UpdateVisualLayers(TileMap newFloor, TileMap newCollision)
//        {
//            // Recreate the visual actor with new layers
//            visual = new Actor();

//            // Add the new tile maps to the visual actor
//            visual.Add(newFloor);
//            visual.Add(newCollision);

//            // Add other necessary layers 
//            // (you'll need to recreate these based on the new map)
//            // For example:
//            // visual.Add(newWallLayer);
//            // visual.Add(newHospitalLayer);
//            // etc.

//            // Remove the old visual from All and add the new one
//            All.Remove(visual);
//            All.Add(visual);

//            // You might need to re-add the sorter if you had one
//            var sorter = new TileMapSorter();
//            sorter.Add(guy);
//            visual.Add(sorter);

           
//        }

//    }
//}
