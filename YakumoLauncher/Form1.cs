using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using YakumoLauncher.appricationFunction;

namespace YakumoLauncher
{
    public partial class Form1 : Form
    {
        //マウスのクリック位置を記憶
        private Point mousePoint;

        public Form1()
        {
            InitializeComponent();
        }
        //Form1のMouseDownイベントハンドラ
        //マウスのボタンが押されたとき
        private void Form1_MouseDown(object sender,
            System.Windows.Forms.MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                //位置を記憶する
                mousePoint = new Point(e.X, e.Y);
            }
        }

        //Form1のMouseMoveイベントハンドラ
        //マウスが動いたとき
        private void Form1_MouseMove(object sender,
            System.Windows.Forms.MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                this.Location = new Point(
                   this.Location.X + e.X - mousePoint.X,
                   this.Location.Y + e.Y - mousePoint.Y);
            }
        }
        
        //textbox入力イベント
        private void TextChangedEvent(object sender, EventArgs e)
        {
            //textboxの内容に変更があったタイミングで書き込み
            MemoClass.WriteMemo(this.textBox1.Text);
        }

        //メモボタンが押下されたときに、メモ欄の状態を切り替え
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Visible)
            {
                this.textBox1.Visible = false;
            }
            else
            {
                //アクティブ化されたときにファイル内容を読み込み
                //後で読み込み位置を変えるかも
                this.textBox1.Text = MemoClass.ReadMemo();
                this.textBox1.Visible = true;
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.TimeLabel.Text = TimeClass.GetTime();
            this.DateLabel.Text = TimeClass.GetDate();
        }
    }
}
