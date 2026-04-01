using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMI計算機
{
    public partial class frmBMI : Form
    {
        public frmBMI()
        {
            InitializeComponent();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            bool isHeightValid = double.TryParse(txtHeight.Text, out double height);
            bool isWeightValid = double.TryParse(txtWeight.Text, out double weight);
            // 驗證身高輸入
            if (isHeightValid)
            {
                if (height <= 0)
                {
                    MessageBox.Show("身高必須大於零。", "身高值錯誤",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("請輸入有效的身高數值。", "身高值錯誤",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // 驗證體重輸入
            if (isWeightValid)
            {
                if (weight <= 0)
                {
                    MessageBox.Show("體重必須大於零。", "體重值錯誤",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("請輸入有效的體重數值。", "體重值錯誤",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 將身高從公分轉換為公尺
            height = height / 100;
            double bmi = weight / (height * height);

            string[] strResultList = { "體重過輕", "健康體位", "體位過重", "輕度肥胖",
                           "中度肥胖", "重度肥胖" };
            Color[] colorList = {
            Color.FromArgb(186, 225, 255),
            Color.FromArgb(186, 255, 201),
            Color.FromArgb(255, 223, 186),
            Color.FromArgb(255, 179, 138),
            Color.FromArgb(255, 153, 153),
            Color.FromArgb(218, 186, 255) };

            int resultIndex = 0;
            if (bmi < 18.5) resultIndex = 0;
            else if (bmi < 24) resultIndex = 1;
            else if (bmi < 27) resultIndex = 2;
            else if (bmi < 30) resultIndex = 3;
            else if (bmi < 35) resultIndex = 4;
            else resultIndex = 5;

            string strResult = strResultList[resultIndex];
            Color colorResult = colorList[resultIndex];

            lblResult.Text = $"{bmi:F2} ({strResult})";
            lblResult.BackColor = colorResult;

            double idealWeight = 22 * (height * height);
            double weightDiff = weight - idealWeight; // 負數代表太輕，正數代表太重

            if (resultIndex == 1) 
            {
                lblSuggestion.Text = "太棒了！您維持得非常完美，請繼續保持。";
            }
            else
            {
                string action = weightDiff < 0 ? "增重" : "減重";
                lblSuggestion.Text = $"距離標準體位 (BMI 22)，您大約還需要{action} {Math.Abs(weightDiff):F1}公斤，加油加油！";
            }

            string timestamp = DateTime.Now.ToString("MM/dd HH:mm");
            string record = $"{timestamp} | 身高:{txtHeight.Text}cm 體重:{txtWeight.Text}kg | BMI:{bmi:F2} ({strResult})";

            lstHistory.Items.Insert(0, record);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (lstHistory.Items.Count == 0)
            {
                MessageBox.Show("目前沒有歷史紀錄可以匯出！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "匯出 BMI 歷史紀錄";
            sfd.Filter = "文字檔 (*.txt)|*.txt|所有檔案 (*.*)|*.*";
            sfd.FileName = "BMI紀錄.txt";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // 把 ListBox 項目收集起來變成一個陣列
                    string[] exportData = new string[lstHistory.Items.Count];
                    for (int i = 0; i < lstHistory.Items.Count; i++)
                    {
                        exportData[i] = lstHistory.Items[i].ToString();
                    }

                    System.IO.File.WriteAllLines(sfd.FileName, exportData);

                    MessageBox.Show("紀錄匯出成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("儲存檔案時發生錯誤：" + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnClearHistory_Click(object sender, EventArgs e)
        {
            if (lstHistory.Items.Count > 0)
            {
                lstHistory.Items.Clear();
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "請選擇 BMI 紀錄檔 (.txt)";
            ofd.Filter = "文字檔 (*.txt)|*.txt";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string[] lines = System.IO.File.ReadAllLines(ofd.FileName);

                    lstHistory.Items.Clear(); // 先清空舊的，再放新的
                    Array.Reverse(lines);    // 讓最新紀錄在最上面

                    foreach (string line in lines)
                    {
                        if (!string.IsNullOrWhiteSpace(line))
                            lstHistory.Items.Add(line);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("載入失敗：" + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
