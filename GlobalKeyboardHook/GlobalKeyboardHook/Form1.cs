using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GlobalKeyboardHook
{
    public partial class Form1 : Form
    {
        InterceptKeys _keyListener;
        InterceptMouse _mouseListener;
        State _state = new State();

        const string CRYPT_KEY = "aAi934Jl340gi9iIie9l2";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadState();

            _keyListener = new InterceptKeys();
            _keyListener.KeyPressed += OnKeyPressed;
            _keyListener.Start();

            _mouseListener = new InterceptMouse();
            _mouseListener.MouseClicked += OnMouseClicked;
            _mouseListener.Start();
        }

        private void OnKeyPressed(object sender, InterceptKeysEventArgs e)
        {
            var keyPressed = e.KeyPressed;

            _state.KeyCount++;
            if(!_state.Hidden)
                lblKeyCount.Text = _state.KeyCount.ToString("N0");

            //_log.AppendLine(String.Format("{0}: {1}", DateTime.Now.ToString("yyyyMMddHHmmssfff"), (Keys)e.KeyPressed));
            //System.IO.File.WriteAllText(String.Format("C:\\Users\\ubdixso\\Desktop\\asdfasdf\\{0}.txt", DateTime.Now.ToString("yyyyMMddHHmmssfff")), _log.ToString());
            //if((Keys)keyPressed == Keys.D1 && Control.ModifierKeys == Keys.Alt)
            //{
            //    Console.WriteLine((Keys)keyPressed);
            //    _hidden = !_hidden;
            //    if(_hidden)
            //        this.Hide();
            //    else
            //    {
            //        this.Show();
            //    }
            //}
            
            if((Keys)keyPressed == Keys.D1 && Control.ModifierKeys == Keys.Alt)
            {
                _state.Hidden = !_state.Hidden;
                if(_state.Hidden)
                    this.Hide();
                else
                {
                    lblClickCount.Text = _state.ClickCount.ToString("N0");
                    lblKeyCount.Text = _state.KeyCount.ToString("N0");
                    this.Show();
                }
            }
        }

        private void SaveClicksImage()
        {
            try
            {
                var maxKeyX = -1;
                var maxKeyY = -1;

                for(var x = 0; x < _state.ClickedPoints.Count; x++)
                {
                    var keyX = _state.ClickedPoints.Keys.ToList()[x];

                    if(keyX > maxKeyX)
                        maxKeyX = keyX;

                    for(var y = 0; y < _state.ClickedPoints[keyX].Count; y++)
                    {
                        var keyY = _state.ClickedPoints[keyX].Keys.ToList()[y];

                        if(keyY > maxKeyY)
                            maxKeyY = keyY;
                    }
                }

                if(maxKeyX == -1 || maxKeyY == -1)
                    return;

                var bitmap = new Bitmap(maxKeyX, maxKeyY);
                using(var g = Graphics.FromImage(bitmap))
                {
                    for(int x = 0; x < maxKeyX; x++)
                    {
                        for(int y = 0; y < maxKeyY; y++)
                        {
                            var rect = new System.Drawing.Rectangle(x, y, 1, 1);
                            if(_state.ClickedPoints.ContainsKey(x) && _state.ClickedPoints[x].ContainsKey(y))
                                g.FillRectangle(GetColorFromClickCount(_state.ClickedPoints[x][y]), rect);
                            else
                                g.FillRectangle(System.Drawing.Brushes.White, rect);
                        }
                    }
                }
                if(!Directory.Exists(Directory.GetCurrentDirectory() + "\\images"))
                    Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\images");

                bitmap.Save(String.Format("{0}\\images\\{1}.jpg", Directory.GetCurrentDirectory(), DateTime.Now.ToString("yyyyMMddHHmmssfff")), ImageFormat.Bmp);
            }
            catch(Exception ex)
            {

            }
            finally
            {
                _state.Loading = false;
                this.UIThread(() =>
                {
                    btnSaveImage.Enabled = true;
                    btnSaveImage.Text = "Save Image";
                });
            }
        }

        private System.Drawing.Brush GetColorFromClickCount(int clickCount)
        {
            if(clickCount >= 1024)
                return System.Drawing.Brushes.OrangeRed;
            if(clickCount >= 512)
                return System.Drawing.Brushes.Red;
            if(clickCount >= 256)
                return System.Drawing.Brushes.Firebrick;
            if(clickCount >= 128)
                return System.Drawing.Brushes.DeepPink;
            if(clickCount >= 64)
                return System.Drawing.Brushes.Fuchsia;
            if(clickCount >= 32)
                return System.Drawing.Brushes.DarkViolet;
            if(clickCount >= 16)
                return System.Drawing.Brushes.DarkMagenta;
            if(clickCount >= 8)
                return System.Drawing.Brushes.DarkSlateBlue;
            if(clickCount >= 4)
                return System.Drawing.Brushes.Blue;
            if(clickCount >= 2)
                return System.Drawing.Brushes.CornflowerBlue;
            if(clickCount >= 1)
                return System.Drawing.Brushes.SkyBlue;
            
            return System.Drawing.Brushes.White;
        }

        private void OnMouseClicked(object sender, InterceptMouseEventArgs e)
        {
            try
            {
                var mouseMessage = e.MouseMessage;
                var mousePoint = e.MousePoint;
                if(mouseMessage == MouseMessages.WM_LBUTTONDOWN
                    || mouseMessage == MouseMessages.WM_RBUTTONDOWN)// Control.ModifierKeys == Keys.Alt)
                {
                    _state.ClickCount++;

                    if(!_state.Hidden)
                        lblClickCount.Text = _state.ClickCount.ToString("N0");

                    Console.WriteLine("({0}, {1})", mousePoint.X, mousePoint.Y);
                    if(_state.ClickedPoints.ContainsKey(mousePoint.X))
                        if(_state.ClickedPoints[mousePoint.X].ContainsKey(mousePoint.Y))
                            _state.ClickedPoints[mousePoint.X][mousePoint.Y]++;
                        else
                            _state.ClickedPoints[mousePoint.X].Add(mousePoint.Y, 1);
                    else
                        _state.ClickedPoints.Add(mousePoint.X, new Dictionary<int, int> { { mousePoint.Y, 1 } });


                    //var image = ScreenCapture.CaptureDesktop();
                    //var image = ScreenCapture.CaptureActiveWindow();
                    //image.Save(String.Format("C:\\Users\\ubdixso\\Desktop\\asdfasdf\\{0}.jpg", DateTime.Now.ToString("yyyyMMddHHmmssfff")), ImageFormat.Jpeg);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error in OnMouseClicked()!");
            }
        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {
            //if(!_hidden)
            //{
            //    _hidden = true;
            //    this.Hide();
            //}
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _keyListener.Stop();
            _mouseListener.Stop();
            //System.IO.File.WriteAllText(String.Format("C:\\Users\\ubdixso\\Desktop\\asdfasdf\\{0}.txt", DateTime.Now.ToString("yyyyMMddHHmmssfff")), _log.ToString());
            SaveStateAs();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            WindowGrabber.Grab(this.Handle);
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            WindowGrabber.Grab(this.Handle);
        }

        private void label2_MouseDown(object sender, MouseEventArgs e)
        {
            WindowGrabber.Grab(this.Handle);
        }

        private void btnSaveImage_Click(object sender, EventArgs e)
        {
            if(_state.Loading)
                return;

            _state.Loading = true;
            btnSaveImage.Enabled = false;
            btnSaveImage.Text = "Saving...";
            Task.Factory.StartNew(SaveClicksImage);
        }

        private void label3_MouseDown(object sender, MouseEventArgs e)
        {
            WindowGrabber.Grab(this.Handle);
        }

        private void btnRestartListeners_Click(object sender, EventArgs e)
        {
            _keyListener.Stop();
            _mouseListener.Stop();
            _keyListener.Start();
            _mouseListener.Start();
        }

        private void label2_MouseDown_1(object sender, MouseEventArgs e)
        {
            WindowGrabber.Grab(this.Handle);
        }

        private void lblKeyCount_MouseDown(object sender, MouseEventArgs e)
        {
            WindowGrabber.Grab(this.Handle);
        }

        private void LoadState()
        {
        }

        private void SaveStateAs()
        {
            try
            {
                var dlg = new SaveFileDialog
                {
                    DefaultExt = ".ckr",
                    FileName = "ExportedSave",
                    Filter = "Clicker Counter (.ckr)|*.ckr",
                    InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                };

                if(dlg.ShowDialog() != DialogResult.OK)
                    return;

                var fileName = dlg.FileName;

                Task.Factory.StartNew(() => WriteSaveFile(fileName));
            }
            catch(Exception ex)
            {
                MessageBox.Show("An error occurred when attempting to export the save.", "Export Failed");
            }
        }

        private void WriteSaveFile(string fileName)
        {
            var sb = new StringBuilder();
            using(StreamWriter outfile = new StreamWriter(fileName, false))
            {
                outfile.Write(Encrypt(sb.ToString(), CRYPT_KEY));
            }
        }

        #region " Security "

        public static string Encrypt(string clearText, string password)
        {
            byte[] clearBytes = System.Text.Encoding.Unicode.GetBytes(clearText);
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(password, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });

            byte[] encryptedData = Encrypt(clearBytes, pdb.GetBytes(32), pdb.GetBytes(16));

            return Convert.ToBase64String(encryptedData);
        }

        public static byte[] Encrypt(byte[] clearData, byte[] key, byte[] IV)
        {
            MemoryStream ms = new MemoryStream();

            Rijndael alg = Rijndael.Create();

            alg.Key = key;
            alg.IV = IV;

            CryptoStream cs = new CryptoStream(ms, alg.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(clearData, 0, clearData.Length);
            cs.Close();

            byte[] encryptedData = ms.ToArray();

            return encryptedData;
        }

        public static string Decrypt(string cipherText, string password)
        {
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(password, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });

            byte[] decryptedData = Decrypt(cipherBytes, pdb.GetBytes(32), pdb.GetBytes(16));

            return System.Text.Encoding.Unicode.GetString(decryptedData);
        }

        public static byte[] Decrypt(byte[] cipherData, byte[] key, byte[] IV)
        {
            MemoryStream ms = new MemoryStream();
            Rijndael alg = Rijndael.Create();

            alg.Key = key;
            alg.IV = IV;

            CryptoStream cs = new CryptoStream(ms, alg.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(cipherData, 0, cipherData.Length);
            cs.Close();

            byte[] decryptedData = ms.ToArray();

            return decryptedData;
        }

        #endregion
    }
}
