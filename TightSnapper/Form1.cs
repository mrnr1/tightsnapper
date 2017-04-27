using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace TightSnapper
{
    public partial class Form1 : Form
    {
        private static int _iterator;               // save file number
        private readonly Timer _durationTimer;      // timer to control duration of recording
        private readonly Timer _snapIntervalTimer;  // time between snapshots

        public Form1()
        {
            InitializeComponent();

            // Setup the interval timer
            _snapIntervalTimer = new Timer();
            _snapIntervalTimer.Tick += SnapTimerElapsedEx;

            // Setup the recording timer
            _durationTimer = new Timer();
            _durationTimer.Tick += DurationTimerElapsedEx;

            stopRecordingBtn.Enabled = false; // we're not recording yet

            compressionNumeric.Value = CompressionLevel;

            // Add our homepage to the link label
            var link = new LinkLabel.Link();
            link.LinkData = "http://lionclawelectronics.com/";
            linkLabel1.Links.Add(link);

            // show hint for duration selection
            var durationSelectionTip = new ToolTip();
            durationSelectionTip.SetToolTip(durationSelection, "Use a value of 0 to record indefinitely");

            // show hint for compression numeric selection
            var compressionNumericTip = new ToolTip();
            compressionNumericTip.SetToolTip(compressionNumeric,
                "0 = None (best quality), 100 = MAX (smallest file size)");
        }

        public static long CompressionLevel { get; set; } = 80;

        // Start Recording
        private void startRecordingBtn_Click(object sender, EventArgs e)
        {
            if (!VerifySaveLocation())
                return; // something with the save location did not validate
            StartRecording();
        }

        // Stop Recording
        private void stopRecordingBtn_Click(object sender, EventArgs e)
        {
            StopRecording();
        }

        // Quick Snapshot
        private void snapBtn_Click(object sender, EventArgs e)
        {
            if (!VerifySaveLocation())
                return;

            Snapshot();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (e.Link != null) Process.Start(e.Link.LinkData as string);
        }
    }
}