using AutomatedHumanContactMonitorySystemApp.IRepositories;
using AutomatedHumanContactMonitorySystemApp.Models.ContextModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutomatedHumanContactMonitorySystemApp.Forms.PlaceForms
{
    public partial class UpdatePlaceForm : Form
    {
        public MainForm MainForm { get; set; }
        public IPlaceRepository PlaceRepository { get; private set; }
        public UpdatePlaceForm(IPlaceRepository placeRepository)
        {
            InitializeComponent();
            PlaceRepository = placeRepository;
        }

        private void UpdatePlaceForm_Load(object sender, EventArgs e)
        {
            LoadGridViewPlaces();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            txtId.Text = row.Cells[0].Value.ToString();
            txtLocation.Text = row.Cells[1].Value.ToString();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            PutPlace();
            LoadGridViewPlaces();
        }


        #region Helpers

        private void PutPlace()
        {
            var placeToUpdate = new Place()
            {
                Id = int.Parse(txtId.Text),
                Location = txtLocation.Text,
            };
            PlaceRepository.PutPlace(placeToUpdate);
        }

        private void LoadGridViewPlaces()
        {
            dataGridView1.DataSource = GetPlaces();
        }

        private List<Place> GetPlaces()
        {
            var places = PlaceRepository.GetPlaces();
            return places.ToList();
        }

        #endregion Helpers

    
    }
}
