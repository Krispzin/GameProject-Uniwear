
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;
using ThanaNita.MonoGameTnt;

namespace Game13
{
    public class Game13Tile : Game2D
    {
        public Game13Tile()
            : base(virtualScreenSize: new Vector2(960, 640),
                    preferredWindowSize: new Vector2(960, 640))
        {
            BackgroundColor = Color.LightGray;
            
        }
        CameraMan cameraMan;

        private TileMap floor2_floor;
        private TileMap floor2_colision;
        private TileMap floor1_floor;
        private TileMap floor1_colision;

        private TileMap elevator_floor;
        private TileMap elevator_colision;
        private TileMap elevator_wall;
        private TileMap elevator_hospital;
        private TileMap elevator_generic;
        private TileMap elevator_jail;

        //18
        private TileMap f18_Floor;
        private TileMap f18_Colision;


        //thesis
        private TileMap Thesis_Floor;
        private TileMap Thesis_Colision;
        private TileMap Thesis_1;
        private TileMap Thesis_2;
        private TileMap Thesis_3;
        private TileMap Thesis_4;
        private TileMap Thesis_5;
        private TileMap Thesis_noon;

        private Guy guy;
        private Actor visual;


        private Texture2D interactImage;
        private bool isImageDisplaying = false;

        protected override void LoadContent()
        {
            BackgroundColor = Color.LightGray;

            var builder = new TileMapBuilder();


            interactImage = TextureCache.Get("Content/resource/img/noon_fight.png");
            //new
            // 1. Create tile maps and STORE REFERENCES
            floor2_floor = builder.CreateSimple("Content/resource/tileset/Room_Builder_32x32.png", new Vector2(32, 32), 76, 109, "Content/resource/tilemap/level_2_floor.csv");
            floor2_colision = builder.CreateSimple("Content/resource/tileset/colision.png", new Vector2(32, 32), 16, 6, "Content/resource/tilemap/level_2_colision.csv");

            // Uncomment and add floor 1 maps
            floor1_floor = builder.CreateSimple("Content/resource/tileset/Room_Builder_32x32.png", new Vector2(32, 32), 76, 109, "Content/resource/tilemap/level_1_floor.csv");
            floor1_colision = builder.CreateSimple("Content/resource/tileset/colision.png", new Vector2(32, 32), 16, 6, "Content/resource/tilemap/level_1_colision.csv");

            //elevator
            elevator_floor = builder.CreateSimple("Content/resource/tileset/Room_Builder_32x32.png", new Vector2(32, 32), 76, 109, "Content/resource/tilemap/elevator_floor.csv");
            elevator_colision = builder.CreateSimple("Content/resource/tileset/colision.png", new Vector2(32, 32), 16, 6, "Content/resource/tilemap/elevator_colision.csv");
            elevator_wall = builder.CreateSimple("Content/resource/tileset/Room_Builder_32x32.png",new Vector2(32, 32),76,109,"Content/resource/tilemap/elevator_wall.csv");
            elevator_hospital = builder.CreateSimple("Content/resource/tileset/19_Hospital_32x32.png",new Vector2(32, 32),16,110,"Content/resource/tilemap/elevator_hospital.csv");
            elevator_generic = builder.CreateSimple("Content/resource/tileset/1_Generic_32x32.png",new Vector2(32, 32),16,78,"Content/resource/tilemap/elevator_generic.csv");
            elevator_jail = builder.CreateSimple("Content/resource/tileset/18_Jail_32x32.png",new Vector2(32, 32),16,45,"Content/resource/tilemap/elevator_jail.csv");

            //f18
            f18_Floor = builder.CreateSimple("Content/resource/tileset/Room_Builder_32x32.png", new Vector2(32, 32), 76, 109, "Content/resource/tilemap/18/Level_18_Roombuilder.csv");
            f18_Colision  = builder.CreateSimple("Content/resource/tileset/colision.png", new Vector2(32, 32), 16, 6, "Content/resource/tilemap/18/Level_18_Colision2.csv");



            //thesis
            Thesis_Floor = builder.CreateSimple("Content/resource/tileset/Room_Builder_32x32.png", new Vector2(32, 32), 76, 109, "Content/resource/tilemap/thesis/Level_Thesis_Floor.csv");
            Thesis_Colision  = builder.CreateSimple("Content/resource/tileset/colision.png", new Vector2(32, 32), 16, 6, "Content/resource/tilemap/thesis/Level_Thesis_Colision.csv");
            Thesis_1 = builder.CreateSimple("Content/resource/tileset/19_Hospital_32x32.png", new Vector2(32, 32), 16, 110, "Content/resource/tilemap/thesis/Level_Thesis_Bin N Chair.csv");
            Thesis_2 = builder.CreateSimple("Content/resource/tileset/5_Classroom_and_library_32x32.png", new Vector2(32, 32), 16, 34, "Content/resource/tilemap/thesis/Level_Thesis_Book.csv");
            Thesis_3 = builder.CreateSimple("Content/resource/tileset/19_Hospital_32x32.png", new Vector2(32, 32), 16, 110, "Content/resource/tilemap/thesis/Level_Thesis_Table.csv");
            Thesis_4 = builder.CreateSimple("Content/resource/tileset/Room_Builder_32x32.png", new Vector2(32, 32), 76, 109, "Content/resource/tilemap/thesis/Level_Thesis_Wall.csv");
            Thesis_5 = builder.CreateSimple("Content/resource/tileset/1_Generic_32x32.png", new Vector2(32, 32), 16, 78, "Content/resource/tilemap/thesis/Level_Thesis_Window.csv");
            Thesis_noon = builder.CreateSimple("Content/resource/tileset/noonspin.png", new Vector2(32, 32), 56, 40, "Content/resource/tilemap/thesis/Level_Thesis_Noon.csv");

            // 2. Create guy BEFORE adding to All
            guy = new Guy(floor1_colision);
            int[] prohibitTiles = [0, 48, 56]; // Prohibit tiles 0 and 2
            guy.ProhibitTiles = prohibitTiles;
            guy.Position = floor1_floor.TileCenter(6, 6);

            // 3. Add map transition detection
            guy.OnTileCollision += CheckMapTransition;

            // 4. Create visual actor
            visual = new Actor();
            visual.Add(floor1_floor);
            visual.Add(floor1_colision);
            // Add other necessary layers...

            // 5. Add to All EXPLICITLY
            All.Add(visual);
            All.Add(guy);
           

            // 6. Camera setup (if needed)
            cameraMan = new CameraMan(Camera, ScreenSize);
            cameraMan.FrameLimit = new RectF(ScreenSize).CreateExpand(new Vector2(-480, -320));
            guy.Add(cameraMan);



        }
        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            // Check if image is displaying and spacebar is pressed to close it
            if (isImageDisplaying && IsSpacebarPressed())
            {
                isImageDisplaying = false;
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            // Draw the image if it's supposed to be displayed
            if (isImageDisplaying)
            {
                // Create a new SpriteBatch using GraphicsDevice
                using (SpriteBatch spriteBatch = new SpriteBatch(GraphicsDevice))
                {
                    spriteBatch.Begin();

                    // Calculate center position
                    Vector2 imagePosition = new Vector2(
                        (ScreenSize.X - interactImage.Width) / 2,
                        (ScreenSize.Y - interactImage.Height) / 2
                    );

                    // Draw the image centrally
                    spriteBatch.Draw(interactImage, imagePosition, Color.White);
                    spriteBatch.End();
                }
            }
        }
        private bool IsSpacebarPressed()
        {
            var keyboardState = Microsoft.Xna.Framework.Input.Keyboard.GetState();
            return keyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Space);
        }

        protected override void AfterUpdateAndCollision()
        {
            if (cameraMan != null)
                cameraMan.AdjustCamera();
        }

        int floor = 1;
        private void CheckMapTransition(int tileX, int tileY, TileMap currentCollisionMap)
        {
            try
            {
              
                //System.Diagnostics.Debug.WriteLine($"Tile X: {tileX}, Tile Y: {tileY}");
               

                int currentTileCode = currentCollisionMap.GetTileCode(new Vector2i(tileX, tileY));


                // Check if the current tile is a transition tile (2)
                if (currentTileCode == 17)
                {
                    System.Diagnostics.Debug.WriteLine(floor);
                    //System.Diagnostics.Debug.WriteLine("Transition tile detected!");

                    if (floor == 2)
                    {
                        ChangeMap(floor1_floor, floor1_colision);
                        floor = 1;
                        Debug.WriteLine(floor);
                    }
                    else if (floor == 1)
                    {
                        Debug.WriteLine(floor);
                        ChangeMap(floor2_floor, floor2_colision);
                        floor = 2;

                    }
                }
                else if (currentTileCode == 32)
                {
                    floor = 88;
                    Debug.WriteLine(floor);
                    ChangeMapElev(elevator_floor, elevator_colision, elevator_wall, elevator_hospital, elevator_generic, elevator_jail);
                    
                }
                else if (currentTileCode == 16)
                {
                    floor = 2;
                    Debug.WriteLine(floor);
                    ChangeMap(floor2_floor, floor2_colision);

                }
                else if (currentTileCode == 84)
                {
                    floor = 182;
                    Debug.WriteLine(floor);
                    ChangeMapThesis(Thesis_Floor, Thesis_Colision, Thesis_1, Thesis_2, Thesis_3, Thesis_4, Thesis_5, Thesis_noon);

                }

                if (currentTileCode == 48 && IsEnterPressed())
                {
                    System.Diagnostics.Debug.WriteLine("interact");

                    // Start displaying the image
                    //isImageDisplaying = true;
                    floor = 18;
                    Debug.WriteLine(floor);
                    ChangeMap(f18_Floor, f18_Colision);
                }
                else if (currentTileCode == 56 && IsEnterPressed())
                {
                    System.Diagnostics.Debug.WriteLine("interact");

                    // Start displaying the image
                    isImageDisplaying = true;
                    
                }



                else
                {
                    //System.Diagnostics.Debug.WriteLine($"Not a transition tile. Current tile code is {currentTileCode}");
                }
            }
            catch (Exception ex)
            {
                //System.Diagnostics.Debug.WriteLine($"Error in CheckMapTransition: {ex}");
            }





        }

        private bool IsEnterPressed()
        {
            
            // You'll need to add a reference to the current keyboard state in your class
            var keyboardState = Microsoft.Xna.Framework.Input.Keyboard.GetState();
            return keyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Enter);
            
        }

        private void ChangeMap(TileMap newFloor, TileMap newCollision)
        {
            try
            {
                if (guy == null)
                {
                    System.Diagnostics.Debug.WriteLine("Error: guy is null in ChangeMap");
                    return;
                }

                if (floor == 2)
                {
                    // Temporarily bypass collision checks
                    Vector2 newPosition = newFloor.TileCenter(4, 4);

                    // Directly set position bypassing movement methods
                    guy.ForcePosition(newPosition);

                    // Update collision map
                    guy.SetCollisionMap(newCollision);
                }
                else {
                    Vector2 newPosition = newFloor.TileCenter(14, 10);

                    // Directly set position bypassing movement methods
                    guy.ForcePosition(newPosition);

                    // Update collision map
                    guy.SetCollisionMap(newCollision);
                }
               

                // Rest of your existing map change logic
                var newVisual = new Actor();
                newVisual.Add(newFloor);
                newVisual.Add(newCollision);

                All.Remove(visual);
                All.Add(newVisual);

                All.Remove(guy);
                All.Add(guy);

                visual = newVisual;

                
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in ChangeMap: {ex}");
            }
        }
       
        private void ChangeMapElev(TileMap newFloor, TileMap newCollision, TileMap Wall, TileMap hos, TileMap gen, TileMap jail)
        {
            try
            {
                if (guy == null)
                {
                    System.Diagnostics.Debug.WriteLine("Error: guy is null in ChangeMap");
                    return;
                }

                // Temporarily bypass collision checks
                Vector2 newPosition = newFloor.TileCenter(14, 10);

                // Directly set position bypassing movement methods
                guy.ForcePosition(newPosition);

                // Update collision map
                guy.SetCollisionMap(newCollision);

                // Rest of your existing map change logic
                var newVisual = new Actor();
                newVisual.Add(newFloor);
                newVisual.Add(newCollision);
                newVisual.Add(Wall);
                newVisual.Add(hos);
                newVisual.Add(gen);
                newVisual.Add(jail);

                All.Remove(visual);
                All.Add(newVisual);

                All.Remove(guy);
                All.Add(guy);

                visual = newVisual;


            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in ChangeMap: {ex}");
            }
        }

        private void ChangeMapThesis(TileMap newFloor, TileMap newCollision, TileMap t1, TileMap t2, TileMap t3, TileMap t4, TileMap t5, TileMap tnoon)
        {
            try
            {
                if (guy == null)
                {
                    System.Diagnostics.Debug.WriteLine("Error: guy is null in ChangeMap");
                    return;
                }

                // Temporarily bypass collision checks
                Vector2 newPosition = newFloor.TileCenter(14, 10);

                // Directly set position bypassing movement methods
                guy.ForcePosition(newPosition);

                // Update collision map
                guy.SetCollisionMap(newCollision);

                // Rest of your existing map change logic
                var newVisual = new Actor();
                newVisual.Add(newFloor);
                newVisual.Add(newCollision);
                newVisual.Add(t1);
                newVisual.Add(t2);
                newVisual.Add(t3);
                newVisual.Add(t4);
                newVisual.Add(t5);
                newVisual.Add(tnoon);

                All.Remove(visual);
                All.Add(newVisual);

                All.Remove(guy);
                All.Add(guy);

                visual = newVisual;


            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in ChangeMap: {ex}");
            }
        }


        private void UpdateVisualLayers(TileMap newFloor, TileMap newCollision)
        {
            // Recreate the visual actor with new layers
            visual = new Actor();

            // Add the new tile maps to the visual actor
            visual.Add(newFloor);
            visual.Add(newCollision);

      

            // Remove the old visual from All and add the new one
            All.Remove(visual);
            All.Add(visual);

            // You might need to re-add the sorter if you had one
            var sorter = new TileMapSorter();
            sorter.Add(guy);
            visual.Add(sorter);

           
        }

    }
}
