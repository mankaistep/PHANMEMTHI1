﻿using PHANMEMTHI.Teachers.Reports;
using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PHANMEMTHI.Forms.Panels {
    public partial class SubjectReportForm : Form {
        public SubjectReportForm(ReportClass reportSource) {
            InitializeComponent();
            this.rptViewer.ReportSource = reportSource;
        }
    }
}
