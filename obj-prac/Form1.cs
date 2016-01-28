using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace obj_prac
{
    public partial class Form1 : Form
    {
        static Random rand = new Random();
        /** データの種類*/
        enum TYPE
        {
            SHIKAKU,     // 四角形
            SANKAKU     // 三角形
        };
        /** 種類。処理を分けるのに利用する*/
        List<TYPE> type = new List<TYPE>();
        /** 底辺*/
        List<float> teihen = new List<float>();
        /** 高さ*/
        List<float> takasa = new List<float>();

        /** 初期化*/
        public Form1()
        {
            InitializeComponent();

            // 初期化
            for (int i = 0; i < 5; i++)
            {
                // 四角形の作成
                instantiateShikaku();
                // 三角形の作成
                instantiateSankaku();
            }
        }

        /** 四角形を作成*/
        void instantiateShikaku()
        {
            // 種類を四角形にする
            type.Add(TYPE.SHIKAKU);
            // 底辺に1～10の乱数を求める
            teihen.Add(rand.Next(1, 11));
            // 高さに1～99の乱数を求める
            takasa.Add(rand.Next(1, 11));
        }

        /** 三角形を作成*/
        void instantiateSankaku()
        {
            // 種類を三角形にする
            type.Add(TYPE.SANKAKU);
            // 底辺に1～10の乱数を求める
            teihen.Add(rand.Next(1, 11));
            // 高さに1～10の乱数を求める
            takasa.Add(rand.Next(1, 11));
        }

        /** ボタンを押したら種類に応じて面積を求めてTextBox1に表示する*/
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < type.Count; i++)
            {
                textBox1.AppendText(calc(i) + "\r\n");
            }
        }

        /** 指定のインデックスの図形の面積を求める*/
        string calc(int idx)
        {
            switch (type[idx])
            {
                // 四角形の面積を求めて返す
                case TYPE.SHIKAKU:
                    return "四角形：底辺" + teihen[idx] + " 高さ" + takasa[idx] + "=" + (takasa[idx] * teihen[idx]);
                // 三角形の面積を求めて返す
                case TYPE.SANKAKU:
                    return "三角形：底辺" + teihen[idx] + " 高さ" + takasa[idx] + "=" + (teihen[idx] * takasa[idx] / 2f);
            }
            // typeが不一致のとき。不要だが念のため
            return "";
        }
    }
}
