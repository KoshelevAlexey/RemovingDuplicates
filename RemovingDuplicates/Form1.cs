using System;
using System.Data;
using System.Windows.Forms;
using RemovingDuplicates.Logger;
using RemovingDuplicates.DBService;
using RemovingDuplicates.RemoveService;

namespace RemovingDublicates
{
    public partial class Form1 : Form
    {
        private DataTable _dt = new DataTable();
        private BindingSource _bs = new BindingSource();

        private IDBService _dbService = new SQLiteService();

        private RemDuplService _service;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _dbService.CreateDB();
            _dbService.CreateTables();
            _service = new RemDuplService(new DBLogger(new SQLiteDBLogService()));

            FillLogTable();
            _bs.DataSource = _dt;
            dgvLogs.DataSource = _bs;
            _bs.Sort = "LogDateTime desc";
            dgvLogs.Columns["Id"].Visible = false;
            dgvLogs.Columns["LogDateTime"].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm:ss.ffff";
            dgvLogs.Columns["UserName"].HeaderText = "Пользователь";
            dgvLogs.Columns["LogDateTime"].HeaderText = "Дата и время";
            dgvLogs.Columns["Description"].HeaderText = "Описание";
            dgvLogs.Columns["FileName"].HeaderText = "Файл";
            dgvLogs.Columns["Level"].HeaderText = "Тип";
            dgvLogs.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void btnOpenJsonFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "JSON | *.json";
            if (fd.ShowDialog() == DialogResult.Cancel) return;

            btnSaveJsonFile.Enabled = false;

            bool result = _service.RemoveDuplicatesFromFile(fd.FileName);
            btnSaveJsonFile.Enabled = result;

            FillLogTable();
        }

        private void btnSaveJsonFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "JSON | *.json";
            if (fd.ShowDialog() == DialogResult.Cancel) return;

            bool result = _service.SaveFile(fd.FileName);
            btnSaveJsonFile.Enabled = !result;

            FillLogTable();
        }

        private void FillLogTable()
        {
            _dt.Rows.Clear();
            _dbService.FillDataTable(_dt);
        }
    }
}
