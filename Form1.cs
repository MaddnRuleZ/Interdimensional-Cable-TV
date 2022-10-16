using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net;
using System.Diagnostics;


namespace Interdimensional_Cable_TV
{
    public partial class Form1 : Form
    {
        private static Random random = new Random();

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          //  Bitmap picture = new Bitmap(@"D:\J_Resourcefiles\Interdimensional Cable TV\Ohne Titel.gif");
            //pictureBox1.BackgroundImage = picture;
            pictureBox1.Enabled = true;
            pictureBox1.Show();
            this.Location = new Point(-1381,55);
        }


        private static void getNewLink()
        {
            var count = 1;
            var API_KEY = "AIzaSyCdmv_SB-tuzy8Ca-qfdIYZ9Uo3yGt0C0k";
            var q = RandomString(3);
            var url = "https://www.googleapis.com/youtube/v3/search?key=" + API_KEY + "&maxResults=" + count + "&part=snippet&type=video&q=" + q;

            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString(url);
                dynamic jsonObject = JsonConvert.DeserializeObject(json);
                foreach (var line in jsonObject["items"])
                {
                   

                    string id = line["id"]["videoId"];

                    

                    Process.Start("https://www.youtube.com/watch?v="+ id);

                    /*store your id*/
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            getNewLink();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
