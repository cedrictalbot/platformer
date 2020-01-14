namespace platformgame {
    partial class Form1 {
        private System.ComponentModel.IContainer components = null;
        private System.Collections.ArrayList platforms = new System.Collections.ArrayList();
        private System.Collections.ArrayList pictureBoxes = new System.Collections.ArrayList();

        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();

            this.platforms.Add(new Platform(System.Drawing.Color.Brown,0,570,"ground",500,35));
            this.platforms.Add(new Platform(System.Drawing.Color.Brown,327,489,"platform1",150,50));
            this.platforms.Add(new Platform(System.Drawing.Color.Brown,168,368,"platform2",100,50));
            this.platforms.Add(new Platform(System.Drawing.Color.Brown,20,263,"platform3",100,50));
            this.platforms.Add(new Platform(System.Drawing.Color.Brown,220,143,"platform4",280,50));

            foreach (Platform p in this.platforms) {
                this.pictureBoxes.Add(new System.Windows.Forms.PictureBox());
            }
            foreach (System.Windows.Forms.PictureBox box in this.pictureBoxes) {
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
            for (int i=0; i < this.platforms.Count; i++) {
                Platform platform = (Platform) this.platforms[i];
                System.Windows.Forms.PictureBox box = (System.Windows.Forms.PictureBox) this.pictureBoxes[i];
                box.BackColor = platform.color;
                box.Location = new System.Drawing.Point(platform.xLocation, platform.yLocation);
                box.Name = platform.name;
                box.Size = new System.Drawing.Size(platform.xSize, platform.ySize);
                box.TabStop = false;
                box.Tag = "platform";
                box.SetImage(platformImage);
            }
            // 
            // player
            //
            this.player.BackColor = System.Drawing.Color.Transparent;
            this.player.Location = new System.Drawing.Point(0, 450);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(47, 64);
            this.player.TabStop = false;
            this.player.Image = System.Drawing.Image.FromFile("platformer/public/character_idle.png");
            //
            // ending
            //
            this.ending.Location = new System.Drawing.Point(402,47);
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
            this.ClientSize = new System.Drawing.Size(445, 557);
            this.MinimumSize = this.ClientSize;
            this.MaximumSize = this.ClientSize;

            foreach (System.Windows.Forms.PictureBox box in this.pictureBoxes) {
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

