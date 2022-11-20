using System;
using System.Collections.Generic;
using System.Text;

namespace Modeli.DashboardModels
{
    public class RealTimeReportVM
    {
        public  List<TopUser> topUsers { get; set; }
        public  List<TopMovie> topMovies { get; set; }
        public  List<TopTheatar> topTheaters { get; set; }
        public  List<int> chart1 { get; set; }
        public  List<float> chart2 { get; set; }
        public  List<float> chart3 { get; set; }

        public RealTimeReportVM()
        {
            topMovies = new List<TopMovie>();
            topTheaters = new List<TopTheatar>();   
            topUsers = new List<TopUser>();

            chart1 = new List<int>();
            chart2 = new List<float>();
            chart3 = new List<float>(); 
        }
    }
}
