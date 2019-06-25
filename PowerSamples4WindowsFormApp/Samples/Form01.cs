using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerSamples4WindowsFormApp.Samples
{
    public partial class Form01 : Form
    {
        public Form01()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            
            // 按Esc关闭窗口 
            CancelButton = new Button();
            (CancelButton as Button).Click += (o, ex) => { Close(); };

            // 关联按钮事件
            btnDo.Click += BtnDo_Click;
        }

        /// <summary>
        /// 异步执行工作任务，将执行结果更新到主线程UI控件
        /// 如果在async函数中调用工作线程，则需要在工作线程前加上await修饰符。
        /// 本示例的async和await可以去掉。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BtnDo_Click(object sender, EventArgs e)
        {
            // 工作线程
            await Task.Run(() =>
            {
                for (int i = 1; i < 50; i++)
                {
                    System.Threading.Thread.Sleep(50);
                }
                // 更新UI
                UpdateUI((o, ex) => { textBox1.Text = DateTime.Now.ToString(); }); // 方法1
                //Invoke(new Action(()=> { textBox1.Text = DateTime.Now.ToString(); })); // 方法2
            });
        }

        /// <summary>
        /// 在工作线程中修改主线程
        /// </summary>
        /// <param name="eh"></param>
        public void UpdateUI(EventHandler eh) => Invoke(eh);
    }
}
