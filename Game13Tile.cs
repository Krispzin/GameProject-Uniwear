
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using System;
using System.Diagnostics;
using ThanaNita.MonoGameTnt;

namespace Project2
{
    public class Game13Tile : Actor
    {
        ExitNotifier exitNotifier;
        public CameraMan cameraMan;
        //floor1
        private TileMap floor1_floor;
        private TileMap floor1_wall;
        private TileMap floor1_clothing;
        private TileMap floor1_gym;
        private TileMap floor1_kitchen;
        private TileMap floor1_museum;
        private TileMap floor1_Hospital;
        private TileMap floor1_generic;
        private TileMap floor1_television;
        private TileMap floor1_office;
        private TileMap floor1_colision;
        //floor 2
        private TileMap floor2_floor;
        private TileMap floor2_colision;
        private TileMap floor2_wall;
        private TileMap floor2_hospital;
        private TileMap floor2_hospital2;
        private TileMap floor2_generic;
        private TileMap floor2_kitchen;

        //f18 entrance
        private TileMap f18_entrance_floor;
        private TileMap f18_entrance_wall;
        private TileMap f18_entrance_colision;
        private TileMap f18_entrance_tuna;
        private TileMap f18_entrance_kitchen;
        private TileMap f18_entrance_hospital;
        private TileMap f18_entrance_generic;
        private TileMap f18_entrance_Classroom;

        //f18 lobby
        private TileMap f18_lobby_floor;
        private TileMap f18_lobby_wall;
        private TileMap f18_lobby_colision;
        private TileMap f18_lobby_chair;
        private TileMap f18_lobby_table;
        private TileMap f18_lobby_window;

        //f18 thesis
        private TileMap f18_thesis_floor;
        private TileMap f18_thesis_wall;
        private TileMap f18_thesis_colision;
        private TileMap f18_thesis_BinNChair;
        private TileMap f18_thesis_book;
        private TileMap f18_thesis_noon;
        private TileMap f18_thesis_table;
        private TileMap f18_thesis_window;


        //elevator
        private TileMap elevator_floor;
        private TileMap elevator_colision;
        private TileMap elevator_wall;
        private TileMap elevator_hospital;
        private TileMap elevator_generic;
        private TileMap elevator_jail;

        //elevator2
        private TileMap elevator2_floor;
        private TileMap elevator2_colision;
        private TileMap elevator2_wall;
        private TileMap elevator2_hospital;
        private TileMap elevator2_generic;
        private TileMap elevator2_jail;


        //thesis
        private TileMap Thesis_Floor;
        private TileMap Thesis_Colision;
        private TileMap Thesis_1;
        private TileMap Thesis_2;
        private TileMap Thesis_3;
        private TileMap Thesis_4;
        private TileMap Thesis_5;
        private TileMap Thesis_noon;

        public Guy guy;
        private Actor visual;


        private Texture2D interactImage;
        private bool isImageDisplaying = false;

        public Game13Tile(Vector2 ScreenSize, OrthographicCamera camera, ExitNotifier exitNotifier)
        {
            this.exitNotifier = exitNotifier;

            var builder = new TileMapBuilder();

            interactImage = TextureCache.Get("Content/resource/img/easteregg.png");
            //new
            // 1. Create tile maps and STORE REFERENCES

            //floor 1
            floor1_colision = builder.CreateSimple("Content/resource/tileset/colision.png", new Vector2(32, 32), 16, 6, "Content/resource/tilemap/level_1_colision.csv");
            floor1_floor = builder.CreateSimple("Content/resource/tileset/Room_Builder_32x32.png", new Vector2(32, 32), 76, 109, "Content/resource/tilemap/level_1_floor.csv");
            floor1_wall = builder.CreateSimple("Content/resource/tileset/Room_Builder_32x32.png", new Vector2(32, 32), 76, 109, "Content/resource/tilemap/level_1_wall.csv");
            floor1_clothing = builder.CreateSimple("Content/resource/tileset/21_Clothing_Store_32x32.png", new Vector2(32, 32), 16, 67, "Content/resource/tilemap/level_1_clothing.csv");
            floor1_gym = builder.CreateSimple("Content/resource/tileset/8_Gym_32x32.png", new Vector2(32, 32), 16, 33, "Content/resource/tilemap/level_1_gym.csv");
            floor1_kitchen = builder.CreateSimple("Content/resource/tileset/12_Kitchen_32x32.png", new Vector2(32, 32), 16, 49, "Content/resource/tilemap/level_1_kitchen.csv");
            floor1_museum = builder.CreateSimple("Content/resource/tileset/22_Museum_32x32.png", new Vector2(32, 32), 16, 122, "Content/resource/tilemap/level_1_museum.csv");
            floor1_Hospital = builder.CreateSimple("Content/resource/tileset/19_Hospital_32x32.png", new Vector2(32, 32), 16, 110, "Content/resource/tilemap/level_1_Hospital.csv");
            floor1_generic = builder.CreateSimple("Content/resource/tileset/1_Generic_32x32.png", new Vector2(32, 32), 16, 78, "Content/resource/tilemap/level_1_generic.csv");
            floor1_television = builder.CreateSimple("Content/resource/tileset/23_Television_and_Film_Studio_32x32.png", new Vector2(32, 32), 16, 14, "Content/resource/tilemap/level_1_television.csv");
            floor1_office = builder.CreateSimple("Content/resource/tileset/Modern_Office_Black_Shadow_32x32.png", new Vector2(32, 32), 16, 53, "Content/resource/tilemap/level_1_office.csv");

            //floor 2
            floor2_floor = builder.CreateSimple("Content/resource/tileset/Room_Builder_32x32.png", new Vector2(32, 32), 76, 109, "Content/resource/tilemap/level_2_floor.csv");
            floor2_colision = builder.CreateSimple("Content/resource/tileset/colision.png", new Vector2(32, 32), 16, 6, "Content/resource/tilemap/level_2_colision.csv");
            floor2_wall = builder.CreateSimple("Content/resource/tileset/Room_Builder_32x32.png", new Vector2(32, 32), 76, 109, "Content/resource/tilemap/level_2_wall.csv");
            floor2_hospital = builder.CreateSimple("Content/resource/tileset/19_Hospital_32x32.png", new Vector2(32, 32), 16, 110, "Content/resource/tilemap/level_2_hospital.csv");
            floor2_hospital2 = builder.CreateSimple("Content/resource/tileset/19_Hospital_32x32.png", new Vector2(32, 32), 16, 110, "Content/resource/tilemap/level_2_hospital2.csv");
            floor2_generic = builder.CreateSimple("Content/resource/tileset/1_Generic_32x32.png", new Vector2(32, 32), 16, 78, "Content/resource/tilemap/level_2_generic.csv");
            floor2_kitchen = builder.CreateSimple("Content/resource/tileset/12_Kitchen_32x32.png", new Vector2(32, 32), 16, 49, "Content/resource/tilemap/level_2_kitchen.csv");

            //elevator
            elevator_floor = builder.CreateSimple("Content/resource/tileset/Room_Builder_32x32.png", new Vector2(32, 32), 76, 109, "Content/resource/tilemap/elevator_floor.csv");
            elevator_colision = builder.CreateSimple("Content/resource/tileset/colision.png", new Vector2(32, 32), 16, 6, "Content/resource/tilemap/elevator_colision.csv");
            elevator_wall = builder.CreateSimple("Content/resource/tileset/Room_Builder_32x32.png", new Vector2(32, 32), 76, 109, "Content/resource/tilemap/elevator_wall.csv");
            elevator_hospital = builder.CreateSimple("Content/resource/tileset/19_Hospital_32x32.png", new Vector2(32, 32), 16, 110, "Content/resource/tilemap/elevator_hospital.csv");
            elevator_generic = builder.CreateSimple("Content/resource/tileset/1_Generic_32x32.png", new Vector2(32, 32), 16, 78, "Content/resource/tilemap/elevator_generic.csv");
            elevator_jail = builder.CreateSimple("Content/resource/tileset/18_Jail_32x32.png", new Vector2(32, 32), 16, 45, "Content/resource/tilemap/elevator_jail.csv");

            //elevator2
            elevator2_floor = builder.CreateSimple("Content/resource/tileset/Room_Builder_32x32.png", new Vector2(32, 32), 76, 109, "Content/resource/tilemap/elevator2_floor.csv");
            elevator2_colision = builder.CreateSimple("Content/resource/tileset/colision.png", new Vector2(32, 32), 16, 6, "Content/resource/tilemap/elevator2_colision.csv");
            elevator2_wall = builder.CreateSimple("Content/resource/tileset/Room_Builder_32x32.png", new Vector2(32, 32), 76, 109, "Content/resource/tilemap/elevator2_wall.csv");
            elevator2_hospital = builder.CreateSimple("Content/resource/tileset/19_Hospital_32x32.png", new Vector2(32, 32), 16, 110, "Content/resource/tilemap/elevator2_hospital.csv");
            elevator2_generic = builder.CreateSimple("Content/resource/tileset/1_Generic_32x32.png", new Vector2(32, 32), 16, 78, "Content/resource/tilemap/elevator2_generic.csv");
            elevator2_jail = builder.CreateSimple("Content/resource/tileset/18_Jail_32x32.png", new Vector2(32, 32), 16, 45, "Content/resource/tilemap/elevator2_jail.csv");

            //f18 entrance
            f18_entrance_floor = builder.CreateSimple("Content/resource/tileset/Room_Builder_32x32.png", new Vector2(32, 32), 76, 109, "Content/resource/tilemap/Level_18_entrance_floor.csv");
            f18_entrance_wall = builder.CreateSimple("Content/resource/tileset/Room_Builder_32x32.png", new Vector2(32, 32), 76, 109, "Content/resource/tilemap/Level_18_entrance_wall.csv");
            f18_entrance_colision = builder.CreateSimple("Content/resource/tileset/colision.png", new Vector2(32, 32), 16, 6, "Content/resource/tilemap/Level_18_entrance_colision.csv");
            f18_entrance_tuna = builder.CreateSimple("Content/resource/tileset/tuna.png", new Vector2(32, 32), 56, 40, "Content/resource/tilemap/Level_18_entrance_tuna.csv");
            f18_entrance_kitchen = builder.CreateSimple("Content/resource/tileset/12_Kitchen_32x32.png", new Vector2(32, 32), 16, 49, "Content/resource/tilemap/Level_18_entrance_kitchen.csv");
            f18_entrance_hospital = builder.CreateSimple("Content/resource/tileset/19_Hospital_32x32.png", new Vector2(32, 32), 16, 110, "Content/resource/tilemap/Level_18_entrance_hospital.csv");
            f18_entrance_generic = builder.CreateSimple("Content/resource/tileset/1_Generic_32x32.png", new Vector2(32, 32), 16, 78, "Content/resource/tilemap/Level_18_entrance_generic.csv");
            f18_entrance_Classroom = builder.CreateSimple("Content/resource/tileset/5_Classroom_and_library_32x32.png", new Vector2(32, 32), 16, 34, "Content/resource/tilemap/Level_18_entrance_Classroom.csv");

            //f18 lobby
            f18_lobby_floor = builder.CreateSimple("Content/resource/tileset/Room_Builder_32x32.png", new Vector2(32, 32), 76, 109, "Content/resource/tilemap/Level_18_lobby_floor.csv");
            f18_lobby_wall = builder.CreateSimple("Content/resource/tileset/Room_Builder_32x32.png", new Vector2(32, 32), 76, 109, "Content/resource/tilemap/Level_18_lobby_wall.csv");
            f18_lobby_colision = builder.CreateSimple("Content/resource/tileset/colision.png", new Vector2(32, 32), 16, 6, "Content/resource/tilemap/Level_18_lobby_colision.csv");
            f18_lobby_chair = builder.CreateSimple("Content/resource/tileset/19_Hospital_32x32.png", new Vector2(32, 32), 16, 110, "Content/resource/tilemap/Level_18_lobby_chair.csv");
            f18_lobby_table = builder.CreateSimple("Content/resource/tileset/Modern_Office_Black_Shadow_32x32.png", new Vector2(32, 32), 16, 53, "Content/resource/tilemap/Level_18_lobby_table.csv");
            f18_lobby_window = builder.CreateSimple("Content/resource/tileset/1_Generic_32x32.png", new Vector2(32, 32), 16, 78, "Content/resource/tilemap/Level_18_lobby_window.csv");

            //f18 thesis
            f18_thesis_floor = builder.CreateSimple("Content/resource/tileset/Room_Builder_32x32.png", new Vector2(32, 32), 76, 109, "Content/resource/tilemap/Level_18_Thesis_Floor.csv");
            f18_thesis_wall = builder.CreateSimple("Content/resource/tileset/Room_Builder_32x32.png", new Vector2(32, 32), 76, 109, "Content/resource/tilemap/Level_18_Thesis_wall.csv");
            f18_thesis_colision = builder.CreateSimple("Content/resource/tileset/colision.png", new Vector2(32, 32), 16, 6, "Content/resource/tilemap/Level_18_Thesis_Colision.csv");
            f18_thesis_BinNChair = builder.CreateSimple("Content/resource/tileset/19_Hospital_32x32.png", new Vector2(32, 32), 16, 110, "Content/resource/tilemap/Level_18_Thesis_BinNChair.csv");
            f18_thesis_book = builder.CreateSimple("Content/resource/tileset/5_Classroom_and_library_32x32.png", new Vector2(32, 32), 16, 34, "Content/resource/tilemap/Level_18_Thesis_Book.csv");
            f18_thesis_noon = builder.CreateSimple("Content/resource/tileset/noonspin.png", new Vector2(32, 32), 56, 40, "Content/resource/tilemap/Level_18_Thesis_Noon.csv");
            f18_thesis_table = builder.CreateSimple("Content/resource/tileset/19_Hospital_32x32.png", new Vector2(32, 32), 16, 110, "Content/resource/tilemap/Level_18_Thesis_Table.csv");
            f18_thesis_window = builder.CreateSimple("Content/resource/tileset/1_Generic_32x32.png", new Vector2(32, 32), 16, 78, "Content/resource/tilemap/Level_18_Thesis_Window.csv");

            //thesis
            Thesis_Floor = builder.CreateSimple("Content/resource/tileset/Room_Builder_32x32.png", new Vector2(32, 32), 76, 109, "Content/resource/tilemap/thesis/Level_Thesis_Floor.csv");
            Thesis_Colision = builder.CreateSimple("Content/resource/tileset/colision.png", new Vector2(32, 32), 16, 6, "Content/resource/tilemap/thesis/Level_Thesis_Colision.csv");
            Thesis_1 = builder.CreateSimple("Content/resource/tileset/19_Hospital_32x32.png", new Vector2(32, 32), 16, 110, "Content/resource/tilemap/thesis/Level_Thesis_Bin N Chair.csv");
            Thesis_2 = builder.CreateSimple("Content/resource/tileset/5_Classroom_and_library_32x32.png", new Vector2(32, 32), 16, 34, "Content/resource/tilemap/thesis/Level_Thesis_Book.csv");
            Thesis_3 = builder.CreateSimple("Content/resource/tileset/19_Hospital_32x32.png", new Vector2(32, 32), 16, 110, "Content/resource/tilemap/thesis/Level_Thesis_Table.csv");
            Thesis_4 = builder.CreateSimple("Content/resource/tileset/Room_Builder_32x32.png", new Vector2(32, 32), 76, 109, "Content/resource/tilemap/thesis/Level_Thesis_wall.csv");
            Thesis_5 = builder.CreateSimple("Content/resource/tileset/1_Generic_32x32.png", new Vector2(32, 32), 16, 78, "Content/resource/tilemap/thesis/Level_Thesis_Window.csv");
            Thesis_noon = builder.CreateSimple("Content/resource/tileset/noonspin.png", new Vector2(32, 32), 56, 40, "Content/resource/tilemap/thesis/Level_Thesis_Noon.csv");

            // 2. Create guy BEFORE adding to All
            guy = new Guy(floor1_colision);
            int[] prohibitTiles = [0, 48, 56, 55, 59]; // Prohibit tiles 0 and 2
            guy.ProhibitTiles = prohibitTiles;
            guy.Position = floor1_floor.TileCenter(1, 18);

            // 3. Add map transition detection
            guy.OnTileCollision += CheckMapTransition;

            // 4. Create visual actor
            visual = new Actor();
            visual.Add(floor1_floor);
            visual.Add(floor1_colision);
            visual.Add(floor1_wall);
            visual.Add(floor1_clothing);
            visual.Add(floor1_gym);
            visual.Add(floor1_kitchen);
            visual.Add(floor1_museum);
            visual.Add(floor1_Hospital);
            visual.Add(floor1_generic);
            visual.Add(floor1_television);
            visual.Add(floor1_office);
            // Add other necessary layers...

            // 5. Add to All EXPLICITLY
            Add(visual);
            Add(guy);


            // 6. Camera setup (if needed)
            cameraMan = new CameraMan(camera, ScreenSize);
            cameraMan.FrameLimit = new RectF(ScreenSize).CreateExpand(new Vector2(-320, -240));
            guy.Add(cameraMan);
        }

        public override void Act(float deltaTime)
        {
            base.Act(deltaTime);

            // Check if image is displaying and spacebar is pressed to close it
            if (isImageDisplaying && IsSpacebarPressed())
            {
                isImageDisplaying = false;
            }
        }
        private bool IsSpacebarPressed()
        {
            var keyboardState = Microsoft.Xna.Framework.Input.Keyboard.GetState();
            return keyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Space);
        }

        int floor = 1;
        private void CheckMapTransition(int tileX, int tileY, TileMap currentCollisionMap)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine($"Tile X: {tileX}, Tile Y: {tileY}");


                int currentTileCode = currentCollisionMap.GetTileCode(new Vector2i(tileX, tileY));
                // Check if the current tile is a transition tile (2)

                //floor1
                if (currentTileCode == 16) //goto floor 2 red stair
                {
                    floor = 2;
                    Debug.WriteLine($"Transitioning to floor 2. Current floor: {floor}");
                    ChangeMapfloor2(floor2_floor, floor2_colision, floor2_wall, floor2_hospital, floor2_hospital2, floor2_generic, floor2_kitchen);
                }
                else if (currentTileCode == 32) //goto elevator red door
                {
                    floor = 88; // floor 88 is elevator
                    Debug.WriteLine($"Transitioning to elevator. Current floor: {floor}");
                    ChangeMapElev(elevator_floor, elevator_colision, elevator_wall, elevator_hospital, elevator_generic, elevator_jail);

                }

                //floor2
                else if (currentTileCode == 17)  //goto floor 1 yellow stair
                {
                    Debug.WriteLine($"Transitioning to floor 1 from floor 2. Current floor: {floor}");
                    ChangeMapFromFloor2ToFloor1(floor1_floor, floor1_colision, floor1_wall, floor1_clothing, floor1_gym, floor1_kitchen, floor1_museum, floor1_Hospital, floor1_generic, floor1_television, floor1_office);
                }

                //elevator
                else if (currentTileCode == 33)
                {
                    Debug.WriteLine($"Transitioning to floor 1 from elevator. Current floor: {floor}");
                    ChangeMapFromElevatorToFloor1(floor1_floor, floor1_colision, floor1_wall, floor1_clothing, floor1_gym, floor1_kitchen, floor1_museum, floor1_Hospital, floor1_generic, floor1_television, floor1_office);
                }

                //elevator2
                else if (currentTileCode == 35)
                {
                    floor = 18;
                    Debug.WriteLine(floor);
                    ChangeFromLiftToMapF18Entrance(f18_entrance_floor, f18_entrance_colision, f18_entrance_wall, f18_entrance_tuna, f18_entrance_kitchen, f18_entrance_hospital, f18_entrance_generic, f18_entrance_Classroom);
                }

                //f18 entrance
                else if (currentTileCode == 43) //goto elevator2 white door
                {
                    floor = 89;
                    Debug.WriteLine(floor);
                    ChangeMapElev(elevator2_floor, elevator2_colision, elevator2_wall, elevator2_hospital, elevator2_generic, elevator2_jail);
                }
                else if (currentTileCode == 71) //goto f18 lobby
                {
                    floor = 181;
                    Debug.WriteLine(floor);
                    ChangeMapF18lobbyFromEntrance(f18_lobby_floor, f18_lobby_colision, f18_lobby_wall, f18_lobby_chair, f18_lobby_table, f18_lobby_window);
                }

                //f18 lobby
                else if (currentTileCode == 75) //goto f18 thesis
                {
                    floor = 182;
                    Debug.WriteLine(floor);
                    ChangeMapThesis(f18_thesis_floor, f18_thesis_colision, f18_thesis_BinNChair, f18_thesis_book, f18_thesis_noon, f18_thesis_table, f18_thesis_wall, f18_thesis_window);
                }
                else if (currentTileCode == 87) //goto f18 entrance
                {
                    floor = 18;
                    Debug.WriteLine(floor);
                    ChangeMapF18Entrance(f18_entrance_floor, f18_entrance_colision, f18_entrance_wall, f18_entrance_tuna, f18_entrance_kitchen, f18_entrance_hospital, f18_entrance_generic, f18_entrance_Classroom);
                }

                //f18 thesis
                else if (currentTileCode == 70)// goto f18 lobby
                {
                    floor = 181;
                    Debug.WriteLine(floor);
                    ChangeMapF18lobbyFromThesis(f18_lobby_floor, f18_lobby_colision, f18_lobby_wall, f18_lobby_chair, f18_lobby_table, f18_lobby_window);
                }

                // interact section

                if (currentTileCode == 48 && IsEnterPressed()) // elevator1 to f18 entrance
                {
                    System.Diagnostics.Debug.WriteLine("interact");

                    // Start displaying the image
                    //isImageDisplaying = true;
                    floor = 18;
                    Debug.WriteLine(floor);
                    ChangeFromLiftToMapF18Entrance(f18_entrance_floor, f18_entrance_colision, f18_entrance_wall, f18_entrance_tuna, f18_entrance_kitchen, f18_entrance_hospital, f18_entrance_generic, f18_entrance_Classroom);
                }
                else if (currentTileCode == 55 && IsEnterPressed())// elevator2 to floor1
                {
                    System.Diagnostics.Debug.WriteLine("interact");
                    floor = 1;
                    Debug.WriteLine($"Transitioning to floor 1 from elevator2. Current floor: {floor}");
                    ChangeMapFromElevator2ToFloor1(floor1_floor, floor1_colision, floor1_wall, floor1_clothing, floor1_gym, floor1_kitchen, floor1_museum, floor1_Hospital, floor1_generic, floor1_television, floor1_office);
                }

                else if (currentTileCode == 56 && IsEnterPressed()) //fight noon
                {
                    System.Diagnostics.Debug.WriteLine("interact");
                    exitNotifier(this, 0);
                    // Start displaying the image
                    isImageDisplaying = true;

                }
                else if (currentTileCode == 59 && IsEnterPressed()) //interact w p tuna
                {
                    System.Diagnostics.Debug.WriteLine("interact");
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

        private void ChangeMap(TileMap newFloor, TileMap newCollision, TileMap t1, TileMap t2, TileMap t3, TileMap t4, TileMap t5, TileMap t6, TileMap t7, TileMap t8, TileMap t9)
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
                else
                {
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

                Remove(visual);
                Add(newVisual);

                Remove(guy);
                Add(guy);

                visual = newVisual;


            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in ChangeMap: {ex}");
            }
        }

        private void ChangeMapfloor1(TileMap newFloor, TileMap newCollision, TileMap t1, TileMap t2, TileMap t3, TileMap t4, TileMap t5, TileMap t6, TileMap t7, TileMap t8, TileMap t9)
        {
            try
            {
                if (guy == null)
                {
                    System.Diagnostics.Debug.WriteLine("Error: guy is null in ChangeMap");
                    return;
                }

                System.Diagnostics.Debug.WriteLine($"Current floor: {floor}");

                if (floor == 2)
                {
                    // Coming from floor 2 to floor 1
                    Vector2 newPosition = newFloor.TileCenter(4, 4);

                    // Directly set position bypassing movement methods
                    guy.ForcePosition(newPosition);

                    // Update collision map
                    guy.SetCollisionMap(newCollision);
                }
                else
                {
                    Vector2 newPosition = newFloor.TileCenter(15, 5);

                    // Directly set position bypassing movement methods
                    guy.ForcePosition(newPosition);

                    // Update collision map
                    guy.SetCollisionMap(newCollision);
                }

                // Rest of your existing map change logic
                var newVisual = new Actor();
                newVisual.Add(newFloor);
                newVisual.Add(newCollision);
                newVisual.Add(t1);
                newVisual.Add(t2);
                newVisual.Add(t3);
                newVisual.Add(t4);
                newVisual.Add(t5);
                newVisual.Add(t6);
                newVisual.Add(t7);
                newVisual.Add(t8);
                newVisual.Add(t9);

                Remove(visual);
                Add(newVisual);

                Remove(guy);
                Add(guy);

                visual = newVisual;


            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in ChangeMap: {ex}");
            }
        }

        private void ChangeMapFromFloor2ToFloor1(TileMap newFloor, TileMap newCollision, TileMap t1, TileMap t2, TileMap t3, TileMap t4, TileMap t5, TileMap t6, TileMap t7, TileMap t8, TileMap t9)
        {
            try
            {
                if (guy == null)
                {
                    Debug.WriteLine("Error: guy is null in ChangeMap");
                    return;
                }

                Debug.WriteLine($"Transitioning from floor 2 to floor 1");

                Vector2 newPosition = newFloor.TileCenter(4, 4);
                guy.ForcePosition(newPosition);
                guy.SetCollisionMap(newCollision);

                var newVisual = new Actor();
                newVisual.Add(newFloor);
                newVisual.Add(newCollision);
                newVisual.Add(t1);
                newVisual.Add(t2);
                newVisual.Add(t3);
                newVisual.Add(t4);
                newVisual.Add(t5);
                newVisual.Add(t6);
                newVisual.Add(t7);
                newVisual.Add(t8);
                newVisual.Add(t9);

                Remove(visual);
                Add(newVisual);

                Remove(guy);
                Add(guy);

                visual = newVisual;
                floor = 1;
                Debug.WriteLine($"Current floor after transition: {floor}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in ChangeMap: {ex}");
            }
        }

        private void ChangeMapfloor2(TileMap newFloor, TileMap newCollision, TileMap t1, TileMap t2, TileMap t3, TileMap t4, TileMap t5)
        {
            try
            {
                if (guy == null)
                {
                    System.Diagnostics.Debug.WriteLine("Error: guy is null in ChangeMap");
                    return;
                }

                System.Diagnostics.Debug.WriteLine($"Current floor: {floor}");

                Vector2 newPosition = newFloor.TileCenter(4, 5);

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

                Remove(visual);
                Add(newVisual);

                Remove(guy);
                Add(guy);

                visual = newVisual;


            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in ChangeMap: {ex}");
            }
        }

        //change map to floor18 entrance with 8 layers
        private void ChangeMapF18Entrance(TileMap newFloor, TileMap newCollision, TileMap t1, TileMap t2, TileMap t3, TileMap t4, TileMap t5, TileMap t6)
        {
            try
            {
                if (guy == null)
                {
                    System.Diagnostics.Debug.WriteLine("Error: guy is null in ChangeMap");
                    return;
                }

                System.Diagnostics.Debug.WriteLine($"Current floor: {floor}");

                // Temporarily bypass collision checks
                Vector2 newPosition = newFloor.TileCenter(15, 17);

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
                newVisual.Add(t6);

                Remove(visual);
                Add(newVisual);

                Remove(guy);
                Add(guy);

                visual = newVisual;


            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in ChangeMap: {ex}");
            }
        }

        private void ChangeFromLiftToMapF18Entrance(TileMap newFloor, TileMap newCollision, TileMap t1, TileMap t2, TileMap t3, TileMap t4, TileMap t5, TileMap t6)
        {
            try
            {
                if (guy == null)
                {
                    System.Diagnostics.Debug.WriteLine("Error: guy is null in ChangeMap");
                    return;
                }

                System.Diagnostics.Debug.WriteLine($"Current floor: {floor}");

                // Temporarily bypass collision checks
                Vector2 newPosition = newFloor.TileCenter(13, 3);

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
                newVisual.Add(t6);

                Remove(visual);
                Add(newVisual);

                Remove(guy);
                Add(guy);

                visual = newVisual;


            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in ChangeMap: {ex}");
            }
        }


        //change map to floor 18 lobby with 6 layers
        private void ChangeMapF18lobby(TileMap newFloor, TileMap newCollision, TileMap t1, TileMap t2, TileMap t3, TileMap t4)
        {
            try
            {
                if (guy == null)
                {
                    System.Diagnostics.Debug.WriteLine("Error: guy is null in ChangeMap");
                    return;
                }

                System.Diagnostics.Debug.WriteLine($"Current floor: {floor}");

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

                Remove(visual);
                Add(newVisual);

                Remove(guy);
                Add(guy);

                visual = newVisual;


            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in ChangeMap: {ex}");
            }
        }

        private void ChangeMapF18lobbyFromThesis(TileMap newFloor, TileMap newCollision, TileMap t1, TileMap t2, TileMap t3, TileMap t4)
        {
            try
            {
                if (guy == null)
                {
                    System.Diagnostics.Debug.WriteLine("Error: guy is null in ChangeMap");
                    return;
                }

                System.Diagnostics.Debug.WriteLine($"Current floor: {floor}");

                // Temporarily bypass collision checks
                Vector2 newPosition = newFloor.TileCenter(3, 9);

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

                Remove(visual);
                Add(newVisual);

                Remove(guy);
                Add(guy);

                visual = newVisual;


            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in ChangeMap: {ex}");
            }
        }

        private void ChangeMapF18lobbyFromEntrance(TileMap newFloor, TileMap newCollision, TileMap t1, TileMap t2, TileMap t3, TileMap t4)
        {
            try
            {
                if (guy == null)
                {
                    System.Diagnostics.Debug.WriteLine("Error: guy is null in ChangeMap");
                    return;
                }

                System.Diagnostics.Debug.WriteLine($"Current floor: {floor}");

                // Temporarily bypass collision checks
                Vector2 newPosition = newFloor.TileCenter(11, 17);

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

                Remove(visual);
                Add(newVisual);

                Remove(guy);
                Add(guy);

                visual = newVisual;


            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in ChangeMap: {ex}");
            }
        }

        //change map to elevator with 6 layers
        private void ChangeMapElev(TileMap newFloor, TileMap newCollision, TileMap Wall, TileMap hos, TileMap gen, TileMap jail)
        {
            try
            {
                if (guy == null)
                {
                    System.Diagnostics.Debug.WriteLine("Error: guy is null in ChangeMap");
                    return;
                }

                System.Diagnostics.Debug.WriteLine($"Current floor: {floor}");

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

                Remove(visual);
                Add(newVisual);

                Remove(guy);
                Add(guy);

                visual = newVisual;


            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in ChangeMap: {ex}");
            }
        }

        private void ChangeMapFromElevatorToFloor1(TileMap newFloor, TileMap newCollision, TileMap t1, TileMap t2, TileMap t3, TileMap t4, TileMap t5, TileMap t6, TileMap t7, TileMap t8, TileMap t9)
        {
            try
            {
                if (guy == null)
                {
                    Debug.WriteLine("Error: guy is null in ChangeMap");
                    return;
                }

                Debug.WriteLine($"Transitioning from elevator to floor 1");

                Vector2 newPosition = newFloor.TileCenter(13, 2);
                guy.ForcePosition(newPosition);
                guy.SetCollisionMap(newCollision);

                var newVisual = new Actor();
                newVisual.Add(newFloor);
                newVisual.Add(newCollision);
                newVisual.Add(t1);
                newVisual.Add(t2);
                newVisual.Add(t3);
                newVisual.Add(t4);
                newVisual.Add(t5);
                newVisual.Add(t6);
                newVisual.Add(t7);
                newVisual.Add(t8);
                newVisual.Add(t9);

                Remove(visual);
                Add(newVisual);

                Remove(guy);
                Add(guy);

                visual = newVisual;
                floor = 1;
                Debug.WriteLine($"Current floor after transition: {floor}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in ChangeMap: {ex}");
            }
        }
        //change map to elevator2 to Floor1
        private void ChangeMapFromElevator2ToFloor1(TileMap newFloor, TileMap newCollision, TileMap t1, TileMap t2, TileMap t3, TileMap t4, TileMap t5, TileMap t6, TileMap t7, TileMap t8, TileMap t9)
        {
            try
            {
                if (guy == null)
                {
                    Debug.WriteLine("Error: guy is null in ChangeMap");
                    return;
                }

                Debug.WriteLine($"Transitioning from elevator2 to floor 1");

                Vector2 newPosition = newFloor.TileCenter(22, 7);
                guy.ForcePosition(newPosition);
                guy.SetCollisionMap(newCollision);

                var newVisual = new Actor();
                newVisual.Add(newFloor);
                newVisual.Add(newCollision);
                newVisual.Add(t1);
                newVisual.Add(t2);
                newVisual.Add(t3);
                newVisual.Add(t4);
                newVisual.Add(t5);
                newVisual.Add(t6);
                newVisual.Add(t7);
                newVisual.Add(t8);
                newVisual.Add(t9);

                Remove(visual);
                Add(newVisual);

                Remove(guy);
                Add(guy);

                visual = newVisual;
                floor = 1;
                Debug.WriteLine($"Current floor after transition: {floor}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in ChangeMap: {ex}");
            }
        }

        //change map to thesis with 8 layers
        private void ChangeMapThesis(TileMap newFloor, TileMap newCollision, TileMap t1, TileMap t2, TileMap t3, TileMap t4, TileMap t5, TileMap tnoon)
        {
            try
            {
                if (guy == null)
                {
                    System.Diagnostics.Debug.WriteLine("Error: guy is null in ChangeMap");
                    return;
                }

                System.Diagnostics.Debug.WriteLine($"Current floor: {floor}");

                // Temporarily bypass collision checks
                Vector2 newPosition = newFloor.TileCenter(23, 18);

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

                Remove(visual);
                Add(newVisual);

                Remove(guy);
                Add(guy);

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
            Remove(visual);
            Add(visual);

            // You might need to re-add the sorter if you had one
            var sorter = new TileMapSorter();
            sorter.Add(guy);
            visual.Add(sorter);


        }

    }
}
