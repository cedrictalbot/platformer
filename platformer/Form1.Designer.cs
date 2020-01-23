namespace platformgame {
    partial class Form1 {
        private System.ComponentModel.IContainer components = null;
        private System.Collections.Generic.Dictionary<string, System.Collections.ArrayList> levelComponents;
        private System.Collections.Generic.Dictionary<string, System.Windows.Forms.PictureBox> pictureBoxes;
        private System.Collections.Generic.Dictionary<string, string> interactions;
        private int level = 1;
        private System.Collections.Generic.Dictionary<string, string> images = LevelHelper.getImages();

        private void InitializeComponent() {
            this.Controls.Clear();
            this.components = new System.ComponentModel.Container();

            this.levelComponents = LevelHelper.getItems(this.level);
            this.pictureBoxes = new System.Collections.Generic.Dictionary<string, System.Windows.Forms.PictureBox>();
            this.interactions = new System.Collections.Generic.Dictionary<string, string>();

            foreach (var pair in this.levelComponents) {
                foreach (ScreenComponent component in pair.Value) {
                    this.pictureBoxes[component.name] = new System.Windows.Forms.PictureBox();
                }
            }

            foreach (System.Windows.Forms.PictureBox box in this.pictureBoxes.Values) {
                ((System.ComponentModel.ISupportInitialize)(box)).BeginInit();
            }

            this.player = new TransparentPictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);

            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            this.SuspendLayout();

            //
            // platforms
            //
            System.Drawing.Image platformImage = System.Drawing.Image.FromFile("platformer/public/platform.png");
            foreach (var pair in this.levelComponents) {
                foreach (ScreenComponent component in pair.Value) {
                    // this switch was created for easier later extension (new kind of interactive elements)
                    switch (pair.Key) {
                        case "button":
                            this.interactions[component.name] = ((InteractiveButton) component).interactsWith;
                            break;
                    }
                    displayComponent(pair.Key, component);
                }
            }
            // 
            // player
            //
            this.player.BackColor = System.Drawing.Color.Transparent;
            this.player.Location = new System.Drawing.Point(0, 708);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(47, 64);
            this.player.TabStop = false;
            this.player.Image = System.Drawing.Image.FromFile("platformer/public/character_idle.png");
            //
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1288, 747);
            this.MinimumSize = this.ClientSize;
            this.MaximumSize = this.ClientSize;
            this.BackgroundImage = System.Drawing.Image.FromFile("platformer/public/background.png");

            this.Controls.Add(this.player);
            foreach (System.Windows.Forms.PictureBox box in this.pictureBoxes.Values) {
                this.Controls.Add(box);
                ((System.ComponentModel.ISupportInitialize)(box)).EndInit();
            }

            this.Name = "Form1";
            this.Text = "Platform Game";
            this.Load += new System.EventHandler(this.d);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyisdown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyisup);

            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            this.ResumeLayout(false);

            foreach (InteractiveButton button in this.levelComponents["button"]) {
                if (!button.active) {
                    System.Windows.Forms.PictureBox box = this.pictureBoxes[this.interactions[button.name]];
                    this.Controls.Remove(box);
                }
            }
        }

        private void displayComponent(string key, ScreenComponent component) {
            System.Windows.Forms.PictureBox box = (System.Windows.Forms.PictureBox) this.pictureBoxes[component.name];
            box.BackColor = System.Drawing.Color.Transparent;
            box.Location = new System.Drawing.Point(component.xLocation, component.yLocation);
            box.Name = component.name;
            box.Size = new System.Drawing.Size(component.xSize, component.ySize);
            box.TabStop = false;
            box.Tag = key;
            box.SetImage(System.Drawing.Image.FromFile(this.images[key]));
        }
        private void update_button(string buttonName) {
            string elementName = this.interactions[buttonName];
            if (!this.Controls.ContainsKey(elementName)) {
                this.Controls.Add(this.pictureBoxes[elementName]);
            } else {
                this.Controls.Remove(this.pictureBoxes[elementName]);
            }
        }

        private void kill_player() {
            timer1.Stop();
            InitializeComponent();
        }

        private TransparentPictureBox player;
        private System.Windows.Forms.Timer timer1;
    }
}

