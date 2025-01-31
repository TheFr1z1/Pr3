using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransportRoutePlanner;

namespace NashAbobus
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DatabaseHelper dbHelper = new DatabaseHelper();
            List<Station> stations = dbHelper.GetAllStations();

            listBox1.DataSource = stations;
            listBox1.DisplayMember = "StationName";
            listBox1.ValueMember = "StationID";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count == 2)
            {
                Station startStation = (Station)listBox1.SelectedItems[0];
                Station endStation = (Station)listBox1.SelectedItems[1];

                DatabaseHelper dbHelper = new DatabaseHelper();
                List<MetroRoutes> routes = dbHelper.GetRoutesBetweenStations(startStation.StationID, endStation.StationID);

                listBox2.DataSource = routes;
                listBox2.DisplayMember = "ToString";
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите две станции.");
            }
        }
    }
}
