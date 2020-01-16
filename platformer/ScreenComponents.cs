using System.Drawing;
using System.Collections;

namespace platformgame {
    public class ScreenComponent {
        public int xLocation;
        public int yLocation;
        public string name;
        public int xSize;
        public int ySize;

        public ScreenComponent(int xLocation, int yLocation, string name, int xSize, int ySize) {
            this.xLocation = xLocation;
            this.yLocation = yLocation;
            this.name = name;
            this.xSize = xSize;
            this.ySize = ySize;
        }
    }

    public class InteractiveButton : ScreenComponent {
        public string interactsWith;
        public bool active;

        public InteractiveButton(int xLocation, int yLocation, string name, int xSize, int ySize, string interactsWith, bool active) 
                    : base(xLocation, yLocation, name, xSize, ySize) {
            this.interactsWith = interactsWith;
            this.active = active;
        }
    }
}
