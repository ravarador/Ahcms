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
    public partial class DeletePlaceForm : Form
    {
        public MainForm MainForm { get; set; }
        public IPlaceRepository PlaceRepository { get; private set; }
        public DeletePlaceForm(IPlaceRepository placeRepository)
        {
            InitializeComponent();
            PlaceRepository = placeRepository;
        }

        private void DeletePlaceForm_Load(object sender, EventArgs e)
        {
            LoadGridViewPlaces();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            lblId.Text = row.Cells[0].Value.ToString();
            lblLocation.Text = row.Cells[1].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeletePlace(int.Parse(lblId.Text));
            LoadGridViewPlaces();
        }

        #region Helpers
        private void LoadGridViewPlaces()
        {
            dataGridView1.DataSource = GetPlaces();
        }

        private List<Place> GetPlaces()
        {
            var places = PlaceRepository.GetPlaces();
            return places.ToList();
        }

        private void DeletePlace(int id)
        {
            PlaceRepository.DeletePlace(id);
        }

        #endregion Helpers

      
    }
}
