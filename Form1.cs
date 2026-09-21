using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; // Import the System.IO namespace -> Contains the FileStream class.
using System.Runtime.Serialization; 
using System.Runtime.Serialization.Formatters.Binary; // Import the Serialization namespaces -> contains the neccessary tools to serialize and deserialize objects.

namespace SERIALIZING_OBJECTS_IN_C__PT._1_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSerialize_Click(object sender, EventArgs e)
        {
            using (FileStream fs = new FileStream("artists.binary", FileMode.Create)) // Creating an instance of the FileStream class.
            {                                                                         // This instance will create a file on the hardware to write the binary data of the serialized objects to it.
                string artists = rtbArtists.Text;

                // The Binary Formatter is the actual tool that translates the object' state into binary data.
                // With the .Serialize() method, we pass in the FileStream object and the object we want to serialize.
                BinaryFormatter bFormatter = new BinaryFormatter();
                bFormatter.Serialize(fs,artists);

                MessageBox.Show("Artists saved successfully!","Data Saved");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using(FileStream fs = new FileStream("artists.binary", FileMode.Open)) // Here the FileStream tool opens the existing file to deserialize.
            {
                // We will need the Binary Formatter to translate the binay data from a file to an actual object.
                // We use the .Deserialize() method to deserialize the object.
                BinaryFormatter bFormatter = new BinaryFormatter();

                // The .Deserialize () method returns an object. This object must be cast to the appropriate type.
                string artists = (string)bFormatter.Deserialize(fs);

                rtbArtists.Text = artists;

                MessageBox.Show("Artists loaded successfully!","Data Loaded");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            rtbArtists.Clear();
        }
    }
}
