﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEditor
{
    public interface IMainForm
    {
        string FilePath { get; }
        string Content { get; set; }
        void SetSymbolCount(int count);
        event EventHandler FileOpenClick;
        event EventHandler FileSaveClick;
        event EventHandler ContentChanged;
    }
    public partial class MainForm : Form, IMainForm
    {
        public MainForm()
        {
            InitializeComponent();
            butOpenFile.Click += new EventHandler(butOpenFile_Click);
            butSaveFile.Click += butSave_Click;
            fldContent.TextChanged += fldContent_TextChanged;
            butSelectFile.Click += butSelectFile_Click;
            numericFont.ValueChanged += numericFont_ValueChanged;
        }

        #region Просування подій
        void butOpenFile_Click(object sender, EventArgs e)
        {
            if (FileOpenClick != null) FileOpenClick(this, EventArgs.Empty);
        }
        private void butSave_Click(object sender, EventArgs e)
        {
            if (FileSaveClick != null) FileSaveClick(this, EventArgs.Empty);
        }
        private void fldContent_TextChanged(object sender, EventArgs e)
        {
            if (ContentChanged != null) ContentChanged(this, EventArgs.Empty);
        }
        #endregion
        #region IMainForm
        public string FilePath
        {
            get { return fldFilePath.Text; }
        }
        public string Content
        {
            get { return fldContent.Text; }
            set { fldContent.Text = value; }
        }
        public void SetSymbolCount(int count)
        {
            lblSymbolsCount.Text = count.ToString();
        }

        public event EventHandler FileOpenClick;
        public event EventHandler FileSaveClick;
        public event EventHandler ContentChanged;
        #endregion
        private void butSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Текстові файли|*.txt|Усі фали|*.*";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                fldFilePath.Text = dlg.FileName;

                if (FileOpenClick != null) FileOpenClick(this, EventArgs.Empty);
            }
        }
        private void numericFont_ValueChanged(object sender, EventArgs e)
        {
            fldContent.Font = new Font("Calibri", (float)numericFont.Value);
        }


        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
