﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace platformgame {
    public partial class Form1 : Form {
        bool goleft = false;
        bool goright = false;
        bool jumping = false;
        bool onGround = false;
        bool hitTop = false;
        bool hitLeft = false;
        bool hitRight = false;
        bool interacting = false;
        bool messageShown = false;

        const int gravity = 12;
        const int jumpSpeed = -12;
        int force = 8;

        public Form1() {
            InitializeComponent();
        }

        private void keyisdown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Left) {
                goleft = true;
            }
            if (e.KeyCode == Keys.Right) {
                goright = true;
            }
            if (e.KeyCode == Keys.Up && !jumping) {
                jumping = true;
            }
            if (e.KeyCode == Keys.E) {
                interacting = true;
            }
        }

        private void keyisup(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Left) {
                goleft = false;
            }
            if (e.KeyCode == Keys.Right) {
                goright = false;
            }
            if (e.KeyCode == Keys.Up) {
                jumping = false;
            }
            if (e.KeyCode == Keys.E) {
                interacting = false;
            }
        }

        private void handlePlatformInteraction(PictureBox player, Control platform) {
            if (player.Left < platform.Right && player.Right > platform.Left) {
                if (platform.Top - player.Bottom >= -gravity && platform.Top - player.Bottom < gravity ) {
                    force = 8;
                    player.Top = platform.Top - player.Height;
                    onGround = true;
                }
                else if (platform.Bottom - player.Top >= 0 && platform.Bottom - player.Top < gravity && jumping) {
                    player.Top = platform.Bottom;
                    hitTop = true;
                }
            }
            if (player.Top <= platform.Bottom && player.Bottom >= platform.Top) {
                if (player.Left - platform.Right >= 0 && player.Left - platform.Right < 5 && goleft) {
                    player.Left = platform.Right;
                    hitLeft = true;
                }
                else if (platform.Left - player.Right >= 0 && platform.Left - player.Right < 5 && goright) {
                    player.Left = platform.Left - player.Width;
                    hitRight = true;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e) {
            onGround = false;
            hitTop = false;
            hitLeft = false;
            hitRight = false;

            // interactions with boxes
            foreach (Control x in this.Controls) {
                if (x is PictureBox) {
                    switch ((string)x.Tag) {
                        case "platform" :
                        case "interactivePlatform" :
                            handlePlatformInteraction(player, x);
                            break;
                        case "button" :
                            if (player.Bounds.IntersectsWith(x.Bounds) && interacting) {
                                //TODO Handle user interaction with appearing platforms 
                                update_button(x.Name);
                            }
                            break;
                        case "ending" :
                            if (player.Bounds.IntersectsWith(x.Bounds)) {
                                if (!messageShown) {
                                    MessageBox.Show("Use E to interact with objects");
                                    goright = false;
                                    goleft = false;
                                    jumping = false;
                                    messageShown = true;
                                }
                                else if (interacting) {
                                    timer1.Stop();
                                    level += 1;
                                    InitializeComponent();
                                }
                            }
                            break;
                        case "spikes" :
                        case "interactiveSpikes" :
                            if (player.Bounds.IntersectsWith(x.Bounds)) {
                                kill_player();
                            }
                            break;
                        default :
                            break;
                    }
                }
            }
            // jumping
            if (jumping && force <0) {
                jumping = false;
            }
            if (jumping) {
                force -= 1;
            }
            // gravity
            if (!onGround && !jumping) {
                player.Top += gravity;
            }
            // avoid clipping through walls
            if (jumping && !hitTop) {
                player.Top += jumpSpeed;
            }
            if (goleft && !hitLeft) {
                player.Left = Math.Max(0, player.Left - 5);
            }
            if (goright && !hitRight) {
                player.Left = Math.Min(this.ClientRectangle.Width-player.Width, player.Left + 5);
            }
            // handle player fall
            if (player.Top > this.Bottom) {
                this.kill_player();
            }
            interacting = false;
        }

        private void d(object sender, EventArgs e) {

        }
    }
}
