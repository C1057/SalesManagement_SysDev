using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev
{
    public partial class FormSalesOfficeMana : Form
    {
        private FormHome formHome;                  //FormHomeのデータを取得するための変数を宣言
        List<M_SalesOffice> SalesOfficeList;                //営業所マスタの全情報を保持するList型変数

        MessageDsp msg = new MessageDsp();          //メッセージ表示用クラスのインスタンス化
        DataInputCheck InputCheck = new DataInputCheck();   //入力チェック用クラスのインスタンス化
        CheckExistence Existence = new CheckExistence();    //存在チェック用クラスのインスタンス化

        public FormSalesOfficeMana()
        {
            InitializeComponent();
        }

        private void buttonSOManaReturn_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void FormSalesOfficeMana_Load(object sender, EventArgs e)
        {
            var columnText = new string[]                       //各列のヘッダーテキストを設定
            {
                "営業所ID", "営業所名", "住所", "電話番号", "郵便番号","非表示リスト"
            };

            var ReadOnlySet = new bool[]                        //各列の読み取り可否を設定
            {
                    true,true,true,true,true,true
            };

            var ColumnSize = new int[]                          //各列のWidthを設定
            {
                    225,225,225,225,251,251
            };

            var columnCellType = new DataGridViewCell[]         //各列のセルタイプを設定
            {
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell(),
                new DataGridViewTextBoxCell()
            };

            for (int i = 0; i < columnText.Length; i++)                 //各列の設定を適用し追加する
            {
                var viewColumn = new DataGridViewColumn();
                viewColumn.HeaderText = columnText[i];                  //ヘッダーに表示される名称
                viewColumn.ReadOnly = ReadOnlySet[i];                   //読み取り可否
                viewColumn.Width = ColumnSize[i];                       //Width設定
                viewColumn.CellTemplate = columnCellType[i];            //セルのタイプ

                dataGridViewSOMana.Columns.Add(viewColumn);          //列の追加
            }

            dataGridViewSOMana.AllowUserToAddRows = false;       //一番下の新しい行を追加するための行を非表示にする 

            var context = new SalesManagement_DevContext();         //DB接続用クラスのインスタンス化

            SalesOfficeList = context.M_SalesOffices.ToList();              //営業所マスタの全情報を取得
            context.Dispose();                                      //contextの解放
        }
    }
}
