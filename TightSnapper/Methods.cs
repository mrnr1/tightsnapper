using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using TightSnapper.Properties;

namespace TightSnapper
{
    public partial class Form1
    {
        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hWnd, out Rect lpRect);

        [DllImport("user32.dll")]
        public static extern bool PrintWindow(IntPtr hWnd, IntPtr hdcBlt, int nFlags);

        // Make sure the selected save location is not empty and is a valid path
        private bool VerifySaveLocation()
        {
            if ((saveToTxtBox.Text == Resources.Form1_VerifySaveLocation_Save_snaps_to___) ||
                string.IsNullOrWhiteSpace(saveToTxtBox.Text))
            {
                MessageBox.Show(Resources.Form1_VerifySaveLocation_Please_select_a_save_location_first_,
                    Resources.Form1_VerifySaveLocation_TightSnapper_Error, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        // The snapshot timer has elapsed to our predetermined interval
        /*
        private void SnapTimerElapsed(object sender, ElapsedEventArgs e)
        {
            Snapshot();
        }

        // Timer to disable recording (in minutes) has fired
        private void DurationTimerElapsed(object sender, ElapsedEventArgs e)
        {
            StopRecording();
        }
        */

        private void DurationTimerElapsedEx(object sender, EventArgs e)
        {
            StopRecording();
        }

        private void SnapTimerElapsedEx(object sender, EventArgs e)
        {
            Snapshot();
        }

        // button1 handler
        private void StartRecording()
        {
            // Start the timer to take snaps at interval
            _snapIntervalTimer.Enabled = true;

            // Adjust our buttons to reflect that we are already recording
            startRecordingBtn.Enabled = false;
            stopRecordingBtn.Enabled = true;

            // Setup our snapshot timer interval based on user input (in seconds)
            _snapIntervalTimer.Interval = (int) intervalSelection.Value*1000;

            // Don't enable the end recording timer if the value is 0
            if ((int) durationSelection.Value != 0)
            {
                _durationTimer.Interval = (int) TimeSpan.FromMinutes((double) durationSelection.Value).TotalMilliseconds;
                _durationTimer.Enabled = true;
                // GC.KeepAlive(_durationTimer);
            }
        }

        private void StopRecording()
        {
            // Reset the buttons
            startRecordingBtn.Enabled = true;
            stopRecordingBtn.Enabled = false;

            _snapIntervalTimer.Enabled = false; // stop taking snapshots
            _durationTimer.Enabled = false; // stop monitoring for end-record tick
        }

        // Quick Snapshot handler
        private void Snapshot()
        {
            // Find the TightVNC Window and take a snapshot of it (restricted to only 1 window due to break)
            var hWnd = IntPtr.Zero;
            foreach (var pList in Process.GetProcesses())
                if (pList.MainWindowTitle.Contains("TightVNC Viewer"))
                {
                    hWnd = pList.MainWindowHandle;
                    break;
                }

            // Don't attempt to get a bitmap of the window if the handle hasn't been obtained
            if (hWnd == IntPtr.Zero)
            {
                MessageBox.Show(Resources.Form1_Snapshot_Unable_to_obtain_a_TightVNC_Window_handle_,
                    Resources.Form1_VerifySaveLocation_TightSnapper_Error, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            var snap = PrintWindow(hWnd);
            var saveName = saveToTxtBox.Text + "\\snap" + _iterator + ".jpeg";

            while (File.Exists(saveName))
            {
                _iterator++;
                saveName = saveToTxtBox.Text + "\\snap" + _iterator + ".jpeg";
            }
            snap.SaveJpg100(saveName);
            _iterator++;
        }

        // 
        public static Bitmap PrintWindow(IntPtr hWnd)
        {
            Rect rc;
            GetWindowRect(hWnd, out rc);

            var bmp = new Bitmap(rc.Width, rc.Height, PixelFormat.Format32bppArgb);
            var gfxBmp = Graphics.FromImage(bmp);
            var hdcBitmap = gfxBmp.GetHdc();

            PrintWindow(hWnd, hdcBitmap, 0);

            gfxBmp.ReleaseHdc(hdcBitmap);
            gfxBmp.Dispose();

            return bmp;
        }

        // Choose a folder to save snaps to
        private void browseBtn_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            fbd.ShowDialog();

            saveToTxtBox.Text = fbd.SelectedPath;
        }

        // User has adjusted the snapshot interval, do something
        private void intervalSelection_ValueChanged(object sender, EventArgs e)
        {
            _snapIntervalTimer.Interval = (int) intervalSelection.Value*1000;
        }

        private void durationSelection_ValueChanged(object sender, EventArgs e)
        {
            _durationTimer.Interval = (int) TimeSpan.FromMinutes((double) durationSelection.Value).TotalMilliseconds;
        }

        private void compressionNumeric_ValueChanged(object sender, EventArgs e)
        {
            CompressionLevel = (long) compressionNumeric.Value;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Rect
        {
            public Rect(Rect rectangle) : this(rectangle.Left, rectangle.Top, rectangle.Right, rectangle.Bottom)
            {
            }

            public Rect(int left, int top, int right, int bottom)
            {
                X = left;
                Y = top;
                Right = right;
                this.Bottom = bottom;
            }

            public int X { get; set; }
            public int Y { get; set; }

            public int Left
            {
                get { return X; }
                set { X = value; }
            }

            public int Top
            {
                get { return Y; }
                set { Y = value; }
            }

            public int Right { get; set; }

            public int Bottom { get; set; }

            public int Height
            {
                get { return Bottom - Y; }
                set { Bottom = value + Y; }
            }

            public int Width
            {
                get { return Right - X; }
                set { Right = value + X; }
            }

            public Point Location
            {
                get { return new Point(Left, Top); }
                set
                {
                    X = value.X;
                    Y = value.Y;
                }
            }

            public Size Size
            {
                get { return new Size(Width, Height); }
                set
                {
                    Right = value.Width + X;
                    Bottom = value.Height + Y;
                }
            }

            public static implicit operator Rectangle(Rect rectangle)
            {
                return new Rectangle(rectangle.Left, rectangle.Top, rectangle.Width, rectangle.Height);
            }

            public static implicit operator Rect(Rectangle rectangle)
            {
                return new Rect(rectangle.Left, rectangle.Top, rectangle.Right, rectangle.Bottom);
            }

            public static bool operator ==(Rect rectangle1, Rect rectangle2)
            {
                return rectangle1.Equals(rectangle2);
            }

            public static bool operator !=(Rect rectangle1, Rect rectangle2)
            {
                return !rectangle1.Equals(rectangle2);
            }

            public override string ToString()
            {
                return "{Left: " + X + "; " + "Top: " + Y + "; Right: " + Right + "; Bottom: " + Bottom + "}";
            }

            public override int GetHashCode()
            {
                return ToString().GetHashCode();
            }

            public bool Equals(Rect rectangle)
            {
                return (rectangle.Left == X) && (rectangle.Top == Y) && (rectangle.Right == Right) &&
                       (rectangle.Bottom == Bottom);
            }

            public override bool Equals(object Object)
            {
                if (Object is Rect)
                    return Equals((Rect) Object);
                if (Object is Rectangle)
                    return Equals(new Rect((Rectangle) Object));

                return false;
            }
        }
    }
}