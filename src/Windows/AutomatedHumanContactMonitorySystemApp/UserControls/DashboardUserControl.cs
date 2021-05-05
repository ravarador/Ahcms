using AutomatedHumanContactMonitorySystemApp.IRepositories;
using AutomatedHumanContactMonitorySystemApp.Models.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutomatedHumanContactMonitorySystemApp.UserControls
{
    public partial class DashboardUserControl : UserControl
    {
        private IAttendanceRepository AttendanceRepository { get; set; }
        public DashboardUserControl()
        {
            InitializeComponent();
        }

        private void DashboardUserControl_Load(object sender, EventArgs e)
        {

        }
        public void LoadRepositories(IAttendanceRepository attendanceRepository)
        {
            AttendanceRepository = attendanceRepository;
        }

        public void LoadAttendanceList(DateTime? date)
        {
            var searchDto = new SearchDto()
            {
                Date = date.Value
            };

            dateTimePicker1.Value = date.Value;

            var attendances = AttendanceRepository.GetAttendanceByDate(searchDto).Where(a => a.PlaceId == Helpers.PlaceHelper.PlaceId);

            double puiCount = attendances.Where(a => a.Status == "PUI").Count();
            double positiveCount = attendances.Where(a => a.Status == "POSITIVE").Count();
            double normalCount = attendances.Where(a => a.Status == "NORMAL").Count();

            lblPuiCount.Text = puiCount.ToString();
            lblPositiveCount.Text = positiveCount.ToString();
            lblNormal.Text = normalCount.ToString();
            lblCasesText.Text = $"Cases for the date of: {date.Value.ToString("MMMM dd, yyyy")}";

            LoadChart(puiCount: puiCount, positiveCount: positiveCount, normalCount: normalCount);
        }

        private void LoadChart(double puiCount = 0, double positiveCount = 0, double normalCount = 0)
        {
            var plt = new ScottPlot.Plot(600, 400);
            formsPlot1.Reset();
            double[] values = { puiCount, positiveCount, normalCount };
            string[] labels = { "PUI", "POSITIVE", "NORMAL" };
            var pie = formsPlot1.plt.PlotPie(values, labels);
            pie.donutSize = .6;
            pie.showLabels = false;
            pie.colors = new Color[] { Color.Blue, Color.Red, Color.Green };

            formsPlot1.plt.Legend();
            formsPlot1.plt.Grid(false);
            formsPlot1.plt.Frame(false);
            formsPlot1.plt.Ticks(false, false);

            formsPlot1.Render();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadAttendanceList(dateTimePicker1.Value);
        }
    }
}
