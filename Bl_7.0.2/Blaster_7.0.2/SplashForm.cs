using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

public sealed class SplashForm : Form
{
    public int nDelayCounter;

    private MainForm mainForm;

    private IContainer container = null;

    private Label lblInfo;

    private Timer timer1;

    private Timer timer2;

    private Label lblLabel1;

    public SplashForm()
    {
        InitUI();
    }

    private void OnLoadEvent(object sender, EventArgs evt)
    {
        lblLabel1.Text += ApplicationManager.version;
        nDelayCounter = 2;
        timer1.Start();
    }

    private void OnTimer1Tick(object sender, EventArgs evt)
    {
        if (nDelayCounter > 0)
        {
            nDelayCounter--;
            return;
        }
        timer1.Stop();
        timer2.Start();
        mainForm = new MainForm();
        mainForm.Show();
        Hide();
    }

    private void OnTimer2Tick(object sender, EventArgs evt)
    {
        if (mainForm != null)
        {
            lblInfo.Text = mainForm.m_strLoadStatus;
            Application.DoEvents();
        }
        if (lblInfo.Text == "Done")
        {
            timer2.Stop();
        }
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (container != null)
            {
                container.Dispose();
            }
            base.Dispose(disposing);
        }
        else
        {
            base.Dispose(disposing);
        }
    }

    private void InitUI()
    {
        container = new Container();
        lblInfo = new Label();
        timer1 = new Timer(container);
        timer2 = new Timer(container);
        lblLabel1 = new Label();
        SuspendLayout();
        lblInfo.AutoSize = true;
        lblInfo.BackColor = Color.Transparent;
        lblInfo.Font = new Font("Times New Roman", 10f, FontStyle.Regular, GraphicsUnit.Point, 204);
        lblInfo.ForeColor = Color.Transparent;
        lblInfo.Location = new Point(7, 261);
        lblInfo.Name = "lInfo";
        lblInfo.Size = new Size(89, 16);
        lblInfo.TabIndex = 1;
        lblInfo.Text = "Wait... Load...";
        timer1.Tick += OnTimer1Tick;
        timer2.Interval = 10;
        timer2.Tick += OnTimer2Tick;
        lblLabel1.BackColor = Color.Transparent;
        lblLabel1.Font = new Font("Times New Roman", 14f, FontStyle.Regular, GraphicsUnit.Point, 204);
        lblLabel1.ForeColor = Color.White;
        lblLabel1.Location = new Point(433, 9);
        lblLabel1.Name = "label1";
        lblLabel1.Size = new Size(96, 21);
        lblLabel1.TabIndex = 2;
        lblLabel1.Text = "v";
        lblLabel1.TextAlign = ContentAlignment.MiddleRight;
        base.AutoScaleDimensions = new SizeF(6f, 13f);
        base.AutoScaleMode = AutoScaleMode.Font;
        BackColor = SystemColors.Control;
        BackgroundImage = AppResourceManager.GetSplashBitmap();
        BackgroundImageLayout = ImageLayout.Stretch;
        base.ClientSize = new Size(541, 284);
        base.Controls.Add(lblLabel1);
        base.Controls.Add(lblInfo);
        DoubleBuffered = true;
        base.FormBorderStyle = FormBorderStyle.None;
        base.Name = "Splash";
        base.ShowIcon = false;
        base.ShowInTaskbar = false;
        base.StartPosition = FormStartPosition.CenterScreen;
        base.TransparencyKey = SystemColors.Control;
        base.Load += OnLoadEvent;
        ResumeLayout(performLayout: false);
        PerformLayout();
    }
}
