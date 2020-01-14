using System.Drawing;

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
    }
}