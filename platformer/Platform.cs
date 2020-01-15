using System.Drawing;
using System.Collections;

namespace platformgame {
    public class Platform {
        public System.Drawing.Color color;
        public int xLocation;
        public int yLocation;
        public string name;
        public int xSize;
        public int ySize;

        public Platform(System.Drawing.Color color, int xLocation, int yLocation, string name, int xSize, int ySize) {
            this.color = color;
            this.xLocation = xLocation;
            this.yLocation = yLocation;
            this.name = name;
            this.xSize = xSize;
            this.ySize = ySize;
        }

        public static ArrayList getPlatforms(int level) {
            ArrayList platforms = new ArrayList();
            switch (level) {
                case 1 :
                    platforms.Add(new Platform(Color.Brown,0,772,"ground",1463,50));
                    platforms.Add(new Platform(Color.Brown,327,693,"platform1",150,50));
                    platforms.Add(new Platform(Color.Brown,518,582,"platform2",100,50));
                    platforms.Add(new Platform(Color.Brown,700,477,"platform3",250,50));
                    platforms.Add(new Platform(Color.Brown,420,357,"platform4",200,50));
                    platforms.Add(new Platform(Color.Brown,710,237,"platform5",50,50));
                    platforms.Add(new Platform(Color.Brown,910,237,"platform6",200,50));
                    platforms.Add(new Platform(Color.Brown,1193,143,"platform7",270,50));
                    break;
                case 2 :
                    platforms.Add(new Platform(Color.Brown,0,772,"ground",1463,50));
                    break;
                default :
                    break;
            }
            return platforms;
        }
    }
}
