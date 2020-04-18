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
            //暫定でアプリと同じフォルダにmemo.txtを作る。
            using (StreamWriter w = new StreamWriter(".\\memo.txt", false, Encoding.UTF8))
            {
                //メモ帳部分のテキスト書き込んでみる
                w.Write(this.textBox1.Text);
            }
        }

        private string ReadMemo()
        {
            using (StreamReader r = new StreamReader(".\\memo.txt", Encoding.UTF8))
            {
                return r.ReadToEnd();
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Visible)
            {
                this.textBox1.Visible = false;
            }
            else
            {
                this.textBox1.Visible = true;
            }
            
        }
    }
}
