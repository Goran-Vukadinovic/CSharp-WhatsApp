using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

internal sealed class AboutForm : Form
{
    internal Label m_label_2;

    internal Label m_label_3;

    internal Label m_label_4;

    internal Label m_label_6;

    internal Label m_lblVersion;

    internal LinkLabel m_lnkMail;

    private TextBox m_tbFeature;

    internal Label m_label1;

    internal PictureBox m_pictureBox_0;

    public AboutForm()
    {
        InitUI();
    }

    private void InitUI()
    {
        ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(AboutForm));
        m_label_2 = new Label();
        m_lnkMail = new LinkLabel();
        m_label_3 = new Label();
        m_label_4 = new Label();
        m_label_6 = new Label();
        m_lblVersion = new Label();
        m_pictureBox_0 = new PictureBox();
        m_tbFeature = new TextBox();
        m_label1 = new Label();
        ((ISupportInitialize)m_pictureBox_0).BeginInit();
        SuspendLayout();
        m_label_2.AutoSize = true;
        m_label_2.BackColor = Color.Transparent;
        m_label_2.Location = new Point(102, 63);
        m_label_2.Name = "label_2";
        m_label_2.Size = new Size(178, 13);
        m_label_2.TabIndex = 68;
        m_label_2.Text = "Messages over WhatsApp platform. ";

        m_lnkMail.AutoSize = true;
        m_lnkMail.BackColor = Color.Transparent;
        m_lnkMail.Font = new Font("Microsoft Sans Serif", 11f, FontStyle.Regular, GraphicsUnit.Point, 204);
        m_lnkMail.Location = new Point(161, 207);
        m_lnkMail.Name = "linkLabel_0";
        m_lnkMail.Size = new Size(113, 18);
        m_lnkMail.TabIndex = 67;
        m_lnkMail.TabStop = true;
        m_lnkMail.Text = "wasoft@pm.me";
        m_lnkMail.LinkClicked += OnLinkClicked_Link0;

        m_label_3.AutoSize = true;
        m_label_3.BackColor = Color.Transparent;
        m_label_3.Location = new Point(12, 221);
        m_label_3.Name = "label_3";
        m_label_3.Size = new Size(90, 13);
        m_label_3.TabIndex = 66;
        m_label_3.Text = "Copyright © 2023";

        m_label_4.AutoSize = true;
        m_label_4.BackColor = Color.Transparent;
        m_label_4.Location = new Point(12, 197);
        m_label_4.Name = "label_4";
        m_label_4.Size = new Size(101, 13);
        m_label_4.TabIndex = 65;
        m_label_4.Text = "License: Registered";

        m_label_6.AutoSize = true;
        m_label_6.BackColor = Color.Transparent;
        m_label_6.Location = new Point(102, 38);
        m_label_6.Name = "label_6";
        m_label_6.Size = new Size(98, 13);
        m_label_6.TabIndex = 63;
        m_label_6.Text = "Date: 04 Jan, 2023";

        m_lblVersion.AutoSize = true;
        m_lblVersion.BackColor = Color.Transparent;
        m_lblVersion.Location = new Point(102, 16);
        m_lblVersion.Name = "label_7";
        m_lblVersion.Size = new Size(48, 13);
        m_lblVersion.TabIndex = 62;
        m_lblVersion.Text = "Version: ";

        m_pictureBox_0.BackColor = Color.Transparent;
        m_pictureBox_0.BackgroundImageLayout = ImageLayout.None;
        m_pictureBox_0.Image = AppResourceManager.GetLogoBitmap();
        m_pictureBox_0.Location = new Point(12, 12);
        m_pictureBox_0.Name = "pictureBox_0";
        m_pictureBox_0.Size = new Size(60, 60);
        m_pictureBox_0.SizeMode = PictureBoxSizeMode.StretchImage;
        m_pictureBox_0.TabIndex = 61;
        m_pictureBox_0.TabStop = false;

        m_tbFeature.Location = new Point(12, 82);
        m_tbFeature.Multiline = true;
        m_tbFeature.Name = "textBox1";
        m_tbFeature.ReadOnly = true;
        m_tbFeature.ScrollBars = ScrollBars.Vertical;
        m_tbFeature.Size = new Size(443, 112);
        m_tbFeature.TabIndex = 97;
        m_tbFeature.Text = componentResourceManager.GetString("textBox1.Text");

        m_label1.AutoSize = true;
        m_label1.BackColor = Color.Transparent;
        m_label1.ForeColor = Color.DarkRed;
        m_label1.Location = new Point(305, 16);
        m_label1.Name = "label1";
        m_label1.Size = new Size(48, 13);
        m_label1.TabIndex = 98;
        m_label1.Text = "Expired: ";

        BackColor = SystemColors.ControlDark;
        BackgroundImage = AppResourceManager.GetWallpaperBitmap();
        base.ClientSize = new Size(467, 246);
        base.Controls.Add(m_label1);
        base.Controls.Add(m_tbFeature);
        base.Controls.Add(m_label_2);
        base.Controls.Add(m_lnkMail);
        base.Controls.Add(m_label_3);
        base.Controls.Add(m_label_4);
        base.Controls.Add(m_label_6);
        base.Controls.Add(m_lblVersion);
        base.Controls.Add(m_pictureBox_0);
        base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
        base.MaximizeBox = false;
        base.MinimizeBox = false;
        base.Name = "Info";
        base.ShowInTaskbar = false;
        base.StartPosition = FormStartPosition.CenterParent;
        this.Text = "About - Whatsapp Blaster";
        base.Load += OnFormLoad;
        ((ISupportInitialize)m_pictureBox_0).EndInit();
        ResumeLayout(performLayout: false);
        PerformLayout();
    }

    private void OnLinkClicked_Link0(object sendor, LinkLabelLinkClickedEventArgs evtObj)
    {
        try
        {
            if (m_lnkMail.Text.IndexOf('@') > 3)
            {
                Process.Start("mailto:" + m_lnkMail.Text);
            }
            else
            {
                Process.Start(m_lnkMail.Text);
            }
        }
        catch (Exception)
        {
        }
    }

    private void OnFormLoad(object sendor, EventArgs evtArg)
    {
        m_lblVersion.Text += ApplicationManager.version;
        m_label1.Text = m_label1.Text + ApplicationManager.expireDate.ToString("dd.MM.yyyy");
        if (File.Exists("data"))
        {
            try
            {
                string text5 = File.ReadAllText("data");
                string[] array = text5.Split(";".ToCharArray());
                array[0] = array[0].Remove(5, 1);
                byte[] bytes = Convert.FromBase64String(array[0]);
                m_lnkMail.Text = Encoding.ASCII.GetString(bytes);
            }
            catch
            {
            }
        }
        if (File.Exists("features.txt"))
        {
            try
            {
                m_tbFeature.Text = File.ReadAllText("features.txt");
            }
            catch
            {
            }
        }
    }
}
