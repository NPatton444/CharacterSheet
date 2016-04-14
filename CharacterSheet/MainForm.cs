using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace CharacterSheet
{
    public partial class MainForm : Form
    {
        public static List<Character> characterDB = new List<Character>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Open the file to be read
            XmlTextReader reader = new XmlTextReader("characters.xml");

            string name, heroClass, dex, str, hea, perk;
            name = heroClass = dex = str = hea = perk = "";

            int index = 0;

            // Continue to read each element and text until the file is done
            while (reader.Read())
            {
                // If the currently read item is text then print it to screen,
                // otherwise the loop repeats getting the next piece of information
                if (reader.NodeType == XmlNodeType.Text)
                {
                    if (index == 0)
                    {
                        name = reader.Value;
                        index++;
                    }
                    else if (index == 1)
                    {
                        heroClass = reader.Value;
                        index++;
                    }
                    else if (index == 2)
                    {
                        dex = reader.Value;
                        index++;
                    }
                    else if (index == 3)
                    {
                        str = reader.Value;
                        index++;
                    }
                    else if (index == 4)
                    {
                        hea = reader.Value;
                        index++;
                    }
                    else if (index == 5)
                    {
                        perk = reader.Value;

                        Character character = new Character(name, heroClass, dex, str, hea, perk);
                        MainForm.characterDB.Add(character);

                        index = 0;
                    }
                }
            }
            // When done reading the file close it
            reader.Close();
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            CreateForm cf = new CreateForm();
            cf.Show();
        }

        private void viewButton_Click(object sender, EventArgs e)
        {
            ViewForm vf = new ViewForm();
            vf.Show();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
