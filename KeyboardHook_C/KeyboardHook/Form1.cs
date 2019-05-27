using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace KeyboardHook
{
    public partial class Form1 : Form
    {
        private List<Keys> lys = new List<Keys>();
        public bool writing = false;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            writing = false;
        }

        public void setString(Keys key)
        {
            //lys.Add(key);
            if(writing == true)
            {
                using (Stream str = new FileStream(Application.StartupPath + @"\log.txt", FileMode.Append, FileAccess.Write))
                {
                    using (StreamWriter writer = new StreamWriter(str))
                    {
                        writer.Write(key);
                    }

                    //str.Dispose();
                }
            }
        }

        

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Up:
                    Cursor.Position = new Point(Cursor.Position.X, Cursor.Position.Y - 10);
                    break;
                case Keys.Right:
                    Cursor.Position = new Point(Cursor.Position.X + 10, Cursor.Position.Y);
                    break;
                case Keys.Down:
                    Cursor.Position = new Point(Cursor.Position.X, Cursor.Position.Y + 10);
                    break;
                case Keys.Left:
                    Cursor.Position = new Point(Cursor.Position.X - 10, Cursor.Position.Y);
                    break;
                default:
                    break;
            }

            if (msg.Msg == 256)
            {
                //if the user pressed control + shift + s
                if (keyData == (Keys.Control | Keys.Shift | Keys.S))
                {
                    writing = true;
                    label1.Text = "Writing to file!";
                    
                }
                //if the user pressed control + shift + o 
                else if (keyData == (Keys.Control | Keys.Shift | Keys.O))
                {
                    writing = false;
                    label1.Text = "Not writing to file!";
                }
                
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*if(writing = true)
            {
                using (Stream str = new FileStream(Application.StartupPath + @"\log.txt", FileMode.Open, FileAccess.Write))
                {
                    using (StreamWriter writer = new StreamWriter(str))
                    {
                        foreach (Keys keys in lys)
                        {
                            writer.WriteLine(keys);
                        }
                    }
                }
            }*/
            
        }
    }
}
