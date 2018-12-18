using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1214._1218
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            Load += Form3_Load;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            button1.Click += btn1;
        }

        private void btn1(object o, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();   //탐색기 찾기 객체
            of.Filter = "images only. |*.jpg; *.jpeg; *.png; *.gif;";
            //DialogResult 가지고 조건문 가능!
            if(of.ShowDialog() == DialogResult.OK)
            {
                //MessageBox.Show("열기 성공");
                string filePath = of.FileName;
                textBox1.Text = filePath;
                Image img = Image.FromFile(filePath); //이미지 객체 생성

                // => 여기 까지는 메모리상에만 저장 = View
                /*===================================================================================*/

                int start = filePath.LastIndexOf("\\") + 1;
                //MessageBox.Show(start.ToString());
                int len = filePath.Length - start;
                //MessageBox.Show(len.ToString());
                string fileName = filePath.Substring(start, len);
                //MessageBox.Show(fileName);

                string ext = fileName.Substring(fileName.LastIndexOf("."), fileName.Length - fileName.LastIndexOf("."));

                string path = "C:\\Users\\GDC2\\Desktop\\github\\smartfactory-\\1214\\1218\\Image"; //저장 파일 경로 설정
                Guid saveNambe = Guid.NewGuid();    //자동이름생성 중복 X
                string fullPath = path + "\\" + saveNambe + ext;  //파일 물리적 저장

                if (!System.IO.Directory.Exists(path))  //null
                {
                    System.IO.Directory.CreateDirectory(path);
                }

                //pictureBox1.Image = img;   //fileName 으로 부터 이미지로 변경해
                //img.Save(fullPath, System.Drawing.Imaging.ImageFormat.Jpeg);

                WebClient wc = new WebClient();
                NameValueCollection param = new NameValueCollection();
                param.Add("fileName", fileName);

                /*********************************************************************************************************/
                //* Image 객체 => byte로 변환 => string으로 변환 *//
                // 1. byte로 변환 
                MemoryStream ms = new MemoryStream();
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg); //대상을 메모리 스트림에 올림
                byte[] imgData = ms.ToArray();
                // 2. string으로 변환 ( => ToBase64String 사용)
                string fileData = Convert.ToBase64String(imgData);
                param.Add("fileData", fileData);
                /*********************************************************************************************************/

                byte[] result = wc.UploadValues("http://localhost:5000/imageUpload", "POST",param);
                string resultStr = Encoding.UTF8.GetString(result);
                MessageBox.Show(resultStr);

                /**************************************************************************************************/
                /* url 주소를 이미지에 담는법 */
                
                pictureBox1.Load(resultStr);
                /**************************************************************************************************/
            }
            else
            {
                MessageBox.Show("열기 실패");
            }
        }
    }
}
