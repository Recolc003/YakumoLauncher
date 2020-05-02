using System;
using System.IO;
using System.Text;
using YakumoLauncher.Constant;

namespace YakumoLauncher.appricationFunction
{
    //メモ関連の機能をまとめておく
    public static class MemoClass
    {
        public static string ReadMemo()
        {
            // ファイルが存在していない場合、空のファイルを生成する
            if (!System.IO.File.Exists(ProvisionalConstantClass.MemoFileName))
            {
                WriteMemo("");
            }

            //ローカル保存のファイルから文字列を読み込み
            using (StreamReader r = new StreamReader(ProvisionalConstantClass.MemoFileName, Encoding.UTF8))
            {
                return r.ReadToEnd();
            }
        }

        public static void WriteMemo(string text)
        {
            //暫定でアプリと同じフォルダにmemo.txtを作る。
            using (StreamWriter w = new StreamWriter(ProvisionalConstantClass.MemoFileName, false, Encoding.UTF8))
            {
                //メモ帳部分のテキスト書き込んでみる
                w.Write(text);
            }

            //あとでResultをリターンするようにしたい感

        }
    }
}
