using System.Drawing;
using System.Collections;

namespace platformgame {
    public class ScreenComponent {
        public System.Drawing.Color color;
        public int xLocation;
        public int yLocation;
        public string name;
        public int xSize;
        public int ySize;

        public ScreenComponent(System.Drawing.Color color, int xLocation, int yLocation, string name, int xSize, int ySize) {
            this.color = color;
            this.xLocation = xLocation;
            this.yLocation = yLocation;
            this.name = name;
            this.xSize = xSize;
            this.ySize = ySize;
        }
    }

    public class InteractiveObject : ScreenComponent {
        public int state = 0;
        public string type;

        public InteractiveObject(System.Drawing.Color color, int xLocation, int yLocation, string name, int xSize, int ySize, string type) 
                    : base(color, xLocation, yLocation, name, xSize, ySize) {
            this.type = type;
        }
    }
}
