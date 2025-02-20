﻿using PHANMEMTHI.Source.Connection;
using PHANMEMTHI.Source.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PHANMEMTHI.Forms {
    public partial class ExamsForm : Form {

        private string teacherID;
        private List<Exam> availableExams;

        private Exam currentExam;

        public ExamsForm() {
            InitializeComponent();
        }

        public ExamsForm(string teacherID) {
            InitializeComponent();
            this.teacherID = teacherID;

            // Generates Values
            GenerateValues();
        }

        public void GenerateValues() {
            // Query Exams
            this.availableExams = SQLConnections.QueryExams(teacherID, true, false);

            this.dgvExams.Rows.Clear();
            foreach (var exam in this.availableExams) {
                this.dgvExams.Rows.Add(exam.ID, exam.ClassID, exam.ExamOrder);
            }
        }

        private void OnFormClosed(object sender, FormClosedEventArgs e) {
            MainTeacherForm.MainForm.ShowAndUpdate();
        }

        private void OnButtonBackClick(object sender, EventArgs e) {
            this.Close();
            MainTeacherForm.MainForm.ShowAndUpdate();
        }

        private void OnSelectionChanged(object sender, EventArgs e) {
            this.currentExam = this.availableExams[this.dgvExams.CurrentCell.RowIndex];
        }

        private void OnButtonEditClick(object sender, EventArgs e) {
            if (this.currentExam == null) return;
            this.Close();
            MainTeacherForm.MainForm.Hide();
            new ExamChangeForm(this.currentExam.ID).Show();
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e) {
            MainTeacherForm.MainForm.ShowAndUpdate();
        }

        private void OnCreateButtonClick(object sender, EventArgs e) {
            this.Close();
            MainTeacherForm.MainForm.Hide();
            new ExamChangeForm(null).ShowDialog();
        }

        private void OnCellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            if (this.currentExam == null) return;
            this.Close();
            MainTeacherForm.MainForm.Hide();
            new ExamChangeForm(this.currentExam.ID).Show();
        }
    }
}
