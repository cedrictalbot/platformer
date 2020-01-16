﻿namespace platformgame {
    partial class Form1 {
        private System.ComponentModel.IContainer components = null;
        private System.Collections.Generic.Dictionary<string, System.Collections.ArrayList> levelComponents;
        private System.Collections.Generic.Dictionary<string, System.Windows.Forms.PictureBox> pictureBoxes;
        private int level = 1;
        private System.Collections.Generic.Dictionary<string, string> images = LevelHelper.getImages();

        private void InitializeComponent() {
            this.Controls.Clear();
            this.components = new System.ComponentModel.Container();

            this.levelComponents = LevelHelper.getItems(this.level);
            this.pictureBoxes = new System.Collections.Generic.Dictionary<string, System.Windows.Forms.PictureBox>();

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
            this.ending = new System.Windows.Forms.PictureBox();

            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ending)).BeginInit();
            this.SuspendLayout();

            //
            // platforms
            //
            System.Drawing.Image platformImage = System.Drawing.Image.FromFile("platformer/public/platform.png");
            foreach (var pair in this.levelComponents) {
                foreach (ScreenComponent component in pair.Value) {
                    System.Windows.Forms.PictureBox box = (System.Windows.Forms.PictureBox) this.pictureBoxes[component.name];
                    box.BackColor = component.color;
                    box.Location = new System.Drawing.Point(component.xLocation, component.yLocation);
                    box.Name = component.name;
                    box.Size = new System.Drawing.Size(component.xSize, component.ySize);
                    box.TabStop = false;
                    box.Tag = pair.Key;
                    box.SetImage(System.Drawing.Image.FromFile(this.images[pair.Key]));
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
            // ending
            //
            this.ending.BackColor = System.Drawing.Color.Transparent;
            this.ending.Location = new System.Drawing.Point(1366,47);
            this.ending.Name = "ending";
            this.ending.Size = new System.Drawing.Size(98,100);
            this.ending.TabStop = false;
            this.ending.Tag = "ending";
            this.ending.Image = System.Drawing.Image.FromFile("platformer/public/door.png");
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

            foreach (System.Windows.Forms.PictureBox box in this.pictureBoxes.Values) {
                this.Controls.Add(box);
                ((System.ComponentModel.ISupportInitialize)(box)).EndInit();
            }

            this.Controls.Add(this.player);
            this.Controls.Add(this.ending);
            this.Name = "Form1";
            this.Text = "Platform Game";
            this.Load += new System.EventHandler(this.d);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyisdown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyisup);

            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ending)).EndInit();
            this.ResumeLayout(false);

        }

        private TransparentPictureBox player;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox ending;
    }
}

