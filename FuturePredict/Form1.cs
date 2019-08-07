using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using Newtonsoft.Json;

namespace FuturePredict
{
    public partial class Form1 : Form
    {
        private const string app_name = "Future Predict";
        private readonly string predictions = $"{Environment.CurrentDirectory}\\Predictionsdate.json";
        private string[] _predictions;
        private Random _random = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private async void but_Predict_Click(object sender, EventArgs e)
        {
            but_Predict.Enabled = false;
            await Task.Run(() =>
            {
                for (int i = 1; i <= 100; i++)
                {
                    progressBar1.Value = i;
                    Thread.Sleep(70);
                    this.Text = $"{i}%";
                }
            });

            var index = _random.Next(_predictions.Length);


            MessageBox.Show(_predictions[index]);
            progressBar1.Value = 0;
            this.Text = app_name;
            but_Predict.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = app_name;

            try
            {
                var data = File.ReadAllText(predictions);
                _predictions = JsonConvert.DeserializeObject<string[]>(data);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally {

            }
        }
    }
}
